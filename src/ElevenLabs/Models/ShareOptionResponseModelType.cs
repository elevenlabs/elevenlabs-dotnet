using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the principal: user, group, or service account (under 'key').</summary>
[JsonConverter(typeof(ShareOptionResponseModelType.ShareOptionResponseModelTypeSerializer))]
[Serializable]
public readonly record struct ShareOptionResponseModelType : IStringEnum
{
    public static readonly ShareOptionResponseModelType User = new(Values.User);

    public static readonly ShareOptionResponseModelType Group = new(Values.Group);

    public static readonly ShareOptionResponseModelType Key = new(Values.Key);

    public ShareOptionResponseModelType(string value)
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
    public static ShareOptionResponseModelType FromCustom(string value)
    {
        return new ShareOptionResponseModelType(value);
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

    public static bool operator ==(ShareOptionResponseModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ShareOptionResponseModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ShareOptionResponseModelType value) => value.Value;

    public static explicit operator ShareOptionResponseModelType(string value) => new(value);

    internal class ShareOptionResponseModelTypeSerializer
        : JsonConverter<ShareOptionResponseModelType>
    {
        public override ShareOptionResponseModelType Read(
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
            return new ShareOptionResponseModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ShareOptionResponseModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ShareOptionResponseModelType ReadAsPropertyName(
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
            return new ShareOptionResponseModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ShareOptionResponseModelType value,
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
        public const string User = "user";

        public const string Group = "group";

        public const string Key = "key";
    }
}
