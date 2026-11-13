using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType
    : IStringEnum
{
    public static readonly ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType ApiIntegrationWebhook =
        new(Values.ApiIntegrationWebhook);

    public ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType(
        string value
    )
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
    public static ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType FromCustom(
        string value
    )
    {
        return new ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType(
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
        ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType value
    ) => value.Value;

    public static explicit operator ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType(
        string value
    ) => new(value);

    internal class ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputTypeSerializer
        : JsonConverter<ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType>
    {
        public override ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType Read(
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
            return new ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType ReadAsPropertyName(
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
            return new ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputType value,
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
