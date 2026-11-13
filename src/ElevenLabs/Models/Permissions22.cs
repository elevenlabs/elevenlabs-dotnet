using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(Permissions22.Permissions22Serializer))]
[Serializable]
public readonly record struct Permissions22 : IStringEnum
{
    public static readonly Permissions22 All = new(Values.All);

    public static readonly Permissions22 NoUpdate = new(Values.NoUpdate);

    public Permissions22(string value)
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
    public static Permissions22 FromCustom(string value)
    {
        return new Permissions22(value);
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

    public static bool operator ==(Permissions22 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Permissions22 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Permissions22 value) => value.Value;

    public static explicit operator Permissions22(string value) => new(value);

    internal class Permissions22Serializer : JsonConverter<Permissions22>
    {
        public override Permissions22 Read(
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
            return new Permissions22(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Permissions22 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Permissions22 ReadAsPropertyName(
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
            return new Permissions22(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Permissions22 value,
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

        public const string NoUpdate = "no_update";
    }
}
