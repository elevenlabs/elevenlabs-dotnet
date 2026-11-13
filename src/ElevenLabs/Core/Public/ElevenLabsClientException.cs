namespace ElevenLabs;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class ElevenLabsClientException(string message, Exception? innerException = null)
    : Exception(message, innerException);
