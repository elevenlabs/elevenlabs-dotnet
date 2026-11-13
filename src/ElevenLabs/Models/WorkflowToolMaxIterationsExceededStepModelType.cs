using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkflowToolMaxIterationsExceededStepModelType.WorkflowToolMaxIterationsExceededStepModelTypeSerializer)
)]
[Serializable]
public readonly record struct WorkflowToolMaxIterationsExceededStepModelType : IStringEnum
{
    public static readonly WorkflowToolMaxIterationsExceededStepModelType MaxIterationsExceeded =
        new(Values.MaxIterationsExceeded);

    public WorkflowToolMaxIterationsExceededStepModelType(string value)
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
    public static WorkflowToolMaxIterationsExceededStepModelType FromCustom(string value)
    {
        return new WorkflowToolMaxIterationsExceededStepModelType(value);
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
        WorkflowToolMaxIterationsExceededStepModelType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WorkflowToolMaxIterationsExceededStepModelType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowToolMaxIterationsExceededStepModelType value) =>
        value.Value;

    public static explicit operator WorkflowToolMaxIterationsExceededStepModelType(string value) =>
        new(value);

    internal class WorkflowToolMaxIterationsExceededStepModelTypeSerializer
        : JsonConverter<WorkflowToolMaxIterationsExceededStepModelType>
    {
        public override WorkflowToolMaxIterationsExceededStepModelType Read(
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
            return new WorkflowToolMaxIterationsExceededStepModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowToolMaxIterationsExceededStepModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowToolMaxIterationsExceededStepModelType ReadAsPropertyName(
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
            return new WorkflowToolMaxIterationsExceededStepModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowToolMaxIterationsExceededStepModelType value,
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
        public const string MaxIterationsExceeded = "max_iterations_exceeded";
    }
}
