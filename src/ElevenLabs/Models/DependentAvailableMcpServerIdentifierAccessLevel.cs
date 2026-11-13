using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DependentAvailableMcpServerIdentifierAccessLevel.DependentAvailableMcpServerIdentifierAccessLevelSerializer)
)]
[Serializable]
public readonly record struct DependentAvailableMcpServerIdentifierAccessLevel : IStringEnum
{
    public static readonly DependentAvailableMcpServerIdentifierAccessLevel Admin = new(
        Values.Admin
    );

    public static readonly DependentAvailableMcpServerIdentifierAccessLevel Editor = new(
        Values.Editor
    );

    public static readonly DependentAvailableMcpServerIdentifierAccessLevel Commenter = new(
        Values.Commenter
    );

    public static readonly DependentAvailableMcpServerIdentifierAccessLevel Viewer = new(
        Values.Viewer
    );

    public DependentAvailableMcpServerIdentifierAccessLevel(string value)
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
    public static DependentAvailableMcpServerIdentifierAccessLevel FromCustom(string value)
    {
        return new DependentAvailableMcpServerIdentifierAccessLevel(value);
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
        DependentAvailableMcpServerIdentifierAccessLevel value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DependentAvailableMcpServerIdentifierAccessLevel value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        DependentAvailableMcpServerIdentifierAccessLevel value
    ) => value.Value;

    public static explicit operator DependentAvailableMcpServerIdentifierAccessLevel(
        string value
    ) => new(value);

    internal class DependentAvailableMcpServerIdentifierAccessLevelSerializer
        : JsonConverter<DependentAvailableMcpServerIdentifierAccessLevel>
    {
        public override DependentAvailableMcpServerIdentifierAccessLevel Read(
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
            return new DependentAvailableMcpServerIdentifierAccessLevel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DependentAvailableMcpServerIdentifierAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DependentAvailableMcpServerIdentifierAccessLevel ReadAsPropertyName(
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
            return new DependentAvailableMcpServerIdentifierAccessLevel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DependentAvailableMcpServerIdentifierAccessLevel value,
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
