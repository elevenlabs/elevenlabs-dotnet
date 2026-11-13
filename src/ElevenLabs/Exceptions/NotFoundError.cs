namespace ElevenLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, ElevenLabs.RawResponse? rawResponse = null)
    : ElevenLabsClientApiException("NotFoundError", 404, body, rawResponse: rawResponse);
