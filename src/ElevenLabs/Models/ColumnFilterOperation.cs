using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ColumnFilterOperation.ColumnFilterOperationSerializer))]
[Serializable]
public readonly record struct ColumnFilterOperation : IStringEnum
{
    public static readonly ColumnFilterOperation In = new(Values.In);

    public static readonly ColumnFilterOperation NotIn = new(Values.NotIn);

    public static readonly ColumnFilterOperation Le = new(Values.Le);

    public static readonly ColumnFilterOperation Ge = new(Values.Ge);

    public static readonly ColumnFilterOperation Lt = new(Values.Lt);

    public static readonly ColumnFilterOperation Gt = new(Values.Gt);

    public static readonly ColumnFilterOperation Eq = new(Values.Eq);

    public static readonly ColumnFilterOperation Neq = new(Values.Neq);

    public ColumnFilterOperation(string value)
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
    public static ColumnFilterOperation FromCustom(string value)
    {
        return new ColumnFilterOperation(value);
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

    public static bool operator ==(ColumnFilterOperation value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ColumnFilterOperation value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ColumnFilterOperation value) => value.Value;

    public static explicit operator ColumnFilterOperation(string value) => new(value);

    internal class ColumnFilterOperationSerializer : JsonConverter<ColumnFilterOperation>
    {
        public override ColumnFilterOperation Read(
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
            return new ColumnFilterOperation(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ColumnFilterOperation value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ColumnFilterOperation ReadAsPropertyName(
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
            return new ColumnFilterOperation(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ColumnFilterOperation value,
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
        public const string In = "in";

        public const string NotIn = "not_in";

        public const string Le = "le";

        public const string Ge = "ge";

        public const string Lt = "lt";

        public const string Gt = "gt";

        public const string Eq = "eq";

        public const string Neq = "neq";
    }
}
