using System.Runtime.InteropServices;

namespace vaudionativewrapper
{
    /// <summary>A 32-bit colour with byte-per-channel components. Only used for debug rendering - has no effect on raytracing.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        /// <summary>Creates a color from byte components. Alpha defaults to 255</summary>
        public Color(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>Red channel</summary>
        public byte R;

        /// <summary>Green channel</summary>
        public byte G;

        /// <summary>Blue channel</summary>
        public byte B;

        /// <summary>Alpha channel</summary>
        public byte A;
    }
}
