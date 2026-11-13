using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Defines the MCP server-level approval policy for tool execution.</summary>
[JsonConverter(typeof(McpApprovalPolicy.McpApprovalPolicySerializer))]
[Serializable]
public readonly record struct McpApprovalPolicy : IStringEnum
{
    public static readonly McpApprovalPolicy AutoApproveAll = new(Values.AutoApproveAll);

    public static readonly McpApprovalPolicy RequireApprovalAll = new(Values.RequireApprovalAll);

    public static readonly McpApprovalPolicy RequireApprovalPerTool = new(
        Values.RequireApprovalPerTool
    );

    public McpApprovalPolicy(string value)
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
    public static McpApprovalPolicy FromCustom(string value)
    {
        return new McpApprovalPolicy(value);
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

    public static bool operator ==(McpApprovalPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpApprovalPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpApprovalPolicy value) => value.Value;

    public static explicit operator McpApprovalPolicy(string value) => new(value);

    internal class McpApprovalPolicySerializer : JsonConverter<McpApprovalPolicy>
    {
        public override McpApprovalPolicy Read(
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
            return new McpApprovalPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpApprovalPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpApprovalPolicy ReadAsPropertyName(
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
            return new McpApprovalPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpApprovalPolicy value,
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
        public const string AutoApproveAll = "auto_approve_all";

        public const string RequireApprovalAll = "require_approval_all";

        public const string RequireApprovalPerTool = "require_approval_per_tool";
    }
}
