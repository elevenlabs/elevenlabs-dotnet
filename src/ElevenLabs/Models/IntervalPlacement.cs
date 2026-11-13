using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(IntervalPlacement.IntervalPlacementSerializer))]
[Serializable]
public readonly record struct IntervalPlacement : IStringEnum
{
    public static readonly IntervalPlacement Start = new(Values.Start);

    public static readonly IntervalPlacement Random = new(Values.Random);

    public static readonly IntervalPlacement Rotate = new(Values.Rotate);

    public IntervalPlacement(string value)
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
    public static IntervalPlacement FromCustom(string value)
    {
        return new IntervalPlacement(value);
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

    public static bool operator ==(IntervalPlacement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IntervalPlacement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IntervalPlacement value) => value.Value;

    public static explicit operator IntervalPlacement(string value) => new(value);

    internal class IntervalPlacementSerializer : JsonConverter<IntervalPlacement>
    {
        public override IntervalPlacement Read(
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
            return new IntervalPlacement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IntervalPlacement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IntervalPlacement ReadAsPropertyName(
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
            return new IntervalPlacement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IntervalPlacement value,
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
        public const string Start = "start";

        public const string Random = "random";

        public const string Rotate = "rotate";
    }
}
