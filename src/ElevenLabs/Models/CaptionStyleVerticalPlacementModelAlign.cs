using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CaptionStyleVerticalPlacementModelAlign.CaptionStyleVerticalPlacementModelAlignSerializer)
)]
[Serializable]
public readonly record struct CaptionStyleVerticalPlacementModelAlign : IStringEnum
{
    public static readonly CaptionStyleVerticalPlacementModelAlign Top = new(Values.Top);

    public static readonly CaptionStyleVerticalPlacementModelAlign Center = new(Values.Center);

    public static readonly CaptionStyleVerticalPlacementModelAlign Bottom = new(Values.Bottom);

    public CaptionStyleVerticalPlacementModelAlign(string value)
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
    public static CaptionStyleVerticalPlacementModelAlign FromCustom(string value)
    {
        return new CaptionStyleVerticalPlacementModelAlign(value);
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

    public static bool operator ==(CaptionStyleVerticalPlacementModelAlign value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleVerticalPlacementModelAlign value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleVerticalPlacementModelAlign value) =>
        value.Value;

    public static explicit operator CaptionStyleVerticalPlacementModelAlign(string value) =>
        new(value);

    internal class CaptionStyleVerticalPlacementModelAlignSerializer
        : JsonConverter<CaptionStyleVerticalPlacementModelAlign>
    {
        public override CaptionStyleVerticalPlacementModelAlign Read(
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
            return new CaptionStyleVerticalPlacementModelAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleVerticalPlacementModelAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleVerticalPlacementModelAlign ReadAsPropertyName(
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
            return new CaptionStyleVerticalPlacementModelAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleVerticalPlacementModelAlign value,
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
        public const string Top = "top";

        public const string Center = "center";

        public const string Bottom = "bottom";
    }
}
