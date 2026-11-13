using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Music;

[JsonConverter(
    typeof(BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility.BodyCreateMusicFinetuneV1MusicFinetunesPostVisibilitySerializer)
)]
[Serializable]
public readonly record struct BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility : IStringEnum
{
    public static readonly BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility Private = new(
        Values.Private
    );

    public static readonly BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility Workspace = new(
        Values.Workspace
    );

    public BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility(string value)
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
    public static BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility FromCustom(string value)
    {
        return new BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility(value);
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

    public static bool operator ==(
        BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility value
    ) => value.Value;

    public static explicit operator BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility(
        string value
    ) => new(value);

    internal class BodyCreateMusicFinetuneV1MusicFinetunesPostVisibilitySerializer
        : JsonConverter<BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility>
    {
        public override BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility Read(
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
            return new BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility ReadAsPropertyName(
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
            return new BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreateMusicFinetuneV1MusicFinetunesPostVisibility value,
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
        public const string Private = "private";

        public const string Workspace = "workspace";
    }
}
