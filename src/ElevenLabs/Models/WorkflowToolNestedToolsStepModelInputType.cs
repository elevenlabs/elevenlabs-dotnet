using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkflowToolNestedToolsStepModelInputType.WorkflowToolNestedToolsStepModelInputTypeSerializer)
)]
[Serializable]
public readonly record struct WorkflowToolNestedToolsStepModelInputType : IStringEnum
{
    public static readonly WorkflowToolNestedToolsStepModelInputType NestedTools = new(
        Values.NestedTools
    );

    public WorkflowToolNestedToolsStepModelInputType(string value)
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
    public static WorkflowToolNestedToolsStepModelInputType FromCustom(string value)
    {
        return new WorkflowToolNestedToolsStepModelInputType(value);
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
        WorkflowToolNestedToolsStepModelInputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WorkflowToolNestedToolsStepModelInputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowToolNestedToolsStepModelInputType value) =>
        value.Value;

    public static explicit operator WorkflowToolNestedToolsStepModelInputType(string value) =>
        new(value);

    internal class WorkflowToolNestedToolsStepModelInputTypeSerializer
        : JsonConverter<WorkflowToolNestedToolsStepModelInputType>
    {
        public override WorkflowToolNestedToolsStepModelInputType Read(
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
            return new WorkflowToolNestedToolsStepModelInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowToolNestedToolsStepModelInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowToolNestedToolsStepModelInputType ReadAsPropertyName(
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
            return new WorkflowToolNestedToolsStepModelInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowToolNestedToolsStepModelInputType value,
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
        public const string NestedTools = "nested_tools";
    }
}
