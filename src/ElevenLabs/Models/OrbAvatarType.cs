using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the avatar</summary>
[JsonConverter(typeof(OrbAvatarType.OrbAvatarTypeSerializer))]
[Serializable]
public readonly record struct OrbAvatarType : IStringEnum
{
    public static readonly OrbAvatarType Orb = new(Values.Orb);

    public OrbAvatarType(string value)
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
    public static OrbAvatarType FromCustom(string value)
    {
        return new OrbAvatarType(value);
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

    public static bool operator ==(OrbAvatarType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrbAvatarType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrbAvatarType value) => value.Value;

    public static explicit operator OrbAvatarType(string value) => new(value);

    internal class OrbAvatarTypeSerializer : JsonConverter<OrbAvatarType>
    {
        public override OrbAvatarType Read(
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
            return new OrbAvatarType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrbAvatarType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrbAvatarType ReadAsPropertyName(
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
            return new OrbAvatarType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrbAvatarType value,
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
        public const string Orb = "orb";
    }
}
