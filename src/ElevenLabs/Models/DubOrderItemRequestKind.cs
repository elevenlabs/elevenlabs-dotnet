using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of order item.</summary>
[JsonConverter(typeof(DubOrderItemRequestKind.DubOrderItemRequestKindSerializer))]
[Serializable]
public readonly record struct DubOrderItemRequestKind : IStringEnum
{
    public static readonly DubOrderItemRequestKind Dub = new(Values.Dub);

    public DubOrderItemRequestKind(string value)
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
    public static DubOrderItemRequestKind FromCustom(string value)
    {
        return new DubOrderItemRequestKind(value);
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

    public static bool operator ==(DubOrderItemRequestKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubOrderItemRequestKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubOrderItemRequestKind value) => value.Value;

    public static explicit operator DubOrderItemRequestKind(string value) => new(value);

    internal class DubOrderItemRequestKindSerializer : JsonConverter<DubOrderItemRequestKind>
    {
        public override DubOrderItemRequestKind Read(
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
            return new DubOrderItemRequestKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubOrderItemRequestKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubOrderItemRequestKind ReadAsPropertyName(
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
            return new DubOrderItemRequestKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubOrderItemRequestKind value,
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
        public const string Dub = "dub";
    }
}
