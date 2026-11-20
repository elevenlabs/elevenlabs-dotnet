using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Reception;

/// <summary>
/// What a service books.
///
/// - `classic`: a staff-delivered service (haircut, consultation, massage, ...).
/// - `rental`: an asset reservation (court, room, equipment).
/// - `group`: seats in a multi-participant session (class, workshop, tour).
/// </summary>
[JsonConverter(typeof(ReceptionServiceKind.ReceptionServiceKindSerializer))]
[Serializable]
public readonly record struct ReceptionServiceKind : IStringEnum
{
    public static readonly ReceptionServiceKind Classic = new(Values.Classic);

    public static readonly ReceptionServiceKind Rental = new(Values.Rental);

    public static readonly ReceptionServiceKind Group = new(Values.Group);

    public ReceptionServiceKind(string value)
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
    public static ReceptionServiceKind FromCustom(string value)
    {
        return new ReceptionServiceKind(value);
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

    public static bool operator ==(ReceptionServiceKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionServiceKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionServiceKind value) => value.Value;

    public static explicit operator ReceptionServiceKind(string value) => new(value);

    internal class ReceptionServiceKindSerializer : JsonConverter<ReceptionServiceKind>
    {
        public override ReceptionServiceKind Read(
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
            return new ReceptionServiceKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionServiceKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionServiceKind ReadAsPropertyName(
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
            return new ReceptionServiceKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionServiceKind value,
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
        public const string Classic = "classic";

        public const string Rental = "rental";

        public const string Group = "group";
    }
}
