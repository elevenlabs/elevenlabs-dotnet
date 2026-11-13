using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetConversationResponseModelStatus.GetConversationResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct GetConversationResponseModelStatus : IStringEnum
{
    public static readonly GetConversationResponseModelStatus Initiated = new(Values.Initiated);

    public static readonly GetConversationResponseModelStatus InProgress = new(Values.InProgress);

    public static readonly GetConversationResponseModelStatus Processing = new(Values.Processing);

    public static readonly GetConversationResponseModelStatus Done = new(Values.Done);

    public static readonly GetConversationResponseModelStatus Failed = new(Values.Failed);

    public GetConversationResponseModelStatus(string value)
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
    public static GetConversationResponseModelStatus FromCustom(string value)
    {
        return new GetConversationResponseModelStatus(value);
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

    public static bool operator ==(GetConversationResponseModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetConversationResponseModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetConversationResponseModelStatus value) => value.Value;

    public static explicit operator GetConversationResponseModelStatus(string value) => new(value);

    internal class GetConversationResponseModelStatusSerializer
        : JsonConverter<GetConversationResponseModelStatus>
    {
        public override GetConversationResponseModelStatus Read(
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
            return new GetConversationResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetConversationResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetConversationResponseModelStatus ReadAsPropertyName(
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
            return new GetConversationResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetConversationResponseModelStatus value,
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
