// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Optional mTLS auth connection. When set, its client certificate is used for the TLS handshake with the LLM endpoint and, when auth_connection is OAuth2 client credentials or OAuth2 JWT, with its token endpoint too. Application auth stays on auth_connection or api_key. auth_connection must then be OAuth2 client credentials, OAuth2 JWT or bearer.</summary>
[JsonConverter(typeof(MtlsAuthConnection.JsonConverter))]
[Serializable]
public class MtlsAuthConnection
{
    private MtlsAuthConnection(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a MtlsAuthConnection from a AuthConnectionLocator value.
    /// </summary>
    public static MtlsAuthConnection FromAuthConnectionLocator(
        global::ElevenLabs.AuthConnectionLocator value
    ) => new("authConnectionLocator", value);

    /// <summary>
    /// Create a MtlsAuthConnection from a EnvironmentAuthConnectionLocator value.
    /// </summary>
    public static MtlsAuthConnection FromEnvironmentAuthConnectionLocator(
        global::ElevenLabs.EnvironmentAuthConnectionLocator value
    ) => new("environmentAuthConnectionLocator", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "authConnectionLocator".
    /// </summary>
    public bool IsAuthConnectionLocator() => Type == "authConnectionLocator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "environmentAuthConnectionLocator".
    /// </summary>
    public bool IsEnvironmentAuthConnectionLocator() => Type == "environmentAuthConnectionLocator";

    /// <summary>
    /// Returns the value as a AuthConnectionLocator if <see cref="Type"/> is "authConnectionLocator", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'authConnectionLocator'.</exception>
    public global::ElevenLabs.AuthConnectionLocator AsAuthConnectionLocator() =>
        IsAuthConnectionLocator()
            ? (global::ElevenLabs.AuthConnectionLocator)Value!
            : throw new ElevenLabsClientException("Union type is not 'authConnectionLocator'");

    /// <summary>
    /// Returns the value as a EnvironmentAuthConnectionLocator if <see cref="Type"/> is "environmentAuthConnectionLocator", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'environmentAuthConnectionLocator'.</exception>
    public global::ElevenLabs.EnvironmentAuthConnectionLocator AsEnvironmentAuthConnectionLocator() =>
        IsEnvironmentAuthConnectionLocator()
            ? (global::ElevenLabs.EnvironmentAuthConnectionLocator)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'environmentAuthConnectionLocator'"
            );

    /// <summary>
    /// Attempts to cast the value to a AuthConnectionLocator and returns true if successful.
    /// </summary>
    public bool TryGetAuthConnectionLocator(out global::ElevenLabs.AuthConnectionLocator? value)
    {
        if (Type == "authConnectionLocator")
        {
            value = (global::ElevenLabs.AuthConnectionLocator)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a EnvironmentAuthConnectionLocator and returns true if successful.
    /// </summary>
    public bool TryGetEnvironmentAuthConnectionLocator(
        out global::ElevenLabs.EnvironmentAuthConnectionLocator? value
    )
    {
        if (Type == "environmentAuthConnectionLocator")
        {
            value = (global::ElevenLabs.EnvironmentAuthConnectionLocator)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.AuthConnectionLocator, T> onAuthConnectionLocator,
        global::System.Func<
            global::ElevenLabs.EnvironmentAuthConnectionLocator,
            T
        > onEnvironmentAuthConnectionLocator
    )
    {
        return Type switch
        {
            "authConnectionLocator" => onAuthConnectionLocator(AsAuthConnectionLocator()),
            "environmentAuthConnectionLocator" => onEnvironmentAuthConnectionLocator(
                AsEnvironmentAuthConnectionLocator()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AuthConnectionLocator> onAuthConnectionLocator,
        global::System.Action<global::ElevenLabs.EnvironmentAuthConnectionLocator> onEnvironmentAuthConnectionLocator
    )
    {
        switch (Type)
        {
            case "authConnectionLocator":
                onAuthConnectionLocator(AsAuthConnectionLocator());
                break;
            case "environmentAuthConnectionLocator":
                onEnvironmentAuthConnectionLocator(AsEnvironmentAuthConnectionLocator());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not MtlsAuthConnection other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator MtlsAuthConnection(
        global::ElevenLabs.AuthConnectionLocator value
    ) => new("authConnectionLocator", value);

    public static implicit operator MtlsAuthConnection(
        global::ElevenLabs.EnvironmentAuthConnectionLocator value
    ) => new("environmentAuthConnectionLocator", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<MtlsAuthConnection>
    {
        public override MtlsAuthConnection? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("authConnectionLocator", typeof(global::ElevenLabs.AuthConnectionLocator)),
                    (
                        "environmentAuthConnectionLocator",
                        typeof(global::ElevenLabs.EnvironmentAuthConnectionLocator)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new MtlsAuthConnection(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into MtlsAuthConnection"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            MtlsAuthConnection value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override MtlsAuthConnection ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            MtlsAuthConnection result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MtlsAuthConnection value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
