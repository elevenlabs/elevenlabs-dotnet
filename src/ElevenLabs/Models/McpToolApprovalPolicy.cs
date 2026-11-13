using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Defines the tool-level approval policy.</summary>
[JsonConverter(typeof(McpToolApprovalPolicy.McpToolApprovalPolicySerializer))]
[Serializable]
public readonly record struct McpToolApprovalPolicy : IStringEnum
{
    public static readonly McpToolApprovalPolicy AutoApproved = new(Values.AutoApproved);

    public static readonly McpToolApprovalPolicy RequiresApproval = new(Values.RequiresApproval);

    public McpToolApprovalPolicy(string value)
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
    public static McpToolApprovalPolicy FromCustom(string value)
    {
        return new McpToolApprovalPolicy(value);
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

    public static bool operator ==(McpToolApprovalPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpToolApprovalPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpToolApprovalPolicy value) => value.Value;

    public static explicit operator McpToolApprovalPolicy(string value) => new(value);

    internal class McpToolApprovalPolicySerializer : JsonConverter<McpToolApprovalPolicy>
    {
        public override McpToolApprovalPolicy Read(
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
            return new McpToolApprovalPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpToolApprovalPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpToolApprovalPolicy ReadAsPropertyName(
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
            return new McpToolApprovalPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpToolApprovalPolicy value,
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
        public const string AutoApproved = "auto_approved";

        public const string RequiresApproval = "requires_approval";
    }
}
