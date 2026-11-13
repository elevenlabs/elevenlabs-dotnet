using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(RegisterForGroupSessionParamsSmbToolType.RegisterForGroupSessionParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct RegisterForGroupSessionParamsSmbToolType : IStringEnum
{
    public static readonly RegisterForGroupSessionParamsSmbToolType RegisterForGroupSession = new(
        Values.RegisterForGroupSession
    );

    public RegisterForGroupSessionParamsSmbToolType(string value)
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
    public static RegisterForGroupSessionParamsSmbToolType FromCustom(string value)
    {
        return new RegisterForGroupSessionParamsSmbToolType(value);
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

    public static bool operator ==(
        RegisterForGroupSessionParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RegisterForGroupSessionParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(RegisterForGroupSessionParamsSmbToolType value) =>
        value.Value;

    public static explicit operator RegisterForGroupSessionParamsSmbToolType(string value) =>
        new(value);

    internal class RegisterForGroupSessionParamsSmbToolTypeSerializer
        : JsonConverter<RegisterForGroupSessionParamsSmbToolType>
    {
        public override RegisterForGroupSessionParamsSmbToolType Read(
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
            return new RegisterForGroupSessionParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RegisterForGroupSessionParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RegisterForGroupSessionParamsSmbToolType ReadAsPropertyName(
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
            return new RegisterForGroupSessionParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RegisterForGroupSessionParamsSmbToolType value,
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
        public const string RegisterForGroupSession = "register_for_group_session";
    }
}
