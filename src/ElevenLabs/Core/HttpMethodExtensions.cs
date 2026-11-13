using global::System.Net.Http;

namespace ElevenLabs.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
