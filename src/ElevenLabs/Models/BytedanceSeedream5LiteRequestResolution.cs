using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(
    typeof(BytedanceSeedream5LiteRequestResolution.BytedanceSeedream5LiteRequestResolutionSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedream5LiteRequestResolution : IStringEnum
{
    public static readonly BytedanceSeedream5LiteRequestResolution TwoK = new(Values.TwoK);

    public static readonly BytedanceSeedream5LiteRequestResolution ThreeK = new(Values.ThreeK);

    public BytedanceSeedream5LiteRequestResolution(string value)
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
    public static BytedanceSeedream5LiteRequestResolution FromCustom(string value)
    {
        return new BytedanceSeedream5LiteRequestResolution(value);
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

    public static bool operator ==(BytedanceSeedream5LiteRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedream5LiteRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedream5LiteRequestResolution value) =>
        value.Value;

    public static explicit operator BytedanceSeedream5LiteRequestResolution(string value) =>
        new(value);

    internal class BytedanceSeedream5LiteRequestResolutionSerializer
        : JsonConverter<BytedanceSeedream5LiteRequestResolution>
    {
        public override BytedanceSeedream5LiteRequestResolution Read(
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
            return new BytedanceSeedream5LiteRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedream5LiteRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedream5LiteRequestResolution ReadAsPropertyName(
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
            return new BytedanceSeedream5LiteRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedream5LiteRequestResolution value,
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
        public const string TwoK = "2K";

        public const string ThreeK = "3K";
    }
}
