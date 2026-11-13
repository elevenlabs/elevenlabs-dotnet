using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListClientInteractionsParamsSmbToolType.ListClientInteractionsParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct ListClientInteractionsParamsSmbToolType : IStringEnum
{
    public static readonly ListClientInteractionsParamsSmbToolType ListClientInteractions = new(
        Values.ListClientInteractions
    );

    public ListClientInteractionsParamsSmbToolType(string value)
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
    public static ListClientInteractionsParamsSmbToolType FromCustom(string value)
    {
        return new ListClientInteractionsParamsSmbToolType(value);
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

    public static bool operator ==(ListClientInteractionsParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListClientInteractionsParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListClientInteractionsParamsSmbToolType value) =>
        value.Value;

    public static explicit operator ListClientInteractionsParamsSmbToolType(string value) =>
        new(value);

    internal class ListClientInteractionsParamsSmbToolTypeSerializer
        : JsonConverter<ListClientInteractionsParamsSmbToolType>
    {
        public override ListClientInteractionsParamsSmbToolType Read(
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
            return new ListClientInteractionsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListClientInteractionsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListClientInteractionsParamsSmbToolType ReadAsPropertyName(
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
            return new ListClientInteractionsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListClientInteractionsParamsSmbToolType value,
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
        public const string ListClientInteractions = "list_client_interactions";
    }
}
