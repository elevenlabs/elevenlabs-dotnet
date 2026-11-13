using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.Conversations;

[JsonConverter(
    typeof(TextSearchMessagesRequestExcludeStatusesItem.TextSearchMessagesRequestExcludeStatusesItemSerializer)
)]
[Serializable]
public readonly record struct TextSearchMessagesRequestExcludeStatusesItem : IStringEnum
{
    public static readonly TextSearchMessagesRequestExcludeStatusesItem Initiated = new(
        Values.Initiated
    );

    public static readonly TextSearchMessagesRequestExcludeStatusesItem InProgress = new(
        Values.InProgress
    );

    public static readonly TextSearchMessagesRequestExcludeStatusesItem Processing = new(
        Values.Processing
    );

    public static readonly TextSearchMessagesRequestExcludeStatusesItem Done = new(Values.Done);

    public static readonly TextSearchMessagesRequestExcludeStatusesItem Failed = new(Values.Failed);

    public TextSearchMessagesRequestExcludeStatusesItem(string value)
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
    public static TextSearchMessagesRequestExcludeStatusesItem FromCustom(string value)
    {
        return new TextSearchMessagesRequestExcludeStatusesItem(value);
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
        TextSearchMessagesRequestExcludeStatusesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TextSearchMessagesRequestExcludeStatusesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TextSearchMessagesRequestExcludeStatusesItem value) =>
        value.Value;

    public static explicit operator TextSearchMessagesRequestExcludeStatusesItem(string value) =>
        new(value);

    internal class TextSearchMessagesRequestExcludeStatusesItemSerializer
        : JsonConverter<TextSearchMessagesRequestExcludeStatusesItem>
    {
        public override TextSearchMessagesRequestExcludeStatusesItem Read(
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
            return new TextSearchMessagesRequestExcludeStatusesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextSearchMessagesRequestExcludeStatusesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextSearchMessagesRequestExcludeStatusesItem ReadAsPropertyName(
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
            return new TextSearchMessagesRequestExcludeStatusesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextSearchMessagesRequestExcludeStatusesItem value,
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
        public const string Initiated = "initiated";

        public const string InProgress = "in-progress";

        public const string Processing = "processing";

        public const string Done = "done";

        public const string Failed = "failed";
    }
}
