using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToNumberToolConfigInputSystemToolType.TransferToNumberToolConfigInputSystemToolTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToNumberToolConfigInputSystemToolType : IStringEnum
{
    public static readonly TransferToNumberToolConfigInputSystemToolType TransferToNumber = new(
        Values.TransferToNumber
    );

    public TransferToNumberToolConfigInputSystemToolType(string value)
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
    public static TransferToNumberToolConfigInputSystemToolType FromCustom(string value)
    {
        return new TransferToNumberToolConfigInputSystemToolType(value);
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
        TransferToNumberToolConfigInputSystemToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToNumberToolConfigInputSystemToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TransferToNumberToolConfigInputSystemToolType value) =>
        value.Value;

    public static explicit operator TransferToNumberToolConfigInputSystemToolType(string value) =>
        new(value);

    internal class TransferToNumberToolConfigInputSystemToolTypeSerializer
        : JsonConverter<TransferToNumberToolConfigInputSystemToolType>
    {
        public override TransferToNumberToolConfigInputSystemToolType Read(
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
            return new TransferToNumberToolConfigInputSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToNumberToolConfigInputSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToNumberToolConfigInputSystemToolType ReadAsPropertyName(
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
            return new TransferToNumberToolConfigInputSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToNumberToolConfigInputSystemToolType value,
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
        public const string TransferToNumber = "transfer_to_number";
    }
}
