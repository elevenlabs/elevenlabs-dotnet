// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SendMessageMulti.JsonConverter))]
[Serializable]
public class SendMessageMulti
{
    private SendMessageMulti(string type, object? value)
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
    /// Create a SendMessageMulti from a InitializeConnectionMulti value.
    /// </summary>
    public static SendMessageMulti FromInitializeConnectionMulti(
        global::ElevenLabs.InitializeConnectionMulti value
    ) => new("initializeConnectionMulti", value);

    /// <summary>
    /// Create a SendMessageMulti from a InitialiseContext value.
    /// </summary>
    public static SendMessageMulti FromInitialiseContext(
        global::ElevenLabs.InitialiseContext value
    ) => new("initialiseContext", value);

    /// <summary>
    /// Create a SendMessageMulti from a SendTextMulti value.
    /// </summary>
    public static SendMessageMulti FromSendTextMulti(global::ElevenLabs.SendTextMulti value) =>
        new("sendTextMulti", value);

    /// <summary>
    /// Create a SendMessageMulti from a FlushContext value.
    /// </summary>
    public static SendMessageMulti FromFlushContext(global::ElevenLabs.FlushContext value) =>
        new("flushContext", value);

    /// <summary>
    /// Create a SendMessageMulti from a CloseContext value.
    /// </summary>
    public static SendMessageMulti FromCloseContext(global::ElevenLabs.CloseContext value) =>
        new("closeContext", value);

    /// <summary>
    /// Create a SendMessageMulti from a CloseSocket value.
    /// </summary>
    public static SendMessageMulti FromCloseSocket(global::ElevenLabs.CloseSocket value) =>
        new("closeSocket", value);

    /// <summary>
    /// Create a SendMessageMulti from a KeepContextAlive value.
    /// </summary>
    public static SendMessageMulti FromKeepContextAlive(
        global::ElevenLabs.KeepContextAlive value
    ) => new("keepContextAlive", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "initializeConnectionMulti".
    /// </summary>
    public bool IsInitializeConnectionMulti() => Type == "initializeConnectionMulti";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "initialiseContext".
    /// </summary>
    public bool IsInitialiseContext() => Type == "initialiseContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sendTextMulti".
    /// </summary>
    public bool IsSendTextMulti() => Type == "sendTextMulti";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flushContext".
    /// </summary>
    public bool IsFlushContext() => Type == "flushContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "closeContext".
    /// </summary>
    public bool IsCloseContext() => Type == "closeContext";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "closeSocket".
    /// </summary>
    public bool IsCloseSocket() => Type == "closeSocket";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "keepContextAlive".
    /// </summary>
    public bool IsKeepContextAlive() => Type == "keepContextAlive";

    /// <summary>
    /// Returns the value as a InitializeConnectionMulti if <see cref="Type"/> is "initializeConnectionMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'initializeConnectionMulti'.</exception>
    public global::ElevenLabs.InitializeConnectionMulti AsInitializeConnectionMulti() =>
        IsInitializeConnectionMulti()
            ? (global::ElevenLabs.InitializeConnectionMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'initializeConnectionMulti'");

    /// <summary>
    /// Returns the value as a InitialiseContext if <see cref="Type"/> is "initialiseContext", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'initialiseContext'.</exception>
    public global::ElevenLabs.InitialiseContext AsInitialiseContext() =>
        IsInitialiseContext()
            ? (global::ElevenLabs.InitialiseContext)Value!
            : throw new ElevenLabsClientException("Union type is not 'initialiseContext'");

    /// <summary>
    /// Returns the value as a SendTextMulti if <see cref="Type"/> is "sendTextMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'sendTextMulti'.</exception>
    public global::ElevenLabs.SendTextMulti AsSendTextMulti() =>
        IsSendTextMulti()
            ? (global::ElevenLabs.SendTextMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'sendTextMulti'");

    /// <summary>
    /// Returns the value as a FlushContext if <see cref="Type"/> is "flushContext", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'flushContext'.</exception>
    public global::ElevenLabs.FlushContext AsFlushContext() =>
        IsFlushContext()
            ? (global::ElevenLabs.FlushContext)Value!
            : throw new ElevenLabsClientException("Union type is not 'flushContext'");

    /// <summary>
    /// Returns the value as a CloseContext if <see cref="Type"/> is "closeContext", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'closeContext'.</exception>
    public global::ElevenLabs.CloseContext AsCloseContext() =>
        IsCloseContext()
            ? (global::ElevenLabs.CloseContext)Value!
            : throw new ElevenLabsClientException("Union type is not 'closeContext'");

    /// <summary>
    /// Returns the value as a CloseSocket if <see cref="Type"/> is "closeSocket", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'closeSocket'.</exception>
    public global::ElevenLabs.CloseSocket AsCloseSocket() =>
        IsCloseSocket()
            ? (global::ElevenLabs.CloseSocket)Value!
            : throw new ElevenLabsClientException("Union type is not 'closeSocket'");

    /// <summary>
    /// Returns the value as a KeepContextAlive if <see cref="Type"/> is "keepContextAlive", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'keepContextAlive'.</exception>
    public global::ElevenLabs.KeepContextAlive AsKeepContextAlive() =>
        IsKeepContextAlive()
            ? (global::ElevenLabs.KeepContextAlive)Value!
            : throw new ElevenLabsClientException("Union type is not 'keepContextAlive'");

    /// <summary>
    /// Attempts to cast the value to a InitializeConnectionMulti and returns true if successful.
    /// </summary>
    public bool TryGetInitializeConnectionMulti(
        out global::ElevenLabs.InitializeConnectionMulti? value
    )
    {
        if (Type == "initializeConnectionMulti")
        {
            value = (global::ElevenLabs.InitializeConnectionMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a InitialiseContext and returns true if successful.
    /// </summary>
    public bool TryGetInitialiseContext(out global::ElevenLabs.InitialiseContext? value)
    {
        if (Type == "initialiseContext")
        {
            value = (global::ElevenLabs.InitialiseContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a SendTextMulti and returns true if successful.
    /// </summary>
    public bool TryGetSendTextMulti(out global::ElevenLabs.SendTextMulti? value)
    {
        if (Type == "sendTextMulti")
        {
            value = (global::ElevenLabs.SendTextMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a FlushContext and returns true if successful.
    /// </summary>
    public bool TryGetFlushContext(out global::ElevenLabs.FlushContext? value)
    {
        if (Type == "flushContext")
        {
            value = (global::ElevenLabs.FlushContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CloseContext and returns true if successful.
    /// </summary>
    public bool TryGetCloseContext(out global::ElevenLabs.CloseContext? value)
    {
        if (Type == "closeContext")
        {
            value = (global::ElevenLabs.CloseContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CloseSocket and returns true if successful.
    /// </summary>
    public bool TryGetCloseSocket(out global::ElevenLabs.CloseSocket? value)
    {
        if (Type == "closeSocket")
        {
            value = (global::ElevenLabs.CloseSocket)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a KeepContextAlive and returns true if successful.
    /// </summary>
    public bool TryGetKeepContextAlive(out global::ElevenLabs.KeepContextAlive? value)
    {
        if (Type == "keepContextAlive")
        {
            value = (global::ElevenLabs.KeepContextAlive)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.InitializeConnectionMulti,
            T
        > onInitializeConnectionMulti,
        global::System.Func<global::ElevenLabs.InitialiseContext, T> onInitialiseContext,
        global::System.Func<global::ElevenLabs.SendTextMulti, T> onSendTextMulti,
        global::System.Func<global::ElevenLabs.FlushContext, T> onFlushContext,
        global::System.Func<global::ElevenLabs.CloseContext, T> onCloseContext,
        global::System.Func<global::ElevenLabs.CloseSocket, T> onCloseSocket,
        global::System.Func<global::ElevenLabs.KeepContextAlive, T> onKeepContextAlive
    )
    {
        return Type switch
        {
            "initializeConnectionMulti" => onInitializeConnectionMulti(
                AsInitializeConnectionMulti()
            ),
            "initialiseContext" => onInitialiseContext(AsInitialiseContext()),
            "sendTextMulti" => onSendTextMulti(AsSendTextMulti()),
            "flushContext" => onFlushContext(AsFlushContext()),
            "closeContext" => onCloseContext(AsCloseContext()),
            "closeSocket" => onCloseSocket(AsCloseSocket()),
            "keepContextAlive" => onKeepContextAlive(AsKeepContextAlive()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.InitializeConnectionMulti> onInitializeConnectionMulti,
        global::System.Action<global::ElevenLabs.InitialiseContext> onInitialiseContext,
        global::System.Action<global::ElevenLabs.SendTextMulti> onSendTextMulti,
        global::System.Action<global::ElevenLabs.FlushContext> onFlushContext,
        global::System.Action<global::ElevenLabs.CloseContext> onCloseContext,
        global::System.Action<global::ElevenLabs.CloseSocket> onCloseSocket,
        global::System.Action<global::ElevenLabs.KeepContextAlive> onKeepContextAlive
    )
    {
        switch (Type)
        {
            case "initializeConnectionMulti":
                onInitializeConnectionMulti(AsInitializeConnectionMulti());
                break;
            case "initialiseContext":
                onInitialiseContext(AsInitialiseContext());
                break;
            case "sendTextMulti":
                onSendTextMulti(AsSendTextMulti());
                break;
            case "flushContext":
                onFlushContext(AsFlushContext());
                break;
            case "closeContext":
                onCloseContext(AsCloseContext());
                break;
            case "closeSocket":
                onCloseSocket(AsCloseSocket());
                break;
            case "keepContextAlive":
                onKeepContextAlive(AsKeepContextAlive());
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
        if (obj is not SendMessageMulti other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SendMessageMulti(
        global::ElevenLabs.InitializeConnectionMulti value
    ) => new("initializeConnectionMulti", value);

    public static implicit operator SendMessageMulti(global::ElevenLabs.InitialiseContext value) =>
        new("initialiseContext", value);

    public static implicit operator SendMessageMulti(global::ElevenLabs.SendTextMulti value) =>
        new("sendTextMulti", value);

    public static implicit operator SendMessageMulti(global::ElevenLabs.FlushContext value) =>
        new("flushContext", value);

    public static implicit operator SendMessageMulti(global::ElevenLabs.CloseContext value) =>
        new("closeContext", value);

    public static implicit operator SendMessageMulti(global::ElevenLabs.CloseSocket value) =>
        new("closeSocket", value);

    public static implicit operator SendMessageMulti(global::ElevenLabs.KeepContextAlive value) =>
        new("keepContextAlive", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SendMessageMulti>
    {
        public override SendMessageMulti? Read(
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

                // A payload carrying a member's literal decodes as that member or not at all.
                var matchedLiteral = false;

                if (HasLiteral(document, "text", " "))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.InitializeConnectionMulti),
                            options
                        );
                        if (value != null)
                        {
                            return new SendMessageMulti("initializeConnectionMulti", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "text", ""))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.KeepContextAlive),
                            options
                        );
                        if (value != null)
                        {
                            return new SendMessageMulti("keepContextAlive", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (matchedLiteral)
                {
                    throw new JsonException(
                        "Cannot deserialize JSON object into SendMessageMulti: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "initializeConnectionMulti",
                        typeof(global::ElevenLabs.InitializeConnectionMulti),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "initialiseContext",
                        typeof(global::ElevenLabs.InitialiseContext),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "sendTextMulti",
                        typeof(global::ElevenLabs.SendTextMulti),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "flushContext",
                        typeof(global::ElevenLabs.FlushContext),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "closeContext",
                        typeof(global::ElevenLabs.CloseContext),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "closeSocket",
                        typeof(global::ElevenLabs.CloseSocket),
                        new[] { "close_socket" }
                    ),
                    (
                        "keepContextAlive",
                        typeof(global::ElevenLabs.KeepContextAlive),
                        global::System.Array.Empty<string>()
                    ),
                };

                foreach (var (key, type, anyOfKeys) in types)
                {
                    // A member whose properties are all optional deserializes from any object, so it
                    // only gets a turn when the payload carries one of its own keys.
                    if (anyOfKeys.Length > 0 && !HasAnyProperty(document, anyOfKeys))
                    {
                        continue;
                    }

                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new SendMessageMulti(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into SendMessageMulti"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendMessageMulti value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override SendMessageMulti ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            SendMessageMulti result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendMessageMulti value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasLiteral(JsonDocument document, string key, string expected)
        {
            if (!document.RootElement.TryGetProperty(key, out var property))
            {
                return false;
            }

            return property.ValueKind == JsonValueKind.String && property.GetString() == expected;
        }

        private static bool HasAnyProperty(JsonDocument document, string[] keys)
        {
            foreach (var key in keys)
            {
                if (document.RootElement.TryGetProperty(key, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
