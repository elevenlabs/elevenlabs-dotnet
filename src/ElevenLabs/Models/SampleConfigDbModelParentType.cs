using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SampleConfigDbModelParentType.SampleConfigDbModelParentTypeSerializer))]
[Serializable]
public readonly record struct SampleConfigDbModelParentType : IStringEnum
{
    public static readonly SampleConfigDbModelParentType Read = new(Values.Read);

    public static readonly SampleConfigDbModelParentType Collection = new(Values.Collection);

    public SampleConfigDbModelParentType(string value)
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
    public static SampleConfigDbModelParentType FromCustom(string value)
    {
        return new SampleConfigDbModelParentType(value);
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

    public static bool operator ==(SampleConfigDbModelParentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SampleConfigDbModelParentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SampleConfigDbModelParentType value) => value.Value;

    public static explicit operator SampleConfigDbModelParentType(string value) => new(value);

    internal class SampleConfigDbModelParentTypeSerializer
        : JsonConverter<SampleConfigDbModelParentType>
    {
        public override SampleConfigDbModelParentType Read(
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
            return new SampleConfigDbModelParentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SampleConfigDbModelParentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SampleConfigDbModelParentType ReadAsPropertyName(
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
            return new SampleConfigDbModelParentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SampleConfigDbModelParentType value,
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
        public const string Read = "read";

        public const string Collection = "collection";
    }
}
