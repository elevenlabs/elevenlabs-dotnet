namespace ElevenLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body, ElevenLabs.RawResponse? rawResponse = null)
    : ElevenLabsClientApiException("ForbiddenError", 403, body, rawResponse: rawResponse);
