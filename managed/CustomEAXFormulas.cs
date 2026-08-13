using System;
using System.Diagnostics;

namespace vaudionativewrapper.managed
{
    /// <summary>Class containing functions that can be overriden to manually calculate each EAX parameter</summary>
    public unsafe class CustomEAXFormulas
    {
        protected float[] tempDiffusionCumulative = new float[1];
        protected float[] echogramDb = new float[1];
        protected float binDurationMs;

        protected vaudionativewrapper.ProcessedReverb* processed;
        protected float totalReturnedEnergyLF;
        protected float totalReturnedEnergyHF;
        protected float totalReturnedEnergyAverage;
        protected float totalReturnedEnergy;
        protected float[] echogramLF;
        protected float[] echogramHF;
        protected float[] echogramAverage;

        protected float maxEnergy;

        /// <summary>Initialises the formula calculator with echogram data from a processed reverb result</summary>
        /// <param name="processed">The processed reverb results containing material and geometry data</param>
        /// <param name="totalReturnedEnergyLF">Total LF energy that returned to the emitter</param>
        /// <param name="totalReturnedEnergyHF">Total HF energy that returned to the emitter</param>
        /// <param name="echogramGranularity">The duration (in milliseconds) of each entry in the echogram arrays</param>
        /// <param name="echogramLF">Low-frequency echogram energy bins</param>
        /// <param name="echogramHF">High-frequency echogram energy bins</param>
        /// <param name="echogramAverage">Average echogram energy bins used for most calculations</param>
        public virtual void Initialise(vaudionativewrapper.ProcessedReverb* processed, float totalReturnedEnergyLF, float totalReturnedEnergyHF, float echogramGranularity, float[] echogramLF, float[] echogramHF, float[] echogramAverage)
        {
            Debug.Assert(echogramGranularity > 0);

            this.binDurationMs = echogramGranularity;
            this.processed = processed;
            this.totalReturnedEnergyLF = totalReturnedEnergyLF;
            this.totalReturnedEnergyHF = totalReturnedEnergyHF;
            this.totalReturnedEnergyAverage = (totalReturnedEnergyLF + totalReturnedEnergyHF) / 2;
            this.totalReturnedEnergy = (totalReturnedEnergyLF + totalReturnedEnergyHF);
            this.echogramLF = echogramLF;
            this.echogramAverage = echogramAverage;
            this.echogramHF = echogramHF;

            // Precalculate
            maxEnergy = 0f;

            foreach (var value in echogramAverage)
            {
                if (value > maxEnergy)
                    maxEnergy = value;
            }
        }

        /// <summary>Calculates the EAX diffusion parameter based on how smoothly energy accumulates over time</summary>
        public virtual float CalculateDiffusion()
        {
            if (tempDiffusionCumulative.Length != echogramAverage.Length)
                Array.Resize(ref tempDiffusionCumulative, echogramAverage.Length);

            // Fallback value
            if (totalReturnedEnergy <= 0f)
                return 0.5f;

            // Calculate how smoothly energy accumulates
            tempDiffusionCumulative[0] = echogramAverage[0];

            for (int i = 1; i < echogramAverage.Length; i++)
                tempDiffusionCumulative[i] = tempDiffusionCumulative[i - 1] + echogramAverage[i];

            // Measure deviation from ideal smooth buildup
            //  Higher variance = less diffuse (more irregular)
            //  Lower variance = more diffuse (smoother)
            float variance = 0f;
            for (int i = 1; i < echogramAverage.Length; i++)
            {
                float expected = totalReturnedEnergy * (i / (float)echogramAverage.Length);
                float actual = tempDiffusionCumulative[i];
                float diff = actual - expected;
                variance += diff * diff;
            }

            variance /= echogramAverage.Length;
            float normalizedVariance = variance / (totalReturnedEnergy * totalReturnedEnergy);

            // Convert variance to diffusion (inverse relationship)
            // Low variance = high diffusion
            float baseDiffusion = 1.0f - Math.Min(normalizedVariance * 10f, 1.0f);

            // Material roughness directly affects diffusion
            float roughnessBonus = processed->materialRoughness * 0.3f;

            // Outdoor spaces have lower diffusion (sound escapes)
            float outdoorPenalty = processed->outsidePercent * 0.25f;

            float diffusion = baseDiffusion + roughnessBonus - outdoorPenalty;
            return diffusion;
        }

        /// <summary>Calculates the EAX density parameter based on the number of energy peaks in the early echogram</summary>
        public virtual float CalculateDensity()
        {
            // Count significant energy peaks in the first 150ms
            int analysisLength = Math.Min((int)(150f / binDurationMs), echogramAverage.Length);

            // Fallback
            if (maxEnergy <= 0f)
                return 0.5f;

            // Count the number of peaks above a threshold
            float threshold = maxEnergy * 0.1f;
            int peakCount = 0;

            for (int i = 1; i < analysisLength - 1; i++)
            {
                if (echogramAverage[i] > threshold &&
                    echogramAverage[i] > echogramAverage[i - 1] &&
                    echogramAverage[i] > echogramAverage[i + 1])
                {
                    peakCount++;
                }
            }

            // Normalize peak count to density value
            //  More peaks per unit time = higher density
            //  Typical range is 10-100 peaks per second
            float peaksPerSecond = peakCount / (analysisLength * binDurationMs / 1000f);

            // Map to 0.0-1.0 range
            float baseDensity = MathF.Max(0, peaksPerSecond - 10f) / 90f;

            // Calculat eextra bonuses/penalties
            float returnedBonus = processed->returnedPercent * 0.3f;
            float outdoorPenalty = processed->outsidePercent * 0.3f;

            float density = baseDensity + returnedBonus - outdoorPenalty;
            return density;
        }

        /// <summary>Calculates the delay in seconds before the first significant reflection is detected</summary>
        public virtual float CalculateReflectionsDelay(float energyThreshold)
        {
            if (maxEnergy <= 0f)
                return 0.0f;

            // Find the first bin with significant energy
            float threshold = maxEnergy * energyThreshold;

            for (int i = 0; i < echogramAverage.Length; i++)
            {
                if (echogramAverage[i] >= threshold)
                {
                    float delayMs = i * binDurationMs;
                    float delaySeconds = delayMs / 1000f;

                    return delaySeconds;
                }
            }

            // No reflections found
            return 0.0f;
        }

        /// <summary>Calculates the delay in seconds before late reverb begins, based on the 25% energy accumulation point</summary>
        public virtual float CalculateLateReverbDelay()
        {
            if (totalReturnedEnergy <= 0f)
                return 0f;

            // Find where we've accumulated 25% of total energy
            // This marks the transition from sparse early reflections to dense late reverb
            float targetEnergy = totalReturnedEnergy * 0.25f;
            float accumulatedEnergy = 0f;
            int transitionBin = 0;

            for (int i = 0; i < echogramAverage.Length; i++)
            {
                accumulatedEnergy += echogramAverage[i];
                if (accumulatedEnergy >= targetEnergy)
                {
                    transitionBin = i;
                    break;
                }
            }

            // Convert to seconds
            float delayMs = transitionBin * binDurationMs;

            // Material roughness delays the transition to late reverb
            float roughnessDelay = processed->materialRoughness * 15f; // Add up to 15ms for fully rough surfaces

            delayMs += roughnessDelay;
            delayMs = MathF.Max(0f, delayMs);

            float delaySeconds = delayMs / 1000f;
            return delaySeconds;
        }

        /// <summary>Calculates the low and high frequency gain values relative to a reference energy level</summary>
        public virtual void CalculateFrequencyGains(float referenceEnergy, out float lfGain, out float hfGain)
        {
            if (totalReturnedEnergy <= 0 || referenceEnergy <= 0)
            {
                lfGain = 0.1f;  // Low default for outdoor/empty
                hfGain = 0.1f;
                return;
            }

            // Scale by reference energy
            float energyScale = MathF.Sqrt(totalReturnedEnergyAverage / referenceEnergy);

            // Calculate relative frequency balance
            float lfRatio = totalReturnedEnergyLF / totalReturnedEnergy;
            float hfRatio = totalReturnedEnergyHF / totalReturnedEnergy;

            // Should add up to 1
            Debug.Assert(MathF.Abs(lfRatio + hfRatio - 1) < 0.001f);

            // Combine absolute level with relative balance
            lfGain = lfRatio * energyScale;
            hfGain = hfRatio * energyScale;
        }

        /// <summary>Calculates the gain for early reflections and late reverb by splitting the echogram at a transition point</summary>
        public virtual void CalculateReflectionsAndLateReverbGain(float earlyLateTransitionMs, float referenceEnergy, out float reflectionsGain, out float lateReverbGain)
        {
            int transitionBin = (int)(earlyLateTransitionMs / binDurationMs);

            // Calculate energy in early reflections
            float earlyEnergyLF = 0f;
            float earlyEnergyHF = 0f;

            for (int i = 0; i < Math.Min(transitionBin, echogramLF.Length); i++)
            {
                earlyEnergyLF += echogramLF[i];
                earlyEnergyHF += echogramHF[i];
            }

            // Calculate energy in late reverb
            float lateEnergyLF = 0f;
            float lateEnergyHF = 0f;

            for (int i = transitionBin; i < echogramLF.Length; i++)
            {
                lateEnergyLF += echogramLF[i];
                lateEnergyHF += echogramHF[i];
            }

            // Average both frequency bands
            float earlyEnergy = (earlyEnergyLF + earlyEnergyHF) * 0.5f;
            float lateEnergy = (lateEnergyLF + lateEnergyHF) * 0.5f;

            if (referenceEnergy <= 0f)
            {
                reflectionsGain = 0.05f;
                lateReverbGain = 0.1f;
                return;
            }

            // Calculate gains relative to reference energy
            reflectionsGain = MathF.Sqrt(earlyEnergy / referenceEnergy);
            lateReverbGain = MathF.Sqrt(lateEnergy / referenceEnergy);
        }

        /// <summary>Calculates the RT60 reverberation time in seconds for a given echogram using linear regression on the decay slope</summary>
        public virtual float CalculateRT60(float[] echogram)
        {
            // Convert energy to dB scale
            float maxEnergy = 0f;

            if (echogramDb.Length < echogram.Length)
                Array.Resize(ref echogramDb, echogram.Length);

            for (int i = 0; i < echogram.Length; i++)
            {
                if (echogram[i] > maxEnergy)
                    maxEnergy = echogram[i];
            }

            if (maxEnergy <= 0f)
                return 0f;

            for (int i = 0; i < echogram.Length; i++)
            {
                if (echogram[i] > 0f)
                    echogramDb[i] = 10f * MathF.Log10(echogram[i] / maxEnergy);
                else
                    echogramDb[i] = -100f;
            }

            // Find the peak energy point
            int peakIndex = 0;
            float peakDb = echogramDb[0];
            for (int i = 1; i < echogramDb.Length; i++)
            {
                if (echogramDb[i] > peakDb)
                {
                    peakDb = echogramDb[i];
                    peakIndex = i;
                }
            }

            // Truncate at the first zero-energy bin after the peak — stray late bins beyond a gap are noise
            int echogramLength = echogram.Length;
            for (int i = peakIndex + 1; i < echogram.Length; i++)
            {
                if (echogram[i] <= 0f)
                {
                    echogramLength = i;
                    break;
                }
            }

            // Try T20 first, then T30, then T60
            float rt60 = TryCalculateDecayTime(echogramDb, peakIndex, peakDb, binDurationMs, echogramLength, 20f, 3f);

            if (rt60 <= 0f)
            {
                rt60 = TryCalculateDecayTime(echogramDb, peakIndex, peakDb, binDurationMs, echogramLength, 30f, 2f);
            }

            if (rt60 <= 0f)
            {
                rt60 = TryCalculateDecayTime(echogramDb, peakIndex, peakDb, binDurationMs, echogramLength, 60f, 1f);
            }

            return rt60;
        }

        /// <summary>Attempts to estimate RT60 by fitting a linear regression to the decay slope between -5 dB and <paramref name="targetDecayDb"/> below the peak</summary>
        /// <param name="echogramDb">Echogram values in decibels</param>
        /// <param name="peakIndex">Index of the peak energy bin</param>
        /// <param name="peakDb">Peak energy level in dB</param>
        /// <param name="binDurationMs">Duration of each echogram bin in milliseconds</param>
        /// <param name="echogramLength">The length of the echogram array</param>
        /// <param name="targetDecayDb">The dB drop range to use for the regression (e.g. 20, 30, or 60)</param>
        /// <param name="scaleFactor">Multiplier applied when extrapolating to full RT60</param>
        /// <returns>Estimated RT60 in seconds, or 0 if there are insufficient data points or the slope is non-negative</returns>
        protected virtual float TryCalculateDecayTime(float[] echogramDb, int peakIndex, float peakDb, float binDurationMs, int echogramLength, float targetDecayDb, float scaleFactor)
        {
            // Use linear regression to find decay slope through noisy/oscillating echograms
            // Analyze from -5dB to -targetDecayDb below peak
            float startDb = peakDb - 5f;
            float endDb = peakDb - targetDecayDb;

            int pointCount = 0;
            float sumX = 0f, sumY = 0f, sumXX = 0f, sumXY = 0f;
            float minTimeMs = float.MaxValue, maxTimeMs = float.MinValue;

            for (int i = peakIndex + 1; i < echogramLength; i++)
            {
                float db = echogramDb[i];
                if (db > startDb || db < endDb)
                    continue;

                float timeMs = (i - peakIndex) * binDurationMs;
                sumX += timeMs;
                sumY += db;
                sumXX += timeMs * timeMs;
                sumXY += timeMs * db;
                pointCount++;

                if (timeMs < minTimeMs) minTimeMs = timeMs;
                if (timeMs > maxTimeMs) maxTimeMs = timeMs;
            }

            // Need enough points and a sufficient time span for reliable regression.
            // A narrow time span (e.g. a brief outdoor burst) produces a shallow extrapolated slope → inflated RT60.
            const float minSpanMs = 100f;
            if (pointCount < 10 || (maxTimeMs - minTimeMs) < minSpanMs)
                return 0f;

            // Calculate slope using least squares: slope = (n*sumXY - sumX*sumY) / (n*sumXX - sumX*sumX)
            float denominator = pointCount * sumXX - sumX * sumX;
            if (MathF.Abs(denominator) < 0.0001f)
                return 0f;

            float slope = (pointCount * sumXY - sumX * sumY) / denominator; // dB per ms

            // Slope must be negative (decaying)
            if (slope >= 0f)
                return 0f;

            // RT60 = 60dB / |slope| gives time in ms for 60dB decay
            float rt60Ms = 60f / MathF.Abs(slope);
            return rt60Ms / 1000f; // Convert to seconds
        }
    }
}
