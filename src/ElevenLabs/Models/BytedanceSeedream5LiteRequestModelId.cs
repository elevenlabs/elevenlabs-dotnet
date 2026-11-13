using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(
    typeof(BytedanceSeedream5LiteRequestModelId.BytedanceSeedream5LiteRequestModelIdSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedream5LiteRequestModelId : IStringEnum
{
    public static readonly BytedanceSeedream5LiteRequestModelId BytedanceSeedream5Lite = new(
        Values.BytedanceSeedream5Lite
    );

    public BytedanceSeedream5LiteRequestModelId(string value)
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
    public static BytedanceSeedream5LiteRequestModelId FromCustom(string value)
    {
        return new BytedanceSeedream5LiteRequestModelId(value);
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

    public static bool operator ==(BytedanceSeedream5LiteRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedream5LiteRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedream5LiteRequestModelId value) =>
        value.Value;

    public static explicit operator BytedanceSeedream5LiteRequestModelId(string value) =>
        new(value);

    internal class BytedanceSeedream5LiteRequestModelIdSerializer
        : JsonConverter<BytedanceSeedream5LiteRequestModelId>
    {
        public override BytedanceSeedream5LiteRequestModelId Read(
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
            return new BytedanceSeedream5LiteRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedream5LiteRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedream5LiteRequestModelId ReadAsPropertyName(
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
            return new BytedanceSeedream5LiteRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedream5LiteRequestModelId value,
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
        public const string BytedanceSeedream5Lite = "bytedance-seedream-5-lite";
    }
}
