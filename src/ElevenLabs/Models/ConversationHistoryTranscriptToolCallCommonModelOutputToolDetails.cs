// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.JsonConverter)
)]
[Serializable]
public record ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails
{
    internal ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        string type,
        object? value
    )
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.ApiIntegrationWebhook"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.ApiIntegrationWebhook value
    )
    {
        Type = "api_integration_webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Client"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Client value
    )
    {
        Type = "client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Mcp"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Mcp value
    )
    {
        Type = "mcp";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Webhook"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Webhook value
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
    /// Returns true if <see cref="Type"/> is "webhook"
    /// </summary>
    public bool IsWebhook => Type == "webhook";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput"/> if <see cref="Type"/> is 'api_integration_webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'api_integration_webhook'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput AsApiIntegrationWebhook() =>
        IsApiIntegrationWebhook
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput)
                Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Type is not 'api_integration_webhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails"/> if <see cref="Type"/> is 'client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails AsClient() =>
        IsClient
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Type is not 'client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails"/> if <see cref="Type"/> is 'mcp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mcp'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails AsMcp() =>
        IsMcp
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Type is not 'mcp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Type is not 'webhook'"
            );

    public T Match<T>(
        Func<
            global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput,
            T
        > onApiIntegrationWebhook,
        Func<global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails, T> onClient,
        Func<global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails, T> onMcp,
        Func<global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails, T> onWebhook,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "api_integration_webhook" => onApiIntegrationWebhook(AsApiIntegrationWebhook()),
            "client" => onClient(AsClient()),
            "mcp" => onMcp(AsMcp()),
            "webhook" => onWebhook(AsWebhook()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput> onApiIntegrationWebhook,
        Action<global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails> onClient,
        Action<global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails> onMcp,
        Action<global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails> onWebhook,
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
            case "webhook":
                onWebhook(AsWebhook());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsApiIntegrationWebhook(
        out global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput? value
    )
    {
        if (Type == "api_integration_webhook")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails"/> and returns true if successful.
    /// </summary>
    public bool TryAsClient(
        out global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails? value
    )
    {
        if (Type == "client")
        {
            value = (global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails"/> and returns true if successful.
    /// </summary>
    public bool TryAsMcp(
        out global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails? value
    )
    {
        if (Type == "mcp")
        {
            value = (global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails"/> and returns true if successful.
    /// </summary>
    public bool TryAsWebhook(
        out global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails? value
    )
    {
        if (Type == "webhook")
        {
            value = (global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.ApiIntegrationWebhook value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Client value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Mcp value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Webhook value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails).IsAssignableFrom(
                typeToConvert
            );

        public override ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails Read(
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
                    json.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput"
                        ),
                "client" =>
                    json.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails"
                        ),
                "mcp" =>
                    json.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails"
                        ),
                "webhook" =>
                    json.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails value,
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
                    "webhook" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails value,
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
        public ApiIntegrationWebhook(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.ApiIntegrationWebhook(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for client
    /// </summary>
    [Serializable]
    public struct Client
    {
        public Client(global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Client(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mcp
    /// </summary>
    [Serializable]
    public struct Mcp
    {
        public Mcp(global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Mcp(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for webhook
    /// </summary>
    [Serializable]
    public struct Webhook
    {
        public Webhook(global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelOutputToolDetails.Webhook(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails value
        ) => new(value);
    }
}
