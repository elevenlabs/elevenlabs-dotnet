using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationSummaryMessageModelRole.ConversationSummaryMessageModelRoleSerializer)
)]
[Serializable]
public readonly record struct ConversationSummaryMessageModelRole : IStringEnum
{
    public static readonly ConversationSummaryMessageModelRole User = new(Values.User);

    public static readonly ConversationSummaryMessageModelRole Agent = new(Values.Agent);

    public ConversationSummaryMessageModelRole(string value)
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
    public static ConversationSummaryMessageModelRole FromCustom(string value)
    {
        return new ConversationSummaryMessageModelRole(value);
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

    public static bool operator ==(ConversationSummaryMessageModelRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationSummaryMessageModelRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationSummaryMessageModelRole value) =>
        value.Value;

    public static explicit operator ConversationSummaryMessageModelRole(string value) => new(value);

    internal class ConversationSummaryMessageModelRoleSerializer
        : JsonConverter<ConversationSummaryMessageModelRole>
    {
        public override ConversationSummaryMessageModelRole Read(
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
            return new ConversationSummaryMessageModelRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationSummaryMessageModelRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationSummaryMessageModelRole ReadAsPropertyName(
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
            return new ConversationSummaryMessageModelRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationSummaryMessageModelRole value,
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
        public const string User = "user";

        public const string Agent = "agent";
    }
}
