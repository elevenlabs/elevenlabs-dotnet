using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(BytedanceSeedance2RequestModelId.BytedanceSeedance2RequestModelIdSerializer))]
[Serializable]
public readonly record struct BytedanceSeedance2RequestModelId : IStringEnum
{
    public static readonly BytedanceSeedance2RequestModelId BytedanceSeedanceV2 = new(
        Values.BytedanceSeedanceV2
    );

    public BytedanceSeedance2RequestModelId(string value)
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
    public static BytedanceSeedance2RequestModelId FromCustom(string value)
    {
        return new BytedanceSeedance2RequestModelId(value);
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

    public static bool operator ==(BytedanceSeedance2RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedance2RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedance2RequestModelId value) => value.Value;

    public static explicit operator BytedanceSeedance2RequestModelId(string value) => new(value);

    internal class BytedanceSeedance2RequestModelIdSerializer
        : JsonConverter<BytedanceSeedance2RequestModelId>
    {
        public override BytedanceSeedance2RequestModelId Read(
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
            return new BytedanceSeedance2RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedance2RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedance2RequestModelId ReadAsPropertyName(
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
            return new BytedanceSeedance2RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedance2RequestModelId value,
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
        public const string BytedanceSeedanceV2 = "bytedance-seedance-v2";
    }
}
