using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Flows;

[JsonConverter(typeof(ListTextToSpeechRequestStatus.ListTextToSpeechRequestStatusSerializer))]
[Serializable]
public readonly record struct ListTextToSpeechRequestStatus : IStringEnum
{
    public static readonly ListTextToSpeechRequestStatus Pending = new(Values.Pending);

    public static readonly ListTextToSpeechRequestStatus Generating = new(Values.Generating);

    public static readonly ListTextToSpeechRequestStatus Completed = new(Values.Completed);

    public static readonly ListTextToSpeechRequestStatus Failed = new(Values.Failed);

    public ListTextToSpeechRequestStatus(string value)
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
    public static ListTextToSpeechRequestStatus FromCustom(string value)
    {
        return new ListTextToSpeechRequestStatus(value);
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

    public static bool operator ==(ListTextToSpeechRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListTextToSpeechRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListTextToSpeechRequestStatus value) => value.Value;

    public static explicit operator ListTextToSpeechRequestStatus(string value) => new(value);

    internal class ListTextToSpeechRequestStatusSerializer
        : JsonConverter<ListTextToSpeechRequestStatus>
    {
        public override ListTextToSpeechRequestStatus Read(
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
            return new ListTextToSpeechRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListTextToSpeechRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListTextToSpeechRequestStatus ReadAsPropertyName(
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
            return new ListTextToSpeechRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListTextToSpeechRequestStatus value,
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
        public const string Pending = "pending";

        public const string Generating = "generating";

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
