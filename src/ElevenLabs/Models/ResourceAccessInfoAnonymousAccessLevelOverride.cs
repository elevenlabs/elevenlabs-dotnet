using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ResourceAccessInfoAnonymousAccessLevelOverride.ResourceAccessInfoAnonymousAccessLevelOverrideSerializer)
)]
[Serializable]
public readonly record struct ResourceAccessInfoAnonymousAccessLevelOverride : IStringEnum
{
    public static readonly ResourceAccessInfoAnonymousAccessLevelOverride Admin = new(Values.Admin);

    public static readonly ResourceAccessInfoAnonymousAccessLevelOverride Editor = new(
        Values.Editor
    );

    public static readonly ResourceAccessInfoAnonymousAccessLevelOverride Commenter = new(
        Values.Commenter
    );

    public static readonly ResourceAccessInfoAnonymousAccessLevelOverride Viewer = new(
        Values.Viewer
    );

    public ResourceAccessInfoAnonymousAccessLevelOverride(string value)
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
    public static ResourceAccessInfoAnonymousAccessLevelOverride FromCustom(string value)
    {
        return new ResourceAccessInfoAnonymousAccessLevelOverride(value);
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
        ResourceAccessInfoAnonymousAccessLevelOverride value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceAccessInfoAnonymousAccessLevelOverride value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ResourceAccessInfoAnonymousAccessLevelOverride value) =>
        value.Value;

    public static explicit operator ResourceAccessInfoAnonymousAccessLevelOverride(string value) =>
        new(value);

    internal class ResourceAccessInfoAnonymousAccessLevelOverrideSerializer
        : JsonConverter<ResourceAccessInfoAnonymousAccessLevelOverride>
    {
        public override ResourceAccessInfoAnonymousAccessLevelOverride Read(
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
            return new ResourceAccessInfoAnonymousAccessLevelOverride(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceAccessInfoAnonymousAccessLevelOverride value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceAccessInfoAnonymousAccessLevelOverride ReadAsPropertyName(
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
            return new ResourceAccessInfoAnonymousAccessLevelOverride(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceAccessInfoAnonymousAccessLevelOverride value,
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
