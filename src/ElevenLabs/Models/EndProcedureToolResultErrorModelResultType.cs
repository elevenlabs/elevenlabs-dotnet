using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(EndProcedureToolResultErrorModelResultType.EndProcedureToolResultErrorModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct EndProcedureToolResultErrorModelResultType : IStringEnum
{
    public static readonly EndProcedureToolResultErrorModelResultType EndProcedureError = new(
        Values.EndProcedureError
    );

    public EndProcedureToolResultErrorModelResultType(string value)
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
    public static EndProcedureToolResultErrorModelResultType FromCustom(string value)
    {
        return new EndProcedureToolResultErrorModelResultType(value);
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

    public static bool operator ==(
        EndProcedureToolResultErrorModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EndProcedureToolResultErrorModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(EndProcedureToolResultErrorModelResultType value) =>
        value.Value;

    public static explicit operator EndProcedureToolResultErrorModelResultType(string value) =>
        new(value);

    internal class EndProcedureToolResultErrorModelResultTypeSerializer
        : JsonConverter<EndProcedureToolResultErrorModelResultType>
    {
        public override EndProcedureToolResultErrorModelResultType Read(
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
            return new EndProcedureToolResultErrorModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndProcedureToolResultErrorModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EndProcedureToolResultErrorModelResultType ReadAsPropertyName(
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
            return new EndProcedureToolResultErrorModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EndProcedureToolResultErrorModelResultType value,
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
        public const string EndProcedureError = "end_procedure_error";
    }
}
