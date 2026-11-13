using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(
    typeof(BytedanceSeedream5ProRequestModelId.BytedanceSeedream5ProRequestModelIdSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedream5ProRequestModelId : IStringEnum
{
    public static readonly BytedanceSeedream5ProRequestModelId BytedanceSeedream5Pro = new(
        Values.BytedanceSeedream5Pro
    );

    public BytedanceSeedream5ProRequestModelId(string value)
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
    public static BytedanceSeedream5ProRequestModelId FromCustom(string value)
    {
        return new BytedanceSeedream5ProRequestModelId(value);
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

    public static bool operator ==(BytedanceSeedream5ProRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedream5ProRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedream5ProRequestModelId value) =>
        value.Value;

    public static explicit operator BytedanceSeedream5ProRequestModelId(string value) => new(value);

    internal class BytedanceSeedream5ProRequestModelIdSerializer
        : JsonConverter<BytedanceSeedream5ProRequestModelId>
    {
        public override BytedanceSeedream5ProRequestModelId Read(
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
            return new BytedanceSeedream5ProRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedream5ProRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedream5ProRequestModelId ReadAsPropertyName(
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
            return new BytedanceSeedream5ProRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedream5ProRequestModelId value,
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
        public const string BytedanceSeedream5Pro = "bytedance-seedream-5-pro";
    }
}
