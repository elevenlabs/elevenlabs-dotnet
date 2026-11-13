using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PendingCancellationResponseModelKind.PendingCancellationResponseModelKindSerializer)
)]
[Serializable]
public readonly record struct PendingCancellationResponseModelKind : IStringEnum
{
    public static readonly PendingCancellationResponseModelKind Cancellation = new(
        Values.Cancellation
    );

    public PendingCancellationResponseModelKind(string value)
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
    public static PendingCancellationResponseModelKind FromCustom(string value)
    {
        return new PendingCancellationResponseModelKind(value);
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

    public static bool operator ==(PendingCancellationResponseModelKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PendingCancellationResponseModelKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PendingCancellationResponseModelKind value) =>
        value.Value;

    public static explicit operator PendingCancellationResponseModelKind(string value) =>
        new(value);

    internal class PendingCancellationResponseModelKindSerializer
        : JsonConverter<PendingCancellationResponseModelKind>
    {
        public override PendingCancellationResponseModelKind Read(
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
            return new PendingCancellationResponseModelKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PendingCancellationResponseModelKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PendingCancellationResponseModelKind ReadAsPropertyName(
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
            return new PendingCancellationResponseModelKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PendingCancellationResponseModelKind value,
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
        public const string Cancellation = "cancellation";
    }
}
