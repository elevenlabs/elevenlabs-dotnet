using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(KnowledgeBaseDependentType.KnowledgeBaseDependentTypeSerializer))]
[Serializable]
public readonly record struct KnowledgeBaseDependentType : IStringEnum
{
    public static readonly KnowledgeBaseDependentType Direct = new(Values.Direct);

    public static readonly KnowledgeBaseDependentType Transitive = new(Values.Transitive);

    public static readonly KnowledgeBaseDependentType All = new(Values.All);

    public KnowledgeBaseDependentType(string value)
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
    public static KnowledgeBaseDependentType FromCustom(string value)
    {
        return new KnowledgeBaseDependentType(value);
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

    public static bool operator ==(KnowledgeBaseDependentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseDependentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseDependentType value) => value.Value;

    public static explicit operator KnowledgeBaseDependentType(string value) => new(value);

    internal class KnowledgeBaseDependentTypeSerializer : JsonConverter<KnowledgeBaseDependentType>
    {
        public override KnowledgeBaseDependentType Read(
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
            return new KnowledgeBaseDependentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseDependentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseDependentType ReadAsPropertyName(
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
            return new KnowledgeBaseDependentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseDependentType value,
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
        public const string Direct = "direct";

        public const string Transitive = "transitive";

        public const string All = "all";
    }
}
