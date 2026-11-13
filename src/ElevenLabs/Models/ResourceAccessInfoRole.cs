using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The role of the user making the request</summary>
[JsonConverter(typeof(ResourceAccessInfoRole.ResourceAccessInfoRoleSerializer))]
[Serializable]
public readonly record struct ResourceAccessInfoRole : IStringEnum
{
    public static readonly ResourceAccessInfoRole Admin = new(Values.Admin);

    public static readonly ResourceAccessInfoRole Editor = new(Values.Editor);

    public static readonly ResourceAccessInfoRole Commenter = new(Values.Commenter);

    public static readonly ResourceAccessInfoRole Viewer = new(Values.Viewer);

    public ResourceAccessInfoRole(string value)
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
    public static ResourceAccessInfoRole FromCustom(string value)
    {
        return new ResourceAccessInfoRole(value);
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

    public static bool operator ==(ResourceAccessInfoRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceAccessInfoRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceAccessInfoRole value) => value.Value;

    public static explicit operator ResourceAccessInfoRole(string value) => new(value);

    internal class ResourceAccessInfoRoleSerializer : JsonConverter<ResourceAccessInfoRole>
    {
        public override ResourceAccessInfoRole Read(
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
            return new ResourceAccessInfoRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceAccessInfoRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceAccessInfoRole ReadAsPropertyName(
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
            return new ResourceAccessInfoRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceAccessInfoRole value,
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
