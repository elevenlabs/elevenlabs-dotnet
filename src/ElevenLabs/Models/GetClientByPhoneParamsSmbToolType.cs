using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetClientByPhoneParamsSmbToolType.GetClientByPhoneParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct GetClientByPhoneParamsSmbToolType : IStringEnum
{
    public static readonly GetClientByPhoneParamsSmbToolType GetClientByPhone = new(
        Values.GetClientByPhone
    );

    public GetClientByPhoneParamsSmbToolType(string value)
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
    public static GetClientByPhoneParamsSmbToolType FromCustom(string value)
    {
        return new GetClientByPhoneParamsSmbToolType(value);
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

    public static bool operator ==(GetClientByPhoneParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetClientByPhoneParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetClientByPhoneParamsSmbToolType value) => value.Value;

    public static explicit operator GetClientByPhoneParamsSmbToolType(string value) => new(value);

    internal class GetClientByPhoneParamsSmbToolTypeSerializer
        : JsonConverter<GetClientByPhoneParamsSmbToolType>
    {
        public override GetClientByPhoneParamsSmbToolType Read(
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
            return new GetClientByPhoneParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetClientByPhoneParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetClientByPhoneParamsSmbToolType ReadAsPropertyName(
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
            return new GetClientByPhoneParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetClientByPhoneParamsSmbToolType value,
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
        public const string GetClientByPhone = "get_client_by_phone";
    }
}
