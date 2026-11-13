using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource.GetPronunciationDictionaryWithRulesResponseModelPermissionOnResourceSerializer)
)]
[Serializable]
public readonly record struct GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource
    : IStringEnum
{
    public static readonly GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource Admin =
        new(Values.Admin);

    public static readonly GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource Editor =
        new(Values.Editor);

    public static readonly GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource Commenter =
        new(Values.Commenter);

    public static readonly GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource Viewer =
        new(Values.Viewer);

    public GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource(string value)
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
    public static GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource FromCustom(
        string value
    )
    {
        return new GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource(value);
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
        GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource value
    ) => value.Value;

    public static explicit operator GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource(
        string value
    ) => new(value);

    internal class GetPronunciationDictionaryWithRulesResponseModelPermissionOnResourceSerializer
        : JsonConverter<GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource>
    {
        public override GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource Read(
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
            return new GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource ReadAsPropertyName(
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
            return new GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPronunciationDictionaryWithRulesResponseModelPermissionOnResource value,
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
