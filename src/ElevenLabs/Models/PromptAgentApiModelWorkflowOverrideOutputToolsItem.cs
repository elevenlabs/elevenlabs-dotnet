// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(PromptAgentApiModelWorkflowOverrideOutputToolsItem.JsonConverter))]
[Serializable]
public record PromptAgentApiModelWorkflowOverrideOutputToolsItem
{
    internal PromptAgentApiModelWorkflowOverrideOutputToolsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelWorkflowOverrideOutputToolsItem with <see cref="PromptAgentApiModelWorkflowOverrideOutputToolsItem.ApiIntegrationWebhook"/>.
    /// </summary>
    public PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.ApiIntegrationWebhook value
    )
    {
        Type = "api_integration_webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelWorkflowOverrideOutputToolsItem with <see cref="PromptAgentApiModelWorkflowOverrideOutputToolsItem.Client"/>.
    /// </summary>
    public PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Client value
    )
    {
        Type = "client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelWorkflowOverrideOutputToolsItem with <see cref="PromptAgentApiModelWorkflowOverrideOutputToolsItem.Mcp"/>.
    /// </summary>
    public PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Mcp value
    )
    {
        Type = "mcp";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelWorkflowOverrideOutputToolsItem with <see cref="PromptAgentApiModelWorkflowOverrideOutputToolsItem.Smb"/>.
    /// </summary>
    public PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Smb value
    )
    {
        Type = "smb";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelWorkflowOverrideOutputToolsItem with <see cref="PromptAgentApiModelWorkflowOverrideOutputToolsItem.System"/>.
    /// </summary>
    public PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.System value
    )
    {
        Type = "system";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PromptAgentApiModelWorkflowOverrideOutputToolsItem with <see cref="PromptAgentApiModelWorkflowOverrideOutputToolsItem.Webhook"/>.
    /// </summary>
    public PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Webhook value
    )
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
    /// Returns the value as a <see cref="global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput"/> if <see cref="Type"/> is 'api_integration_webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'api_integration_webhook'.</exception>
    public global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput AsApiIntegrationWebhook() =>
        IsApiIntegrationWebhook
            ? (global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelWorkflowOverrideOutputToolsItem.Type is not 'api_integration_webhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ClientToolConfigOutput"/> if <see cref="Type"/> is 'client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client'.</exception>
    public global::ElevenLabs.ClientToolConfigOutput AsClient() =>
        IsClient
            ? (global::ElevenLabs.ClientToolConfigOutput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelWorkflowOverrideOutputToolsItem.Type is not 'client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.McpToolConfigOutput"/> if <see cref="Type"/> is 'mcp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mcp'.</exception>
    public global::ElevenLabs.McpToolConfigOutput AsMcp() =>
        IsMcp
            ? (global::ElevenLabs.McpToolConfigOutput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelWorkflowOverrideOutputToolsItem.Type is not 'mcp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SmbToolConfig"/> if <see cref="Type"/> is 'smb', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'smb'.</exception>
    public global::ElevenLabs.SmbToolConfig AsSmb() =>
        IsSmb
            ? (global::ElevenLabs.SmbToolConfig)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelWorkflowOverrideOutputToolsItem.Type is not 'smb'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SystemToolConfigOutput"/> if <see cref="Type"/> is 'system', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'system'.</exception>
    public global::ElevenLabs.SystemToolConfigOutput AsSystem() =>
        IsSystem
            ? (global::ElevenLabs.SystemToolConfigOutput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelWorkflowOverrideOutputToolsItem.Type is not 'system'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WebhookToolConfigOutput"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.WebhookToolConfigOutput AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.WebhookToolConfigOutput)Value!
            : throw new global::System.Exception(
                "PromptAgentApiModelWorkflowOverrideOutputToolsItem.Type is not 'webhook'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput, T> onApiIntegrationWebhook,
        Func<global::ElevenLabs.ClientToolConfigOutput, T> onClient,
        Func<global::ElevenLabs.McpToolConfigOutput, T> onMcp,
        Func<global::ElevenLabs.SmbToolConfig, T> onSmb,
        Func<global::ElevenLabs.SystemToolConfigOutput, T> onSystem,
        Func<global::ElevenLabs.WebhookToolConfigOutput, T> onWebhook,
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
        Action<global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput> onApiIntegrationWebhook,
        Action<global::ElevenLabs.ClientToolConfigOutput> onClient,
        Action<global::ElevenLabs.McpToolConfigOutput> onMcp,
        Action<global::ElevenLabs.SmbToolConfig> onSmb,
        Action<global::ElevenLabs.SystemToolConfigOutput> onSystem,
        Action<global::ElevenLabs.WebhookToolConfigOutput> onWebhook,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsApiIntegrationWebhook(
        out global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput? value
    )
    {
        if (Type == "api_integration_webhook")
        {
            value = (global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ClientToolConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsClient(out global::ElevenLabs.ClientToolConfigOutput? value)
    {
        if (Type == "client")
        {
            value = (global::ElevenLabs.ClientToolConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.McpToolConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsMcp(out global::ElevenLabs.McpToolConfigOutput? value)
    {
        if (Type == "mcp")
        {
            value = (global::ElevenLabs.McpToolConfigOutput)Value!;
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SystemToolConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSystem(out global::ElevenLabs.SystemToolConfigOutput? value)
    {
        if (Type == "system")
        {
            value = (global::ElevenLabs.SystemToolConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WebhookToolConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsWebhook(out global::ElevenLabs.WebhookToolConfigOutput? value)
    {
        if (Type == "webhook")
        {
            value = (global::ElevenLabs.WebhookToolConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.ApiIntegrationWebhook value
    ) => new(value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Client value
    ) => new(value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Mcp value
    ) => new(value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Smb value
    ) => new(value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.System value
    ) => new(value);

    public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem(
        PromptAgentApiModelWorkflowOverrideOutputToolsItem.Webhook value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PromptAgentApiModelWorkflowOverrideOutputToolsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PromptAgentApiModelWorkflowOverrideOutputToolsItem).IsAssignableFrom(
                typeToConvert
            );

        public override PromptAgentApiModelWorkflowOverrideOutputToolsItem Read(
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
                    json.Deserialize<global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput"
                        ),
                "client" => json.Deserialize<global::ElevenLabs.ClientToolConfigOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ClientToolConfigOutput"
                    ),
                "mcp" => json.Deserialize<global::ElevenLabs.McpToolConfigOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.McpToolConfigOutput"
                    ),
                "smb" => json.Deserialize<global::ElevenLabs.SmbToolConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SmbToolConfig"
                    ),
                "system" => json.Deserialize<global::ElevenLabs.SystemToolConfigOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SystemToolConfigOutput"
                    ),
                "webhook" => json.Deserialize<global::ElevenLabs.WebhookToolConfigOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WebhookToolConfigOutput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new PromptAgentApiModelWorkflowOverrideOutputToolsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptAgentApiModelWorkflowOverrideOutputToolsItem value,
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

        public override PromptAgentApiModelWorkflowOverrideOutputToolsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PromptAgentApiModelWorkflowOverrideOutputToolsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PromptAgentApiModelWorkflowOverrideOutputToolsItem value,
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
        public ApiIntegrationWebhook(global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem.ApiIntegrationWebhook(
            global::ElevenLabs.ApiIntegrationWebhookToolConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for client
    /// </summary>
    [Serializable]
    public struct Client
    {
        public Client(global::ElevenLabs.ClientToolConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ClientToolConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem.Client(
            global::ElevenLabs.ClientToolConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mcp
    /// </summary>
    [Serializable]
    public struct Mcp
    {
        public Mcp(global::ElevenLabs.McpToolConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.McpToolConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem.Mcp(
            global::ElevenLabs.McpToolConfigOutput value
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

        public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem.Smb(
            global::ElevenLabs.SmbToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for system
    /// </summary>
    [Serializable]
    public struct System
    {
        public System(global::ElevenLabs.SystemToolConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SystemToolConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem.System(
            global::ElevenLabs.SystemToolConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for webhook
    /// </summary>
    [Serializable]
    public struct Webhook
    {
        public Webhook(global::ElevenLabs.WebhookToolConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WebhookToolConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PromptAgentApiModelWorkflowOverrideOutputToolsItem.Webhook(
            global::ElevenLabs.WebhookToolConfigOutput value
        ) => new(value);
    }
}
