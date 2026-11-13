using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace.Analytics;

[JsonConverter(
    typeof(BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort.BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSortSerializer)
)]
[Serializable]
public readonly record struct BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort : IStringEnum
{
    public static readonly BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort Asc = new(
        Values.Asc
    );

    public static readonly BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort Desc = new(
        Values.Desc
    );

    public BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort(string value)
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
    public static BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort FromCustom(string value)
    {
        return new BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort(value);
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
        BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort value
    ) => value.Value;

    public static explicit operator BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort(
        string value
    ) => new(value);

    internal class BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSortSerializer
        : JsonConverter<BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort>
    {
        public override BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort Read(
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
            return new BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort ReadAsPropertyName(
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
            return new BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostSort value,
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
        public const string Asc = "asc";

        public const string Desc = "desc";
    }
}
