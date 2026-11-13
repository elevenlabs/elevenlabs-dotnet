using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetConversationSummaryResponseModelStatus.GetConversationSummaryResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct GetConversationSummaryResponseModelStatus : IStringEnum
{
    public static readonly GetConversationSummaryResponseModelStatus Initiated = new(
        Values.Initiated
    );

    public static readonly GetConversationSummaryResponseModelStatus InProgress = new(
        Values.InProgress
    );

    public static readonly GetConversationSummaryResponseModelStatus Processing = new(
        Values.Processing
    );

    public static readonly GetConversationSummaryResponseModelStatus Done = new(Values.Done);

    public static readonly GetConversationSummaryResponseModelStatus Failed = new(Values.Failed);

    public GetConversationSummaryResponseModelStatus(string value)
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
    public static GetConversationSummaryResponseModelStatus FromCustom(string value)
    {
        return new GetConversationSummaryResponseModelStatus(value);
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
        GetConversationSummaryResponseModelStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetConversationSummaryResponseModelStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetConversationSummaryResponseModelStatus value) =>
        value.Value;

    public static explicit operator GetConversationSummaryResponseModelStatus(string value) =>
        new(value);

    internal class GetConversationSummaryResponseModelStatusSerializer
        : JsonConverter<GetConversationSummaryResponseModelStatus>
    {
        public override GetConversationSummaryResponseModelStatus Read(
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
            return new GetConversationSummaryResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetConversationSummaryResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetConversationSummaryResponseModelStatus ReadAsPropertyName(
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
            return new GetConversationSummaryResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetConversationSummaryResponseModelStatus value,
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
