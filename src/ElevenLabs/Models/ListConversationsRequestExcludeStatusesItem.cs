using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(
    typeof(ListConversationsRequestExcludeStatusesItem.ListConversationsRequestExcludeStatusesItemSerializer)
)]
[Serializable]
public readonly record struct ListConversationsRequestExcludeStatusesItem : IStringEnum
{
    public static readonly ListConversationsRequestExcludeStatusesItem Initiated = new(
        Values.Initiated
    );

    public static readonly ListConversationsRequestExcludeStatusesItem InProgress = new(
        Values.InProgress
    );

    public static readonly ListConversationsRequestExcludeStatusesItem Processing = new(
        Values.Processing
    );

    public static readonly ListConversationsRequestExcludeStatusesItem Done = new(Values.Done);

    public static readonly ListConversationsRequestExcludeStatusesItem Failed = new(Values.Failed);

    public ListConversationsRequestExcludeStatusesItem(string value)
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
    public static ListConversationsRequestExcludeStatusesItem FromCustom(string value)
    {
        return new ListConversationsRequestExcludeStatusesItem(value);
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
        ListConversationsRequestExcludeStatusesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListConversationsRequestExcludeStatusesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListConversationsRequestExcludeStatusesItem value) =>
        value.Value;

    public static explicit operator ListConversationsRequestExcludeStatusesItem(string value) =>
        new(value);

    internal class ListConversationsRequestExcludeStatusesItemSerializer
        : JsonConverter<ListConversationsRequestExcludeStatusesItem>
    {
        public override ListConversationsRequestExcludeStatusesItem Read(
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
            return new ListConversationsRequestExcludeStatusesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListConversationsRequestExcludeStatusesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListConversationsRequestExcludeStatusesItem ReadAsPropertyName(
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
            return new ListConversationsRequestExcludeStatusesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListConversationsRequestExcludeStatusesItem value,
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
