using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How to break down the information. Cannot be "user" or "api_key" if include_workspace_metrics is False.</summary>
[JsonConverter(typeof(BreakdownTypes.BreakdownTypesSerializer))]
[Serializable]
public readonly record struct BreakdownTypes : IStringEnum
{
    public static readonly BreakdownTypes None = new(Values.None);

    public static readonly BreakdownTypes Voice = new(Values.Voice);

    public static readonly BreakdownTypes VoiceMultiplier = new(Values.VoiceMultiplier);

    public static readonly BreakdownTypes User = new(Values.User);

    public static readonly BreakdownTypes Groups = new(Values.Groups);

    public static readonly BreakdownTypes ApiKeys = new(Values.ApiKeys);

    public static readonly BreakdownTypes AllApiKeys = new(Values.AllApiKeys);

    public static readonly BreakdownTypes ProductType = new(Values.ProductType);

    public static readonly BreakdownTypes Model = new(Values.Model);

    public static readonly BreakdownTypes Resource = new(Values.Resource);

    public static readonly BreakdownTypes RequestQueue = new(Values.RequestQueue);

    public static readonly BreakdownTypes Region = new(Values.Region);

    public static readonly BreakdownTypes SubresourceId = new(Values.SubresourceId);

    public static readonly BreakdownTypes ReportingWorkspaceId = new(Values.ReportingWorkspaceId);

    public static readonly BreakdownTypes HasApiKey = new(Values.HasApiKey);

    public static readonly BreakdownTypes RequestSource = new(Values.RequestSource);

    public BreakdownTypes(string value)
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
    public static BreakdownTypes FromCustom(string value)
    {
        return new BreakdownTypes(value);
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

    public static bool operator ==(BreakdownTypes value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BreakdownTypes value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BreakdownTypes value) => value.Value;

    public static explicit operator BreakdownTypes(string value) => new(value);

    internal class BreakdownTypesSerializer : JsonConverter<BreakdownTypes>
    {
        public override BreakdownTypes Read(
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
            return new BreakdownTypes(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BreakdownTypes value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BreakdownTypes ReadAsPropertyName(
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
            return new BreakdownTypes(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BreakdownTypes value,
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
        public const string None = "none";

        public const string Voice = "voice";

        public const string VoiceMultiplier = "voice_multiplier";

        public const string User = "user";

        public const string Groups = "groups";

        public const string ApiKeys = "api_keys";

        public const string AllApiKeys = "all_api_keys";

        public const string ProductType = "product_type";

        public const string Model = "model";

        public const string Resource = "resource";

        public const string RequestQueue = "request_queue";

        public const string Region = "region";

        public const string SubresourceId = "subresource_id";

        public const string ReportingWorkspaceId = "reporting_workspace_id";

        public const string HasApiKey = "has_api_key";

        public const string RequestSource = "request_source";
    }
}
