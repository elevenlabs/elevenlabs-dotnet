using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(StartProcedureToolConfigSystemToolType.StartProcedureToolConfigSystemToolTypeSerializer)
)]
[Serializable]
public readonly record struct StartProcedureToolConfigSystemToolType : IStringEnum
{
    public static readonly StartProcedureToolConfigSystemToolType StartProcedure = new(
        Values.StartProcedure
    );

    public StartProcedureToolConfigSystemToolType(string value)
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
    public static StartProcedureToolConfigSystemToolType FromCustom(string value)
    {
        return new StartProcedureToolConfigSystemToolType(value);
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

    public static bool operator ==(StartProcedureToolConfigSystemToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StartProcedureToolConfigSystemToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StartProcedureToolConfigSystemToolType value) =>
        value.Value;

    public static explicit operator StartProcedureToolConfigSystemToolType(string value) =>
        new(value);

    internal class StartProcedureToolConfigSystemToolTypeSerializer
        : JsonConverter<StartProcedureToolConfigSystemToolType>
    {
        public override StartProcedureToolConfigSystemToolType Read(
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
            return new StartProcedureToolConfigSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartProcedureToolConfigSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartProcedureToolConfigSystemToolType ReadAsPropertyName(
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
            return new StartProcedureToolConfigSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartProcedureToolConfigSystemToolType value,
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
        public const string StartProcedure = "start_procedure";
    }
}
