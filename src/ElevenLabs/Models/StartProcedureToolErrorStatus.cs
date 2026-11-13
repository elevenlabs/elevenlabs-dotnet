using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(StartProcedureToolErrorStatus.StartProcedureToolErrorStatusSerializer))]
[Serializable]
public readonly record struct StartProcedureToolErrorStatus : IStringEnum
{
    public static readonly StartProcedureToolErrorStatus NotFound = new(Values.NotFound);

    public static readonly StartProcedureToolErrorStatus InvalidName = new(Values.InvalidName);

    public static readonly StartProcedureToolErrorStatus AlreadyActive = new(Values.AlreadyActive);

    public StartProcedureToolErrorStatus(string value)
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
    public static StartProcedureToolErrorStatus FromCustom(string value)
    {
        return new StartProcedureToolErrorStatus(value);
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

    public static bool operator ==(StartProcedureToolErrorStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StartProcedureToolErrorStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StartProcedureToolErrorStatus value) => value.Value;

    public static explicit operator StartProcedureToolErrorStatus(string value) => new(value);

    internal class StartProcedureToolErrorStatusSerializer
        : JsonConverter<StartProcedureToolErrorStatus>
    {
        public override StartProcedureToolErrorStatus Read(
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
            return new StartProcedureToolErrorStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StartProcedureToolErrorStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StartProcedureToolErrorStatus ReadAsPropertyName(
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
            return new StartProcedureToolErrorStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StartProcedureToolErrorStatus value,
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

        public const string InvalidName = "invalid_name";

        public const string AlreadyActive = "already_active";
    }
}
