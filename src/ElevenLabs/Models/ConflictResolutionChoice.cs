using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConflictResolutionChoice.ConflictResolutionChoiceSerializer))]
[Serializable]
public readonly record struct ConflictResolutionChoice : IStringEnum
{
    public static readonly ConflictResolutionChoice Source = new(Values.Source);

    public static readonly ConflictResolutionChoice Target = new(Values.Target);

    public static readonly ConflictResolutionChoice Custom = new(Values.Custom);

    public ConflictResolutionChoice(string value)
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
    public static ConflictResolutionChoice FromCustom(string value)
    {
        return new ConflictResolutionChoice(value);
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

    public static bool operator ==(ConflictResolutionChoice value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConflictResolutionChoice value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConflictResolutionChoice value) => value.Value;

    public static explicit operator ConflictResolutionChoice(string value) => new(value);

    internal class ConflictResolutionChoiceSerializer : JsonConverter<ConflictResolutionChoice>
    {
        public override ConflictResolutionChoice Read(
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
            return new ConflictResolutionChoice(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConflictResolutionChoice value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConflictResolutionChoice ReadAsPropertyName(
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
            return new ConflictResolutionChoice(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConflictResolutionChoice value,
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
        public const string Source = "source";

        public const string Target = "target";

        public const string Custom = "custom";
    }
}
