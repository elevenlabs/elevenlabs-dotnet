using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AddPronunciationDictionaryResponseModelPermissionOnResource.AddPronunciationDictionaryResponseModelPermissionOnResourceSerializer)
)]
[Serializable]
public readonly record struct AddPronunciationDictionaryResponseModelPermissionOnResource
    : IStringEnum
{
    public static readonly AddPronunciationDictionaryResponseModelPermissionOnResource Admin = new(
        Values.Admin
    );

    public static readonly AddPronunciationDictionaryResponseModelPermissionOnResource Editor = new(
        Values.Editor
    );

    public static readonly AddPronunciationDictionaryResponseModelPermissionOnResource Commenter =
        new(Values.Commenter);

    public static readonly AddPronunciationDictionaryResponseModelPermissionOnResource Viewer = new(
        Values.Viewer
    );

    public AddPronunciationDictionaryResponseModelPermissionOnResource(string value)
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
    public static AddPronunciationDictionaryResponseModelPermissionOnResource FromCustom(
        string value
    )
    {
        return new AddPronunciationDictionaryResponseModelPermissionOnResource(value);
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
        AddPronunciationDictionaryResponseModelPermissionOnResource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddPronunciationDictionaryResponseModelPermissionOnResource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AddPronunciationDictionaryResponseModelPermissionOnResource value
    ) => value.Value;

    public static explicit operator AddPronunciationDictionaryResponseModelPermissionOnResource(
        string value
    ) => new(value);

    internal class AddPronunciationDictionaryResponseModelPermissionOnResourceSerializer
        : JsonConverter<AddPronunciationDictionaryResponseModelPermissionOnResource>
    {
        public override AddPronunciationDictionaryResponseModelPermissionOnResource Read(
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
            return new AddPronunciationDictionaryResponseModelPermissionOnResource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddPronunciationDictionaryResponseModelPermissionOnResource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddPronunciationDictionaryResponseModelPermissionOnResource ReadAsPropertyName(
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
            return new AddPronunciationDictionaryResponseModelPermissionOnResource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddPronunciationDictionaryResponseModelPermissionOnResource value,
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
