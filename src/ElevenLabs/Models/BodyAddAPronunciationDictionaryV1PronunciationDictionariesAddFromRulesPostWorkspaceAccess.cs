using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess.BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccessSerializer)
)]
[Serializable]
public readonly record struct BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess
    : IStringEnum
{
    public static readonly BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess Admin =
        new(Values.Admin);

    public static readonly BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess Editor =
        new(Values.Editor);

    public static readonly BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess Commenter =
        new(Values.Commenter);

    public static readonly BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess Viewer =
        new(Values.Viewer);

    public BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess(
        string value
    )
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
    public static BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess FromCustom(
        string value
    )
    {
        return new BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess(
            value
        );
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
        BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess value
    ) => value.Value;

    public static explicit operator BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess(
        string value
    ) => new(value);

    internal class BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccessSerializer
        : JsonConverter<BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess>
    {
        public override BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess Read(
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
            return new BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess ReadAsPropertyName(
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
            return new BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyAddAPronunciationDictionaryV1PronunciationDictionariesAddFromRulesPostWorkspaceAccess value,
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
        public const string Admin = "admin";

        public const string Editor = "editor";

        public const string Commenter = "commenter";

        public const string Viewer = "viewer";
    }
}
