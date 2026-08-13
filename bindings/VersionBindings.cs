using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class VersionBindings
    {
        /// <summary>Get the major, minor and patch version numbers of this SDK.</summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaGetVersion")]
        public static extern void GetVersion(out int major, out int minor, out int patch);

        /// <summary>Get whether this is a production build. Returns false in dev/debug builds.</summary>
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaIsProduction")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool IsProduction();
    }
}
