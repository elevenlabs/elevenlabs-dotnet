using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EntryBehavior.EntryBehaviorSerializer))]
[Serializable]
public readonly record struct EntryBehavior : IStringEnum
{
    public static readonly EntryBehavior GenerateImmediately = new(Values.GenerateImmediately);

    public static readonly EntryBehavior WaitForUser = new(Values.WaitForUser);

    public static readonly EntryBehavior Auto = new(Values.Auto);

    public EntryBehavior(string value)
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
    public static EntryBehavior FromCustom(string value)
    {
        return new EntryBehavior(value);
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

    public static bool operator ==(EntryBehavior value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EntryBehavior value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EntryBehavior value) => value.Value;

    public static explicit operator EntryBehavior(string value) => new(value);

    internal class EntryBehaviorSerializer : JsonConverter<EntryBehavior>
    {
        public override EntryBehavior Read(
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
            return new EntryBehavior(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryBehavior value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EntryBehavior ReadAsPropertyName(
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
            return new EntryBehavior(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EntryBehavior value,
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
        public const string GenerateImmediately = "generate_immediately";

        public const string WaitForUser = "wait_for_user";

        public const string Auto = "auto";
    }
}
