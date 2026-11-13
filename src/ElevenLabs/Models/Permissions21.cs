using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(Permissions21.Permissions21Serializer))]
[Serializable]
public readonly record struct Permissions21 : IStringEnum
{
    public static readonly Permissions21 All = new(Values.All);

    public Permissions21(string value)
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
    public static Permissions21 FromCustom(string value)
    {
        return new Permissions21(value);
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

    public static bool operator ==(Permissions21 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Permissions21 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Permissions21 value) => value.Value;

    public static explicit operator Permissions21(string value) => new(value);

    internal class Permissions21Serializer : JsonConverter<Permissions21>
    {
        public override Permissions21 Read(
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
            return new Permissions21(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Permissions21 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Permissions21 ReadAsPropertyName(
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
            return new Permissions21(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Permissions21 value,
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
        public const string All = "all";
    }
}
