namespace ElevenLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooEarlyError(object body, ElevenLabs.RawResponse? rawResponse = null)
    : ElevenLabsClientApiException("TooEarlyError", 425, body, rawResponse: rawResponse);
