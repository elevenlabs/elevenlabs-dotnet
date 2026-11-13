using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Flows;

[JsonConverter(typeof(ListVideoRequestStatus.ListVideoRequestStatusSerializer))]
[Serializable]
public readonly record struct ListVideoRequestStatus : IStringEnum
{
    public static readonly ListVideoRequestStatus Pending = new(Values.Pending);

    public static readonly ListVideoRequestStatus Generating = new(Values.Generating);

    public static readonly ListVideoRequestStatus Completed = new(Values.Completed);

    public static readonly ListVideoRequestStatus Failed = new(Values.Failed);

    public ListVideoRequestStatus(string value)
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
    public static ListVideoRequestStatus FromCustom(string value)
    {
        return new ListVideoRequestStatus(value);
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

    public static bool operator ==(ListVideoRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListVideoRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListVideoRequestStatus value) => value.Value;

    public static explicit operator ListVideoRequestStatus(string value) => new(value);

    internal class ListVideoRequestStatusSerializer : JsonConverter<ListVideoRequestStatus>
    {
        public override ListVideoRequestStatus Read(
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
            return new ListVideoRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListVideoRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListVideoRequestStatus ReadAsPropertyName(
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
            return new ListVideoRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListVideoRequestStatus value,
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
