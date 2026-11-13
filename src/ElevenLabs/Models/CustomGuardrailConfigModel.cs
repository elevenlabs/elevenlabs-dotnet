using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>LLM model to use for custom guardrail evaluation</summary>
[JsonConverter(typeof(CustomGuardrailConfigModel.CustomGuardrailConfigModelSerializer))]
[Serializable]
public readonly record struct CustomGuardrailConfigModel : IStringEnum
{
    public static readonly CustomGuardrailConfigModel Gemini25FlashLite = new(
        Values.Gemini25FlashLite
    );

    public static readonly CustomGuardrailConfigModel Gemini25Flash = new(Values.Gemini25Flash);

    public static readonly CustomGuardrailConfigModel Gemini31FlashLite = new(
        Values.Gemini31FlashLite
    );

    public static readonly CustomGuardrailConfigModel Gemini35Flash = new(Values.Gemini35Flash);

    public static readonly CustomGuardrailConfigModel ClaudeHaiku45 = new(Values.ClaudeHaiku45);

    public static readonly CustomGuardrailConfigModel ClaudeSonnet46 = new(Values.ClaudeSonnet46);

    public static readonly CustomGuardrailConfigModel Gpt54Nano = new(Values.Gpt54Nano);

    public static readonly CustomGuardrailConfigModel Gpt54Mini = new(Values.Gpt54Mini);

    public CustomGuardrailConfigModel(string value)
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
    public static CustomGuardrailConfigModel FromCustom(string value)
    {
        return new CustomGuardrailConfigModel(value);
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

    public static bool operator ==(CustomGuardrailConfigModel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomGuardrailConfigModel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomGuardrailConfigModel value) => value.Value;

    public static explicit operator CustomGuardrailConfigModel(string value) => new(value);

    internal class CustomGuardrailConfigModelSerializer : JsonConverter<CustomGuardrailConfigModel>
    {
        public override CustomGuardrailConfigModel Read(
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
            return new CustomGuardrailConfigModel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomGuardrailConfigModel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomGuardrailConfigModel ReadAsPropertyName(
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
            return new CustomGuardrailConfigModel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomGuardrailConfigModel value,
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
        public const string Gemini25FlashLite = "gemini-2.5-flash-lite";

        public const string Gemini25Flash = "gemini-2.5-flash";

        public const string Gemini31FlashLite = "gemini-3.1-flash-lite";

        public const string Gemini35Flash = "gemini-3.5-flash";

        public const string ClaudeHaiku45 = "claude-haiku-4-5";

        public const string ClaudeSonnet46 = "claude-sonnet-4-6";

        public const string Gpt54Nano = "gpt-5.4-nano";

        public const string Gpt54Mini = "gpt-5.4-mini";
    }
}
