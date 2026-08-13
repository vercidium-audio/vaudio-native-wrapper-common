using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LowPassFilter
    {
        public float gainLF;
        public float gainHF;
    }
}
