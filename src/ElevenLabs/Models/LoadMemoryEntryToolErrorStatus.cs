using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LoadMemoryEntryToolErrorStatus.LoadMemoryEntryToolErrorStatusSerializer))]
[Serializable]
public readonly record struct LoadMemoryEntryToolErrorStatus : IStringEnum
{
    public static readonly LoadMemoryEntryToolErrorStatus NotFound = new(Values.NotFound);

    public static readonly LoadMemoryEntryToolErrorStatus InvalidId = new(Values.InvalidId);

    public LoadMemoryEntryToolErrorStatus(string value)
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
    public static LoadMemoryEntryToolErrorStatus FromCustom(string value)
    {
        return new LoadMemoryEntryToolErrorStatus(value);
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

    public static bool operator ==(LoadMemoryEntryToolErrorStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LoadMemoryEntryToolErrorStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LoadMemoryEntryToolErrorStatus value) => value.Value;

    public static explicit operator LoadMemoryEntryToolErrorStatus(string value) => new(value);

    internal class LoadMemoryEntryToolErrorStatusSerializer
        : JsonConverter<LoadMemoryEntryToolErrorStatus>
    {
        public override LoadMemoryEntryToolErrorStatus Read(
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
            return new LoadMemoryEntryToolErrorStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LoadMemoryEntryToolErrorStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LoadMemoryEntryToolErrorStatus ReadAsPropertyName(
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
            return new LoadMemoryEntryToolErrorStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LoadMemoryEntryToolErrorStatus value,
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
        public const string NotFound = "not_found";

        public const string InvalidId = "invalid_id";
    }
}
