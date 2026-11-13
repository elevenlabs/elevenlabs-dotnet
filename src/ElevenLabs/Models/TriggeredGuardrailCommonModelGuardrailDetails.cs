// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TriggeredGuardrailCommonModelGuardrailDetails.JsonConverter))]
[Serializable]
public class TriggeredGuardrailCommonModelGuardrailDetails
{
    private TriggeredGuardrailCommonModelGuardrailDetails(string type, object? value)
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
    /// Create a TriggeredGuardrailCommonModelGuardrailDetails from a GuardrailLlmVerdict value.
    /// </summary>
    public static TriggeredGuardrailCommonModelGuardrailDetails FromGuardrailLlmVerdict(
        global::ElevenLabs.GuardrailLlmVerdict value
    ) => new("guardrailLlmVerdict", value);

    /// <summary>
    /// Create a TriggeredGuardrailCommonModelGuardrailDetails from a GuardrailClassifierVerdict value.
    /// </summary>
    public static TriggeredGuardrailCommonModelGuardrailDetails FromGuardrailClassifierVerdict(
        global::ElevenLabs.GuardrailClassifierVerdict value
    ) => new("guardrailClassifierVerdict", value);

    /// <summary>
    /// Create a TriggeredGuardrailCommonModelGuardrailDetails from a GuardrailUnknownVerdict value.
    /// </summary>
    public static TriggeredGuardrailCommonModelGuardrailDetails FromGuardrailUnknownVerdict(
        global::ElevenLabs.GuardrailUnknownVerdict value
    ) => new("guardrailUnknownVerdict", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guardrailLlmVerdict".
    /// </summary>
    public bool IsGuardrailLlmVerdict() => Type == "guardrailLlmVerdict";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guardrailClassifierVerdict".
    /// </summary>
    public bool IsGuardrailClassifierVerdict() => Type == "guardrailClassifierVerdict";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "guardrailUnknownVerdict".
    /// </summary>
    public bool IsGuardrailUnknownVerdict() => Type == "guardrailUnknownVerdict";

    /// <summary>
    /// Returns the value as a GuardrailLlmVerdict if <see cref="Type"/> is "guardrailLlmVerdict", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'guardrailLlmVerdict'.</exception>
    public global::ElevenLabs.GuardrailLlmVerdict AsGuardrailLlmVerdict() =>
        IsGuardrailLlmVerdict()
            ? (global::ElevenLabs.GuardrailLlmVerdict)Value!
            : throw new ElevenLabsClientException("Union type is not 'guardrailLlmVerdict'");

    /// <summary>
    /// Returns the value as a GuardrailClassifierVerdict if <see cref="Type"/> is "guardrailClassifierVerdict", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'guardrailClassifierVerdict'.</exception>
    public global::ElevenLabs.GuardrailClassifierVerdict AsGuardrailClassifierVerdict() =>
        IsGuardrailClassifierVerdict()
            ? (global::ElevenLabs.GuardrailClassifierVerdict)Value!
            : throw new ElevenLabsClientException("Union type is not 'guardrailClassifierVerdict'");

    /// <summary>
    /// Returns the value as a GuardrailUnknownVerdict if <see cref="Type"/> is "guardrailUnknownVerdict", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'guardrailUnknownVerdict'.</exception>
    public global::ElevenLabs.GuardrailUnknownVerdict AsGuardrailUnknownVerdict() =>
        IsGuardrailUnknownVerdict()
            ? (global::ElevenLabs.GuardrailUnknownVerdict)Value!
            : throw new ElevenLabsClientException("Union type is not 'guardrailUnknownVerdict'");

    /// <summary>
    /// Attempts to cast the value to a GuardrailLlmVerdict and returns true if successful.
    /// </summary>
    public bool TryGetGuardrailLlmVerdict(out global::ElevenLabs.GuardrailLlmVerdict? value)
    {
        if (Type == "guardrailLlmVerdict")
        {
            value = (global::ElevenLabs.GuardrailLlmVerdict)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a GuardrailClassifierVerdict and returns true if successful.
    /// </summary>
    public bool TryGetGuardrailClassifierVerdict(
        out global::ElevenLabs.GuardrailClassifierVerdict? value
    )
    {
        if (Type == "guardrailClassifierVerdict")
        {
            value = (global::ElevenLabs.GuardrailClassifierVerdict)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a GuardrailUnknownVerdict and returns true if successful.
    /// </summary>
    public bool TryGetGuardrailUnknownVerdict(out global::ElevenLabs.GuardrailUnknownVerdict? value)
    {
        if (Type == "guardrailUnknownVerdict")
        {
            value = (global::ElevenLabs.GuardrailUnknownVerdict)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.GuardrailLlmVerdict, T> onGuardrailLlmVerdict,
        global::System.Func<
            global::ElevenLabs.GuardrailClassifierVerdict,
            T
        > onGuardrailClassifierVerdict,
        global::System.Func<global::ElevenLabs.GuardrailUnknownVerdict, T> onGuardrailUnknownVerdict
    )
    {
        return Type switch
        {
            "guardrailLlmVerdict" => onGuardrailLlmVerdict(AsGuardrailLlmVerdict()),
            "guardrailClassifierVerdict" => onGuardrailClassifierVerdict(
                AsGuardrailClassifierVerdict()
            ),
            "guardrailUnknownVerdict" => onGuardrailUnknownVerdict(AsGuardrailUnknownVerdict()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.GuardrailLlmVerdict> onGuardrailLlmVerdict,
        global::System.Action<global::ElevenLabs.GuardrailClassifierVerdict> onGuardrailClassifierVerdict,
        global::System.Action<global::ElevenLabs.GuardrailUnknownVerdict> onGuardrailUnknownVerdict
    )
    {
        switch (Type)
        {
            case "guardrailLlmVerdict":
                onGuardrailLlmVerdict(AsGuardrailLlmVerdict());
                break;
            case "guardrailClassifierVerdict":
                onGuardrailClassifierVerdict(AsGuardrailClassifierVerdict());
                break;
            case "guardrailUnknownVerdict":
                onGuardrailUnknownVerdict(AsGuardrailUnknownVerdict());
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
        if (obj is not TriggeredGuardrailCommonModelGuardrailDetails other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TriggeredGuardrailCommonModelGuardrailDetails(
        global::ElevenLabs.GuardrailLlmVerdict value
    ) => new("guardrailLlmVerdict", value);

    public static implicit operator TriggeredGuardrailCommonModelGuardrailDetails(
        global::ElevenLabs.GuardrailClassifierVerdict value
    ) => new("guardrailClassifierVerdict", value);

    public static implicit operator TriggeredGuardrailCommonModelGuardrailDetails(
        global::ElevenLabs.GuardrailUnknownVerdict value
    ) => new("guardrailUnknownVerdict", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<TriggeredGuardrailCommonModelGuardrailDetails>
    {
        public override TriggeredGuardrailCommonModelGuardrailDetails? Read(
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

                if (HasLiteral(document, "type", "llm"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.GuardrailLlmVerdict),
                            options
                        );
                        if (value != null)
                        {
                            return new TriggeredGuardrailCommonModelGuardrailDetails(
                                "guardrailLlmVerdict",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "classifier"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.GuardrailClassifierVerdict),
                            options
                        );
                        if (value != null)
                        {
                            return new TriggeredGuardrailCommonModelGuardrailDetails(
                                "guardrailClassifierVerdict",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "unknown"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.GuardrailUnknownVerdict),
                            options
                        );
                        if (value != null)
                        {
                            return new TriggeredGuardrailCommonModelGuardrailDetails(
                                "guardrailUnknownVerdict",
                                value
                            );
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
                        "Cannot deserialize JSON object into TriggeredGuardrailCommonModelGuardrailDetails: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "guardrailLlmVerdict",
                        typeof(global::ElevenLabs.GuardrailLlmVerdict),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "guardrailClassifierVerdict",
                        typeof(global::ElevenLabs.GuardrailClassifierVerdict),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "guardrailUnknownVerdict",
                        typeof(global::ElevenLabs.GuardrailUnknownVerdict),
                        new[] { "type" }
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
                            return new TriggeredGuardrailCommonModelGuardrailDetails(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into TriggeredGuardrailCommonModelGuardrailDetails"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            TriggeredGuardrailCommonModelGuardrailDetails value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override TriggeredGuardrailCommonModelGuardrailDetails ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            TriggeredGuardrailCommonModelGuardrailDetails result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TriggeredGuardrailCommonModelGuardrailDetails value,
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
