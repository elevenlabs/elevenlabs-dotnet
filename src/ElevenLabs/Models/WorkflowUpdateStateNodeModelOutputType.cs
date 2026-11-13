using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkflowUpdateStateNodeModelOutputType.WorkflowUpdateStateNodeModelOutputTypeSerializer)
)]
[Serializable]
public readonly record struct WorkflowUpdateStateNodeModelOutputType : IStringEnum
{
    public static readonly WorkflowUpdateStateNodeModelOutputType UpdateState = new(
        Values.UpdateState
    );

    public WorkflowUpdateStateNodeModelOutputType(string value)
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
    public static WorkflowUpdateStateNodeModelOutputType FromCustom(string value)
    {
        return new WorkflowUpdateStateNodeModelOutputType(value);
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

    public static bool operator ==(WorkflowUpdateStateNodeModelOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowUpdateStateNodeModelOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowUpdateStateNodeModelOutputType value) =>
        value.Value;

    public static explicit operator WorkflowUpdateStateNodeModelOutputType(string value) =>
        new(value);

    internal class WorkflowUpdateStateNodeModelOutputTypeSerializer
        : JsonConverter<WorkflowUpdateStateNodeModelOutputType>
    {
        public override WorkflowUpdateStateNodeModelOutputType Read(
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
            return new WorkflowUpdateStateNodeModelOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowUpdateStateNodeModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowUpdateStateNodeModelOutputType ReadAsPropertyName(
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
            return new WorkflowUpdateStateNodeModelOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowUpdateStateNodeModelOutputType value,
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
        public const string UpdateState = "update_state";
    }
}
