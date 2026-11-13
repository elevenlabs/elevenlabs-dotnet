using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the avatar</summary>
[JsonConverter(typeof(UrlAvatarType.UrlAvatarTypeSerializer))]
[Serializable]
public readonly record struct UrlAvatarType : IStringEnum
{
    public static readonly UrlAvatarType Url = new(Values.Url);

    public UrlAvatarType(string value)
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
    public static UrlAvatarType FromCustom(string value)
    {
        return new UrlAvatarType(value);
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

    public static bool operator ==(UrlAvatarType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UrlAvatarType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UrlAvatarType value) => value.Value;

    public static explicit operator UrlAvatarType(string value) => new(value);

    internal class UrlAvatarTypeSerializer : JsonConverter<UrlAvatarType>
    {
        public override UrlAvatarType Read(
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
            return new UrlAvatarType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UrlAvatarType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UrlAvatarType ReadAsPropertyName(
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
            return new UrlAvatarType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UrlAvatarType value,
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
        public const string Url = "url";
    }
}
