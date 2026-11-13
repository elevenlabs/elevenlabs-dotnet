using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The permission level to grant to the group</summary>
[JsonConverter(
    typeof(DefaultSharingGroupResponseModelPermissionLevel.DefaultSharingGroupResponseModelPermissionLevelSerializer)
)]
[Serializable]
public readonly record struct DefaultSharingGroupResponseModelPermissionLevel : IStringEnum
{
    public static readonly DefaultSharingGroupResponseModelPermissionLevel Admin = new(
        Values.Admin
    );

    public static readonly DefaultSharingGroupResponseModelPermissionLevel Editor = new(
        Values.Editor
    );

    public static readonly DefaultSharingGroupResponseModelPermissionLevel Viewer = new(
        Values.Viewer
    );

    public DefaultSharingGroupResponseModelPermissionLevel(string value)
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
    public static DefaultSharingGroupResponseModelPermissionLevel FromCustom(string value)
    {
        return new DefaultSharingGroupResponseModelPermissionLevel(value);
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
        DefaultSharingGroupResponseModelPermissionLevel value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DefaultSharingGroupResponseModelPermissionLevel value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DefaultSharingGroupResponseModelPermissionLevel value) =>
        value.Value;

    public static explicit operator DefaultSharingGroupResponseModelPermissionLevel(string value) =>
        new(value);

    internal class DefaultSharingGroupResponseModelPermissionLevelSerializer
        : JsonConverter<DefaultSharingGroupResponseModelPermissionLevel>
    {
        public override DefaultSharingGroupResponseModelPermissionLevel Read(
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
            return new DefaultSharingGroupResponseModelPermissionLevel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DefaultSharingGroupResponseModelPermissionLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DefaultSharingGroupResponseModelPermissionLevel ReadAsPropertyName(
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
            return new DefaultSharingGroupResponseModelPermissionLevel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DefaultSharingGroupResponseModelPermissionLevel value,
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

        public const string Viewer = "viewer";
    }
}
