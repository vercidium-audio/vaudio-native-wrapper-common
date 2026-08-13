namespace vaudionativewrapper.managed
{
    /// <summary>SDK version information</summary>
    public static class Version
    {
        /// <summary>Gets the major, minor and patch version numbers of this SDK.</summary>
        public static (int major, int minor, int patch) Get()
        {
            VersionBindings.GetVersion(out int major, out int minor, out int patch);
            return (major, minor, patch);
        }

        /// <summary>Whether this is a production build. False in dev/debug builds.</summary>
        public static bool IsProduction => VersionBindings.IsProduction();
    }
}
