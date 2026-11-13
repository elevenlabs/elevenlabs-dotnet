// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Schema for array elements.</summary>
[JsonConverter(typeof(ArrayJsonSchemaPropertyInputItems.JsonConverter))]
[Serializable]
public class ArrayJsonSchemaPropertyInputItems
{
    private ArrayJsonSchemaPropertyInputItems(string type, object? value)
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
    /// Create a ArrayJsonSchemaPropertyInputItems from a LiteralJsonSchemaProperty value.
    /// </summary>
    public static ArrayJsonSchemaPropertyInputItems FromLiteralJsonSchemaProperty(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    /// <summary>
    /// Create a ArrayJsonSchemaPropertyInputItems from a ObjectJsonSchemaPropertyInput value.
    /// </summary>
    public static ArrayJsonSchemaPropertyInputItems FromObjectJsonSchemaPropertyInput(
        global::ElevenLabs.ObjectJsonSchemaPropertyInput value
    ) => new("objectJsonSchemaPropertyInput", value);

    /// <summary>
    /// Create a ArrayJsonSchemaPropertyInputItems from a ArrayJsonSchemaPropertyInput value.
    /// </summary>
    public static ArrayJsonSchemaPropertyInputItems FromArrayJsonSchemaPropertyInput(
        global::ElevenLabs.ArrayJsonSchemaPropertyInput value
    ) => new("arrayJsonSchemaPropertyInput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "literalJsonSchemaProperty".
    /// </summary>
    public bool IsLiteralJsonSchemaProperty() => Type == "literalJsonSchemaProperty";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "objectJsonSchemaPropertyInput".
    /// </summary>
    public bool IsObjectJsonSchemaPropertyInput() => Type == "objectJsonSchemaPropertyInput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "arrayJsonSchemaPropertyInput".
    /// </summary>
    public bool IsArrayJsonSchemaPropertyInput() => Type == "arrayJsonSchemaPropertyInput";

    /// <summary>
    /// Returns the value as a LiteralJsonSchemaProperty if <see cref="Type"/> is "literalJsonSchemaProperty", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'literalJsonSchemaProperty'.</exception>
    public global::ElevenLabs.LiteralJsonSchemaProperty AsLiteralJsonSchemaProperty() =>
        IsLiteralJsonSchemaProperty()
            ? (global::ElevenLabs.LiteralJsonSchemaProperty)Value!
            : throw new ElevenLabsClientException("Union type is not 'literalJsonSchemaProperty'");

    /// <summary>
    /// Returns the value as a ObjectJsonSchemaPropertyInput if <see cref="Type"/> is "objectJsonSchemaPropertyInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'objectJsonSchemaPropertyInput'.</exception>
    public global::ElevenLabs.ObjectJsonSchemaPropertyInput AsObjectJsonSchemaPropertyInput() =>
        IsObjectJsonSchemaPropertyInput()
            ? (global::ElevenLabs.ObjectJsonSchemaPropertyInput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'objectJsonSchemaPropertyInput'"
            );

    /// <summary>
    /// Returns the value as a ArrayJsonSchemaPropertyInput if <see cref="Type"/> is "arrayJsonSchemaPropertyInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'arrayJsonSchemaPropertyInput'.</exception>
    public global::ElevenLabs.ArrayJsonSchemaPropertyInput AsArrayJsonSchemaPropertyInput() =>
        IsArrayJsonSchemaPropertyInput()
            ? (global::ElevenLabs.ArrayJsonSchemaPropertyInput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'arrayJsonSchemaPropertyInput'"
            );

    /// <summary>
    /// Attempts to cast the value to a LiteralJsonSchemaProperty and returns true if successful.
    /// </summary>
    public bool TryGetLiteralJsonSchemaProperty(
        out global::ElevenLabs.LiteralJsonSchemaProperty? value
    )
    {
        if (Type == "literalJsonSchemaProperty")
        {
            value = (global::ElevenLabs.LiteralJsonSchemaProperty)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ObjectJsonSchemaPropertyInput and returns true if successful.
    /// </summary>
    public bool TryGetObjectJsonSchemaPropertyInput(
        out global::ElevenLabs.ObjectJsonSchemaPropertyInput? value
    )
    {
        if (Type == "objectJsonSchemaPropertyInput")
        {
            value = (global::ElevenLabs.ObjectJsonSchemaPropertyInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ArrayJsonSchemaPropertyInput and returns true if successful.
    /// </summary>
    public bool TryGetArrayJsonSchemaPropertyInput(
        out global::ElevenLabs.ArrayJsonSchemaPropertyInput? value
    )
    {
        if (Type == "arrayJsonSchemaPropertyInput")
        {
            value = (global::ElevenLabs.ArrayJsonSchemaPropertyInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.LiteralJsonSchemaProperty,
            T
        > onLiteralJsonSchemaProperty,
        global::System.Func<
            global::ElevenLabs.ObjectJsonSchemaPropertyInput,
            T
        > onObjectJsonSchemaPropertyInput,
        global::System.Func<
            global::ElevenLabs.ArrayJsonSchemaPropertyInput,
            T
        > onArrayJsonSchemaPropertyInput
    )
    {
        return Type switch
        {
            "literalJsonSchemaProperty" => onLiteralJsonSchemaProperty(
                AsLiteralJsonSchemaProperty()
            ),
            "objectJsonSchemaPropertyInput" => onObjectJsonSchemaPropertyInput(
                AsObjectJsonSchemaPropertyInput()
            ),
            "arrayJsonSchemaPropertyInput" => onArrayJsonSchemaPropertyInput(
                AsArrayJsonSchemaPropertyInput()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.LiteralJsonSchemaProperty> onLiteralJsonSchemaProperty,
        global::System.Action<global::ElevenLabs.ObjectJsonSchemaPropertyInput> onObjectJsonSchemaPropertyInput,
        global::System.Action<global::ElevenLabs.ArrayJsonSchemaPropertyInput> onArrayJsonSchemaPropertyInput
    )
    {
        switch (Type)
        {
            case "literalJsonSchemaProperty":
                onLiteralJsonSchemaProperty(AsLiteralJsonSchemaProperty());
                break;
            case "objectJsonSchemaPropertyInput":
                onObjectJsonSchemaPropertyInput(AsObjectJsonSchemaPropertyInput());
                break;
            case "arrayJsonSchemaPropertyInput":
                onArrayJsonSchemaPropertyInput(AsArrayJsonSchemaPropertyInput());
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
        if (obj is not ArrayJsonSchemaPropertyInputItems other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    public static implicit operator ArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.ObjectJsonSchemaPropertyInput value
    ) => new("objectJsonSchemaPropertyInput", value);

    public static implicit operator ArrayJsonSchemaPropertyInputItems(
        global::ElevenLabs.ArrayJsonSchemaPropertyInput value
    ) => new("arrayJsonSchemaPropertyInput", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ArrayJsonSchemaPropertyInputItems>
    {
        public override ArrayJsonSchemaPropertyInputItems? Read(
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
                            typeof(global::ElevenLabs.ObjectJsonSchemaPropertyInput),
                            options
                        );
                        if (value != null)
                        {
                            return new ArrayJsonSchemaPropertyInputItems(
                                "objectJsonSchemaPropertyInput",
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
                            typeof(global::ElevenLabs.ArrayJsonSchemaPropertyInput),
                            options
                        );
                        if (value != null)
                        {
                            return new ArrayJsonSchemaPropertyInputItems(
                                "arrayJsonSchemaPropertyInput",
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
                        "Cannot deserialize JSON object into ArrayJsonSchemaPropertyInputItems: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "literalJsonSchemaProperty",
                        typeof(global::ElevenLabs.LiteralJsonSchemaProperty),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "objectJsonSchemaPropertyInput",
                        typeof(global::ElevenLabs.ObjectJsonSchemaPropertyInput),
                        new[]
                        {
                            "property_kind",
                            "description",
                            "dynamic_variable",
                            "constant_value",
                            "is_omitted",
                            "type",
                            "required",
                            "properties",
                            "required_constraints",
                        }
                    ),
                    (
                        "arrayJsonSchemaPropertyInput",
                        typeof(global::ElevenLabs.ArrayJsonSchemaPropertyInput),
                        new[]
                        {
                            "property_kind",
                            "description",
                            "dynamic_variable",
                            "constant_value",
                            "is_omitted",
                            "type",
                            "items",
                        }
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
                            return new ArrayJsonSchemaPropertyInputItems(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ArrayJsonSchemaPropertyInputItems"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ArrayJsonSchemaPropertyInputItems value,
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

        public override ArrayJsonSchemaPropertyInputItems ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ArrayJsonSchemaPropertyInputItems result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ArrayJsonSchemaPropertyInputItems value,
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
