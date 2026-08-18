using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class PrimitiveBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPrimitiveSetMaterial")]
        public static extern VAResult SetMaterial(IntPtr primitive, MaterialType material);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPrimitiveGetMaterial")]
        public static extern MaterialType GetMaterial(IntPtr primitive);
    }
}
