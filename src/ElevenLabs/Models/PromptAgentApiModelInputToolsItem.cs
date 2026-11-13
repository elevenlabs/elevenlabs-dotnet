// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(PromptAgentApiModelInputToolsItem.JsonConverter))]
[Serializable]
public record PromptAgentApiModelInputToolsItem
{
    internal PromptAgentApiModelInputToolsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelInputToolsItem with <see cref="PromptAgentApiModelInputToolsItem.ApiIntegrationWebhook"/>.
    /// </summary>
    public PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.ApiIntegrationWebhook value
    )
    {
        Type = "api_integration_webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelInputToolsItem with <see cref="PromptAgentApiModelInputToolsItem.Client"/>.
    /// </summary>
    public PromptAgentApiModelInputToolsItem(PromptAgentApiModelInputToolsItem.Client value)
    {
        Type = "client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelInputToolsItem with <see cref="PromptAgentApiModelInputToolsItem.Mcp"/>.
    /// </summary>
    public PromptAgentApiModelInputToolsItem(PromptAgentApiModelInputToolsItem.Mcp value)
    {
        Type = "mcp";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelInputToolsItem with <see cref="PromptAgentApiModelInputToolsItem.Smb"/>.
    /// </summary>
    public PromptAgentApiModelInputToolsItem(PromptAgentApiModelInputToolsItem.Smb value)
    {
        Type = "smb";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelInputToolsItem with <see cref="PromptAgentApiModelInputToolsItem.System"/>.
    /// </summary>
    public PromptAgentApiModelInputToolsItem(PromptAgentApiModelInputToolsItem.System value)
    {
        Type = "system";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelInputToolsItem with <see cref="PromptAgentApiModelInputToolsItem.Webhook"/>.
    /// </summary>
    public PromptAgentApiModelInputToolsItem(PromptAgentApiModelInputToolsItem.Webhook value)
    {
        Type = "webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "api_integration_webhook"
    /// </summary>
    public bool IsApiIntegrationWebhook => Type == "api_integration_webhook";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "client"
    /// </summary>
    public bool IsClient => Type == "client";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mcp"
    /// </summary>
    public bool IsMcp => Type == "mcp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "smb"
    /// </summary>
    public bool IsSmb => Type == "smb";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "system"
    /// </summary>
    public bool IsSystem => Type == "system";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "webhook"
    /// </summary>
    public bool IsWebhook => Type == "webhook";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ApiIntegrationWebhookToolConfigInput"/> if <see cref="Type"/> is 'api_integration_webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'api_integration_webhook'.</exception>
    public global::ElevenLabs.ApiIntegrationWebhookToolConfigInput AsApiIntegrationWebhook() =>
        IsApiIntegrationWebhook
            ? (global::ElevenLabs.ApiIntegrationWebhookToolConfigInput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelInputToolsItem.Type is not 'api_integration_webhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ClientToolConfigInput"/> if <see cref="Type"/> is 'client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client'.</exception>
    public global::ElevenLabs.ClientToolConfigInput AsClient() =>
        IsClient
            ? (global::ElevenLabs.ClientToolConfigInput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelInputToolsItem.Type is not 'client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.McpToolConfigInput"/> if <see cref="Type"/> is 'mcp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mcp'.</exception>
    public global::ElevenLabs.McpToolConfigInput AsMcp() =>
        IsMcp
            ? (global::ElevenLabs.McpToolConfigInput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelInputToolsItem.Type is not 'mcp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SmbToolConfig"/> if <see cref="Type"/> is 'smb', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'smb'.</exception>
    public global::ElevenLabs.SmbToolConfig AsSmb() =>
        IsSmb
            ? (global::ElevenLabs.SmbToolConfig)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelInputToolsItem.Type is not 'smb'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SystemToolConfigInput"/> if <see cref="Type"/> is 'system', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'system'.</exception>
    public global::ElevenLabs.SystemToolConfigInput AsSystem() =>
        IsSystem
            ? (global::ElevenLabs.SystemToolConfigInput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelInputToolsItem.Type is not 'system'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WebhookToolConfigInput"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.WebhookToolConfigInput AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.WebhookToolConfigInput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelInputToolsItem.Type is not 'webhook'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ApiIntegrationWebhookToolConfigInput, T> onApiIntegrationWebhook,
        Func<global::ElevenLabs.ClientToolConfigInput, T> onClient,
        Func<global::ElevenLabs.McpToolConfigInput, T> onMcp,
        Func<global::ElevenLabs.SmbToolConfig, T> onSmb,
        Func<global::ElevenLabs.SystemToolConfigInput, T> onSystem,
        Func<global::ElevenLabs.WebhookToolConfigInput, T> onWebhook,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "api_integration_webhook" => onApiIntegrationWebhook(AsApiIntegrationWebhook()),
            "client" => onClient(AsClient()),
            "mcp" => onMcp(AsMcp()),
            "smb" => onSmb(AsSmb()),
            "system" => onSystem(AsSystem()),
            "webhook" => onWebhook(AsWebhook()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ApiIntegrationWebhookToolConfigInput> onApiIntegrationWebhook,
        Action<global::ElevenLabs.ClientToolConfigInput> onClient,
        Action<global::ElevenLabs.McpToolConfigInput> onMcp,
        Action<global::ElevenLabs.SmbToolConfig> onSmb,
        Action<global::ElevenLabs.SystemToolConfigInput> onSystem,
        Action<global::ElevenLabs.WebhookToolConfigInput> onWebhook,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "api_integration_webhook":
                onApiIntegrationWebhook(AsApiIntegrationWebhook());
                break;
            case "client":
                onClient(AsClient());
                break;
            case "mcp":
                onMcp(AsMcp());
                break;
            case "smb":
                onSmb(AsSmb());
                break;
            case "system":
                onSystem(AsSystem());
                break;
            case "webhook":
                onWebhook(AsWebhook());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ApiIntegrationWebhookToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsApiIntegrationWebhook(
        out global::ElevenLabs.ApiIntegrationWebhookToolConfigInput? value
    )
    {
        if (Type == "api_integration_webhook")
        {
            value = (global::ElevenLabs.ApiIntegrationWebhookToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ClientToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsClient(out global::ElevenLabs.ClientToolConfigInput? value)
    {
        if (Type == "client")
        {
            value = (global::ElevenLabs.ClientToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.McpToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsMcp(out global::ElevenLabs.McpToolConfigInput? value)
    {
        if (Type == "mcp")
        {
            value = (global::ElevenLabs.McpToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SmbToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsSmb(out global::ElevenLabs.SmbToolConfig? value)
    {
        if (Type == "smb")
        {
            value = (global::ElevenLabs.SmbToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SystemToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSystem(out global::ElevenLabs.SystemToolConfigInput? value)
    {
        if (Type == "system")
        {
            value = (global::ElevenLabs.SystemToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WebhookToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsWebhook(out global::ElevenLabs.WebhookToolConfigInput? value)
    {
        if (Type == "webhook")
        {
            value = (global::ElevenLabs.WebhookToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.ApiIntegrationWebhook value
    ) => new(value);

    public static implicit operator PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.Client value
    ) => new(value);

    public static implicit operator PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.Mcp value
    ) => new(value);

    public static implicit operator PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.Smb value
    ) => new(value);

    public static implicit operator PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.System value
    ) => new(value);

    public static implicit operator PromptAgentApiModelInputToolsItem(
        PromptAgentApiModelInputToolsItem.Webhook value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PromptAgentApiModelInputToolsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PromptAgentApiModelInputToolsItem).IsAssignableFrom(typeToConvert);

        public override PromptAgentApiModelInputToolsItem Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "api_integration_webhook" =>
                    json.Deserialize<global::ElevenLabs.ApiIntegrationWebhookToolConfigInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ApiIntegrationWebhookToolConfigInput"
                        ),
                "client" => json.Deserialize<global::ElevenLabs.ClientToolConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ClientToolConfigInput"
                    ),
                "mcp" => json.Deserialize<global::ElevenLabs.McpToolConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.McpToolConfigInput"
                    ),
                "smb" => json.Deserialize<global::ElevenLabs.SmbToolConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SmbToolConfig"
                    ),
                "system" => json.Deserialize<global::ElevenLabs.SystemToolConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SystemToolConfigInput"
                    ),
                "webhook" => json.Deserialize<global::ElevenLabs.WebhookToolConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WebhookToolConfigInput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new PromptAgentApiModelInputToolsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptAgentApiModelInputToolsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "api_integration_webhook" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "client" => JsonSerializer.SerializeToNode(value.Value, options),
                    "mcp" => JsonSerializer.SerializeToNode(value.Value, options),
                    "smb" => JsonSerializer.SerializeToNode(value.Value, options),
                    "system" => JsonSerializer.SerializeToNode(value.Value, options),
                    "webhook" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override PromptAgentApiModelInputToolsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PromptAgentApiModelInputToolsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PromptAgentApiModelInputToolsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for api_integration_webhook
    /// </summary>
    [Serializable]
    public struct ApiIntegrationWebhook
    {
        public ApiIntegrationWebhook(global::ElevenLabs.ApiIntegrationWebhookToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ApiIntegrationWebhookToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelInputToolsItem.ApiIntegrationWebhook(
            global::ElevenLabs.ApiIntegrationWebhookToolConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for client
    /// </summary>
    [Serializable]
    public struct Client
    {
        public Client(global::ElevenLabs.ClientToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ClientToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelInputToolsItem.Client(
            global::ElevenLabs.ClientToolConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mcp
    /// </summary>
    [Serializable]
    public struct Mcp
    {
        public Mcp(global::ElevenLabs.McpToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.McpToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelInputToolsItem.Mcp(
            global::ElevenLabs.McpToolConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for smb
    /// </summary>
    [Serializable]
    public struct Smb
    {
        public Smb(global::ElevenLabs.SmbToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SmbToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelInputToolsItem.Smb(
            global::ElevenLabs.SmbToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for system
    /// </summary>
    [Serializable]
    public struct System
    {
        public System(global::ElevenLabs.SystemToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SystemToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelInputToolsItem.System(
            global::ElevenLabs.SystemToolConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for webhook
    /// </summary>
    [Serializable]
    public struct Webhook
    {
        public Webhook(global::ElevenLabs.WebhookToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WebhookToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelInputToolsItem.Webhook(
            global::ElevenLabs.WebhookToolConfigInput value
        ) => new(value);
    }
}
