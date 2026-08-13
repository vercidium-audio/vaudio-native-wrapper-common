using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class CustomEAXFormulasBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaCustomEAXFormulasCreate")]
        public static extern unsafe CustomEAXFormulas* Create();

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaCustomEAXFormulasDestroy")]
        public static extern unsafe VAResult Destroy(CustomEAXFormulas* formulas);
    }
}
