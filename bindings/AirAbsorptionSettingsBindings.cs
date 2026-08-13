using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class AirAbsorptionSettingsBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionCreate")]
        public static extern IntPtr Create();

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionValidate")]
        public static extern VAResult Validate(IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionSetHumidity")]
        public static extern VAResult SetHumidity(IntPtr settings, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionSetTemperature")]
        public static extern VAResult SetTemperature(IntPtr settings, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionSetPressure")]
        public static extern VAResult SetPressure(IntPtr settings, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionSetCustomFormulaLF")]
        public static extern VAResult SetCustomFormulaLF(IntPtr settings, IntPtr formula);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionSetCustomFormulaHF")]
        public static extern VAResult SetCustomFormulaHF(IntPtr settings, IntPtr formula);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionGetHumidity")]
        public static extern float GetHumidity(IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionGetTemperature")]
        public static extern float GetTemperature(IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionGetPressure")]
        public static extern float GetPressure(IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionGetCustomFormulaLF")]
        public static extern IntPtr GetCustomFormulaLF(IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionGetCustomFormulaHF")]
        public static extern IntPtr GetCustomFormulaHF(IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaAirAbsorptionDestroy")]
        public static extern VAResult Destroy(IntPtr settings);
    }
}
