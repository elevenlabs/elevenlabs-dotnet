using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EndProcedureToolErrorStatus.EndProcedureToolErrorStatusSerializer))]
[Serializable]
public readonly record struct EndProcedureToolErrorStatus : IStringEnum
{
    public static readonly EndProcedureToolErrorStatus NotFound = new(Values.NotFound);

    public static readonly EndProcedureToolErrorStatus InvalidId = new(Values.InvalidId);

    public EndProcedureToolErrorStatus(string value)
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
    public static EndProcedureToolErrorStatus FromCustom(string value)
    {
        return new EndProcedureToolErrorStatus(value);
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

    public static bool operator ==(EndProcedureToolErrorStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EndProcedureToolErrorStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EndProcedureToolErrorStatus value) => value.Value;

    public static explicit operator EndProcedureToolErrorStatus(string value) => new(value);

    internal class EndProcedureToolErrorStatusSerializer
        : JsonConverter<EndProcedureToolErrorStatus>
    {
        public override EndProcedureToolErrorStatus Read(
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
            return new EndProcedureToolErrorStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndProcedureToolErrorStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EndProcedureToolErrorStatus ReadAsPropertyName(
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
            return new EndProcedureToolErrorStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EndProcedureToolErrorStatus value,
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
        public const string NotFound = "not_found";

        public const string InvalidId = "invalid_id";
    }
}
