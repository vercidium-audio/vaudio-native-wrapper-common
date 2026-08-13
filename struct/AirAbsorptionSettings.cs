using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float AirAbsorptionFormulaDelegate(float distance);
}
