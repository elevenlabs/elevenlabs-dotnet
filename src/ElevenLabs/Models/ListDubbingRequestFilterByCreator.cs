using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Filters who created the resources being listed, whether it was the user running the request or someone else that shared the resource with them.</summary>
[JsonConverter(
    typeof(ListDubbingRequestFilterByCreator.ListDubbingRequestFilterByCreatorSerializer)
)]
[Serializable]
public readonly record struct ListDubbingRequestFilterByCreator : IStringEnum
{
    public static readonly ListDubbingRequestFilterByCreator Personal = new(Values.Personal);

    public static readonly ListDubbingRequestFilterByCreator Others = new(Values.Others);

    public static readonly ListDubbingRequestFilterByCreator All = new(Values.All);

    public ListDubbingRequestFilterByCreator(string value)
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
    public static ListDubbingRequestFilterByCreator FromCustom(string value)
    {
        return new ListDubbingRequestFilterByCreator(value);
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

    public static bool operator ==(ListDubbingRequestFilterByCreator value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestFilterByCreator value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestFilterByCreator value) => value.Value;

    public static explicit operator ListDubbingRequestFilterByCreator(string value) => new(value);

    internal class ListDubbingRequestFilterByCreatorSerializer
        : JsonConverter<ListDubbingRequestFilterByCreator>
    {
        public override ListDubbingRequestFilterByCreator Read(
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
            return new ListDubbingRequestFilterByCreator(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestFilterByCreator value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestFilterByCreator ReadAsPropertyName(
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
            return new ListDubbingRequestFilterByCreator(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestFilterByCreator value,
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
        public const string Personal = "personal";

        public const string Others = "others";

        public const string All = "all";
    }
}
