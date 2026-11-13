using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WhatsAppCallPermissionRequestState.WhatsAppCallPermissionRequestStateSerializer)
)]
[Serializable]
public readonly record struct WhatsAppCallPermissionRequestState : IStringEnum
{
    public static readonly WhatsAppCallPermissionRequestState Blocked = new(Values.Blocked);

    public static readonly WhatsAppCallPermissionRequestState Sent = new(Values.Sent);

    public static readonly WhatsAppCallPermissionRequestState Accepted = new(Values.Accepted);

    public static readonly WhatsAppCallPermissionRequestState Declined = new(Values.Declined);

    public WhatsAppCallPermissionRequestState(string value)
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
    public static WhatsAppCallPermissionRequestState FromCustom(string value)
    {
        return new WhatsAppCallPermissionRequestState(value);
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

    public static bool operator ==(WhatsAppCallPermissionRequestState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WhatsAppCallPermissionRequestState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WhatsAppCallPermissionRequestState value) => value.Value;

    public static explicit operator WhatsAppCallPermissionRequestState(string value) => new(value);

    internal class WhatsAppCallPermissionRequestStateSerializer
        : JsonConverter<WhatsAppCallPermissionRequestState>
    {
        public override WhatsAppCallPermissionRequestState Read(
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
            return new WhatsAppCallPermissionRequestState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppCallPermissionRequestState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WhatsAppCallPermissionRequestState ReadAsPropertyName(
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
            return new WhatsAppCallPermissionRequestState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppCallPermissionRequestState value,
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
        public const string Blocked = "blocked";

        public const string Sent = "sent";

        public const string Accepted = "accepted";

        public const string Declined = "declined";
    }
}
