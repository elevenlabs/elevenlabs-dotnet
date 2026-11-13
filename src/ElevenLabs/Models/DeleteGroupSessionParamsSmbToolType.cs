using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DeleteGroupSessionParamsSmbToolType.DeleteGroupSessionParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct DeleteGroupSessionParamsSmbToolType : IStringEnum
{
    public static readonly DeleteGroupSessionParamsSmbToolType DeleteGroupSession = new(
        Values.DeleteGroupSession
    );

    public DeleteGroupSessionParamsSmbToolType(string value)
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
    public static DeleteGroupSessionParamsSmbToolType FromCustom(string value)
    {
        return new DeleteGroupSessionParamsSmbToolType(value);
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

    public static bool operator ==(DeleteGroupSessionParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeleteGroupSessionParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeleteGroupSessionParamsSmbToolType value) =>
        value.Value;

    public static explicit operator DeleteGroupSessionParamsSmbToolType(string value) => new(value);

    internal class DeleteGroupSessionParamsSmbToolTypeSerializer
        : JsonConverter<DeleteGroupSessionParamsSmbToolType>
    {
        public override DeleteGroupSessionParamsSmbToolType Read(
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
            return new DeleteGroupSessionParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeleteGroupSessionParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeleteGroupSessionParamsSmbToolType ReadAsPropertyName(
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
            return new DeleteGroupSessionParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeleteGroupSessionParamsSmbToolType value,
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
        public const string DeleteGroupSession = "delete_group_session";
    }
}
