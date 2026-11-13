using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(EndProcedureToolResultSuccessModelResultType.EndProcedureToolResultSuccessModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct EndProcedureToolResultSuccessModelResultType : IStringEnum
{
    public static readonly EndProcedureToolResultSuccessModelResultType EndProcedureSuccess = new(
        Values.EndProcedureSuccess
    );

    public EndProcedureToolResultSuccessModelResultType(string value)
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
    public static EndProcedureToolResultSuccessModelResultType FromCustom(string value)
    {
        return new EndProcedureToolResultSuccessModelResultType(value);
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
        EndProcedureToolResultSuccessModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EndProcedureToolResultSuccessModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(EndProcedureToolResultSuccessModelResultType value) =>
        value.Value;

    public static explicit operator EndProcedureToolResultSuccessModelResultType(string value) =>
        new(value);

    internal class EndProcedureToolResultSuccessModelResultTypeSerializer
        : JsonConverter<EndProcedureToolResultSuccessModelResultType>
    {
        public override EndProcedureToolResultSuccessModelResultType Read(
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
            return new EndProcedureToolResultSuccessModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndProcedureToolResultSuccessModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EndProcedureToolResultSuccessModelResultType ReadAsPropertyName(
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
            return new EndProcedureToolResultSuccessModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EndProcedureToolResultSuccessModelResultType value,
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
        public const string EndProcedureSuccess = "end_procedure_success";
    }
}
