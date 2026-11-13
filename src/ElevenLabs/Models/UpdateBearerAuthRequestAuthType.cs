using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UpdateBearerAuthRequestAuthType.UpdateBearerAuthRequestAuthTypeSerializer))]
[Serializable]
public readonly record struct UpdateBearerAuthRequestAuthType : IStringEnum
{
    public static readonly UpdateBearerAuthRequestAuthType BearerAuth = new(Values.BearerAuth);

    public UpdateBearerAuthRequestAuthType(string value)
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
    public static UpdateBearerAuthRequestAuthType FromCustom(string value)
    {
        return new UpdateBearerAuthRequestAuthType(value);
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

    public static bool operator ==(UpdateBearerAuthRequestAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateBearerAuthRequestAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBearerAuthRequestAuthType value) => value.Value;

    public static explicit operator UpdateBearerAuthRequestAuthType(string value) => new(value);

    internal class UpdateBearerAuthRequestAuthTypeSerializer
        : JsonConverter<UpdateBearerAuthRequestAuthType>
    {
        public override UpdateBearerAuthRequestAuthType Read(
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
            return new UpdateBearerAuthRequestAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateBearerAuthRequestAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateBearerAuthRequestAuthType ReadAsPropertyName(
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
            return new UpdateBearerAuthRequestAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateBearerAuthRequestAuthType value,
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
