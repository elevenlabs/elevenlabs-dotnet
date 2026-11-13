using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(SecretDependencyResourceType.SecretDependencyResourceTypeSerializer))]
[Serializable]
public readonly record struct SecretDependencyResourceType : IStringEnum
{
    public static readonly SecretDependencyResourceType Tools = new(Values.Tools);

    public static readonly SecretDependencyResourceType Agents = new(Values.Agents);

    public static readonly SecretDependencyResourceType PhoneNumbers = new(Values.PhoneNumbers);

    public SecretDependencyResourceType(string value)
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
    public static SecretDependencyResourceType FromCustom(string value)
    {
        return new SecretDependencyResourceType(value);
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

    public static bool operator ==(SecretDependencyResourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SecretDependencyResourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SecretDependencyResourceType value) => value.Value;

    public static explicit operator SecretDependencyResourceType(string value) => new(value);

    internal class SecretDependencyResourceTypeSerializer
        : JsonConverter<SecretDependencyResourceType>
    {
        public override SecretDependencyResourceType Read(
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
            return new SecretDependencyResourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SecretDependencyResourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SecretDependencyResourceType ReadAsPropertyName(
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
            return new SecretDependencyResourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SecretDependencyResourceType value,
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
        public const string Tools = "tools";

        public const string Agents = "agents";

        public const string PhoneNumbers = "phone_numbers";
    }
}
