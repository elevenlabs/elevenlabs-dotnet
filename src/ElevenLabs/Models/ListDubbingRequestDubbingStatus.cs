using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>What state the dub is currently in.</summary>
[JsonConverter(typeof(ListDubbingRequestDubbingStatus.ListDubbingRequestDubbingStatusSerializer))]
[Serializable]
public readonly record struct ListDubbingRequestDubbingStatus : IStringEnum
{
    public static readonly ListDubbingRequestDubbingStatus Dubbing = new(Values.Dubbing);

    public static readonly ListDubbingRequestDubbingStatus Dubbed = new(Values.Dubbed);

    public static readonly ListDubbingRequestDubbingStatus Failed = new(Values.Failed);

    public ListDubbingRequestDubbingStatus(string value)
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
    public static ListDubbingRequestDubbingStatus FromCustom(string value)
    {
        return new ListDubbingRequestDubbingStatus(value);
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

    public static bool operator ==(ListDubbingRequestDubbingStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestDubbingStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestDubbingStatus value) => value.Value;

    public static explicit operator ListDubbingRequestDubbingStatus(string value) => new(value);

    internal class ListDubbingRequestDubbingStatusSerializer
        : JsonConverter<ListDubbingRequestDubbingStatus>
    {
        public override ListDubbingRequestDubbingStatus Read(
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
            return new ListDubbingRequestDubbingStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestDubbingStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestDubbingStatus ReadAsPropertyName(
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
            return new ListDubbingRequestDubbingStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestDubbingStatus value,
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
        public const string Dubbing = "dubbing";

        public const string Dubbed = "dubbed";

        public const string Failed = "failed";
    }
}
