using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SlaMetric.SlaMetricSerializer))]
[Serializable]
public readonly record struct SlaMetric : IStringEnum
{
    public static readonly SlaMetric FirstResponse = new(Values.FirstResponse);

    public static readonly SlaMetric Resolution = new(Values.Resolution);

    public static readonly SlaMetric NextResponse = new(Values.NextResponse);

    public SlaMetric(string value)
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
    public static SlaMetric FromCustom(string value)
    {
        return new SlaMetric(value);
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

    public static bool operator ==(SlaMetric value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(SlaMetric value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(SlaMetric value) => value.Value;

    public static explicit operator SlaMetric(string value) => new(value);

    internal class SlaMetricSerializer : JsonConverter<SlaMetric>
    {
        public override SlaMetric Read(
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
            return new SlaMetric(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SlaMetric value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SlaMetric ReadAsPropertyName(
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
            return new SlaMetric(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SlaMetric value,
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
        public const string FirstResponse = "first_response";

        public const string Resolution = "resolution";

        public const string NextResponse = "next_response";
    }
}
