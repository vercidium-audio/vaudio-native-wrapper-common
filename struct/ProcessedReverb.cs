using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessedReverb
    {
        public float returnedPercent;
        public float outsidePercent;
        public float measuredDecayTimeLF;
        public float measuredDecayTimeHF;
        public float materialRoughness;
        public float materialAbsorptionLF;
        public float materialAbsorptionHF;
    }
}