using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListDubbingRequestCreationSourcesItem.ListDubbingRequestCreationSourcesItemSerializer)
)]
[Serializable]
public readonly record struct ListDubbingRequestCreationSourcesItem : IStringEnum
{
    public static readonly ListDubbingRequestCreationSourcesItem FlowNode = new(Values.FlowNode);

    public static readonly ListDubbingRequestCreationSourcesItem DubbingUi = new(Values.DubbingUi);

    public static readonly ListDubbingRequestCreationSourcesItem DubbingApi = new(
        Values.DubbingApi
    );

    public ListDubbingRequestCreationSourcesItem(string value)
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
    public static ListDubbingRequestCreationSourcesItem FromCustom(string value)
    {
        return new ListDubbingRequestCreationSourcesItem(value);
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

    public static bool operator ==(ListDubbingRequestCreationSourcesItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestCreationSourcesItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestCreationSourcesItem value) =>
        value.Value;

    public static explicit operator ListDubbingRequestCreationSourcesItem(string value) =>
        new(value);

    internal class ListDubbingRequestCreationSourcesItemSerializer
        : JsonConverter<ListDubbingRequestCreationSourcesItem>
    {
        public override ListDubbingRequestCreationSourcesItem Read(
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
            return new ListDubbingRequestCreationSourcesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestCreationSourcesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestCreationSourcesItem ReadAsPropertyName(
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
            return new ListDubbingRequestCreationSourcesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestCreationSourcesItem value,
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
        public const string FlowNode = "flow_node";

        public const string DubbingUi = "dubbing_ui";

        public const string DubbingApi = "dubbing_api";
    }
}
