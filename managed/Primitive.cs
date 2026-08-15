using System;

namespace vaudionativewrapper.managed
{
    /// <summary>A 3D primitive that rays collide with.</summary>
    public class Primitive
    {
        public IntPtr native;
        protected bool owns;

        public Primitive(IntPtr native)
        {
            this.native = native;
        }

        public Primitive() { }

        /// <summary>Unique properties logged in the ~Primitive finaliser to identify which primitive was leaked</summary>
        protected virtual string DebugInfo => "";

        public void Destroy()
        {
            DestroyNative(native).ThrowIfError();
            native = IntPtr.Zero;
        }

        /// <summary>Calls the primitive-specific native Destroy binding</summary>
        protected virtual VAResult DestroyNative(IntPtr native) => throw new NotImplementedException();

        ~Primitive()
        {
            if (owns && native != IntPtr.Zero)
                LogSettings.Warn($"{GetType().Name} was garbage collected without calling Destroy() first. {DebugInfo}");
        }
    }
}
