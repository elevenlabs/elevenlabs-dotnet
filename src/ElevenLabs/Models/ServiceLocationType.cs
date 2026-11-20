using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Where a classic service is delivered.</summary>
[JsonConverter(typeof(ServiceLocationType.ServiceLocationTypeSerializer))]
[Serializable]
public readonly record struct ServiceLocationType : IStringEnum
{
    public static readonly ServiceLocationType Business = new(Values.Business);

    public static readonly ServiceLocationType Customer = new(Values.Customer);

    public ServiceLocationType(string value)
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
    public static ServiceLocationType FromCustom(string value)
    {
        return new ServiceLocationType(value);
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

    public static bool operator ==(ServiceLocationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ServiceLocationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ServiceLocationType value) => value.Value;

    public static explicit operator ServiceLocationType(string value) => new(value);

    internal class ServiceLocationTypeSerializer : JsonConverter<ServiceLocationType>
    {
        public override ServiceLocationType Read(
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
            return new ServiceLocationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ServiceLocationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ServiceLocationType ReadAsPropertyName(
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
            return new ServiceLocationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ServiceLocationType value,
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
        public const string Business = "business";

        public const string Customer = "customer";
    }
}
