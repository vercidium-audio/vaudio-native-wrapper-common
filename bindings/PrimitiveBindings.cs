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

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPrimitiveSetUseFlatTransmission")]
        public static extern VAResult SetUseFlatTransmission(IntPtr primitive, bool useFlatTransmission);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaPrimitiveGetUseFlatTransmission")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetUseFlatTransmission(IntPtr primitive);
    }
}
