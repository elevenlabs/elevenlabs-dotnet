using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Buckets that make up the non-LLM ``platform_charge`` of a conversation.</summary>
[JsonConverter(typeof(PlatformCategory.PlatformCategorySerializer))]
[Serializable]
public readonly record struct PlatformCategory : IStringEnum
{
    public static readonly PlatformCategory Voice = new(Values.Voice);

    public static readonly PlatformCategory Silence = new(Values.Silence);

    public static readonly PlatformCategory Burst = new(Values.Burst);

    public static readonly PlatformCategory Asr = new(Values.Asr);

    public static readonly PlatformCategory TextMessage = new(Values.TextMessage);

    public static readonly PlatformCategory Reception = new(Values.Reception);

    public static readonly PlatformCategory V3Addon = new(Values.V3Addon);

    public static readonly PlatformCategory V4Addon = new(Values.V4Addon);

    public static readonly PlatformCategory RagAddon = new(Values.RagAddon);

    public static readonly PlatformCategory Other = new(Values.Other);

    public PlatformCategory(string value)
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
    public static PlatformCategory FromCustom(string value)
    {
        return new PlatformCategory(value);
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

    public static bool operator ==(PlatformCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlatformCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlatformCategory value) => value.Value;

    public static explicit operator PlatformCategory(string value) => new(value);

    internal class PlatformCategorySerializer : JsonConverter<PlatformCategory>
    {
        public override PlatformCategory Read(
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
            return new PlatformCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlatformCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlatformCategory ReadAsPropertyName(
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
            return new PlatformCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlatformCategory value,
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
        public const string Voice = "voice";

        public const string Silence = "silence";

        public const string Burst = "burst";

        public const string Asr = "asr";

        public const string TextMessage = "text_message";

        public const string Reception = "reception";

        public const string V3Addon = "v3_addon";

        public const string V4Addon = "v4_addon";

        public const string RagAddon = "rag_addon";

        public const string Other = "other";
    }
}
