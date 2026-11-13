using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(GuardrailType.GuardrailTypeSerializer))]
[Serializable]
public readonly record struct GuardrailType : IStringEnum
{
    public static readonly GuardrailType Custom = new(Values.Custom);

    public static readonly GuardrailType PromptInjection = new(Values.PromptInjection);

    public static readonly GuardrailType SelfHarmIntent = new(Values.SelfHarmIntent);

    public static readonly GuardrailType ViolenceGraphic = new(Values.ViolenceGraphic);

    public static readonly GuardrailType Sexual = new(Values.Sexual);

    public static readonly GuardrailType Violence = new(Values.Violence);

    public static readonly GuardrailType Harassment = new(Values.Harassment);

    public static readonly GuardrailType SexualMinors = new(Values.SexualMinors);

    public static readonly GuardrailType SelfHarm = new(Values.SelfHarm);

    public static readonly GuardrailType SelfHarmInstructions = new(Values.SelfHarmInstructions);

    public static readonly GuardrailType HarassmentThreatening = new(Values.HarassmentThreatening);

    public static readonly GuardrailType Hate = new(Values.Hate);

    public static readonly GuardrailType HateThreatening = new(Values.HateThreatening);

    public static readonly GuardrailType Profanity = new(Values.Profanity);

    public static readonly GuardrailType ReligionOrPolitics = new(Values.ReligionOrPolitics);

    public static readonly GuardrailType MedicalAndLegal = new(Values.MedicalAndLegal);

    public static readonly GuardrailType Guardrail = new(Values.Guardrail);

    public GuardrailType(string value)
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
    public static GuardrailType FromCustom(string value)
    {
        return new GuardrailType(value);
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

    public static bool operator ==(GuardrailType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardrailType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardrailType value) => value.Value;

    public static explicit operator GuardrailType(string value) => new(value);

    internal class GuardrailTypeSerializer : JsonConverter<GuardrailType>
    {
        public override GuardrailType Read(
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
            return new GuardrailType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardrailType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardrailType ReadAsPropertyName(
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
            return new GuardrailType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardrailType value,
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
        public const string Custom = "custom";

        public const string PromptInjection = "prompt_injection";

        public const string SelfHarmIntent = "self_harm_intent";

        public const string ViolenceGraphic = "violence_graphic";

        public const string Sexual = "sexual";

        public const string Violence = "violence";

        public const string Harassment = "harassment";

        public const string SexualMinors = "sexual_minors";

        public const string SelfHarm = "self_harm";

        public const string SelfHarmInstructions = "self_harm_instructions";

        public const string HarassmentThreatening = "harassment_threatening";

        public const string Hate = "hate";

        public const string HateThreatening = "hate_threatening";

        public const string Profanity = "profanity";

        public const string ReligionOrPolitics = "religion_or_politics";

        public const string MedicalAndLegal = "medical_and_legal";

        public const string Guardrail = "guardrail";
    }
}
