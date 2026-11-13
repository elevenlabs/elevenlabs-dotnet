using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstllmNodeOutputType.AstllmNodeOutputTypeSerializer))]
[Serializable]
public readonly record struct AstllmNodeOutputType : IStringEnum
{
    public static readonly AstllmNodeOutputType Llm = new(Values.Llm);

    public AstllmNodeOutputType(string value)
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
    public static AstllmNodeOutputType FromCustom(string value)
    {
        return new AstllmNodeOutputType(value);
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

    public static bool operator ==(AstllmNodeOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstllmNodeOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstllmNodeOutputType value) => value.Value;

    public static explicit operator AstllmNodeOutputType(string value) => new(value);

    internal class AstllmNodeOutputTypeSerializer : JsonConverter<AstllmNodeOutputType>
    {
        public override AstllmNodeOutputType Read(
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
            return new AstllmNodeOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstllmNodeOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstllmNodeOutputType ReadAsPropertyName(
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
            return new AstllmNodeOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstllmNodeOutputType value,
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
        public const string Llm = "llm";
    }
}
