using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType.ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType
    : IStringEnum
{
    public static readonly ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType ApiIntegrationWebhook =
        new(Values.ApiIntegrationWebhook);

    public ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType FromCustom(
        string value
    )
    {
        return new ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType(
            value
        );
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType value
    ) => value.Value;

    public static explicit operator ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType(
        string value
    ) => new(value);

    internal class ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputTypeSerializer
        : JsonConverter<ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType>
    {
        public override ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallApiIntegrationWebhookDetailsOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ApiIntegrationWebhook = "api_integration_webhook";
    }
}
