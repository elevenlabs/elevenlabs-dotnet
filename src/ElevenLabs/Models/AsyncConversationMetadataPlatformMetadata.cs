// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AsyncConversationMetadataPlatformMetadata.JsonConverter))]
[Serializable]
public record AsyncConversationMetadataPlatformMetadata
{
    internal AsyncConversationMetadataPlatformMetadata(string type, object? value)
    {
        ConversationInitiationSource = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AsyncConversationMetadataPlatformMetadata with <see cref="AsyncConversationMetadataPlatformMetadata.PlainIntegration"/>.
    /// </summary>
    public AsyncConversationMetadataPlatformMetadata(
        AsyncConversationMetadataPlatformMetadata.PlainIntegration value
    )
    {
        ConversationInitiationSource = "plain_integration";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AsyncConversationMetadataPlatformMetadata with <see cref="AsyncConversationMetadataPlatformMetadata.ZendeskIntegration"/>.
    /// </summary>
    public AsyncConversationMetadataPlatformMetadata(
        AsyncConversationMetadataPlatformMetadata.ZendeskIntegration value
    )
    {
        ConversationInitiationSource = "zendesk_integration";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("conversation_initiation_source")]
    public string ConversationInitiationSource { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="ConversationInitiationSource"/> is "plain_integration"
    /// </summary>
    public bool IsPlainIntegration => ConversationInitiationSource == "plain_integration";

    /// <summary>
    /// Returns true if <see cref="ConversationInitiationSource"/> is "zendesk_integration"
    /// </summary>
    public bool IsZendeskIntegration => ConversationInitiationSource == "zendesk_integration";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PlainPlatformMetadata"/> if <see cref="ConversationInitiationSource"/> is 'plain_integration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationInitiationSource"/> is not 'plain_integration'.</exception>
    public global::ElevenLabs.PlainPlatformMetadata AsPlainIntegration() =>
        IsPlainIntegration
            ? (global::ElevenLabs.PlainPlatformMetadata)Value!
            : throw new global::System.Exception(
                "AsyncConversationMetadataPlatformMetadata.ConversationInitiationSource is not 'plain_integration'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ZendeskPlatformMetadata"/> if <see cref="ConversationInitiationSource"/> is 'zendesk_integration', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationInitiationSource"/> is not 'zendesk_integration'.</exception>
    public global::ElevenLabs.ZendeskPlatformMetadata AsZendeskIntegration() =>
        IsZendeskIntegration
            ? (global::ElevenLabs.ZendeskPlatformMetadata)Value!
            : throw new global::System.Exception(
                "AsyncConversationMetadataPlatformMetadata.ConversationInitiationSource is not 'zendesk_integration'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PlainPlatformMetadata, T> onPlainIntegration,
        Func<global::ElevenLabs.ZendeskPlatformMetadata, T> onZendeskIntegration,
        Func<string, object?, T> onUnknown_
    )
    {
        return ConversationInitiationSource switch
        {
            "plain_integration" => onPlainIntegration(AsPlainIntegration()),
            "zendesk_integration" => onZendeskIntegration(AsZendeskIntegration()),
            _ => onUnknown_(ConversationInitiationSource, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PlainPlatformMetadata> onPlainIntegration,
        Action<global::ElevenLabs.ZendeskPlatformMetadata> onZendeskIntegration,
        Action<string, object?> onUnknown_
    )
    {
        switch (ConversationInitiationSource)
        {
            case "plain_integration":
                onPlainIntegration(AsPlainIntegration());
                break;
            case "zendesk_integration":
                onZendeskIntegration(AsZendeskIntegration());
                break;
            default:
                onUnknown_(ConversationInitiationSource, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PlainPlatformMetadata"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlainIntegration(out global::ElevenLabs.PlainPlatformMetadata? value)
    {
        if (ConversationInitiationSource == "plain_integration")
        {
            value = (global::ElevenLabs.PlainPlatformMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ZendeskPlatformMetadata"/> and returns true if successful.
    /// </summary>
    public bool TryAsZendeskIntegration(out global::ElevenLabs.ZendeskPlatformMetadata? value)
    {
        if (ConversationInitiationSource == "zendesk_integration")
        {
            value = (global::ElevenLabs.ZendeskPlatformMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AsyncConversationMetadataPlatformMetadata(
        AsyncConversationMetadataPlatformMetadata.PlainIntegration value
    ) => new(value);

    public static implicit operator AsyncConversationMetadataPlatformMetadata(
        AsyncConversationMetadataPlatformMetadata.ZendeskIntegration value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AsyncConversationMetadataPlatformMetadata>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AsyncConversationMetadataPlatformMetadata).IsAssignableFrom(typeToConvert);

        public override AsyncConversationMetadataPlatformMetadata Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (
                !json.TryGetProperty("conversation_initiation_source", out var discriminatorElement)
            )
            {
                throw new JsonException(
                    "Missing discriminator property 'conversation_initiation_source'"
                );
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException(
                        "Discriminator property 'conversation_initiation_source' is null"
                    );
                }

                throw new JsonException(
                    $"Discriminator property 'conversation_initiation_source' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException(
                    "Discriminator property 'conversation_initiation_source' is null"
                );

            var value = discriminator switch
            {
                "plain_integration" => json.Deserialize<global::ElevenLabs.PlainPlatformMetadata?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PlainPlatformMetadata"
                    ),
                "zendesk_integration" =>
                    json.Deserialize<global::ElevenLabs.ZendeskPlatformMetadata?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ZendeskPlatformMetadata"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new AsyncConversationMetadataPlatformMetadata(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AsyncConversationMetadataPlatformMetadata value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.ConversationInitiationSource switch
                {
                    "plain_integration" => JsonSerializer.SerializeToNode(value.Value, options),
                    "zendesk_integration" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["conversation_initiation_source"] = value.ConversationInitiationSource;
            json.WriteTo(writer, options);
        }

        public override AsyncConversationMetadataPlatformMetadata ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AsyncConversationMetadataPlatformMetadata(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AsyncConversationMetadataPlatformMetadata value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.ConversationInitiationSource);
        }
    }

    /// <summary>
    /// Discriminated union type for plain_integration
    /// </summary>
    [Serializable]
    public struct PlainIntegration
    {
        public PlainIntegration(global::ElevenLabs.PlainPlatformMetadata value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PlainPlatformMetadata Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AsyncConversationMetadataPlatformMetadata.PlainIntegration(
            global::ElevenLabs.PlainPlatformMetadata value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for zendesk_integration
    /// </summary>
    [Serializable]
    public struct ZendeskIntegration
    {
        public ZendeskIntegration(global::ElevenLabs.ZendeskPlatformMetadata value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ZendeskPlatformMetadata Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AsyncConversationMetadataPlatformMetadata.ZendeskIntegration(
            global::ElevenLabs.ZendeskPlatformMetadata value
        ) => new(value);
    }
}
