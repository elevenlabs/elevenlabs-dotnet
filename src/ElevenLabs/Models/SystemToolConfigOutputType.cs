using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(SystemToolConfigOutputType.SystemToolConfigOutputTypeSerializer))]
[Serializable]
public readonly record struct SystemToolConfigOutputType : IStringEnum
{
    public static readonly SystemToolConfigOutputType System = new(Values.System);

    public SystemToolConfigOutputType(string value)
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
    public static SystemToolConfigOutputType FromCustom(string value)
    {
        return new SystemToolConfigOutputType(value);
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

    public static bool operator ==(SystemToolConfigOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SystemToolConfigOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SystemToolConfigOutputType value) => value.Value;

    public static explicit operator SystemToolConfigOutputType(string value) => new(value);

    internal class SystemToolConfigOutputTypeSerializer : JsonConverter<SystemToolConfigOutputType>
    {
        public override SystemToolConfigOutputType Read(
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
            return new SystemToolConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SystemToolConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SystemToolConfigOutputType ReadAsPropertyName(
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
            return new SystemToolConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SystemToolConfigOutputType value,
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
        public const string System = "system";
    }
}
