// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

/// <summary>Optional auth connection to use for authentication with this MCP server</summary>
[JsonConverter(typeof(McpServerConfigUpdateRequestModelAuthConnection.JsonConverter))]
[Serializable]
public class McpServerConfigUpdateRequestModelAuthConnection
{
    private McpServerConfigUpdateRequestModelAuthConnection(string type, object? value)
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
    /// Create a McpServerConfigUpdateRequestModelAuthConnection from a AuthConnectionLocator value.
    /// </summary>
    public static McpServerConfigUpdateRequestModelAuthConnection FromAuthConnectionLocator(
        global::ElevenLabs.AuthConnectionLocator value
    ) => new("authConnectionLocator", value);

    /// <summary>
    /// Create a McpServerConfigUpdateRequestModelAuthConnection from a EnvironmentAuthConnectionLocator value.
    /// </summary>
    public static McpServerConfigUpdateRequestModelAuthConnection FromEnvironmentAuthConnectionLocator(
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
        if (obj is not McpServerConfigUpdateRequestModelAuthConnection other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator McpServerConfigUpdateRequestModelAuthConnection(
        global::ElevenLabs.AuthConnectionLocator value
    ) => new("authConnectionLocator", value);

    public static implicit operator McpServerConfigUpdateRequestModelAuthConnection(
        global::ElevenLabs.EnvironmentAuthConnectionLocator value
    ) => new("environmentAuthConnectionLocator", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<McpServerConfigUpdateRequestModelAuthConnection>
    {
        public override McpServerConfigUpdateRequestModelAuthConnection? Read(
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
                            return new McpServerConfigUpdateRequestModelAuthConnection(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into McpServerConfigUpdateRequestModelAuthConnection"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpServerConfigUpdateRequestModelAuthConnection value,
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

        public override McpServerConfigUpdateRequestModelAuthConnection ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            McpServerConfigUpdateRequestModelAuthConnection result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpServerConfigUpdateRequestModelAuthConnection value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
