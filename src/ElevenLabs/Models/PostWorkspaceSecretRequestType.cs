using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(PostWorkspaceSecretRequestType.PostWorkspaceSecretRequestTypeSerializer))]
[Serializable]
public readonly record struct PostWorkspaceSecretRequestType : IStringEnum
{
    public static readonly PostWorkspaceSecretRequestType New = new(Values.New);

    public PostWorkspaceSecretRequestType(string value)
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
    public static PostWorkspaceSecretRequestType FromCustom(string value)
    {
        return new PostWorkspaceSecretRequestType(value);
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

    public static bool operator ==(PostWorkspaceSecretRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PostWorkspaceSecretRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PostWorkspaceSecretRequestType value) => value.Value;

    public static explicit operator PostWorkspaceSecretRequestType(string value) => new(value);

    internal class PostWorkspaceSecretRequestTypeSerializer
        : JsonConverter<PostWorkspaceSecretRequestType>
    {
        public override PostWorkspaceSecretRequestType Read(
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
            return new PostWorkspaceSecretRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PostWorkspaceSecretRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PostWorkspaceSecretRequestType ReadAsPropertyName(
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
            return new PostWorkspaceSecretRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PostWorkspaceSecretRequestType value,
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
        public const string New = "new";
    }
}
