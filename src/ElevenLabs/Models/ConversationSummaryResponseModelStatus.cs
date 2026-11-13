using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationSummaryResponseModelStatus.ConversationSummaryResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct ConversationSummaryResponseModelStatus : IStringEnum
{
    public static readonly ConversationSummaryResponseModelStatus Initiated = new(Values.Initiated);

    public static readonly ConversationSummaryResponseModelStatus InProgress = new(
        Values.InProgress
    );

    public static readonly ConversationSummaryResponseModelStatus Processing = new(
        Values.Processing
    );

    public static readonly ConversationSummaryResponseModelStatus Done = new(Values.Done);

    public static readonly ConversationSummaryResponseModelStatus Failed = new(Values.Failed);

    public ConversationSummaryResponseModelStatus(string value)
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
    public static ConversationSummaryResponseModelStatus FromCustom(string value)
    {
        return new ConversationSummaryResponseModelStatus(value);
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

    public static bool operator ==(ConversationSummaryResponseModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationSummaryResponseModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationSummaryResponseModelStatus value) =>
        value.Value;

    public static explicit operator ConversationSummaryResponseModelStatus(string value) =>
        new(value);

    internal class ConversationSummaryResponseModelStatusSerializer
        : JsonConverter<ConversationSummaryResponseModelStatus>
    {
        public override ConversationSummaryResponseModelStatus Read(
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
            return new ConversationSummaryResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationSummaryResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationSummaryResponseModelStatus ReadAsPropertyName(
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
            return new ConversationSummaryResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationSummaryResponseModelStatus value,
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
        public const string Initiated = "initiated";

        public const string InProgress = "in-progress";

        public const string Processing = "processing";

        public const string Done = "done";

        public const string Failed = "failed";
    }
}
