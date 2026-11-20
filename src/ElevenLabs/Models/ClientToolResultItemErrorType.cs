using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ClientToolResultItemErrorType.ClientToolResultItemErrorTypeSerializer))]
[Serializable]
public readonly record struct ClientToolResultItemErrorType : IStringEnum
{
    public static readonly ClientToolResultItemErrorType UserRejected = new(Values.UserRejected);

    public static readonly ClientToolResultItemErrorType ExternalServer = new(
        Values.ExternalServer
    );

    public static readonly ClientToolResultItemErrorType ExternalClient = new(
        Values.ExternalClient
    );

    public static readonly ClientToolResultItemErrorType CustomerAuth = new(Values.CustomerAuth);

    public static readonly ClientToolResultItemErrorType ClientTimeout = new(Values.ClientTimeout);

    public static readonly ClientToolResultItemErrorType Unknown = new(Values.Unknown);

    public ClientToolResultItemErrorType(string value)
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
    public static ClientToolResultItemErrorType FromCustom(string value)
    {
        return new ClientToolResultItemErrorType(value);
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

    public static bool operator ==(ClientToolResultItemErrorType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientToolResultItemErrorType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientToolResultItemErrorType value) => value.Value;

    public static explicit operator ClientToolResultItemErrorType(string value) => new(value);

    internal class ClientToolResultItemErrorTypeSerializer
        : JsonConverter<ClientToolResultItemErrorType>
    {
        public override ClientToolResultItemErrorType Read(
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
            return new ClientToolResultItemErrorType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientToolResultItemErrorType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientToolResultItemErrorType ReadAsPropertyName(
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
            return new ClientToolResultItemErrorType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientToolResultItemErrorType value,
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
