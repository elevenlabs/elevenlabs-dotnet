using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PostWorkspaceSecretResponseModelType.PostWorkspaceSecretResponseModelTypeSerializer)
)]
[Serializable]
public readonly record struct PostWorkspaceSecretResponseModelType : IStringEnum
{
    public static readonly PostWorkspaceSecretResponseModelType Stored = new(Values.Stored);

    public PostWorkspaceSecretResponseModelType(string value)
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
    public static PostWorkspaceSecretResponseModelType FromCustom(string value)
    {
        return new PostWorkspaceSecretResponseModelType(value);
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

    public static bool operator ==(PostWorkspaceSecretResponseModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PostWorkspaceSecretResponseModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PostWorkspaceSecretResponseModelType value) =>
        value.Value;

    public static explicit operator PostWorkspaceSecretResponseModelType(string value) =>
        new(value);

    internal class PostWorkspaceSecretResponseModelTypeSerializer
        : JsonConverter<PostWorkspaceSecretResponseModelType>
    {
        public override PostWorkspaceSecretResponseModelType Read(
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
            return new PostWorkspaceSecretResponseModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PostWorkspaceSecretResponseModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PostWorkspaceSecretResponseModelType ReadAsPropertyName(
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
            return new PostWorkspaceSecretResponseModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PostWorkspaceSecretResponseModelType value,
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
        public const string Stored = "stored";
    }
}
