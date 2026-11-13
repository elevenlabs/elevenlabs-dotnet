using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ColumnUnit.ColumnUnitSerializer))]
[Serializable]
public readonly record struct ColumnUnit : IStringEnum
{
    public static readonly ColumnUnit Ms = new(Values.Ms);

    public static readonly ColumnUnit S = new(Values.S);

    public static readonly ColumnUnit Min = new(Values.Min);

    public static readonly ColumnUnit Duration = new(Values.Duration);

    public static readonly ColumnUnit Credits = new(Values.Credits);

    public static readonly ColumnUnit Usd = new(Values.Usd);

    public static readonly ColumnUnit Eur = new(Values.Eur);

    public static readonly ColumnUnit Inr = new(Values.Inr);

    public static readonly ColumnUnit Pln = new(Values.Pln);

    public static readonly ColumnUnit Gbp = new(Values.Gbp);

    public static readonly ColumnUnit Ratio = new(Values.Ratio);

    public static readonly ColumnUnit Rating = new(Values.Rating);

    public ColumnUnit(string value)
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
    public static ColumnUnit FromCustom(string value)
    {
        return new ColumnUnit(value);
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

    public static bool operator ==(ColumnUnit value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(ColumnUnit value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ColumnUnit value) => value.Value;

    public static explicit operator ColumnUnit(string value) => new(value);

    internal class ColumnUnitSerializer : JsonConverter<ColumnUnit>
    {
        public override ColumnUnit Read(
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
            return new ColumnUnit(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ColumnUnit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ColumnUnit ReadAsPropertyName(
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
            return new ColumnUnit(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ColumnUnit value,
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
        public const string Ms = "ms";

        public const string S = "s";

        public const string Min = "min";

        public const string Duration = "duration";

        public const string Credits = "credits";

        public const string Usd = "usd";

        public const string Eur = "eur";

        public const string Inr = "inr";

        public const string Pln = "pln";

        public const string Gbp = "gbp";

        public const string Ratio = "ratio";

        public const string Rating = "rating";
    }
}
