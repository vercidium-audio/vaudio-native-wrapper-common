using System;

namespace vaudionativewrapper
{
    public enum VAResult
    {
        Success = 0,
        InvalidValue = 1,
        OutOfRange = 2,
        AlreadyExists = 3,
        FeatureDisabled = 4,
        ErrorInUse = 5,
        InvalidCount = 6,
        WorldConflict = 7,
        ErrorFileOpen = 8,
        ErrorFileWrite = 9,
        ErrorFileVersion = 10,
        ErrorFileCorrupt = 11,
        InvalidMaterial = 12,
        MaterialDoesNotExist = 13,
        NotAddedToWorld = 14,
        InsufficientVertices = 15,
        InvalidVertexCount = 16,
        InvalidArray = 17,
        InvalidPointer = 18,
        Unchanged = 19,
        NotFound = 20,
        StillRunning = 21,
        PendingRemoval = 22,
        ConfigError = 23,
        True = 24,
        False = 25,
    }

    public static class VAResultExtensions
    {
        // VA_UNCHANGED means the setter was a no-op (value already matched) - not an error.
        public static void ThrowIfError(this VAResult result)
        {
            if (result != VAResult.Success && result != VAResult.Unchanged && result != VAResult.StillRunning && result != VAResult.PendingRemoval && result != VAResult.True && result != VAResult.False)
                throw new InvalidOperationException($"Native call failed: {result}");
        }
    }
}