using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>What a promotion discounts: the service price or add-on prices.</summary>
[JsonConverter(typeof(PromotionTarget.PromotionTargetSerializer))]
[Serializable]
public readonly record struct PromotionTarget : IStringEnum
{
    public static readonly PromotionTarget Service = new(Values.Service);

    public static readonly PromotionTarget AddOn = new(Values.AddOn);

    public PromotionTarget(string value)
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
    public static PromotionTarget FromCustom(string value)
    {
        return new PromotionTarget(value);
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

    public static bool operator ==(PromotionTarget value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PromotionTarget value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PromotionTarget value) => value.Value;

    public static explicit operator PromotionTarget(string value) => new(value);

    internal class PromotionTargetSerializer : JsonConverter<PromotionTarget>
    {
        public override PromotionTarget Read(
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
            return new PromotionTarget(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromotionTarget value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PromotionTarget ReadAsPropertyName(
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
            return new PromotionTarget(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PromotionTarget value,
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
        public const string Service = "service";

        public const string AddOn = "add_on";
    }
}
