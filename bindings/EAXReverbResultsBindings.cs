using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class EAXReverbResultsBindings
    {
        /// <summary>
        /// Returns a pointer to the relative direction Vector for the given emitter, or null if not set.
        /// </summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaEAXReverbGetRelativeDirection")]
        public static extern unsafe Vector* GetRelativeDirection(IntPtr eax, IntPtr emitter);

        /// <summary>
        /// Returns a pointer to the relative gain float for the given emitter, or null if not set.
        /// </summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaEAXReverbGetRelativeGain")]
        public static extern unsafe float* GetRelativeGain(IntPtr eax, IntPtr emitter);
    }
}
