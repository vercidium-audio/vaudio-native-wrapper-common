using System;

namespace vaudionativewrapper.managed
{
    /// <summary>EAX reverb parameters that can be directly copied to an EAX reverb effect (e.g. in OpenAL)</summary>
    public unsafe class EAXReverb
    {
        public vaudionativewrapper.EAXReverb* native;

        public EAXReverb(vaudionativewrapper.EAXReverb* native)
        {
            this.native = native;
        }

        /// <summary>Linear gain applied per meter of distance for high-frequency air absorption (0.892–1)</summary>
        public float AirAbsorptionGainHF => native->airAbsorptionGainHF;
        /// <summary>Ratio of high-frequency decay time to mid-frequency decay time (0.1–2)</summary>
        public float DecayHFRatio => native->decayHFRatio;
        /// <summary>Ratio of low-frequency decay time to mid-frequency decay time (0.1–2)</summary>
        public float DecayLFRatio => native->decayLFRatio;
        /// <summary>Reverberation decay time at mid frequencies, in seconds (0.1–20)</summary>
        public float DecayTime => native->decayTime;
        /// <summary>Modal density of the late reverberation (0–1)</summary>
        public float Density => native->density;
        /// <summary>Echo diffusion of the late reverberation (0–1)</summary>
        public float Diffusion => native->diffusion;
        /// <summary>Amplitude of the echo effect (0–1)</summary>
        public float EchoDepth => native->echoDepth;
        /// <summary>Cycling time of the echo effect, in seconds (0.075–0.25)</summary>
        public float EchoTime => native->echoTime;
        /// <summary>Overall linear gain of the reverb (0–1)</summary>
        public float Gain => native->gain;
        /// <summary>High-frequency gain of the reverb (0–1)</summary>
        public float GainHF => native->gainHF;
        /// <summary>Low-frequency gain of the reverb (0–1)</summary>
        public float GainLF => native->gainLF;
        /// <summary>Reference frequency for high-frequency decay ratio, in Hz (1000–20000)</summary>
        public float HFReference => native->hfReference;
        /// <summary>Delay of late reverberation relative to early reflections, in seconds (0–0.1)</summary>
        public float LateReverbDelay => native->lateReverbDelay;
        /// <summary>Linear gain of late reverberation (0–10)</summary>
        public float LateReverbGain => native->lateReverbGain;
        /// <summary>Reference frequency for low-frequency decay ratio, in Hz (20–1000)</summary>
        public float LFReference => native->lfReference;
        /// <summary>Amplitude of the modulation effect (0–1)</summary>
        public float ModulationDepth => native->modulationDepth;
        /// <summary>Cycling time of the modulation effect, in seconds (0.04–4)</summary>
        public float ModulationTime => native->modulationTime;
        /// <summary>Delay before early reflections are heard, in seconds (0–0.3)</summary>
        public float ReflectionsDelay => native->reflectionsDelay;
        /// <summary>Linear gain of early reflections (0–3.16)</summary>
        public float ReflectionsGain => native->reflectionsGain;
        /// <summary>Rolloff factor for reflected sound sources (0–10)</summary>
        public float RoomRolloffFactor => native->roomRolloffFactor;
        /// <summary>Whether to limit high-frequency decay time to the air absorption limit (0 or 1)</summary>
        public int DecayHFLimit => native->decayHFLimit;

        public Vector? GetRelativeDirection(Emitter emitter)
        {
            var ptr = EAXReverbResultsBindings.GetRelativeDirection((IntPtr)native, emitter.native);

            if (ptr != null)
                return *ptr;

            return null;
        }

        public float? GetRelativeGain(Emitter emitter)
        {
            var ptr = EAXReverbResultsBindings.GetRelativeGain((IntPtr)native, emitter.native);

            if (ptr != null)
                return *ptr;

            return null;
        }

        /// <summary>
        /// Computes a similarity score between this reverb preset and another, in the range [0, 1] where 1 means identical.
        /// </summary>
        public float GetSimilarity(EAXReverb other) => EAXUtilsBindings.GetSimilarity(native, other.native);

        /// <summary>
        /// Gets the number of seconds this reverb's tail remains audible after the emitter stops emitting, used to delay removal from the world.
        /// maxVolume is the loudest linear volume (0-1) the emitter's dry source is ever played at (see Emitter.GetMaxVolume).
        /// </summary>
        public float GetEffectiveTailSeconds(float maxVolume) => EAXUtilsBindings.GetEffectiveTailSeconds(native, maxVolume);

        /// <summary>
        /// Finds the candidate most similar to target.
        /// Returns the best match, or null if target or candidates is null/empty.
        /// </summary>
        public static EAXReverb FindBestMatch(EAXReverb target, EAXReverb[] candidates)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (candidates == null)
                throw new ArgumentNullException(nameof(candidates));

            if (candidates.Length == 0)
                throw new ArgumentException("candidates cannot be empty", nameof(candidates));

            var nativeCandidates = stackalloc vaudionativewrapper.EAXReverb*[candidates.Length];

            for (int i = 0; i < candidates.Length; i++)
                nativeCandidates[i] = candidates[i].native;

            vaudionativewrapper.EAXReverb* outBest;
            int index = EAXUtilsBindings.FindBestMatch(target.native, nativeCandidates, candidates.Length, &outBest);

            if (index < 0 || outBest == null)
                return null;

            return candidates[index];
        }
    }
}