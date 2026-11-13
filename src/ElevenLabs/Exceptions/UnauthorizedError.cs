namespace ElevenLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(object body, ElevenLabs.RawResponse? rawResponse = null)
    : ElevenLabsClientApiException("UnauthorizedError", 401, body, rawResponse: rawResponse);
