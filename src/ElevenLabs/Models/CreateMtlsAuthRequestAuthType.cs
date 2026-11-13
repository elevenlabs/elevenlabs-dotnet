using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateMtlsAuthRequestAuthType.CreateMtlsAuthRequestAuthTypeSerializer))]
[Serializable]
public readonly record struct CreateMtlsAuthRequestAuthType : IStringEnum
{
    public static readonly CreateMtlsAuthRequestAuthType Mtls = new(Values.Mtls);

    public CreateMtlsAuthRequestAuthType(string value)
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
    public static CreateMtlsAuthRequestAuthType FromCustom(string value)
    {
        return new CreateMtlsAuthRequestAuthType(value);
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

    public static bool operator ==(CreateMtlsAuthRequestAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateMtlsAuthRequestAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateMtlsAuthRequestAuthType value) => value.Value;

    public static explicit operator CreateMtlsAuthRequestAuthType(string value) => new(value);

    internal class CreateMtlsAuthRequestAuthTypeSerializer
        : JsonConverter<CreateMtlsAuthRequestAuthType>
    {
        public override CreateMtlsAuthRequestAuthType Read(
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
            return new CreateMtlsAuthRequestAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateMtlsAuthRequestAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateMtlsAuthRequestAuthType ReadAsPropertyName(
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
            return new CreateMtlsAuthRequestAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateMtlsAuthRequestAuthType value,
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
        public const string Mtls = "mtls";
    }
}
