using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConflictSection.ConflictSectionSerializer))]
[Serializable]
public readonly record struct ConflictSection : IStringEnum
{
    public static readonly ConflictSection ConversationConfig = new(Values.ConversationConfig);

    public static readonly ConflictSection PlatformSettings = new(Values.PlatformSettings);

    public static readonly ConflictSection Procedures = new(Values.Procedures);

    public static readonly ConflictSection Workflow = new(Values.Workflow);

    public ConflictSection(string value)
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
    public static ConflictSection FromCustom(string value)
    {
        return new ConflictSection(value);
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

    public static bool operator ==(ConflictSection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConflictSection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConflictSection value) => value.Value;

    public static explicit operator ConflictSection(string value) => new(value);

    internal class ConflictSectionSerializer : JsonConverter<ConflictSection>
    {
        public override ConflictSection Read(
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
            return new ConflictSection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConflictSection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConflictSection ReadAsPropertyName(
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
            return new ConflictSection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConflictSection value,
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
        public const string ConversationConfig = "conversation_config";

        public const string PlatformSettings = "platform_settings";

        public const string Procedures = "procedures";

        public const string Workflow = "workflow";
    }
}
