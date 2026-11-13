using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(ClientToolConfigInputType.ClientToolConfigInputTypeSerializer))]
[Serializable]
public readonly record struct ClientToolConfigInputType : IStringEnum
{
    public static readonly ClientToolConfigInputType Client = new(Values.Client);

    public ClientToolConfigInputType(string value)
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
    public static ClientToolConfigInputType FromCustom(string value)
    {
        return new ClientToolConfigInputType(value);
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

    public static bool operator ==(ClientToolConfigInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolConfigInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolConfigInputType value) => value.Value;

    public static explicit operator ClientToolConfigInputType(string value) => new(value);

    internal class ClientToolConfigInputTypeSerializer : JsonConverter<ClientToolConfigInputType>
    {
        public override ClientToolConfigInputType Read(
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
            return new ClientToolConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolConfigInputType ReadAsPropertyName(
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
            return new ClientToolConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolConfigInputType value,
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
