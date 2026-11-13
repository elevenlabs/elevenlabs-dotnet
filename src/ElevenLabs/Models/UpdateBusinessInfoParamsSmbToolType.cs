using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateBusinessInfoParamsSmbToolType.UpdateBusinessInfoParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateBusinessInfoParamsSmbToolType : IStringEnum
{
    public static readonly UpdateBusinessInfoParamsSmbToolType UpdateBusinessInfo = new(
        Values.UpdateBusinessInfo
    );

    public UpdateBusinessInfoParamsSmbToolType(string value)
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
    public static UpdateBusinessInfoParamsSmbToolType FromCustom(string value)
    {
        return new UpdateBusinessInfoParamsSmbToolType(value);
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

    public static bool operator ==(UpdateBusinessInfoParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateBusinessInfoParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBusinessInfoParamsSmbToolType value) =>
        value.Value;

    public static explicit operator UpdateBusinessInfoParamsSmbToolType(string value) => new(value);

    internal class UpdateBusinessInfoParamsSmbToolTypeSerializer
        : JsonConverter<UpdateBusinessInfoParamsSmbToolType>
    {
        public override UpdateBusinessInfoParamsSmbToolType Read(
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
            return new UpdateBusinessInfoParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateBusinessInfoParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateBusinessInfoParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateBusinessInfoParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateBusinessInfoParamsSmbToolType value,
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
        public const string UpdateBusinessInfo = "update_business_info";
    }
}
