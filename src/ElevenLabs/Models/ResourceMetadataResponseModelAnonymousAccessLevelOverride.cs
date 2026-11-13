using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ResourceMetadataResponseModelAnonymousAccessLevelOverride.ResourceMetadataResponseModelAnonymousAccessLevelOverrideSerializer)
)]
[Serializable]
public readonly record struct ResourceMetadataResponseModelAnonymousAccessLevelOverride
    : IStringEnum
{
    public static readonly ResourceMetadataResponseModelAnonymousAccessLevelOverride Admin = new(
        Values.Admin
    );

    public static readonly ResourceMetadataResponseModelAnonymousAccessLevelOverride Editor = new(
        Values.Editor
    );

    public static readonly ResourceMetadataResponseModelAnonymousAccessLevelOverride Commenter =
        new(Values.Commenter);

    public static readonly ResourceMetadataResponseModelAnonymousAccessLevelOverride Viewer = new(
        Values.Viewer
    );

    public ResourceMetadataResponseModelAnonymousAccessLevelOverride(string value)
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
    public static ResourceMetadataResponseModelAnonymousAccessLevelOverride FromCustom(string value)
    {
        return new ResourceMetadataResponseModelAnonymousAccessLevelOverride(value);
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
        ResourceMetadataResponseModelAnonymousAccessLevelOverride value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceMetadataResponseModelAnonymousAccessLevelOverride value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ResourceMetadataResponseModelAnonymousAccessLevelOverride value
    ) => value.Value;

    public static explicit operator ResourceMetadataResponseModelAnonymousAccessLevelOverride(
        string value
    ) => new(value);

    internal class ResourceMetadataResponseModelAnonymousAccessLevelOverrideSerializer
        : JsonConverter<ResourceMetadataResponseModelAnonymousAccessLevelOverride>
    {
        public override ResourceMetadataResponseModelAnonymousAccessLevelOverride Read(
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
            return new ResourceMetadataResponseModelAnonymousAccessLevelOverride(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceMetadataResponseModelAnonymousAccessLevelOverride value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceMetadataResponseModelAnonymousAccessLevelOverride ReadAsPropertyName(
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
            return new ResourceMetadataResponseModelAnonymousAccessLevelOverride(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceMetadataResponseModelAnonymousAccessLevelOverride value,
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
