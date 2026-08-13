namespace vaudionativewrapper.managed
{
    /// <summary>Useful properties produced by reverb rays</summary>
    public unsafe class ProcessedReverb
    {
        public vaudionativewrapper.ProcessedReverb* native;

        public ProcessedReverb(vaudionativewrapper.ProcessedReverb* native)
        {
            this.native = native;
        }

        /// <summary>The percentage of energy that returned back to the emitter. Calculated as raw.ReturnedTotal / (ReverbRayCount * ReverbBounceCount)</summary>
        public float ReturnedPercent => native->returnedPercent;

        /// <summary>The percentage of energy that escaped outside (hit the world edge). Calculated as raw.OutsideTotal / (ReverbRayCount * ReverbBounceCount)</summary>
        public float OutsidePercent => native->outsidePercent;

        /// <summary>The low-frequency reverberation decay time measured from the echogram. Calculated using RT20, RT30, or RT60 method depending on echogram length and room size. Used to calculate EAX DecayTime and DecayLFRatio.</summary>
        public float MeasuredDecayTimeLF => native->measuredDecayTimeLF;

        /// <summary>The high-frequency reverberation decay time measured from the echogram. Calculated using RT20, RT30, or RT60 method depending on echogram length and room size. Used to calculate EAX DecayTime and DecayHFRatio.</summary>
        public float MeasuredDecayTimeHF => native->measuredDecayTimeHF;

        /// <summary>The average roughness/scattering of all surfaces that all rays hit.</summary>
        public float MaterialRoughness => native->materialRoughness;

        /// <summary>The average low-frequency absorption of all surfaces that all rays hit.</summary>
        public float MaterialAbsorptionLF => native->materialAbsorptionLF;

        /// <summary>The average high-frequency absorption of all surfaces that all rays hit.</summary>
        public float MaterialAbsorptionHF => native->materialAbsorptionHF;

        public float GetMaterialAbsorption() => ProcessedReverbBindings.GetMaterialAbsorption(native);
    }
}
