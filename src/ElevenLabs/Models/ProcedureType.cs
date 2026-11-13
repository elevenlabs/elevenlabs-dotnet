using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProcedureType.ProcedureTypeSerializer))]
[Serializable]
public readonly record struct ProcedureType : IStringEnum
{
    public static readonly ProcedureType FreeForm = new(Values.FreeForm);

    public static readonly ProcedureType Deterministic = new(Values.Deterministic);

    public static readonly ProcedureType Folder = new(Values.Folder);

    public ProcedureType(string value)
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
    public static ProcedureType FromCustom(string value)
    {
        return new ProcedureType(value);
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

    public static bool operator ==(ProcedureType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProcedureType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProcedureType value) => value.Value;

    public static explicit operator ProcedureType(string value) => new(value);

    internal class ProcedureTypeSerializer : JsonConverter<ProcedureType>
    {
        public override ProcedureType Read(
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
            return new ProcedureType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProcedureType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProcedureType ReadAsPropertyName(
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
            return new ProcedureType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProcedureType value,
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
        public const string FreeForm = "free_form";

        public const string Deterministic = "deterministic";

        public const string Folder = "folder";
    }
}
