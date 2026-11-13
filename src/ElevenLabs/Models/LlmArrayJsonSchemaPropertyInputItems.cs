// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LlmArrayJsonSchemaPropertyInputItems.JsonConverter))]
[Serializable]
public class LlmArrayJsonSchemaPropertyInputItems
{
    private LlmArrayJsonSchemaPropertyInputItems(string type, object? value)
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
    /// Create a LlmArrayJsonSchemaPropertyInputItems from a LlmLiteralJsonSchemaProperty value.
    /// </summary>
    public static LlmArrayJsonSchemaPropertyInputItems FromLlmLiteralJsonSchemaProperty(
        global::ElevenLabs.LlmLiteralJsonSchemaProperty value
    ) => new("llmLiteralJsonSchemaProperty", value);

    /// <summary>
    /// Create a LlmArrayJsonSchemaPropertyInputItems from a LlmObjectJsonSchemaPropertyInput value.
    /// </summary>
    public static LlmArrayJsonSchemaPropertyInputItems FromLlmObjectJsonSchemaPropertyInput(
        global::ElevenLabs.LlmObjectJsonSchemaPropertyInput value
    ) => new("llmObjectJsonSchemaPropertyInput", value);

    /// <summary>
    /// Create a LlmArrayJsonSchemaPropertyInputItems from a LlmArrayJsonSchemaPropertyInput value.
    /// </summary>
    public static LlmArrayJsonSchemaPropertyInputItems FromLlmArrayJsonSchemaPropertyInput(
        global::ElevenLabs.LlmArrayJsonSchemaPropertyInput value
    ) => new("llmArrayJsonSchemaPropertyInput", value);

    /// <summary>
    /// Create a LlmArrayJsonSchemaPropertyInputItems from a LlmAnyOfJsonSchemaPropertyInput value.
    /// </summary>
    public static LlmArrayJsonSchemaPropertyInputItems FromLlmAnyOfJsonSchemaPropertyInput(
        global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput value
    ) => new("llmAnyOfJsonSchemaPropertyInput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llmLiteralJsonSchemaProperty".
    /// </summary>
    public bool IsLlmLiteralJsonSchemaProperty() => Type == "llmLiteralJsonSchemaProperty";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llmObjectJsonSchemaPropertyInput".
    /// </summary>
    public bool IsLlmObjectJsonSchemaPropertyInput() => Type == "llmObjectJsonSchemaPropertyInput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llmArrayJsonSchemaPropertyInput".
    /// </summary>
    public bool IsLlmArrayJsonSchemaPropertyInput() => Type == "llmArrayJsonSchemaPropertyInput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llmAnyOfJsonSchemaPropertyInput".
    /// </summary>
    public bool IsLlmAnyOfJsonSchemaPropertyInput() => Type == "llmAnyOfJsonSchemaPropertyInput";

    /// <summary>
    /// Returns the value as a LlmLiteralJsonSchemaProperty if <see cref="Type"/> is "llmLiteralJsonSchemaProperty", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'llmLiteralJsonSchemaProperty'.</exception>
    public global::ElevenLabs.LlmLiteralJsonSchemaProperty AsLlmLiteralJsonSchemaProperty() =>
        IsLlmLiteralJsonSchemaProperty()
            ? (global::ElevenLabs.LlmLiteralJsonSchemaProperty)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'llmLiteralJsonSchemaProperty'"
            );

    /// <summary>
    /// Returns the value as a LlmObjectJsonSchemaPropertyInput if <see cref="Type"/> is "llmObjectJsonSchemaPropertyInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'llmObjectJsonSchemaPropertyInput'.</exception>
    public global::ElevenLabs.LlmObjectJsonSchemaPropertyInput AsLlmObjectJsonSchemaPropertyInput() =>
        IsLlmObjectJsonSchemaPropertyInput()
            ? (global::ElevenLabs.LlmObjectJsonSchemaPropertyInput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'llmObjectJsonSchemaPropertyInput'"
            );

    /// <summary>
    /// Returns the value as a LlmArrayJsonSchemaPropertyInput if <see cref="Type"/> is "llmArrayJsonSchemaPropertyInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'llmArrayJsonSchemaPropertyInput'.</exception>
    public global::ElevenLabs.LlmArrayJsonSchemaPropertyInput AsLlmArrayJsonSchemaPropertyInput() =>
        IsLlmArrayJsonSchemaPropertyInput()
            ? (global::ElevenLabs.LlmArrayJsonSchemaPropertyInput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'llmArrayJsonSchemaPropertyInput'"
            );

    /// <summary>
    /// Returns the value as a LlmAnyOfJsonSchemaPropertyInput if <see cref="Type"/> is "llmAnyOfJsonSchemaPropertyInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'llmAnyOfJsonSchemaPropertyInput'.</exception>
    public global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput AsLlmAnyOfJsonSchemaPropertyInput() =>
        IsLlmAnyOfJsonSchemaPropertyInput()
            ? (global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'llmAnyOfJsonSchemaPropertyInput'"
            );

    /// <summary>
    /// Attempts to cast the value to a LlmLiteralJsonSchemaProperty and returns true if successful.
    /// </summary>
    public bool TryGetLlmLiteralJsonSchemaProperty(
        out global::ElevenLabs.LlmLiteralJsonSchemaProperty? value
    )
    {
        if (Type == "llmLiteralJsonSchemaProperty")
        {
            value = (global::ElevenLabs.LlmLiteralJsonSchemaProperty)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a LlmObjectJsonSchemaPropertyInput and returns true if successful.
    /// </summary>
    public bool TryGetLlmObjectJsonSchemaPropertyInput(
        out global::ElevenLabs.LlmObjectJsonSchemaPropertyInput? value
    )
    {
        if (Type == "llmObjectJsonSchemaPropertyInput")
        {
            value = (global::ElevenLabs.LlmObjectJsonSchemaPropertyInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a LlmArrayJsonSchemaPropertyInput and returns true if successful.
    /// </summary>
    public bool TryGetLlmArrayJsonSchemaPropertyInput(
        out global::ElevenLabs.LlmArrayJsonSchemaPropertyInput? value
    )
    {
        if (Type == "llmArrayJsonSchemaPropertyInput")
        {
            value = (global::ElevenLabs.LlmArrayJsonSchemaPropertyInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a LlmAnyOfJsonSchemaPropertyInput and returns true if successful.
    /// </summary>
    public bool TryGetLlmAnyOfJsonSchemaPropertyInput(
        out global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput? value
    )
    {
        if (Type == "llmAnyOfJsonSchemaPropertyInput")
        {
            value = (global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.LlmLiteralJsonSchemaProperty,
            T
        > onLlmLiteralJsonSchemaProperty,
        global::System.Func<
            global::ElevenLabs.LlmObjectJsonSchemaPropertyInput,
            T
        > onLlmObjectJsonSchemaPropertyInput,
        global::System.Func<
            global::ElevenLabs.LlmArrayJsonSchemaPropertyInput,
            T
        > onLlmArrayJsonSchemaPropertyInput,
        global::System.Func<
            global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput,
            T
        > onLlmAnyOfJsonSchemaPropertyInput
    )
    {
        return Type switch
        {
            "llmLiteralJsonSchemaProperty" => onLlmLiteralJsonSchemaProperty(
                AsLlmLiteralJsonSchemaProperty()
            ),
            "llmObjectJsonSchemaPropertyInput" => onLlmObjectJsonSchemaPropertyInput(
                AsLlmObjectJsonSchemaPropertyInput()
            ),
            "llmArrayJsonSchemaPropertyInput" => onLlmArrayJsonSchemaPropertyInput(
                AsLlmArrayJsonSchemaPropertyInput()
            ),
            "llmAnyOfJsonSchemaPropertyInput" => onLlmAnyOfJsonSchemaPropertyInput(
                AsLlmAnyOfJsonSchemaPropertyInput()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.LlmLiteralJsonSchemaProperty> onLlmLiteralJsonSchemaProperty,
        global::System.Action<global::ElevenLabs.LlmObjectJsonSchemaPropertyInput> onLlmObjectJsonSchemaPropertyInput,
        global::System.Action<global::ElevenLabs.LlmArrayJsonSchemaPropertyInput> onLlmArrayJsonSchemaPropertyInput,
        global::System.Action<global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput> onLlmAnyOfJsonSchemaPropertyInput
    )
    {
        switch (Type)
        {
            case "llmLiteralJsonSchemaProperty":
                onLlmLiteralJsonSchemaProperty(AsLlmLiteralJsonSchemaProperty());
                break;
            case "llmObjectJsonSchemaPropertyInput":
                onLlmObjectJsonSchemaPropertyInput(AsLlmObjectJsonSchemaPropertyInput());
                break;
            case "llmArrayJsonSchemaPropertyInput":
                onLlmArrayJsonSchemaPropertyInput(AsLlmArrayJsonSchemaPropertyInput());
                break;
            case "llmAnyOfJsonSchemaPropertyInput":
                onLlmAnyOfJsonSchemaPropertyInput(AsLlmAnyOfJsonSchemaPropertyInput());
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
        if (obj is not LlmArrayJsonSchemaPropertyInputItems other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator LlmArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.LlmLiteralJsonSchemaProperty value
    ) => new("llmLiteralJsonSchemaProperty", value);

    public static implicit operator LlmArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.LlmObjectJsonSchemaPropertyInput value
    ) => new("llmObjectJsonSchemaPropertyInput", value);

    public static implicit operator LlmArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.LlmArrayJsonSchemaPropertyInput value
    ) => new("llmArrayJsonSchemaPropertyInput", value);

    public static implicit operator LlmArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput value
    ) => new("llmAnyOfJsonSchemaPropertyInput", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<LlmArrayJsonSchemaPropertyInputItems>
    {
        public override LlmArrayJsonSchemaPropertyInputItems? Read(
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

                if (HasLiteral(document, "type", "object"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.LlmObjectJsonSchemaPropertyInput),
                            options
                        );
                        if (value != null)
                        {
                            return new LlmArrayJsonSchemaPropertyInputItems(
                                "llmObjectJsonSchemaPropertyInput",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "array"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.LlmArrayJsonSchemaPropertyInput),
                            options
                        );
                        if (value != null)
                        {
                            return new LlmArrayJsonSchemaPropertyInputItems(
                                "llmArrayJsonSchemaPropertyInput",
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
                        "Cannot deserialize JSON object into LlmArrayJsonSchemaPropertyInputItems: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "llmLiteralJsonSchemaProperty",
                        typeof(global::ElevenLabs.LlmLiteralJsonSchemaProperty),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "llmObjectJsonSchemaPropertyInput",
                        typeof(global::ElevenLabs.LlmObjectJsonSchemaPropertyInput),
                        new[] { "type", "required", "description", "properties" }
                    ),
                    (
                        "llmArrayJsonSchemaPropertyInput",
                        typeof(global::ElevenLabs.LlmArrayJsonSchemaPropertyInput),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "llmAnyOfJsonSchemaPropertyInput",
                        typeof(global::ElevenLabs.LlmAnyOfJsonSchemaPropertyInput),
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
                            return new LlmArrayJsonSchemaPropertyInputItems(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into LlmArrayJsonSchemaPropertyInputItems"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            LlmArrayJsonSchemaPropertyInputItems value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override LlmArrayJsonSchemaPropertyInputItems ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            LlmArrayJsonSchemaPropertyInputItems result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LlmArrayJsonSchemaPropertyInputItems value,
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
