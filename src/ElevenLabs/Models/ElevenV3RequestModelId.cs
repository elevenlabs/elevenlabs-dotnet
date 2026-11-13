using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(ElevenV3RequestModelId.ElevenV3RequestModelIdSerializer))]
[Serializable]
public readonly record struct ElevenV3RequestModelId : IStringEnum
{
    public static readonly ElevenV3RequestModelId ElevenV3 = new(Values.ElevenV3);

    public ElevenV3RequestModelId(string value)
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
    public static ElevenV3RequestModelId FromCustom(string value)
    {
        return new ElevenV3RequestModelId(value);
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

    public static bool operator ==(ElevenV3RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ElevenV3RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ElevenV3RequestModelId value) => value.Value;

    public static explicit operator ElevenV3RequestModelId(string value) => new(value);

    internal class ElevenV3RequestModelIdSerializer : JsonConverter<ElevenV3RequestModelId>
    {
        public override ElevenV3RequestModelId Read(
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
            return new ElevenV3RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ElevenV3RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ElevenV3RequestModelId ReadAsPropertyName(
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
            return new ElevenV3RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ElevenV3RequestModelId value,
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
        public const string ElevenV3 = "eleven_v3";
    }
}
