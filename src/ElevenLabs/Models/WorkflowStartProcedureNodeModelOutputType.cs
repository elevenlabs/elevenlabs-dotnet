using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkflowStartProcedureNodeModelOutputType.WorkflowStartProcedureNodeModelOutputTypeSerializer)
)]
[Serializable]
public readonly record struct WorkflowStartProcedureNodeModelOutputType : IStringEnum
{
    public static readonly WorkflowStartProcedureNodeModelOutputType StartProcedure = new(
        Values.StartProcedure
    );

    public WorkflowStartProcedureNodeModelOutputType(string value)
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
    public static WorkflowStartProcedureNodeModelOutputType FromCustom(string value)
    {
        return new WorkflowStartProcedureNodeModelOutputType(value);
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
        WorkflowStartProcedureNodeModelOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WorkflowStartProcedureNodeModelOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowStartProcedureNodeModelOutputType value) =>
        value.Value;

    public static explicit operator WorkflowStartProcedureNodeModelOutputType(string value) =>
        new(value);

    internal class WorkflowStartProcedureNodeModelOutputTypeSerializer
        : JsonConverter<WorkflowStartProcedureNodeModelOutputType>
    {
        public override WorkflowStartProcedureNodeModelOutputType Read(
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
            return new WorkflowStartProcedureNodeModelOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowStartProcedureNodeModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowStartProcedureNodeModelOutputType ReadAsPropertyName(
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
            return new WorkflowStartProcedureNodeModelOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowStartProcedureNodeModelOutputType value,
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
