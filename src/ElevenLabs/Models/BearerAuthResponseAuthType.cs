using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BearerAuthResponseAuthType.BearerAuthResponseAuthTypeSerializer))]
[Serializable]
public readonly record struct BearerAuthResponseAuthType : IStringEnum
{
    public static readonly BearerAuthResponseAuthType BearerAuth = new(Values.BearerAuth);

    public BearerAuthResponseAuthType(string value)
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
    public static BearerAuthResponseAuthType FromCustom(string value)
    {
        return new BearerAuthResponseAuthType(value);
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

    public static bool operator ==(BearerAuthResponseAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BearerAuthResponseAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BearerAuthResponseAuthType value) => value.Value;

    public static explicit operator BearerAuthResponseAuthType(string value) => new(value);

    internal class BearerAuthResponseAuthTypeSerializer : JsonConverter<BearerAuthResponseAuthType>
    {
        public override BearerAuthResponseAuthType Read(
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
            return new BearerAuthResponseAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BearerAuthResponseAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BearerAuthResponseAuthType ReadAsPropertyName(
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
            return new BearerAuthResponseAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BearerAuthResponseAuthType value,
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
        public const string BearerAuth = "bearer_auth";
    }
}
