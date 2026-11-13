using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ResourceAccessInfoAccessSource.ResourceAccessInfoAccessSourceSerializer))]
[Serializable]
public readonly record struct ResourceAccessInfoAccessSource : IStringEnum
{
    public static readonly ResourceAccessInfoAccessSource Creator = new(Values.Creator);

    public static readonly ResourceAccessInfoAccessSource Explicit = new(Values.Explicit);

    public static readonly ResourceAccessInfoAccessSource WorkspaceAdmin = new(
        Values.WorkspaceAdmin
    );

    public static readonly ResourceAccessInfoAccessSource WorkspaceDefault = new(
        Values.WorkspaceDefault
    );

    public ResourceAccessInfoAccessSource(string value)
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
    public static ResourceAccessInfoAccessSource FromCustom(string value)
    {
        return new ResourceAccessInfoAccessSource(value);
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

    public static bool operator ==(ResourceAccessInfoAccessSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResourceAccessInfoAccessSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResourceAccessInfoAccessSource value) => value.Value;

    public static explicit operator ResourceAccessInfoAccessSource(string value) => new(value);

    internal class ResourceAccessInfoAccessSourceSerializer
        : JsonConverter<ResourceAccessInfoAccessSource>
    {
        public override ResourceAccessInfoAccessSource Read(
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
            return new ResourceAccessInfoAccessSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceAccessInfoAccessSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceAccessInfoAccessSource ReadAsPropertyName(
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
            return new ResourceAccessInfoAccessSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceAccessInfoAccessSource value,
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
        public const string Creator = "creator";

        public const string Explicit = "explicit";

        public const string WorkspaceAdmin = "workspace_admin";

        public const string WorkspaceDefault = "workspace_default";
    }
}
