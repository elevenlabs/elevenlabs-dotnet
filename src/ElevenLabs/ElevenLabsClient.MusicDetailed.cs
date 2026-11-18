namespace ElevenLabs;

public partial class ElevenLabsClient
{
    /// <summary>
    /// The HTTP pipeline the generated sub-clients share, for hand-written helpers such as
    /// <see cref="ElevenLabs.Music.MusicDetailed"/> that send a request the generated methods can't
    /// decode. Hand-written (see <c>.fernignore</c>).
    /// </summary>
    internal global::ElevenLabs.Http.Client SharedHttpClient => _httpClient;
}
