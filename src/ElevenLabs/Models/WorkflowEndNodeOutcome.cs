using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether reaching an End node completes successfully or fails.</summary>
[JsonConverter(typeof(WorkflowEndNodeOutcome.WorkflowEndNodeOutcomeSerializer))]
[Serializable]
public readonly record struct WorkflowEndNodeOutcome : IStringEnum
{
    public static readonly WorkflowEndNodeOutcome Success = new(Values.Success);

    public static readonly WorkflowEndNodeOutcome Failure = new(Values.Failure);

    public WorkflowEndNodeOutcome(string value)
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
    public static WorkflowEndNodeOutcome FromCustom(string value)
    {
        return new WorkflowEndNodeOutcome(value);
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

    public static bool operator ==(WorkflowEndNodeOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowEndNodeOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowEndNodeOutcome value) => value.Value;

    public static explicit operator WorkflowEndNodeOutcome(string value) => new(value);

    internal class WorkflowEndNodeOutcomeSerializer : JsonConverter<WorkflowEndNodeOutcome>
    {
        public override WorkflowEndNodeOutcome Read(
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
            return new WorkflowEndNodeOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowEndNodeOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowEndNodeOutcome ReadAsPropertyName(
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
            return new WorkflowEndNodeOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowEndNodeOutcome value,
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
        public const string Success = "success";

        public const string Failure = "failure";
    }
}
