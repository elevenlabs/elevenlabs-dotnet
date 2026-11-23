using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ClientToolResultType.ClientToolResultTypeSerializer))]
[Serializable]
public readonly record struct ClientToolResultType : IStringEnum
{
    public static readonly ClientToolResultType ClientToolResult = new(Values.ClientToolResult);

    public ClientToolResultType(string value)
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
    public static ClientToolResultType FromCustom(string value)
    {
        return new ClientToolResultType(value);
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

    public static bool operator ==(ClientToolResultType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolResultType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolResultType value) => value.Value;

    public static explicit operator ClientToolResultType(string value) => new(value);

    internal class ClientToolResultTypeSerializer : JsonConverter<ClientToolResultType>
    {
        public override ClientToolResultType Read(
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
            return new ClientToolResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolResultType ReadAsPropertyName(
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
            return new ClientToolResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolResultType value,
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
        public const string ClientToolResult = "client_tool_result";
    }
}
