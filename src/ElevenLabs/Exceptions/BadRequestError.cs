namespace ElevenLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, ElevenLabs.RawResponse? rawResponse = null)
    : ElevenLabsClientApiException("BadRequestError", 400, body, rawResponse: rawResponse);
