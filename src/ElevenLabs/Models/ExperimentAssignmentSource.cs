using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExperimentAssignmentSource.ExperimentAssignmentSourceSerializer))]
[Serializable]
public readonly record struct ExperimentAssignmentSource : IStringEnum
{
    public static readonly ExperimentAssignmentSource ServerBranch = new(Values.ServerBranch);

    public static readonly ExperimentAssignmentSource ClientDeclared = new(Values.ClientDeclared);

    public ExperimentAssignmentSource(string value)
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
    public static ExperimentAssignmentSource FromCustom(string value)
    {
        return new ExperimentAssignmentSource(value);
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

    public static bool operator ==(ExperimentAssignmentSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExperimentAssignmentSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExperimentAssignmentSource value) => value.Value;

    public static explicit operator ExperimentAssignmentSource(string value) => new(value);

    internal class ExperimentAssignmentSourceSerializer : JsonConverter<ExperimentAssignmentSource>
    {
        public override ExperimentAssignmentSource Read(
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
            return new ExperimentAssignmentSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExperimentAssignmentSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExperimentAssignmentSource ReadAsPropertyName(
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
            return new ExperimentAssignmentSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExperimentAssignmentSource value,
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
        public const string ServerBranch = "server_branch";

        public const string ClientDeclared = "client_declared";
    }
}
