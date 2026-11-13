using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Request-time processing tier for a model.
///
/// STANDARD: default price and throughput.
/// FAST: pays a per-token price premium for higher throughput / lower latency.
///     See OpenAI's fast mode: https://openai.com/api-fast-mode/
/// </summary>
[JsonConverter(typeof(LlmServiceTier.LlmServiceTierSerializer))]
[Serializable]
public readonly record struct LlmServiceTier : IStringEnum
{
    public static readonly LlmServiceTier Standard = new(Values.Standard);

    public static readonly LlmServiceTier Fast = new(Values.Fast);

    public LlmServiceTier(string value)
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
    public static LlmServiceTier FromCustom(string value)
    {
        return new LlmServiceTier(value);
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

    public static bool operator ==(LlmServiceTier value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LlmServiceTier value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LlmServiceTier value) => value.Value;

    public static explicit operator LlmServiceTier(string value) => new(value);

    internal class LlmServiceTierSerializer : JsonConverter<LlmServiceTier>
    {
        public override LlmServiceTier Read(
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
            return new LlmServiceTier(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LlmServiceTier value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LlmServiceTier ReadAsPropertyName(
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
            return new LlmServiceTier(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LlmServiceTier value,
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
        public const string Standard = "standard";

        public const string Fast = "fast";
    }
}
