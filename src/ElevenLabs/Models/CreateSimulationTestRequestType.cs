using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateSimulationTestRequestType.CreateSimulationTestRequestTypeSerializer))]
[Serializable]
public readonly record struct CreateSimulationTestRequestType : IStringEnum
{
    public static readonly CreateSimulationTestRequestType Simulation = new(Values.Simulation);

    public CreateSimulationTestRequestType(string value)
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
    public static CreateSimulationTestRequestType FromCustom(string value)
    {
        return new CreateSimulationTestRequestType(value);
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

    public static bool operator ==(CreateSimulationTestRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSimulationTestRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSimulationTestRequestType value) => value.Value;

    public static explicit operator CreateSimulationTestRequestType(string value) => new(value);

    internal class CreateSimulationTestRequestTypeSerializer
        : JsonConverter<CreateSimulationTestRequestType>
    {
        public override CreateSimulationTestRequestType Read(
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
            return new CreateSimulationTestRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSimulationTestRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSimulationTestRequestType ReadAsPropertyName(
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
            return new CreateSimulationTestRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSimulationTestRequestType value,
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
        public const string Simulation = "simulation";
    }
}
