using System;

namespace vaudionativewrapper.managed
{
    /// <summary>Acoustic properties for a specific material</summary>
    public class MaterialProperties
    {
        private IntPtr world;
        private int id;

        public MaterialProperties(IntPtr world, int id)
        {
            this.world = world;
            this.id = id;
        }

        /// <summary>Percentage of low-frequency energy that is lost on each bounce (0.0 to 1.0).</summary>
        public float AbsorptionLF
        {
            get => WorldBindings.GetMaterialAbsorptionLF(world, id);
            set => WorldBindings.SetMaterialAbsorptionLF(world, id, value);
        }

        /// <summary>Percentage of high-frequency energy that is lost on each bounce (0.0 to 1.0).</summary>
        public float AbsorptionHF
        {
            get => WorldBindings.GetMaterialAbsorptionHF(world, id);
            set => WorldBindings.SetMaterialAbsorptionHF(world, id, value);
        }

        /// <summary>Scattering strength (0.0 to 1.0), where 0.0 has no scattering and 1.0 skews the ray reflection direction by up to 90 degrees</summary>
        public float Scattering
        {
            get => WorldBindings.GetMaterialScattering(world, id);
            set => WorldBindings.SetMaterialScattering(world, id, value);
        }

        /// <summary>How many meters a ray must travel through a primitive before it loses all low-frequency energy</summary>
        public float TransmissionLF
        {
            get => WorldBindings.GetMaterialTransmissionLF(world, id);
            set => WorldBindings.SetMaterialTransmissionLF(world, id, value);
        }

        /// <summary>How many meters a ray must travel through a primitive before it loses all high-frequency energy</summary>
        public float TransmissionHF
        {
            get => WorldBindings.GetMaterialTransmissionHF(world, id);
            set => WorldBindings.SetMaterialTransmissionHF(world, id, value);
        }

        /// <summary>Percentage of low-frequency energy lost when a ray passes through a flat PlanePrimitive, DiskPrimitive, TrianglePrimitive or non-watertight MeshPrimitive. Ranges from 0.0 to 1.0</summary>
        public float PlaneTransmissionLF
        {
            get => WorldBindings.GetMaterialPlaneTransmissionLF(world, id);
            set => WorldBindings.SetMaterialPlaneTransmissionLF(world, id, value);
        }

        /// <summary>Percentage of high-frequency energy lost when a ray passes through a flat PlanePrimitive, DiskPrimitive, TrianglePrimitive or non-watertight MeshPrimitive. Ranges from 0.0 to 1.0</summary>
        public float PlaneTransmissionHF
        {
            get => WorldBindings.GetMaterialPlaneTransmissionHF(world, id);
            set => WorldBindings.SetMaterialPlaneTransmissionHF(world, id, value);
        }

        /// <summary>Debug rendering colour for this material (dev build only). No effect on raytracing.</summary>
        public Color Color
        {
            get => WorldBindings.GetMaterialColor(world, id);
            set => WorldBindings.SetMaterialColor(world, id, value).ThrowIfError();
        }
    }
}