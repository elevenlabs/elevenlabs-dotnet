using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkflowResultConditionModelOutputType.WorkflowResultConditionModelOutputTypeSerializer)
)]
[Serializable]
public readonly record struct WorkflowResultConditionModelOutputType : IStringEnum
{
    public static readonly WorkflowResultConditionModelOutputType Result = new(Values.Result);

    public WorkflowResultConditionModelOutputType(string value)
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
    public static WorkflowResultConditionModelOutputType FromCustom(string value)
    {
        return new WorkflowResultConditionModelOutputType(value);
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

    public static bool operator ==(WorkflowResultConditionModelOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowResultConditionModelOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowResultConditionModelOutputType value) =>
        value.Value;

    public static explicit operator WorkflowResultConditionModelOutputType(string value) =>
        new(value);

    internal class WorkflowResultConditionModelOutputTypeSerializer
        : JsonConverter<WorkflowResultConditionModelOutputType>
    {
        public override WorkflowResultConditionModelOutputType Read(
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
            return new WorkflowResultConditionModelOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowResultConditionModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowResultConditionModelOutputType ReadAsPropertyName(
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
            return new WorkflowResultConditionModelOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowResultConditionModelOutputType value,
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
        public const string Result = "result";
    }
}
