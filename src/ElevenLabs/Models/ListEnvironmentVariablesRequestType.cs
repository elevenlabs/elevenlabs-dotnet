using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListEnvironmentVariablesRequestType.ListEnvironmentVariablesRequestTypeSerializer)
)]
[Serializable]
public readonly record struct ListEnvironmentVariablesRequestType : IStringEnum
{
    public static readonly ListEnvironmentVariablesRequestType String = new(Values.String);

    public static readonly ListEnvironmentVariablesRequestType Secret = new(Values.Secret);

    public static readonly ListEnvironmentVariablesRequestType AuthConnection = new(
        Values.AuthConnection
    );

    public ListEnvironmentVariablesRequestType(string value)
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
    public static ListEnvironmentVariablesRequestType FromCustom(string value)
    {
        return new ListEnvironmentVariablesRequestType(value);
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

    public static bool operator ==(ListEnvironmentVariablesRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListEnvironmentVariablesRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListEnvironmentVariablesRequestType value) =>
        value.Value;

    public static explicit operator ListEnvironmentVariablesRequestType(string value) => new(value);

    internal class ListEnvironmentVariablesRequestTypeSerializer
        : JsonConverter<ListEnvironmentVariablesRequestType>
    {
        public override ListEnvironmentVariablesRequestType Read(
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
            return new ListEnvironmentVariablesRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListEnvironmentVariablesRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListEnvironmentVariablesRequestType ReadAsPropertyName(
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
            return new ListEnvironmentVariablesRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListEnvironmentVariablesRequestType value,
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
        public const string String = "string";

        public const string Secret = "secret";

        public const string AuthConnection = "auth_connection";
    }
}
