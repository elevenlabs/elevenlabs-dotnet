using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(
    typeof(BytedanceSeedance2FastRequestModelId.BytedanceSeedance2FastRequestModelIdSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedance2FastRequestModelId : IStringEnum
{
    public static readonly BytedanceSeedance2FastRequestModelId BytedanceSeedanceV2Fast = new(
        Values.BytedanceSeedanceV2Fast
    );

    public BytedanceSeedance2FastRequestModelId(string value)
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
    public static BytedanceSeedance2FastRequestModelId FromCustom(string value)
    {
        return new BytedanceSeedance2FastRequestModelId(value);
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

    public static bool operator ==(BytedanceSeedance2FastRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedance2FastRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedance2FastRequestModelId value) =>
        value.Value;

    public static explicit operator BytedanceSeedance2FastRequestModelId(string value) =>
        new(value);

    internal class BytedanceSeedance2FastRequestModelIdSerializer
        : JsonConverter<BytedanceSeedance2FastRequestModelId>
    {
        public override BytedanceSeedance2FastRequestModelId Read(
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
            return new BytedanceSeedance2FastRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedance2FastRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedance2FastRequestModelId ReadAsPropertyName(
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
            return new BytedanceSeedance2FastRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedance2FastRequestModelId value,
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
        public const string BytedanceSeedanceV2Fast = "bytedance-seedance-v2-fast";
    }
}
