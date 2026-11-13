using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LeaveMessageParamsSmbToolType.LeaveMessageParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct LeaveMessageParamsSmbToolType : IStringEnum
{
    public static readonly LeaveMessageParamsSmbToolType LeaveMessage = new(Values.LeaveMessage);

    public LeaveMessageParamsSmbToolType(string value)
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
    public static LeaveMessageParamsSmbToolType FromCustom(string value)
    {
        return new LeaveMessageParamsSmbToolType(value);
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

    public static bool operator ==(LeaveMessageParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LeaveMessageParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LeaveMessageParamsSmbToolType value) => value.Value;

    public static explicit operator LeaveMessageParamsSmbToolType(string value) => new(value);

    internal class LeaveMessageParamsSmbToolTypeSerializer
        : JsonConverter<LeaveMessageParamsSmbToolType>
    {
        public override LeaveMessageParamsSmbToolType Read(
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
            return new LeaveMessageParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LeaveMessageParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LeaveMessageParamsSmbToolType ReadAsPropertyName(
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
            return new LeaveMessageParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LeaveMessageParamsSmbToolType value,
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
        public const string LeaveMessage = "leave_message";
    }
}
