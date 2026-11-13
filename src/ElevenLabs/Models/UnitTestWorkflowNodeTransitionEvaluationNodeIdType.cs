using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UnitTestWorkflowNodeTransitionEvaluationNodeIdType.UnitTestWorkflowNodeTransitionEvaluationNodeIdTypeSerializer)
)]
[Serializable]
public readonly record struct UnitTestWorkflowNodeTransitionEvaluationNodeIdType : IStringEnum
{
    public static readonly UnitTestWorkflowNodeTransitionEvaluationNodeIdType NodeId = new(
        Values.NodeId
    );

    public UnitTestWorkflowNodeTransitionEvaluationNodeIdType(string value)
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
    public static UnitTestWorkflowNodeTransitionEvaluationNodeIdType FromCustom(string value)
    {
        return new UnitTestWorkflowNodeTransitionEvaluationNodeIdType(value);
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
        UnitTestWorkflowNodeTransitionEvaluationNodeIdType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UnitTestWorkflowNodeTransitionEvaluationNodeIdType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        UnitTestWorkflowNodeTransitionEvaluationNodeIdType value
    ) => value.Value;

    public static explicit operator UnitTestWorkflowNodeTransitionEvaluationNodeIdType(
        string value
    ) => new(value);

    internal class UnitTestWorkflowNodeTransitionEvaluationNodeIdTypeSerializer
        : JsonConverter<UnitTestWorkflowNodeTransitionEvaluationNodeIdType>
    {
        public override UnitTestWorkflowNodeTransitionEvaluationNodeIdType Read(
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
            return new UnitTestWorkflowNodeTransitionEvaluationNodeIdType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnitTestWorkflowNodeTransitionEvaluationNodeIdType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UnitTestWorkflowNodeTransitionEvaluationNodeIdType ReadAsPropertyName(
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
            return new UnitTestWorkflowNodeTransitionEvaluationNodeIdType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UnitTestWorkflowNodeTransitionEvaluationNodeIdType value,
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
        public const string NodeId = "node_id";
    }
}
