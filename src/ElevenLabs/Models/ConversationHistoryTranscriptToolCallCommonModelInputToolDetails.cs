// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.JsonConverter)
)]
[Serializable]
public record ConversationHistoryTranscriptToolCallCommonModelInputToolDetails
{
    internal ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        string type,
        object? value
    )
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelInputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.ApiIntegrationWebhook"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.ApiIntegrationWebhook value
    )
    {
        Type = "api_integration_webhook";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelInputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Client"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Client value
    )
    {
        Type = "client";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelInputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Mcp"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Mcp value
    )
    {
        Type = "mcp";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptToolCallCommonModelInputToolDetails with <see cref="ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Webhook"/>.
    /// </summary>
    public ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Webhook value
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
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput"/> if <see cref="Type"/> is 'api_integration_webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'api_integration_webhook'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput AsApiIntegrationWebhook() =>
        IsApiIntegrationWebhook
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput)
                Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Type is not 'api_integration_webhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails"/> if <see cref="Type"/> is 'client', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'client'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails AsClient() =>
        IsClient
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallClientDetails)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Type is not 'client'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails"/> if <see cref="Type"/> is 'mcp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mcp'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails AsMcp() =>
        IsMcp
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallMcpDetails)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Type is not 'mcp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails"/> if <see cref="Type"/> is 'webhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'webhook'.</exception>
    public global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails AsWebhook() =>
        IsWebhook
            ? (global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Type is not 'webhook'"
            );

    public T Match<T>(
        Func<
            global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput,
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
        Action<global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput> onApiIntegrationWebhook,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsApiIntegrationWebhook(
        out global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput? value
    )
    {
        if (Type == "api_integration_webhook")
        {
            value =
                (global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput)
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

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.ApiIntegrationWebhook value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Client value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Mcp value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
        ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Webhook value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ConversationHistoryTranscriptToolCallCommonModelInputToolDetails>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationHistoryTranscriptToolCallCommonModelInputToolDetails).IsAssignableFrom(
                typeToConvert
            );

        public override ConversationHistoryTranscriptToolCallCommonModelInputToolDetails Read(
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
                    json.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput"
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
            return new ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallCommonModelInputToolDetails value,
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

        public override ConversationHistoryTranscriptToolCallCommonModelInputToolDetails ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ConversationHistoryTranscriptToolCallCommonModelInputToolDetails(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallCommonModelInputToolDetails value,
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
            global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.ApiIntegrationWebhook(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsInput value
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

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Client(
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

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Mcp(
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

        public static implicit operator ConversationHistoryTranscriptToolCallCommonModelInputToolDetails.Webhook(
            global::ElevenLabs.ConversationHistoryTranscriptToolCallWebhookDetails value
        ) => new(value);
    }
}
