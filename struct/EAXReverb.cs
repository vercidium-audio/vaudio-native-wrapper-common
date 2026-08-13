using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EAXReverb
    {
        public float outsidePercent;
        public float returnedPercent;
        public float materialAbsorptionLF;
        public float materialAbsorptionHF;
        public float materialRoughness;

        // Opaque list pointers - use EAXReverbResultsBindings.GetPan / GetEffectSlotGain to query per-emitter
        IntPtr relativeEmitters;     /* Emitter keys for relativeDirections/relativeGains */
        IntPtr relativeDirections;   /* Direction that reverb should be heard from, relative to each emitter with hasRelativeReverb=true. Access via vaEAXReverbGetRelativeDirection */
        IntPtr relativeGains;        /* Gain for this reverb effect, relative to each emitter with hasRelativeReverb=true. Access via vaEAXReverbGetRelativeGain */
        int relativeCount;
        int relativeCapacity;

        public float reflectionsDelay;
        public float density;
        public float diffusion;
        public float gainLF;
        public float gainHF;
        public float gain;
        public float decayTime;
        public float decayLFRatio;
        public float decayHFRatio;
        public float reflectionsGain;
        public float lateReverbGain;
        public float lateReverbDelay;
        public float echoTime;
        public float echoDepth;
        public float modulationTime;
        public float modulationDepth;
        public float airAbsorptionGainHF;
        public float hfReference;
        public float lfReference;
        public float roomRolloffFactor;
        public int decayHFLimit;

        // Ignore this
        private int internalData;
    }
}