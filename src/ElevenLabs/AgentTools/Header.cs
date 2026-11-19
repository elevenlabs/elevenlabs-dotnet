using System.Text.Json.Nodes;

namespace ElevenLabs.AgentTools;

/// <summary>The value of a webhook request header. Built with the static constructors.</summary>
public sealed class Header
{
    private readonly JsonNode _model;

    private Header(JsonNode model) => _model = model;

    /// <summary>A fixed value.</summary>
    public static Header Value(string text) => new(JsonValue.Create(text)!);

    /// <summary>A secret from the workspace's secret store, so the value never appears in the config.</summary>
    public static Header Secret(string secretId) => new(new JsonObject { ["secret_id"] = secretId });

    /// <summary>The value of a dynamic variable when the tool runs.</summary>
    public static Header Variable(string name) => new(new JsonObject { ["variable_name"] = name });

    /// <summary>A workspace environment variable, by label.</summary>
    public static Header EnvVar(string label) => new(new JsonObject { ["env_var_label"] = label });

    /// <summary>The header value in API wire format.</summary>
    internal JsonNode ToWire() => _model.DeepClone();
}

/// <summary>The auth connection a webhook tool authenticates with. Built with the static constructors.</summary>
public sealed class AuthConnection
{
    private readonly JsonObject _model;

    private AuthConnection(JsonObject model) => _model = model;

    /// <summary>An auth connection from the workspace's store, by id.</summary>
    public static AuthConnection Id(string authConnectionId) =>
        new(new JsonObject { ["auth_connection_id"] = authConnectionId });

    /// <summary>An environment variable of type auth connection, by label, resolved for the current environment.</summary>
    public static AuthConnection EnvVar(string label) => new(new JsonObject { ["env_var_label"] = label });

    /// <summary>The auth connection in API wire format.</summary>
    internal JsonObject ToWire() => (JsonObject)_model.DeepClone();
}
