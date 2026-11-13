using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How the model uses the image: `subject` places its subject or scene elements into the video; `style` transfers its visual style.</summary>
[JsonConverter(typeof(VeoImageReferenceRole.VeoImageReferenceRoleSerializer))]
[Serializable]
public readonly record struct VeoImageReferenceRole : IStringEnum
{
    public static readonly VeoImageReferenceRole Subject = new(Values.Subject);

    public static readonly VeoImageReferenceRole Style = new(Values.Style);

    public VeoImageReferenceRole(string value)
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
    public static VeoImageReferenceRole FromCustom(string value)
    {
        return new VeoImageReferenceRole(value);
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

    public static bool operator ==(VeoImageReferenceRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VeoImageReferenceRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VeoImageReferenceRole value) => value.Value;

    public static explicit operator VeoImageReferenceRole(string value) => new(value);

    internal class VeoImageReferenceRoleSerializer : JsonConverter<VeoImageReferenceRole>
    {
        public override VeoImageReferenceRole Read(
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
            return new VeoImageReferenceRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VeoImageReferenceRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VeoImageReferenceRole ReadAsPropertyName(
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
            return new VeoImageReferenceRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VeoImageReferenceRole value,
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
        public const string Subject = "subject";

        public const string Style = "style";
    }
}
