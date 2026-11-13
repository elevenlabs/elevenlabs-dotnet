using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DeleteServiceParamsSmbToolType.DeleteServiceParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct DeleteServiceParamsSmbToolType : IStringEnum
{
    public static readonly DeleteServiceParamsSmbToolType DeleteService = new(Values.DeleteService);

    public DeleteServiceParamsSmbToolType(string value)
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
    public static DeleteServiceParamsSmbToolType FromCustom(string value)
    {
        return new DeleteServiceParamsSmbToolType(value);
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

    public static bool operator ==(DeleteServiceParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeleteServiceParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeleteServiceParamsSmbToolType value) => value.Value;

    public static explicit operator DeleteServiceParamsSmbToolType(string value) => new(value);

    internal class DeleteServiceParamsSmbToolTypeSerializer
        : JsonConverter<DeleteServiceParamsSmbToolType>
    {
        public override DeleteServiceParamsSmbToolType Read(
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
            return new DeleteServiceParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeleteServiceParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeleteServiceParamsSmbToolType ReadAsPropertyName(
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
            return new DeleteServiceParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeleteServiceParamsSmbToolType value,
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
        public const string DeleteService = "delete_service";
    }
}
