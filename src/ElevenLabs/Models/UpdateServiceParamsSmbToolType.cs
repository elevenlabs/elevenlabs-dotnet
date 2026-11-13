using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UpdateServiceParamsSmbToolType.UpdateServiceParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct UpdateServiceParamsSmbToolType : IStringEnum
{
    public static readonly UpdateServiceParamsSmbToolType UpdateService = new(Values.UpdateService);

    public UpdateServiceParamsSmbToolType(string value)
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
    public static UpdateServiceParamsSmbToolType FromCustom(string value)
    {
        return new UpdateServiceParamsSmbToolType(value);
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

    public static bool operator ==(UpdateServiceParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateServiceParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateServiceParamsSmbToolType value) => value.Value;

    public static explicit operator UpdateServiceParamsSmbToolType(string value) => new(value);

    internal class UpdateServiceParamsSmbToolTypeSerializer
        : JsonConverter<UpdateServiceParamsSmbToolType>
    {
        public override UpdateServiceParamsSmbToolType Read(
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
            return new UpdateServiceParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateServiceParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateServiceParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateServiceParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateServiceParamsSmbToolType value,
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
        public const string UpdateService = "update_service";
    }
}
