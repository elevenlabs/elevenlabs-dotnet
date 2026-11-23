using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Optional category for the failure reason. When set, `is_error` is treated as true. `user_rejected` is special-cased to mark the tool as not having been called.</summary>
[JsonConverter(typeof(ClientToolResultErrorType.ClientToolResultErrorTypeSerializer))]
[Serializable]
public readonly record struct ClientToolResultErrorType : IStringEnum
{
    public static readonly ClientToolResultErrorType UserRejected = new(Values.UserRejected);

    public static readonly ClientToolResultErrorType ExternalServer = new(Values.ExternalServer);

    public static readonly ClientToolResultErrorType ExternalClient = new(Values.ExternalClient);

    public static readonly ClientToolResultErrorType CustomerAuth = new(Values.CustomerAuth);

    public static readonly ClientToolResultErrorType ClientTimeout = new(Values.ClientTimeout);

    public static readonly ClientToolResultErrorType Unknown = new(Values.Unknown);

    public ClientToolResultErrorType(string value)
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
    public static ClientToolResultErrorType FromCustom(string value)
    {
        return new ClientToolResultErrorType(value);
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

    public static bool operator ==(ClientToolResultErrorType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolResultErrorType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolResultErrorType value) => value.Value;

    public static explicit operator ClientToolResultErrorType(string value) => new(value);

    internal class ClientToolResultErrorTypeSerializer : JsonConverter<ClientToolResultErrorType>
    {
        public override ClientToolResultErrorType Read(
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
            return new ClientToolResultErrorType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolResultErrorType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolResultErrorType ReadAsPropertyName(
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
            return new ClientToolResultErrorType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolResultErrorType value,
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
        public const string UserRejected = "user_rejected";

        public const string ExternalServer = "external_server";

        public const string ExternalClient = "external_client";

        public const string CustomerAuth = "customer_auth";

        public const string ClientTimeout = "client_timeout";

        public const string Unknown = "unknown";
    }
}
