using Environment = ElevenLabs.Http.Environment;

namespace ElevenLabs.Config;

/// <summary>
/// Configuration options for the ElevenLabsClient.
/// </summary>
internal record ElevenlabsApiConfig(
    /// <value>The environment to use for the SDK.</value>
    Environment? Environment = null
);
