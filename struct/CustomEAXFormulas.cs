using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void CustomEAXFormulas_InitialiseDelegate(CustomEAXFormulas* formulas, ProcessedReverb* processed, float totalReturningEnergyLF, float totalReturningEnergyHF, float echogramGranularity, float* echogramLF, float* echogramHF, float* echogramAverage, int echogramLength);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float CustomEAXFormulas_CalculateDiffusionDelegate(CustomEAXFormulas* formulas);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float CustomEAXFormulas_CalculateDensityDelegate(CustomEAXFormulas* formulas);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float CustomEAXFormulas_CalculateReflectionsDelayDelegate(CustomEAXFormulas* formulas, float energyThreshold);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float CustomEAXFormulas_CalculateLateReverbDelayDelegate(CustomEAXFormulas* formulas);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void CustomEAXFormulas_CalculateFrequencyGainsDelegate(CustomEAXFormulas* formulas, float referenceEnergy, float* outLFGain, float* outHFGain);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void CustomEAXFormulas_CalculateReflectionsAndLateReverbGainDelegate(CustomEAXFormulas* formulas, float earlyLateTransitionMs, float referenceEnergy, float* outReflectionsGain, float* outLateReverbGain);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float CustomEAXFormulas_CalculateRT60Delegate(CustomEAXFormulas* formulas, float* echogram, int echogramLength);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float CustomEAXFormulas_TryCalculateDecayTimeDelegate(CustomEAXFormulas* formulas, float* echogramDb, int echogramDbLength, int peakIndex, float peakDb, float binDurationMs, float targetDecayDb, float scaleFactor);

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CustomEAXFormulas
    {
        public IntPtr initialise;
        public IntPtr calculateDiffusion;
        public IntPtr calculateDensity;
        public IntPtr calculateReflectionsDelay;
        public IntPtr calculateLateReverbDelay;
        public IntPtr calculateFrequencyGains;
        public IntPtr calculateReflectionsAndLateReverbGain;
        public IntPtr calculateRT60;
        public IntPtr tryCalculateDecayTime;

        public float* tempDiffusionCumulative;
        public int tempDiffusionCumulativeLength;

        public float* echogramDB;
        public int echogramDBLength;

        public float binDurationMs;

        public ProcessedReverb* processed;
        public float* echogramLF;
        public float* echogramHF;
        public float* echogramAverage;
        public int echogramLength;

        public float maxEnergy;
        public float totalEnergy;
    }
}
