using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.ServiceAccounts;

[JsonConverter(typeof(ExpiresAtUnix2.ExpiresAtUnix2Serializer))]
[Serializable]
public readonly record struct ExpiresAtUnix2 : IStringEnum
{
    public static readonly ExpiresAtUnix2 Clear = new(Values.Clear);

    public static readonly ExpiresAtUnix2 NoUpdate = new(Values.NoUpdate);

    public ExpiresAtUnix2(string value)
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
    public static ExpiresAtUnix2 FromCustom(string value)
    {
        return new ExpiresAtUnix2(value);
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

    public static bool operator ==(ExpiresAtUnix2 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExpiresAtUnix2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExpiresAtUnix2 value) => value.Value;

    public static explicit operator ExpiresAtUnix2(string value) => new(value);

    internal class ExpiresAtUnix2Serializer : JsonConverter<ExpiresAtUnix2>
    {
        public override ExpiresAtUnix2 Read(
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
            return new ExpiresAtUnix2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExpiresAtUnix2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExpiresAtUnix2 ReadAsPropertyName(
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
            return new ExpiresAtUnix2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExpiresAtUnix2 value,
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
        public const string Clear = "clear";

        public const string NoUpdate = "no_update";
    }
}
