using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(SystemToolConfigInputType.SystemToolConfigInputTypeSerializer))]
[Serializable]
public readonly record struct SystemToolConfigInputType : IStringEnum
{
    public static readonly SystemToolConfigInputType System = new(Values.System);

    public SystemToolConfigInputType(string value)
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
    public static SystemToolConfigInputType FromCustom(string value)
    {
        return new SystemToolConfigInputType(value);
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

    public static bool operator ==(SystemToolConfigInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SystemToolConfigInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SystemToolConfigInputType value) => value.Value;

    public static explicit operator SystemToolConfigInputType(string value) => new(value);

    internal class SystemToolConfigInputTypeSerializer : JsonConverter<SystemToolConfigInputType>
    {
        public override SystemToolConfigInputType Read(
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
            return new SystemToolConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SystemToolConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SystemToolConfigInputType ReadAsPropertyName(
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
            return new SystemToolConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SystemToolConfigInputType value,
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
