using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UpdateSimulationTestRequestType.UpdateSimulationTestRequestTypeSerializer))]
[Serializable]
public readonly record struct UpdateSimulationTestRequestType : IStringEnum
{
    public static readonly UpdateSimulationTestRequestType Simulation = new(Values.Simulation);

    public UpdateSimulationTestRequestType(string value)
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
    public static UpdateSimulationTestRequestType FromCustom(string value)
    {
        return new UpdateSimulationTestRequestType(value);
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

    public static bool operator ==(UpdateSimulationTestRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateSimulationTestRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSimulationTestRequestType value) => value.Value;

    public static explicit operator UpdateSimulationTestRequestType(string value) => new(value);

    internal class UpdateSimulationTestRequestTypeSerializer
        : JsonConverter<UpdateSimulationTestRequestType>
    {
        public override UpdateSimulationTestRequestType Read(
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
            return new UpdateSimulationTestRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSimulationTestRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSimulationTestRequestType ReadAsPropertyName(
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
            return new UpdateSimulationTestRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSimulationTestRequestType value,
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
