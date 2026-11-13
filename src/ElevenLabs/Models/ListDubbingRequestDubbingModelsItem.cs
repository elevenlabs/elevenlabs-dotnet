using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListDubbingRequestDubbingModelsItem.ListDubbingRequestDubbingModelsItemSerializer)
)]
[Serializable]
public readonly record struct ListDubbingRequestDubbingModelsItem : IStringEnum
{
    public static readonly ListDubbingRequestDubbingModelsItem DubbingV1 = new(Values.DubbingV1);

    public static readonly ListDubbingRequestDubbingModelsItem DubbingV2 = new(Values.DubbingV2);

    public ListDubbingRequestDubbingModelsItem(string value)
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
    public static ListDubbingRequestDubbingModelsItem FromCustom(string value)
    {
        return new ListDubbingRequestDubbingModelsItem(value);
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

    public static bool operator ==(ListDubbingRequestDubbingModelsItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestDubbingModelsItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestDubbingModelsItem value) =>
        value.Value;

    public static explicit operator ListDubbingRequestDubbingModelsItem(string value) => new(value);

    internal class ListDubbingRequestDubbingModelsItemSerializer
        : JsonConverter<ListDubbingRequestDubbingModelsItem>
    {
        public override ListDubbingRequestDubbingModelsItem Read(
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
            return new ListDubbingRequestDubbingModelsItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestDubbingModelsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestDubbingModelsItem ReadAsPropertyName(
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
            return new ListDubbingRequestDubbingModelsItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestDubbingModelsItem value,
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
        public const string DubbingV1 = "dubbing_v1";

        public const string DubbingV2 = "dubbing_v2";
    }
}
