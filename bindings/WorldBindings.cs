using System;
using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    public static class WorldBindings
    {
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldCreate")]
        public static extern IntPtr Create();
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldDestroy")]
        public static extern VAResult Destroy(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldAddPrimitive_")]
        public static extern VAResult AddPrimitive(IntPtr world, IntPtr primitive);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldRemovePrimitive_")]
        public static extern VAResult RemovePrimitive(IntPtr world, IntPtr primitive);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldAddEmitter")]
        public static extern VAResult AddEmitter(IntPtr ctx, IntPtr emitter);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldHasEmitter")]
        public static extern VAResult HasEmitter(IntPtr ctx, IntPtr emitter);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldRemoveEmitter")]
        public static extern VAResult RemoveEmitter(IntPtr ctx, IntPtr emitter);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldUpdate")]
        public static extern VAResult Update(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldWait")]
        public static extern VAResult Wait(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetPendingShutdown")]
        public static extern VAResult SetPendingShutdown(IntPtr world, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetPendingShutdown")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetPendingShutdown(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetThreadsRunning")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetThreadsRunning(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMainThreadTime")]
        public static extern double GetMainThreadTime(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetRaytracingTime")]
        public static extern double GetRaytracingTime(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetPreparationTime")]
        public static extern double GetPreparationTime(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetAnalysisTime")]
        public static extern double GetAnalysisTime(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetPosition")]
        public static extern Vector GetPosition(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetPosition")]
        public static extern VAResult SetPosition(IntPtr world, Vector position);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetSize")]
        public static extern Vector GetSize(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetSize")]
        public static extern VAResult SetSize(IntPtr world, Vector size);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaximumBounds")]
        public static extern Vector GetMaximumBounds(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaximumBounds")]
        public static extern VAResult SetMaximumBounds(IntPtr world, Vector maxBounds);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetGroupedEAX")]
        public static extern unsafe EAXReverb** GetGroupedEAX(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetGroupedEAXCount")]
        public static extern int GetCurrentGroupedEAXCount(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldCreateMaterial")]
        public static extern VAResult CreateMaterial(IntPtr world, int materialId);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldHasMaterial")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool HasMaterial(IntPtr world, int materialId);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialAbsorptionLF")]
        public static extern float GetMaterialAbsorptionLF(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialAbsorptionHF")]
        public static extern float GetMaterialAbsorptionHF(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialScattering")]
        public static extern float GetMaterialScattering(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialTransmissionLF")]
        public static extern float GetMaterialTransmissionLF(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialTransmissionHF")]
        public static extern float GetMaterialTransmissionHF(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialPlaneTransmissionLF")]
        public static extern float GetMaterialPlaneTransmissionLF(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialPlaneTransmissionHF")]
        public static extern float GetMaterialPlaneTransmissionHF(IntPtr world, int materialId);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialAbsorptionLF")]
        public static extern VAResult SetMaterialAbsorptionLF(IntPtr world, int materialId, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialAbsorptionHF")]
        public static extern VAResult SetMaterialAbsorptionHF(IntPtr world, int materialId, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialScattering")]
        public static extern VAResult SetMaterialScattering(IntPtr world, int materialId, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialTransmissionLF")]
        public static extern VAResult SetMaterialTransmissionLF(IntPtr world, int materialId, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialTransmissionHF")]
        public static extern VAResult SetMaterialTransmissionHF(IntPtr world, int materialId, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialPlaneTransmissionLF")]
        public static extern VAResult SetMaterialPlaneTransmissionLF(IntPtr world, int materialId, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialPlaneTransmissionHF")]
        public static extern VAResult SetMaterialPlaneTransmissionHF(IntPtr world, int materialId, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaterialColor")]
        public static extern Color GetMaterialColor(IntPtr world, int materialId);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaterialColor")]
        public static extern VAResult SetMaterialColor(IntPtr world, int materialId, Color color);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaximumGroupedEAXCount")]
        public static extern int GetMaximumGroupedEAXCount(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaximumGroupedEAXCount")]
        public static extern VAResult SetMaximumGroupedEAXCount(IntPtr world, int value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetWorkItemCount")]
        public static extern int GetWorkItemCount(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetWorkItemCount")]
        public static extern VAResult SetWorkItemCount(IntPtr world, int value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMaximumConcurrencyLevel")]
        public static extern int GetMaximumConcurrencyLevel(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMaximumConcurrencyLevel")]
        public static extern VAResult SetMaximumConcurrencyLevel(IntPtr world, int value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetMetersPerUnit")]
        public static extern float GetMetersPerUnit(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetMetersPerUnit")]
        public static extern VAResult SetMetersPerUnit(IntPtr world, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetInverseSpeedOfSound")]
        public static extern float GetInverseSpeedOfSound(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetInverseSpeedOfSound")]
        public static extern VAResult SetInverseSpeedOfSound(IntPtr world, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetReferenceFrequencyLF")]
        public static extern float GetReferenceFrequencyLF(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetReferenceFrequencyLF")]
        public static extern VAResult SetReferenceFrequencyLF(IntPtr world, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetReferenceFrequencyHF")]
        public static extern float GetReferenceFrequencyHF(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetReferenceFrequencyHF")]
        public static extern VAResult SetReferenceFrequencyHF(IntPtr world, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetAirAbsorption")]
        public static extern IntPtr GetAirAbsorption(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetAirAbsorption")]
        public static extern VAResult SetAirAbsorption(IntPtr world, IntPtr settings);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetAirAbsorptionHumidity")]
        public static extern VAResult SetAirAbsorptionHumidity(IntPtr world, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetAirAbsorptionTemperature")]
        public static extern VAResult SetAirAbsorptionTemperature(IntPtr world, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetAirAbsorptionPressure")]
        public static extern VAResult SetAirAbsorptionPressure(IntPtr world, float value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetAirAbsorptionCustomFormulaLF")]
        public static extern VAResult SetAirAbsorptionCustomFormulaLF(IntPtr world, IntPtr formula);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetAirAbsorptionCustomFormulaHF")]
        public static extern VAResult SetAirAbsorptionCustomFormulaHF(IntPtr world, IntPtr formula);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetCustomEAXFormulas")]
        public static extern unsafe VAResult SetCustomEAXFormulas(IntPtr world, CustomEAXFormulas* formulas);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetEmittersOutsideTheWorldAreMuffled")]
        public static extern VAResult SetEmittersOutsideTheWorldAreMuffled(IntPtr ctx, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetEmittersOutsideTheWorldAreMuffled")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetEmittersOutsideTheWorldAreMuffled(IntPtr ctx);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetWorldIsIndoors")]
        public static extern VAResult SetWorldIsIndoors(IntPtr ctx, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetWorldIsIndoors")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetWorldIsIndoors(IntPtr ctx);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetEmitterCount")]
        public static extern int GetEmitterCount(IntPtr ctx);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetInitialising")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetInitialising(IntPtr ctx);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetOnRaytracingCompletedCallback")]
        public static extern VAResult SetOnRaytracingCompleted(IntPtr ctx, IntPtr callback);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetOnReverbUpdatedCallback")]
        public static extern VAResult SetOnReverbUpdated(IntPtr ctx, IntPtr callback);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetOnRaytracingResultsHandledCallback")]
        public static extern VAResult SetOnRaytracingResultsHandled(IntPtr ctx, IntPtr callback);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetLogCallback")]
        public static extern VAResult SetLogCallback(IntPtr ctx, IntPtr callback);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetLogMemoryAllocationWarnings")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetLogMemoryAllocationWarnings(IntPtr ctx);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetLogMemoryAllocationWarnings")]
        public static extern VAResult SetLogMemoryAllocationWarnings(IntPtr ctx, bool value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetCoordinateSystem")]
        public static extern CoordinateSystem GetCoordinateSystem(IntPtr ctx);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetCoordinateSystem")]
        public static extern VAResult SetCoordinateSystem(IntPtr ctx, CoordinateSystem value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetEpsilon")]
        public static extern float GetEpsilon(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetEpsilon")]
        public static extern VAResult SetEpsilon(IntPtr world, float value);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetLatency")]
        public static extern double GetLatency(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetUserData")]
        public static extern IntPtr GetUserData(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetUserData")]
        public static extern VAResult SetUserData(IntPtr world, IntPtr userData);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldCalculateListenerRelativePan")]
        public static extern Vector CalculateListenerRelativePan(IntPtr ctx, Vector worldVector, float listenerPitch, float listenerYaw);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetRaysCastThisFrame")]
        public static extern int GetRaysCastThisFrame(IntPtr ctx);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldExport")]
        public static extern VAResult Export(IntPtr world, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldImport")]
        public static extern unsafe VAResult Import(IntPtr world, [MarshalAs(UnmanagedType.LPStr)] string fileName, IntPtr** outEmitters, int* outEmitterCount);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldImportFreeEmitters")]
        public static extern unsafe VAResult ImportFreeEmitters(IntPtr* emitters);

#region Rendering
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetRenderingEnabled")]
        public static extern VAResult SetRenderingEnabled(IntPtr world, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetRenderingEnabled")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetRenderingEnabled(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetManualCamera")]
        public static extern VAResult SetManualCamera(IntPtr world, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetManualCamera")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetManualCamera(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetShouldRenderRays")]
        public static extern VAResult SetShouldRenderRays(IntPtr world, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetShouldRenderRays")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetShouldRenderRays(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetShouldRenderPrimitives")]
        public static extern VAResult SetShouldRenderPrimitives(IntPtr world, bool value);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetShouldRenderPrimitives")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool GetShouldRenderPrimitives(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetCameraPosition")]
        public static extern Vector GetCameraPosition(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetCameraPosition")]
        public static extern VAResult SetCameraPosition(IntPtr world, Vector position);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetCameraPitch")]
        public static extern float GetCameraPitch(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetCameraPitch")]
        public static extern VAResult SetCameraPitch(IntPtr world, float pitch);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetCameraYaw")]
        public static extern float GetCameraYaw(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetCameraYaw")]
        public static extern VAResult SetCameraYaw(IntPtr world, float yaw);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetFieldOfView")]
        public static extern float GetFieldOfView(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetFieldOfView")]
        public static extern VAResult SetFieldOfView(IntPtr world, float fieldOfView);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetCameraSpeed")]
        public static extern float GetCameraSpeed(IntPtr world);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetCameraSpeed")]
        public static extern VAResult SetCameraSpeed(IntPtr world, float cameraSpeed);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetRenderTime")]
        public static extern double GetRenderTime(IntPtr world);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetWindowPosition")]
        public static extern void GetWindowPosition(IntPtr world, out int x, out int y);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetWindowPosition")]
        public static extern VAResult SetWindowPosition(IntPtr world, int x, int y);

        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldGetWindowSize")]
        public static extern void GetWindowSize(IntPtr world, out int width, out int height);
        [DllImport(Constants.DLL_NAME, CallingConvention = CallingConvention.Cdecl, EntryPoint = "vaWorldSetWindowSize")]
        public static extern VAResult SetWindowSize(IntPtr world, int width, int height);

        #endregion
    }
}
