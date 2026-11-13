using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AsyncConversationMetadataDeliveryStatus.AsyncConversationMetadataDeliveryStatusSerializer)
)]
[Serializable]
public readonly record struct AsyncConversationMetadataDeliveryStatus : IStringEnum
{
    public static readonly AsyncConversationMetadataDeliveryStatus Pending = new(Values.Pending);

    public static readonly AsyncConversationMetadataDeliveryStatus Success = new(Values.Success);

    public static readonly AsyncConversationMetadataDeliveryStatus Failed = new(Values.Failed);

    public AsyncConversationMetadataDeliveryStatus(string value)
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
    public static AsyncConversationMetadataDeliveryStatus FromCustom(string value)
    {
        return new AsyncConversationMetadataDeliveryStatus(value);
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

    public static bool operator ==(AsyncConversationMetadataDeliveryStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AsyncConversationMetadataDeliveryStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AsyncConversationMetadataDeliveryStatus value) =>
        value.Value;

    public static explicit operator AsyncConversationMetadataDeliveryStatus(string value) =>
        new(value);

    internal class AsyncConversationMetadataDeliveryStatusSerializer
        : JsonConverter<AsyncConversationMetadataDeliveryStatus>
    {
        public override AsyncConversationMetadataDeliveryStatus Read(
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
            return new AsyncConversationMetadataDeliveryStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AsyncConversationMetadataDeliveryStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AsyncConversationMetadataDeliveryStatus ReadAsPropertyName(
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
            return new AsyncConversationMetadataDeliveryStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AsyncConversationMetadataDeliveryStatus value,
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
        public const string Pending = "pending";

        public const string Success = "success";

        public const string Failed = "failed";
    }
}
