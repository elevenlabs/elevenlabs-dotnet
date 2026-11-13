using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(ClientToolConfigOutputType.ClientToolConfigOutputTypeSerializer))]
[Serializable]
public readonly record struct ClientToolConfigOutputType : IStringEnum
{
    public static readonly ClientToolConfigOutputType Client = new(Values.Client);

    public ClientToolConfigOutputType(string value)
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
    public static ClientToolConfigOutputType FromCustom(string value)
    {
        return new ClientToolConfigOutputType(value);
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

    public static bool operator ==(ClientToolConfigOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolConfigOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolConfigOutputType value) => value.Value;

    public static explicit operator ClientToolConfigOutputType(string value) => new(value);

    internal class ClientToolConfigOutputTypeSerializer : JsonConverter<ClientToolConfigOutputType>
    {
        public override ClientToolConfigOutputType Read(
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
            return new ClientToolConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolConfigOutputType ReadAsPropertyName(
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
            return new ClientToolConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolConfigOutputType value,
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
        public const string Client = "client";
    }
}
