using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListDubbingRequestDubbingStatusesItem.ListDubbingRequestDubbingStatusesItemSerializer)
)]
[Serializable]
public readonly record struct ListDubbingRequestDubbingStatusesItem : IStringEnum
{
    public static readonly ListDubbingRequestDubbingStatusesItem Queued = new(Values.Queued);

    public static readonly ListDubbingRequestDubbingStatusesItem Preparing = new(Values.Preparing);

    public static readonly ListDubbingRequestDubbingStatusesItem Dubbing = new(Values.Dubbing);

    public static readonly ListDubbingRequestDubbingStatusesItem Dubbed = new(Values.Dubbed);

    public static readonly ListDubbingRequestDubbingStatusesItem Failed = new(Values.Failed);

    public ListDubbingRequestDubbingStatusesItem(string value)
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
    public static ListDubbingRequestDubbingStatusesItem FromCustom(string value)
    {
        return new ListDubbingRequestDubbingStatusesItem(value);
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

    public static bool operator ==(ListDubbingRequestDubbingStatusesItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestDubbingStatusesItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestDubbingStatusesItem value) =>
        value.Value;

    public static explicit operator ListDubbingRequestDubbingStatusesItem(string value) =>
        new(value);

    internal class ListDubbingRequestDubbingStatusesItemSerializer
        : JsonConverter<ListDubbingRequestDubbingStatusesItem>
    {
        public override ListDubbingRequestDubbingStatusesItem Read(
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
            return new ListDubbingRequestDubbingStatusesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestDubbingStatusesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestDubbingStatusesItem ReadAsPropertyName(
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
            return new ListDubbingRequestDubbingStatusesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestDubbingStatusesItem value,
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
        public const string Queued = "queued";

        public const string Preparing = "preparing";

        public const string Dubbing = "dubbing";

        public const string Dubbed = "dubbed";

        public const string Failed = "failed";
    }
}
