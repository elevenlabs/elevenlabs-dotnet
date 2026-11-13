using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Agent's eagerness to respond. Higher values make agent wait for higher turn probability.</summary>
[JsonConverter(typeof(TurnEagerness.TurnEagernessSerializer))]
[Serializable]
public readonly record struct TurnEagerness : IStringEnum
{
    public static readonly TurnEagerness Patient = new(Values.Patient);

    public static readonly TurnEagerness Normal = new(Values.Normal);

    public static readonly TurnEagerness Eager = new(Values.Eager);

    public TurnEagerness(string value)
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
    public static TurnEagerness FromCustom(string value)
    {
        return new TurnEagerness(value);
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

    public static bool operator ==(TurnEagerness value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TurnEagerness value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TurnEagerness value) => value.Value;

    public static explicit operator TurnEagerness(string value) => new(value);

    internal class TurnEagernessSerializer : JsonConverter<TurnEagerness>
    {
        public override TurnEagerness Read(
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
            return new TurnEagerness(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TurnEagerness value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TurnEagerness ReadAsPropertyName(
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
            return new TurnEagerness(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TurnEagerness value,
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
        public const string Patient = "patient";

        public const string Normal = "normal";

        public const string Eager = "eager";
    }
}
