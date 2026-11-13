using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Studio;

[JsonConverter(
    typeof(BodyCreateStudioProjectV1StudioProjectsPostFiction.BodyCreateStudioProjectV1StudioProjectsPostFictionSerializer)
)]
[Serializable]
public readonly record struct BodyCreateStudioProjectV1StudioProjectsPostFiction : IStringEnum
{
    public static readonly BodyCreateStudioProjectV1StudioProjectsPostFiction Fiction = new(
        Values.Fiction
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostFiction NonFiction = new(
        Values.NonFiction
    );

    public BodyCreateStudioProjectV1StudioProjectsPostFiction(string value)
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
    public static BodyCreateStudioProjectV1StudioProjectsPostFiction FromCustom(string value)
    {
        return new BodyCreateStudioProjectV1StudioProjectsPostFiction(value);
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
        BodyCreateStudioProjectV1StudioProjectsPostFiction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreateStudioProjectV1StudioProjectsPostFiction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreateStudioProjectV1StudioProjectsPostFiction value
    ) => value.Value;

    public static explicit operator BodyCreateStudioProjectV1StudioProjectsPostFiction(
        string value
    ) => new(value);

    internal class BodyCreateStudioProjectV1StudioProjectsPostFictionSerializer
        : JsonConverter<BodyCreateStudioProjectV1StudioProjectsPostFiction>
    {
        public override BodyCreateStudioProjectV1StudioProjectsPostFiction Read(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostFiction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostFiction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreateStudioProjectV1StudioProjectsPostFiction ReadAsPropertyName(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostFiction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostFiction value,
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
        public const string Fiction = "fiction";

        public const string NonFiction = "non-fiction";
    }
}
