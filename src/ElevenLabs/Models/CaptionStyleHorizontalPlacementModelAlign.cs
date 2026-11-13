using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CaptionStyleHorizontalPlacementModelAlign.CaptionStyleHorizontalPlacementModelAlignSerializer)
)]
[Serializable]
public readonly record struct CaptionStyleHorizontalPlacementModelAlign : IStringEnum
{
    public static readonly CaptionStyleHorizontalPlacementModelAlign Left = new(Values.Left);

    public static readonly CaptionStyleHorizontalPlacementModelAlign Center = new(Values.Center);

    public static readonly CaptionStyleHorizontalPlacementModelAlign Right = new(Values.Right);

    public CaptionStyleHorizontalPlacementModelAlign(string value)
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
    public static CaptionStyleHorizontalPlacementModelAlign FromCustom(string value)
    {
        return new CaptionStyleHorizontalPlacementModelAlign(value);
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
        CaptionStyleHorizontalPlacementModelAlign value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CaptionStyleHorizontalPlacementModelAlign value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleHorizontalPlacementModelAlign value) =>
        value.Value;

    public static explicit operator CaptionStyleHorizontalPlacementModelAlign(string value) =>
        new(value);

    internal class CaptionStyleHorizontalPlacementModelAlignSerializer
        : JsonConverter<CaptionStyleHorizontalPlacementModelAlign>
    {
        public override CaptionStyleHorizontalPlacementModelAlign Read(
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
            return new CaptionStyleHorizontalPlacementModelAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleHorizontalPlacementModelAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleHorizontalPlacementModelAlign ReadAsPropertyName(
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
            return new CaptionStyleHorizontalPlacementModelAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleHorizontalPlacementModelAlign value,
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
        public const string Left = "left";

        public const string Center = "center";

        public const string Right = "right";
    }
}
