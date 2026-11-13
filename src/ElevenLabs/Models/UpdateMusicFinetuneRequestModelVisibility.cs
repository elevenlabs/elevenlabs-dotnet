using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Music;

[JsonConverter(
    typeof(UpdateMusicFinetuneRequestModelVisibility.UpdateMusicFinetuneRequestModelVisibilitySerializer)
)]
[Serializable]
public readonly record struct UpdateMusicFinetuneRequestModelVisibility : IStringEnum
{
    public static readonly UpdateMusicFinetuneRequestModelVisibility Private = new(Values.Private);

    public static readonly UpdateMusicFinetuneRequestModelVisibility Workspace = new(
        Values.Workspace
    );

    public UpdateMusicFinetuneRequestModelVisibility(string value)
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
    public static UpdateMusicFinetuneRequestModelVisibility FromCustom(string value)
    {
        return new UpdateMusicFinetuneRequestModelVisibility(value);
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
        UpdateMusicFinetuneRequestModelVisibility value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateMusicFinetuneRequestModelVisibility value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateMusicFinetuneRequestModelVisibility value) =>
        value.Value;

    public static explicit operator UpdateMusicFinetuneRequestModelVisibility(string value) =>
        new(value);

    internal class UpdateMusicFinetuneRequestModelVisibilitySerializer
        : JsonConverter<UpdateMusicFinetuneRequestModelVisibility>
    {
        public override UpdateMusicFinetuneRequestModelVisibility Read(
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
            return new UpdateMusicFinetuneRequestModelVisibility(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateMusicFinetuneRequestModelVisibility value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateMusicFinetuneRequestModelVisibility ReadAsPropertyName(
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
            return new UpdateMusicFinetuneRequestModelVisibility(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateMusicFinetuneRequestModelVisibility value,
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
