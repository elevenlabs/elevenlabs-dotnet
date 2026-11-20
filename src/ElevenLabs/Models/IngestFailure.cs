using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Why processing a knowledge source failed.</summary>
[JsonConverter(typeof(IngestFailure.IngestFailureSerializer))]
[Serializable]
public readonly record struct IngestFailure : IStringEnum
{
    public static readonly IngestFailure BlockedUrl = new(Values.BlockedUrl);

    public static readonly IngestFailure DnsFailure = new(Values.DnsFailure);

    public static readonly IngestFailure HostUnreachable = new(Values.HostUnreachable);

    public static readonly IngestFailure AccessRefused = new(Values.AccessRefused);

    public static readonly IngestFailure CrawlTimeout = new(Values.CrawlTimeout);

    public static readonly IngestFailure NoPages = new(Values.NoPages);

    public static readonly IngestFailure NoContent = new(Values.NoContent);

    public static readonly IngestFailure UpstreamTimeout = new(Values.UpstreamTimeout);

    public static readonly IngestFailure UpstreamError = new(Values.UpstreamError);

    public static readonly IngestFailure Unknown = new(Values.Unknown);

    public IngestFailure(string value)
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
    public static IngestFailure FromCustom(string value)
    {
        return new IngestFailure(value);
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

    public static bool operator ==(IngestFailure value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IngestFailure value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IngestFailure value) => value.Value;

    public static explicit operator IngestFailure(string value) => new(value);

    internal class IngestFailureSerializer : JsonConverter<IngestFailure>
    {
        public override IngestFailure Read(
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
            return new IngestFailure(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IngestFailure value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IngestFailure ReadAsPropertyName(
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
            return new IngestFailure(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IngestFailure value,
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
        public const string BlockedUrl = "blocked_url";

        public const string DnsFailure = "dns_failure";

        public const string HostUnreachable = "host_unreachable";

        public const string AccessRefused = "access_refused";

        public const string CrawlTimeout = "crawl_timeout";

        public const string NoPages = "no_pages";

        public const string NoContent = "no_content";

        public const string UpstreamTimeout = "upstream_timeout";

        public const string UpstreamError = "upstream_error";

        public const string Unknown = "unknown";
    }
}
