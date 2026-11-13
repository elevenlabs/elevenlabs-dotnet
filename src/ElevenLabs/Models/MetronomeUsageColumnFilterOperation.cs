using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(MetronomeUsageColumnFilterOperation.MetronomeUsageColumnFilterOperationSerializer)
)]
[Serializable]
public readonly record struct MetronomeUsageColumnFilterOperation : IStringEnum
{
    public static readonly MetronomeUsageColumnFilterOperation Eq = new(Values.Eq);

    public static readonly MetronomeUsageColumnFilterOperation In = new(Values.In);

    public static readonly MetronomeUsageColumnFilterOperation Neq = new(Values.Neq);

    public static readonly MetronomeUsageColumnFilterOperation NotIn = new(Values.NotIn);

    public MetronomeUsageColumnFilterOperation(string value)
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
    public static MetronomeUsageColumnFilterOperation FromCustom(string value)
    {
        return new MetronomeUsageColumnFilterOperation(value);
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

    public static bool operator ==(MetronomeUsageColumnFilterOperation value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MetronomeUsageColumnFilterOperation value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MetronomeUsageColumnFilterOperation value) =>
        value.Value;

    public static explicit operator MetronomeUsageColumnFilterOperation(string value) => new(value);

    internal class MetronomeUsageColumnFilterOperationSerializer
        : JsonConverter<MetronomeUsageColumnFilterOperation>
    {
        public override MetronomeUsageColumnFilterOperation Read(
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
            return new MetronomeUsageColumnFilterOperation(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MetronomeUsageColumnFilterOperation value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MetronomeUsageColumnFilterOperation ReadAsPropertyName(
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
            return new MetronomeUsageColumnFilterOperation(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MetronomeUsageColumnFilterOperation value,
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
        public const string Eq = "eq";

        public const string In = "in";

        public const string Neq = "neq";

        public const string NotIn = "not_in";
    }
}
