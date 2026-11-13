using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ChatSourceMedium.ChatSourceMediumSerializer))]
[Serializable]
public readonly record struct ChatSourceMedium : IStringEnum
{
    public static readonly ChatSourceMedium Audio = new(Values.Audio);

    public static readonly ChatSourceMedium Dtmf = new(Values.Dtmf);

    public static readonly ChatSourceMedium Text = new(Values.Text);

    public static readonly ChatSourceMedium Image = new(Values.Image);

    public static readonly ChatSourceMedium File = new(Values.File);

    public ChatSourceMedium(string value)
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
    public static ChatSourceMedium FromCustom(string value)
    {
        return new ChatSourceMedium(value);
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

    public static bool operator ==(ChatSourceMedium value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChatSourceMedium value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChatSourceMedium value) => value.Value;

    public static explicit operator ChatSourceMedium(string value) => new(value);

    internal class ChatSourceMediumSerializer : JsonConverter<ChatSourceMedium>
    {
        public override ChatSourceMedium Read(
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
            return new ChatSourceMedium(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChatSourceMedium value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChatSourceMedium ReadAsPropertyName(
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
            return new ChatSourceMedium(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChatSourceMedium value,
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
        public const string Audio = "audio";

        public const string Dtmf = "dtmf";

        public const string Text = "text";

        public const string Image = "image";

        public const string File = "file";
    }
}
