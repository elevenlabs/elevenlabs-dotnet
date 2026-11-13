using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowEndNodeModelInputType.WorkflowEndNodeModelInputTypeSerializer))]
[Serializable]
public readonly record struct WorkflowEndNodeModelInputType : IStringEnum
{
    public static readonly WorkflowEndNodeModelInputType End = new(Values.End);

    public WorkflowEndNodeModelInputType(string value)
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
    public static WorkflowEndNodeModelInputType FromCustom(string value)
    {
        return new WorkflowEndNodeModelInputType(value);
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

    public static bool operator ==(WorkflowEndNodeModelInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowEndNodeModelInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowEndNodeModelInputType value) => value.Value;

    public static explicit operator WorkflowEndNodeModelInputType(string value) => new(value);

    internal class WorkflowEndNodeModelInputTypeSerializer
        : JsonConverter<WorkflowEndNodeModelInputType>
    {
        public override WorkflowEndNodeModelInputType Read(
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
            return new WorkflowEndNodeModelInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowEndNodeModelInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowEndNodeModelInputType ReadAsPropertyName(
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
            return new WorkflowEndNodeModelInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowEndNodeModelInputType value,
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
        public const string End = "end";
    }
}
