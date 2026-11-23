using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(MultimodalMessageTextSourceMedium.MultimodalMessageTextSourceMediumSerializer)
)]
[Serializable]
public readonly record struct MultimodalMessageTextSourceMedium : IStringEnum
{
    public static readonly MultimodalMessageTextSourceMedium Audio = new(Values.Audio);

    public static readonly MultimodalMessageTextSourceMedium Dtmf = new(Values.Dtmf);

    public static readonly MultimodalMessageTextSourceMedium Text = new(Values.Text);

    public static readonly MultimodalMessageTextSourceMedium Image = new(Values.Image);

    public static readonly MultimodalMessageTextSourceMedium File = new(Values.File);

    public MultimodalMessageTextSourceMedium(string value)
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
    public static MultimodalMessageTextSourceMedium FromCustom(string value)
    {
        return new MultimodalMessageTextSourceMedium(value);
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

    public static bool operator ==(MultimodalMessageTextSourceMedium value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MultimodalMessageTextSourceMedium value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MultimodalMessageTextSourceMedium value) => value.Value;

    public static explicit operator MultimodalMessageTextSourceMedium(string value) => new(value);

    internal class MultimodalMessageTextSourceMediumSerializer
        : JsonConverter<MultimodalMessageTextSourceMedium>
    {
        public override MultimodalMessageTextSourceMedium Read(
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
            return new MultimodalMessageTextSourceMedium(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MultimodalMessageTextSourceMedium value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MultimodalMessageTextSourceMedium ReadAsPropertyName(
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
            return new MultimodalMessageTextSourceMedium(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MultimodalMessageTextSourceMedium value,
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
