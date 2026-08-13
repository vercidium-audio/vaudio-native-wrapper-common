using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class ProcessedReverbBindings
    {
        /// <summary>
        /// Returns the average of materialAbsorptionLF and materialAbsorptionHF, or 0 if p is null.
        /// </summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaProcessedReverbGetMaterialAbsorption")]
        public static extern unsafe float GetMaterialAbsorption(ProcessedReverb* p);
    }
}
