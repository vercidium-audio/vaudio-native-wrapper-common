using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class EAXUtilsBindings
    {
        /// <summary>
        /// Finds the candidate most similar to target. outBest is set to the best match.
        /// Returns the index of the best match, or -1 if target or outBest is NULL, or candidates is NULL or empty (outBest is set to NULL in these cases)
        /// </summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaEAXUtilsFindBestMatch")]
        public static extern unsafe int FindBestMatch(EAXReverb* target, EAXReverb** candidates, int candidateCount, EAXReverb** outBest);

        /// <summary>
        /// Computes a similarity score between two reverb presets, in the range [0, 1] where 1 means identical.
        /// Returns 0 if a or b is NULL
        /// </summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaEAXUtilsGetSimilarity")]
        public static extern unsafe float GetSimilarity(EAXReverb* a, EAXReverb* b);

        /// <summary>
        /// Get the number of seconds an emitter's reverb tail remains audible after it stops emitting, used to delay removal from the world.
        /// maxVolume is the loudest linear volume (0-1) the emitter's dry source is ever played at (see vaEmitterGetMaxVolume).
        /// Returns 0 if eax is NULL (no reverb has been calculated yet)
        /// </summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaEAXUtilsGetEffectiveTailSeconds")]
        public static extern unsafe float GetEffectiveTailSeconds(EAXReverb* eax, float maxVolume);
    }
}
