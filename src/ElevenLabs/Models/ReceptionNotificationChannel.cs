using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceptionNotificationChannel.ReceptionNotificationChannelSerializer))]
[Serializable]
public readonly record struct ReceptionNotificationChannel : IStringEnum
{
    public static readonly ReceptionNotificationChannel Email = new(Values.Email);

    public static readonly ReceptionNotificationChannel Sms = new(Values.Sms);

    public ReceptionNotificationChannel(string value)
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
    public static ReceptionNotificationChannel FromCustom(string value)
    {
        return new ReceptionNotificationChannel(value);
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

    public static bool operator ==(ReceptionNotificationChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionNotificationChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionNotificationChannel value) => value.Value;

    public static explicit operator ReceptionNotificationChannel(string value) => new(value);

    internal class ReceptionNotificationChannelSerializer
        : JsonConverter<ReceptionNotificationChannel>
    {
        public override ReceptionNotificationChannel Read(
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
            return new ReceptionNotificationChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionNotificationChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionNotificationChannel ReadAsPropertyName(
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
            return new ReceptionNotificationChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionNotificationChannel value,
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
        public const string Email = "email";

        public const string Sms = "sms";
    }
}
