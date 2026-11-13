using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DependentUnknownToolIdentifierType.DependentUnknownToolIdentifierTypeSerializer)
)]
[Serializable]
public readonly record struct DependentUnknownToolIdentifierType : IStringEnum
{
    public static readonly DependentUnknownToolIdentifierType Unknown = new(Values.Unknown);

    public DependentUnknownToolIdentifierType(string value)
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
    public static DependentUnknownToolIdentifierType FromCustom(string value)
    {
        return new DependentUnknownToolIdentifierType(value);
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

    public static bool operator ==(DependentUnknownToolIdentifierType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DependentUnknownToolIdentifierType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DependentUnknownToolIdentifierType value) => value.Value;

    public static explicit operator DependentUnknownToolIdentifierType(string value) => new(value);

    internal class DependentUnknownToolIdentifierTypeSerializer
        : JsonConverter<DependentUnknownToolIdentifierType>
    {
        public override DependentUnknownToolIdentifierType Read(
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
            return new DependentUnknownToolIdentifierType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DependentUnknownToolIdentifierType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DependentUnknownToolIdentifierType ReadAsPropertyName(
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
            return new DependentUnknownToolIdentifierType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DependentUnknownToolIdentifierType value,
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
        public const string Unknown = "unknown";
    }
}
