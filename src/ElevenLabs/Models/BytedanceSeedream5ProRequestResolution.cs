using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(
    typeof(BytedanceSeedream5ProRequestResolution.BytedanceSeedream5ProRequestResolutionSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedream5ProRequestResolution : IStringEnum
{
    public static readonly BytedanceSeedream5ProRequestResolution OneK = new(Values.OneK);

    public static readonly BytedanceSeedream5ProRequestResolution TwoK = new(Values.TwoK);

    public BytedanceSeedream5ProRequestResolution(string value)
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
    public static BytedanceSeedream5ProRequestResolution FromCustom(string value)
    {
        return new BytedanceSeedream5ProRequestResolution(value);
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

    public static bool operator ==(BytedanceSeedream5ProRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedream5ProRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedream5ProRequestResolution value) =>
        value.Value;

    public static explicit operator BytedanceSeedream5ProRequestResolution(string value) =>
        new(value);

    internal class BytedanceSeedream5ProRequestResolutionSerializer
        : JsonConverter<BytedanceSeedream5ProRequestResolution>
    {
        public override BytedanceSeedream5ProRequestResolution Read(
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
            return new BytedanceSeedream5ProRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedream5ProRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedream5ProRequestResolution ReadAsPropertyName(
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
            return new BytedanceSeedream5ProRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedream5ProRequestResolution value,
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
        public const string OneK = "1K";

        public const string TwoK = "2K";
    }
}
