using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DependentAvailableToolIdentifierAccessLevel.DependentAvailableToolIdentifierAccessLevelSerializer)
)]
[Serializable]
public readonly record struct DependentAvailableToolIdentifierAccessLevel : IStringEnum
{
    public static readonly DependentAvailableToolIdentifierAccessLevel Admin = new(Values.Admin);

    public static readonly DependentAvailableToolIdentifierAccessLevel Editor = new(Values.Editor);

    public static readonly DependentAvailableToolIdentifierAccessLevel Commenter = new(
        Values.Commenter
    );

    public static readonly DependentAvailableToolIdentifierAccessLevel Viewer = new(Values.Viewer);

    public DependentAvailableToolIdentifierAccessLevel(string value)
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
    public static DependentAvailableToolIdentifierAccessLevel FromCustom(string value)
    {
        return new DependentAvailableToolIdentifierAccessLevel(value);
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
        DependentAvailableToolIdentifierAccessLevel value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DependentAvailableToolIdentifierAccessLevel value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DependentAvailableToolIdentifierAccessLevel value) =>
        value.Value;

    public static explicit operator DependentAvailableToolIdentifierAccessLevel(string value) =>
        new(value);

    internal class DependentAvailableToolIdentifierAccessLevelSerializer
        : JsonConverter<DependentAvailableToolIdentifierAccessLevel>
    {
        public override DependentAvailableToolIdentifierAccessLevel Read(
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
            return new DependentAvailableToolIdentifierAccessLevel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DependentAvailableToolIdentifierAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DependentAvailableToolIdentifierAccessLevel ReadAsPropertyName(
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
            return new DependentAvailableToolIdentifierAccessLevel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DependentAvailableToolIdentifierAccessLevel value,
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
