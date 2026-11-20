using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ClientToolResultItemType.ClientToolResultItemTypeSerializer))]
[Serializable]
public readonly record struct ClientToolResultItemType : IStringEnum
{
    public static readonly ClientToolResultItemType ClientToolResult = new(Values.ClientToolResult);

    public ClientToolResultItemType(string value)
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
    public static ClientToolResultItemType FromCustom(string value)
    {
        return new ClientToolResultItemType(value);
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

    public static bool operator ==(ClientToolResultItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolResultItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolResultItemType value) => value.Value;

    public static explicit operator ClientToolResultItemType(string value) => new(value);

    internal class ClientToolResultItemTypeSerializer : JsonConverter<ClientToolResultItemType>
    {
        public override ClientToolResultItemType Read(
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
            return new ClientToolResultItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolResultItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolResultItemType ReadAsPropertyName(
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
            return new ClientToolResultItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolResultItemType value,
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
