using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CharacterRefreshPeriod.CharacterRefreshPeriodSerializer))]
[Serializable]
public readonly record struct CharacterRefreshPeriod : IStringEnum
{
    public static readonly CharacterRefreshPeriod MonthlyPeriod = new(Values.MonthlyPeriod);

    public static readonly CharacterRefreshPeriod ThreeMonthPeriod = new(Values.ThreeMonthPeriod);

    public static readonly CharacterRefreshPeriod SixMonthPeriod = new(Values.SixMonthPeriod);

    public static readonly CharacterRefreshPeriod AnnualPeriod = new(Values.AnnualPeriod);

    public CharacterRefreshPeriod(string value)
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
    public static CharacterRefreshPeriod FromCustom(string value)
    {
        return new CharacterRefreshPeriod(value);
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

    public static bool operator ==(CharacterRefreshPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CharacterRefreshPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CharacterRefreshPeriod value) => value.Value;

    public static explicit operator CharacterRefreshPeriod(string value) => new(value);

    internal class CharacterRefreshPeriodSerializer : JsonConverter<CharacterRefreshPeriod>
    {
        public override CharacterRefreshPeriod Read(
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
            return new CharacterRefreshPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CharacterRefreshPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CharacterRefreshPeriod ReadAsPropertyName(
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
            return new CharacterRefreshPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CharacterRefreshPeriod value,
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
        public const string MonthlyPeriod = "monthly_period";

        public const string ThreeMonthPeriod = "3_month_period";

        public const string SixMonthPeriod = "6_month_period";

        public const string AnnualPeriod = "annual_period";
    }
}
