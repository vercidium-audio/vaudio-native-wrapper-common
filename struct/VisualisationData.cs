using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VisualisationData
    {
        public Vector position;
        public Vector normal;
    }
}
