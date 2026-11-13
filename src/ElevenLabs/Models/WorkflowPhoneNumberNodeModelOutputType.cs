using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WorkflowPhoneNumberNodeModelOutputType.WorkflowPhoneNumberNodeModelOutputTypeSerializer)
)]
[Serializable]
public readonly record struct WorkflowPhoneNumberNodeModelOutputType : IStringEnum
{
    public static readonly WorkflowPhoneNumberNodeModelOutputType PhoneNumber = new(
        Values.PhoneNumber
    );

    public WorkflowPhoneNumberNodeModelOutputType(string value)
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
    public static WorkflowPhoneNumberNodeModelOutputType FromCustom(string value)
    {
        return new WorkflowPhoneNumberNodeModelOutputType(value);
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

    public static bool operator ==(WorkflowPhoneNumberNodeModelOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowPhoneNumberNodeModelOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowPhoneNumberNodeModelOutputType value) =>
        value.Value;

    public static explicit operator WorkflowPhoneNumberNodeModelOutputType(string value) =>
        new(value);

    internal class WorkflowPhoneNumberNodeModelOutputTypeSerializer
        : JsonConverter<WorkflowPhoneNumberNodeModelOutputType>
    {
        public override WorkflowPhoneNumberNodeModelOutputType Read(
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
            return new WorkflowPhoneNumberNodeModelOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowPhoneNumberNodeModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowPhoneNumberNodeModelOutputType ReadAsPropertyName(
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
            return new WorkflowPhoneNumberNodeModelOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowPhoneNumberNodeModelOutputType value,
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
        public const string PhoneNumber = "phone_number";
    }
}
