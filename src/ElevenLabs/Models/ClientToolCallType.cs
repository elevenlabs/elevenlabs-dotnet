using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ClientToolCallType.ClientToolCallTypeSerializer))]
[Serializable]
public readonly record struct ClientToolCallType : IStringEnum
{
    public static readonly ClientToolCallType ClientToolCall = new(Values.ClientToolCall);

    public ClientToolCallType(string value)
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
    public static ClientToolCallType FromCustom(string value)
    {
        return new ClientToolCallType(value);
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

    public static bool operator ==(ClientToolCallType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolCallType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolCallType value) => value.Value;

    public static explicit operator ClientToolCallType(string value) => new(value);

    internal class ClientToolCallTypeSerializer : JsonConverter<ClientToolCallType>
    {
        public override ClientToolCallType Read(
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
            return new ClientToolCallType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolCallType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolCallType ReadAsPropertyName(
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
            return new ClientToolCallType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolCallType value,
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
        public const string ClientToolCall = "client_tool_call";
    }
}
