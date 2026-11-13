using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(CreatifyAuroraRequestModelId.CreatifyAuroraRequestModelIdSerializer))]
[Serializable]
public readonly record struct CreatifyAuroraRequestModelId : IStringEnum
{
    public static readonly CreatifyAuroraRequestModelId CreatifyAurora = new(Values.CreatifyAurora);

    public CreatifyAuroraRequestModelId(string value)
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
    public static CreatifyAuroraRequestModelId FromCustom(string value)
    {
        return new CreatifyAuroraRequestModelId(value);
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

    public static bool operator ==(CreatifyAuroraRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatifyAuroraRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatifyAuroraRequestModelId value) => value.Value;

    public static explicit operator CreatifyAuroraRequestModelId(string value) => new(value);

    internal class CreatifyAuroraRequestModelIdSerializer
        : JsonConverter<CreatifyAuroraRequestModelId>
    {
        public override CreatifyAuroraRequestModelId Read(
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
            return new CreatifyAuroraRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatifyAuroraRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatifyAuroraRequestModelId ReadAsPropertyName(
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
            return new CreatifyAuroraRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatifyAuroraRequestModelId value,
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
        public const string CreatifyAurora = "creatify-aurora";
    }
}
