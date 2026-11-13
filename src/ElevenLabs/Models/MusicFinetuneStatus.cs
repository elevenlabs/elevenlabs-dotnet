using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicFinetuneStatus.MusicFinetuneStatusSerializer))]
[Serializable]
public readonly record struct MusicFinetuneStatus : IStringEnum
{
    public static readonly MusicFinetuneStatus Pending = new(Values.Pending);

    public static readonly MusicFinetuneStatus InProgress = new(Values.InProgress);

    public static readonly MusicFinetuneStatus Completed = new(Values.Completed);

    public static readonly MusicFinetuneStatus Failed = new(Values.Failed);

    public static readonly MusicFinetuneStatus Blocked = new(Values.Blocked);

    public MusicFinetuneStatus(string value)
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
    public static MusicFinetuneStatus FromCustom(string value)
    {
        return new MusicFinetuneStatus(value);
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

    public static bool operator ==(MusicFinetuneStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicFinetuneStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicFinetuneStatus value) => value.Value;

    public static explicit operator MusicFinetuneStatus(string value) => new(value);

    internal class MusicFinetuneStatusSerializer : JsonConverter<MusicFinetuneStatus>
    {
        public override MusicFinetuneStatus Read(
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
            return new MusicFinetuneStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicFinetuneStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicFinetuneStatus ReadAsPropertyName(
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
            return new MusicFinetuneStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicFinetuneStatus value,
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

        public const string InProgress = "in_progress";

        public const string Completed = "completed";

        public const string Failed = "failed";

        public const string Blocked = "blocked";
    }
}
