using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SecretDependencyType.SecretDependencyTypeSerializer))]
[Serializable]
public readonly record struct SecretDependencyType : IStringEnum
{
    public static readonly SecretDependencyType ConversationInitiationWebhook = new(
        Values.ConversationInitiationWebhook
    );

    public SecretDependencyType(string value)
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
    public static SecretDependencyType FromCustom(string value)
    {
        return new SecretDependencyType(value);
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

    public static bool operator ==(SecretDependencyType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SecretDependencyType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SecretDependencyType value) => value.Value;

    public static explicit operator SecretDependencyType(string value) => new(value);

    internal class SecretDependencyTypeSerializer : JsonConverter<SecretDependencyType>
    {
        public override SecretDependencyType Read(
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
            return new SecretDependencyType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SecretDependencyType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SecretDependencyType ReadAsPropertyName(
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
            return new SecretDependencyType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SecretDependencyType value,
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
        public const string ConversationInitiationWebhook = "conversation_initiation_webhook";
    }
}
