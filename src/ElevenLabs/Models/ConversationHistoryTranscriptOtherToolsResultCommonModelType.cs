using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptOtherToolsResultCommonModelType.ConversationHistoryTranscriptOtherToolsResultCommonModelTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptOtherToolsResultCommonModelType
    : IStringEnum
{
    public static readonly ConversationHistoryTranscriptOtherToolsResultCommonModelType Client =
        new(Values.Client);

    public static readonly ConversationHistoryTranscriptOtherToolsResultCommonModelType Webhook =
        new(Values.Webhook);

    public static readonly ConversationHistoryTranscriptOtherToolsResultCommonModelType Mcp = new(
        Values.Mcp
    );

    public static readonly ConversationHistoryTranscriptOtherToolsResultCommonModelType Code = new(
        Values.Code
    );

    public ConversationHistoryTranscriptOtherToolsResultCommonModelType(string value)
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
    public static ConversationHistoryTranscriptOtherToolsResultCommonModelType FromCustom(
        string value
    )
    {
        return new ConversationHistoryTranscriptOtherToolsResultCommonModelType(value);
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
        ConversationHistoryTranscriptOtherToolsResultCommonModelType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptOtherToolsResultCommonModelType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistoryTranscriptOtherToolsResultCommonModelType value
    ) => value.Value;

    public static explicit operator ConversationHistoryTranscriptOtherToolsResultCommonModelType(
        string value
    ) => new(value);

    internal class ConversationHistoryTranscriptOtherToolsResultCommonModelTypeSerializer
        : JsonConverter<ConversationHistoryTranscriptOtherToolsResultCommonModelType>
    {
        public override ConversationHistoryTranscriptOtherToolsResultCommonModelType Read(
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
            return new ConversationHistoryTranscriptOtherToolsResultCommonModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptOtherToolsResultCommonModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptOtherToolsResultCommonModelType ReadAsPropertyName(
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
            return new ConversationHistoryTranscriptOtherToolsResultCommonModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptOtherToolsResultCommonModelType value,
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
        public const string Client = "client";

        public const string Webhook = "webhook";

        public const string Mcp = "mcp";

        public const string Code = "code";
    }
}
