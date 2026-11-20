using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How quickly the receptionist decides the caller has finished speaking.</summary>
[JsonConverter(typeof(ReceptionTurnEagerness.ReceptionTurnEagernessSerializer))]
[Serializable]
public readonly record struct ReceptionTurnEagerness : IStringEnum
{
    public static readonly ReceptionTurnEagerness Patient = new(Values.Patient);

    public static readonly ReceptionTurnEagerness Normal = new(Values.Normal);

    public static readonly ReceptionTurnEagerness Eager = new(Values.Eager);

    public ReceptionTurnEagerness(string value)
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
    public static ReceptionTurnEagerness FromCustom(string value)
    {
        return new ReceptionTurnEagerness(value);
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

    public static bool operator ==(ReceptionTurnEagerness value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionTurnEagerness value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionTurnEagerness value) => value.Value;

    public static explicit operator ReceptionTurnEagerness(string value) => new(value);

    internal class ReceptionTurnEagernessSerializer : JsonConverter<ReceptionTurnEagerness>
    {
        public override ReceptionTurnEagerness Read(
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
            return new ReceptionTurnEagerness(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionTurnEagerness value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionTurnEagerness ReadAsPropertyName(
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
            return new ReceptionTurnEagerness(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionTurnEagerness value,
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
