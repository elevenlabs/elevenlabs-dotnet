using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Tool type identifier</summary>
[JsonConverter(typeof(SmbToolConfigType.SmbToolConfigTypeSerializer))]
[Serializable]
public readonly record struct SmbToolConfigType : IStringEnum
{
    public static readonly SmbToolConfigType Smb = new(Values.Smb);

    public SmbToolConfigType(string value)
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
    public static SmbToolConfigType FromCustom(string value)
    {
        return new SmbToolConfigType(value);
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

    public static bool operator ==(SmbToolConfigType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmbToolConfigType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmbToolConfigType value) => value.Value;

    public static explicit operator SmbToolConfigType(string value) => new(value);

    internal class SmbToolConfigTypeSerializer : JsonConverter<SmbToolConfigType>
    {
        public override SmbToolConfigType Read(
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
            return new SmbToolConfigType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmbToolConfigType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmbToolConfigType ReadAsPropertyName(
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
            return new SmbToolConfigType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmbToolConfigType value,
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
        public const string Smb = "smb";
    }
}
