using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TurnMode.TurnModeSerializer))]
[Serializable]
public readonly record struct TurnMode : IStringEnum
{
    public static readonly TurnMode Silence = new(Values.Silence);

    public static readonly TurnMode Turn = new(Values.Turn);

    public TurnMode(string value)
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
    public static TurnMode FromCustom(string value)
    {
        return new TurnMode(value);
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

    public static bool operator ==(TurnMode value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TurnMode value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(TurnMode value) => value.Value;

    public static explicit operator TurnMode(string value) => new(value);

    internal class TurnModeSerializer : JsonConverter<TurnMode>
    {
        public override TurnMode Read(
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
            return new TurnMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TurnMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TurnMode ReadAsPropertyName(
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
            return new TurnMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TurnMode value,
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
        public const string Silence = "silence";

        public const string Turn = "turn";
    }
}
