// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Configuration for the tool</summary>
[JsonConverter(typeof(ToolRequestModelToolConfig.JsonConverter))]
[Serializable]
public record ToolRequestModelToolConfig
{
    internal ToolRequestModelToolConfig(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ToolRequestModelToolConfig with <see cref="ToolRequestModelToolConfig.Client"/>.
    /// </summary>
    public ToolRequestModelToolConfig(ToolRequestModelToolConfig.Client value)
    {
        Type = "client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ToolRequestModelToolConfig with <see cref="ToolRequestModelToolConfig.Mcp"/>.
    /// </summary>
    public ToolRequestModelToolConfig(ToolRequestModelToolConfig.Mcp value)
    {
        Type = "mcp";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ToolRequestModelToolConfig with <see cref="ToolRequestModelToolConfig.System"/>.
    /// </summary>
    public ToolRequestModelToolConfig(ToolRequestModelToolConfig.System value)
    {
        Type = "system";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ToolRequestModelToolConfig with <see cref="ToolRequestModelToolConfig.Webhook"/>.
    /// </summary>
    public ToolRequestModelToolConfig(ToolRequestModelToolConfig.Webhook value)
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
    /// Returns true if <see cref="Type"/> is "client"
    /// </summary>
    public bool IsClient => Type == "client";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mcp"
    /// </summary>
    public bool IsMcp => Type == "mcp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "system"
    /// </summary>
    public bool IsSystem => Type == "system";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "webhook"
    /// </summary>
    public bool IsWebhook => Type == "webhook";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ClientToolConfigInput"/> if <see cref="Type"/> is 'client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client'.</exception>
    public global::ElevenLabs.ClientToolConfigInput AsClient() =>
        IsClient
            ? (global::ElevenLabs.ClientToolConfigInput)Value!
            : throw new global::System.Exception("ToolRequestModelToolConfig.Type is not 'client'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.McpToolConfigInput"/> if <see cref="Type"/> is 'mcp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mcp'.</exception>
    public global::ElevenLabs.McpToolConfigInput AsMcp() =>
        IsMcp
            ? (global::ElevenLabs.McpToolConfigInput)Value!
            : throw new global::System.Exception("ToolRequestModelToolConfig.Type is not 'mcp'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SystemToolConfigInput"/> if <see cref="Type"/> is 'system', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'system'.</exception>
    public global::ElevenLabs.SystemToolConfigInput AsSystem() =>
        IsSystem
            ? (global::ElevenLabs.SystemToolConfigInput)Value!
            : throw new global::System.Exception("ToolRequestModelToolConfig.Type is not 'system'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WebhookToolConfigInput"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.WebhookToolConfigInput AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.WebhookToolConfigInput)Value!
            : throw new global::System.Exception(
                "ToolRequestModelToolConfig.Type is not 'webhook'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ClientToolConfigInput, T> onClient,
        Func<global::ElevenLabs.McpToolConfigInput, T> onMcp,
        Func<global::ElevenLabs.SystemToolConfigInput, T> onSystem,
        Func<global::ElevenLabs.WebhookToolConfigInput, T> onWebhook,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "client" => onClient(AsClient()),
            "mcp" => onMcp(AsMcp()),
            "system" => onSystem(AsSystem()),
            "webhook" => onWebhook(AsWebhook()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ClientToolConfigInput> onClient,
        Action<global::ElevenLabs.McpToolConfigInput> onMcp,
        Action<global::ElevenLabs.SystemToolConfigInput> onSystem,
        Action<global::ElevenLabs.WebhookToolConfigInput> onWebhook,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "client":
                onClient(AsClient());
                break;
            case "mcp":
                onMcp(AsMcp());
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

    public static implicit operator ToolRequestModelToolConfig(
        ToolRequestModelToolConfig.Client value
    ) => new(value);

    public static implicit operator ToolRequestModelToolConfig(
        ToolRequestModelToolConfig.Mcp value
    ) => new(value);

    public static implicit operator ToolRequestModelToolConfig(
        ToolRequestModelToolConfig.System value
    ) => new(value);

    public static implicit operator ToolRequestModelToolConfig(
        ToolRequestModelToolConfig.Webhook value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ToolRequestModelToolConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ToolRequestModelToolConfig).IsAssignableFrom(typeToConvert);

        public override ToolRequestModelToolConfig Read(
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
                "client" => json.Deserialize<global::ElevenLabs.ClientToolConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ClientToolConfigInput"
                    ),
                "mcp" => json.Deserialize<global::ElevenLabs.McpToolConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.McpToolConfigInput"
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
            return new ToolRequestModelToolConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolRequestModelToolConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "client" => JsonSerializer.SerializeToNode(value.Value, options),
                    "mcp" => JsonSerializer.SerializeToNode(value.Value, options),
                    "system" => JsonSerializer.SerializeToNode(value.Value, options),
                    "webhook" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ToolRequestModelToolConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ToolRequestModelToolConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolRequestModelToolConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
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

        public static implicit operator ToolRequestModelToolConfig.Client(
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

        public static implicit operator ToolRequestModelToolConfig.Mcp(
            global::ElevenLabs.McpToolConfigInput value
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

        public static implicit operator ToolRequestModelToolConfig.System(
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

        public static implicit operator ToolRequestModelToolConfig.Webhook(
            global::ElevenLabs.WebhookToolConfigInput value
        ) => new(value);
    }
}
