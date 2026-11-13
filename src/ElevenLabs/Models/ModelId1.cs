using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Dubbing;

[JsonConverter(typeof(ModelId1.ModelId1Serializer))]
[Serializable]
public readonly record struct ModelId1 : IStringEnum
{
    public static readonly ModelId1 DubbingV1 = new(Values.DubbingV1);

    public static readonly ModelId1 DubbingV2 = new(Values.DubbingV2);

    public ModelId1(string value)
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
    public static ModelId1 FromCustom(string value)
    {
        return new ModelId1(value);
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

    public static bool operator ==(ModelId1 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(ModelId1 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(ModelId1 value) => value.Value;

    public static explicit operator ModelId1(string value) => new(value);

    internal class ModelId1Serializer : JsonConverter<ModelId1>
    {
        public override ModelId1 Read(
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
            return new ModelId1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ModelId1 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ModelId1 ReadAsPropertyName(
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
            return new ModelId1(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ModelId1 value,
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
        public const string DubbingV1 = "dubbing_v1";

        public const string DubbingV2 = "dubbing_v2";
    }
}
