using System;
using System.Diagnostics;

namespace vaudionativewrapper.managed
{
    /// <summary>A 3D primitive that rays collide with.</summary>
    public abstract class Primitive
    {
        public IntPtr native;
        protected bool owns;

#if DEBUG
        string stackTrace;
#endif

        public Primitive(IntPtr native)
        {
            this.native = native;

#if DEBUG
            stackTrace = Environment.StackTrace;
#endif
        }

        public Primitive() { }

        /// <summary>Determines the amount of energy lost when rays bounce off this primitive, permeate through it, and scatter off it</summary>
        public MaterialType material
        {
            get => PrimitiveBindings.GetMaterial(native);
            set => PrimitiveBindings.SetMaterial(native, value).ThrowIfError();
        }

        /// <summary>Unique properties logged in the ~Primitive finaliser to identify which primitive was leaked</summary>
        protected virtual string DebugInfo => "";

        /// <summary>Attempts to destroy the native primitive. Throws an exception if the primitive is still added to a world</summary>
        public void Destroy()
        {
            DestroyNative(native).ThrowIfError();
            native = IntPtr.Zero;
        }

        /// <summary>Calls the primitive-specific native Destroy binding</summary>
        protected abstract VAResult DestroyNative(IntPtr native);

#if DEBUG
        ~Primitive()
        {
            if (owns && native != IntPtr.Zero)
                LogSettings.Warn($"{GetType().Name} was garbage collected without calling Destroy() first. {DebugInfo}. Stack trace: {stackTrace}");
        }
#endif
    }
}
