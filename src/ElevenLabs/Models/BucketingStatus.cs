using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BucketingStatus.BucketingStatusSerializer))]
[Serializable]
public readonly record struct BucketingStatus : IStringEnum
{
    public static readonly BucketingStatus Pending = new(Values.Pending);

    public static readonly BucketingStatus Completed = new(Values.Completed);

    public static readonly BucketingStatus Failed = new(Values.Failed);

    public BucketingStatus(string value)
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
    public static BucketingStatus FromCustom(string value)
    {
        return new BucketingStatus(value);
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

    public static bool operator ==(BucketingStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BucketingStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BucketingStatus value) => value.Value;

    public static explicit operator BucketingStatus(string value) => new(value);

    internal class BucketingStatusSerializer : JsonConverter<BucketingStatus>
    {
        public override BucketingStatus Read(
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
            return new BucketingStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BucketingStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BucketingStatus ReadAsPropertyName(
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
            return new BucketingStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BucketingStatus value,
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

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
