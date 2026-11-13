using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExternalSyncProvider.ExternalSyncProviderSerializer))]
[Serializable]
public readonly record struct ExternalSyncProvider : IStringEnum
{
    public static readonly ExternalSyncProvider GoogleDrive = new(Values.GoogleDrive);

    public ExternalSyncProvider(string value)
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
    public static ExternalSyncProvider FromCustom(string value)
    {
        return new ExternalSyncProvider(value);
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

    public static bool operator ==(ExternalSyncProvider value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExternalSyncProvider value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExternalSyncProvider value) => value.Value;

    public static explicit operator ExternalSyncProvider(string value) => new(value);

    internal class ExternalSyncProviderSerializer : JsonConverter<ExternalSyncProvider>
    {
        public override ExternalSyncProvider Read(
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
            return new ExternalSyncProvider(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExternalSyncProvider value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExternalSyncProvider ReadAsPropertyName(
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
            return new ExternalSyncProvider(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExternalSyncProvider value,
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
        public const string GoogleDrive = "google_drive";
    }
}
