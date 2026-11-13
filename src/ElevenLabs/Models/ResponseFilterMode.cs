using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Controls how tool responses are filtered before being visible to the agent.</summary>
[JsonConverter(typeof(ResponseFilterMode.ResponseFilterModeSerializer))]
[Serializable]
public readonly record struct ResponseFilterMode : IStringEnum
{
    public static readonly ResponseFilterMode All = new(Values.All);

    public static readonly ResponseFilterMode Allow = new(Values.Allow);

    public static readonly ResponseFilterMode HideAll = new(Values.HideAll);

    public ResponseFilterMode(string value)
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
    public static ResponseFilterMode FromCustom(string value)
    {
        return new ResponseFilterMode(value);
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

    public static bool operator ==(ResponseFilterMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResponseFilterMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResponseFilterMode value) => value.Value;

    public static explicit operator ResponseFilterMode(string value) => new(value);

    internal class ResponseFilterModeSerializer : JsonConverter<ResponseFilterMode>
    {
        public override ResponseFilterMode Read(
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
            return new ResponseFilterMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseFilterMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResponseFilterMode ReadAsPropertyName(
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
            return new ResponseFilterMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseFilterMode value,
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
        public const string All = "all";

        public const string Allow = "allow";

        public const string HideAll = "hide_all";
    }
}
