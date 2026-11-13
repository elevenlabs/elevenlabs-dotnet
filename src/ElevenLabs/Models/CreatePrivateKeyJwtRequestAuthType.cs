using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreatePrivateKeyJwtRequestAuthType.CreatePrivateKeyJwtRequestAuthTypeSerializer)
)]
[Serializable]
public readonly record struct CreatePrivateKeyJwtRequestAuthType : IStringEnum
{
    public static readonly CreatePrivateKeyJwtRequestAuthType PrivateKeyJwt = new(
        Values.PrivateKeyJwt
    );

    public CreatePrivateKeyJwtRequestAuthType(string value)
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
    public static CreatePrivateKeyJwtRequestAuthType FromCustom(string value)
    {
        return new CreatePrivateKeyJwtRequestAuthType(value);
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

    public static bool operator ==(CreatePrivateKeyJwtRequestAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePrivateKeyJwtRequestAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePrivateKeyJwtRequestAuthType value) => value.Value;

    public static explicit operator CreatePrivateKeyJwtRequestAuthType(string value) => new(value);

    internal class CreatePrivateKeyJwtRequestAuthTypeSerializer
        : JsonConverter<CreatePrivateKeyJwtRequestAuthType>
    {
        public override CreatePrivateKeyJwtRequestAuthType Read(
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
            return new CreatePrivateKeyJwtRequestAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePrivateKeyJwtRequestAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePrivateKeyJwtRequestAuthType ReadAsPropertyName(
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
            return new CreatePrivateKeyJwtRequestAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePrivateKeyJwtRequestAuthType value,
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
        public const string PrivateKeyJwt = "private_key_jwt";
    }
}
