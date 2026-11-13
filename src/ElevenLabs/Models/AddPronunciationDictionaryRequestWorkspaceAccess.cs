using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AddPronunciationDictionaryRequestWorkspaceAccess.AddPronunciationDictionaryRequestWorkspaceAccessSerializer)
)]
[Serializable]
public readonly record struct AddPronunciationDictionaryRequestWorkspaceAccess : IStringEnum
{
    public static readonly AddPronunciationDictionaryRequestWorkspaceAccess Admin = new(
        Values.Admin
    );

    public static readonly AddPronunciationDictionaryRequestWorkspaceAccess Editor = new(
        Values.Editor
    );

    public static readonly AddPronunciationDictionaryRequestWorkspaceAccess Commenter = new(
        Values.Commenter
    );

    public static readonly AddPronunciationDictionaryRequestWorkspaceAccess Viewer = new(
        Values.Viewer
    );

    public AddPronunciationDictionaryRequestWorkspaceAccess(string value)
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
    public static AddPronunciationDictionaryRequestWorkspaceAccess FromCustom(string value)
    {
        return new AddPronunciationDictionaryRequestWorkspaceAccess(value);
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
        AddPronunciationDictionaryRequestWorkspaceAccess value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddPronunciationDictionaryRequestWorkspaceAccess value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AddPronunciationDictionaryRequestWorkspaceAccess value
    ) => value.Value;

    public static explicit operator AddPronunciationDictionaryRequestWorkspaceAccess(
        string value
    ) => new(value);

    internal class AddPronunciationDictionaryRequestWorkspaceAccessSerializer
        : JsonConverter<AddPronunciationDictionaryRequestWorkspaceAccess>
    {
        public override AddPronunciationDictionaryRequestWorkspaceAccess Read(
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
            return new AddPronunciationDictionaryRequestWorkspaceAccess(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPronunciationDictionaryRequestWorkspaceAccess value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddPronunciationDictionaryRequestWorkspaceAccess ReadAsPropertyName(
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
            return new AddPronunciationDictionaryRequestWorkspaceAccess(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddPronunciationDictionaryRequestWorkspaceAccess value,
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
