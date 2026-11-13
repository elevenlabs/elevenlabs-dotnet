// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ObjectJsonSchemaPropertyOutputProperties.JsonConverter))]
[Serializable]
public class ObjectJsonSchemaPropertyOutputProperties
{
    private ObjectJsonSchemaPropertyOutputProperties(string type, object? value)
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
    /// Create a ObjectJsonSchemaPropertyOutputProperties from a LiteralJsonSchemaProperty value.
    /// </summary>
    public static ObjectJsonSchemaPropertyOutputProperties FromLiteralJsonSchemaProperty(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    /// <summary>
    /// Create a ObjectJsonSchemaPropertyOutputProperties from a ObjectJsonSchemaPropertyOutput value.
    /// </summary>
    public static ObjectJsonSchemaPropertyOutputProperties FromObjectJsonSchemaPropertyOutput(
        global::ElevenLabs.ObjectJsonSchemaPropertyOutput value
    ) => new("objectJsonSchemaPropertyOutput", value);

    /// <summary>
    /// Create a ObjectJsonSchemaPropertyOutputProperties from a ArrayJsonSchemaPropertyOutput value.
    /// </summary>
    public static ObjectJsonSchemaPropertyOutputProperties FromArrayJsonSchemaPropertyOutput(
        global::ElevenLabs.ArrayJsonSchemaPropertyOutput value
    ) => new("arrayJsonSchemaPropertyOutput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "literalJsonSchemaProperty".
    /// </summary>
    public bool IsLiteralJsonSchemaProperty() => Type == "literalJsonSchemaProperty";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "objectJsonSchemaPropertyOutput".
    /// </summary>
    public bool IsObjectJsonSchemaPropertyOutput() => Type == "objectJsonSchemaPropertyOutput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "arrayJsonSchemaPropertyOutput".
    /// </summary>
    public bool IsArrayJsonSchemaPropertyOutput() => Type == "arrayJsonSchemaPropertyOutput";

    /// <summary>
    /// Returns the value as a LiteralJsonSchemaProperty if <see cref="Type"/> is "literalJsonSchemaProperty", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'literalJsonSchemaProperty'.</exception>
    public global::ElevenLabs.LiteralJsonSchemaProperty AsLiteralJsonSchemaProperty() =>
        IsLiteralJsonSchemaProperty()
            ? (global::ElevenLabs.LiteralJsonSchemaProperty)Value!
            : throw new ElevenLabsClientException("Union type is not 'literalJsonSchemaProperty'");

    /// <summary>
    /// Returns the value as a ObjectJsonSchemaPropertyOutput if <see cref="Type"/> is "objectJsonSchemaPropertyOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'objectJsonSchemaPropertyOutput'.</exception>
    public global::ElevenLabs.ObjectJsonSchemaPropertyOutput AsObjectJsonSchemaPropertyOutput() =>
        IsObjectJsonSchemaPropertyOutput()
            ? (global::ElevenLabs.ObjectJsonSchemaPropertyOutput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'objectJsonSchemaPropertyOutput'"
            );

    /// <summary>
    /// Returns the value as a ArrayJsonSchemaPropertyOutput if <see cref="Type"/> is "arrayJsonSchemaPropertyOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'arrayJsonSchemaPropertyOutput'.</exception>
    public global::ElevenLabs.ArrayJsonSchemaPropertyOutput AsArrayJsonSchemaPropertyOutput() =>
        IsArrayJsonSchemaPropertyOutput()
            ? (global::ElevenLabs.ArrayJsonSchemaPropertyOutput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'arrayJsonSchemaPropertyOutput'"
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
    /// Attempts to cast the value to a ObjectJsonSchemaPropertyOutput and returns true if successful.
    /// </summary>
    public bool TryGetObjectJsonSchemaPropertyOutput(
        out global::ElevenLabs.ObjectJsonSchemaPropertyOutput? value
    )
    {
        if (Type == "objectJsonSchemaPropertyOutput")
        {
            value = (global::ElevenLabs.ObjectJsonSchemaPropertyOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ArrayJsonSchemaPropertyOutput and returns true if successful.
    /// </summary>
    public bool TryGetArrayJsonSchemaPropertyOutput(
        out global::ElevenLabs.ArrayJsonSchemaPropertyOutput? value
    )
    {
        if (Type == "arrayJsonSchemaPropertyOutput")
        {
            value = (global::ElevenLabs.ArrayJsonSchemaPropertyOutput)Value!;
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
            global::ElevenLabs.ObjectJsonSchemaPropertyOutput,
            T
        > onObjectJsonSchemaPropertyOutput,
        global::System.Func<
            global::ElevenLabs.ArrayJsonSchemaPropertyOutput,
            T
        > onArrayJsonSchemaPropertyOutput
    )
    {
        return Type switch
        {
            "literalJsonSchemaProperty" => onLiteralJsonSchemaProperty(
                AsLiteralJsonSchemaProperty()
            ),
            "objectJsonSchemaPropertyOutput" => onObjectJsonSchemaPropertyOutput(
                AsObjectJsonSchemaPropertyOutput()
            ),
            "arrayJsonSchemaPropertyOutput" => onArrayJsonSchemaPropertyOutput(
                AsArrayJsonSchemaPropertyOutput()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.LiteralJsonSchemaProperty> onLiteralJsonSchemaProperty,
        global::System.Action<global::ElevenLabs.ObjectJsonSchemaPropertyOutput> onObjectJsonSchemaPropertyOutput,
        global::System.Action<global::ElevenLabs.ArrayJsonSchemaPropertyOutput> onArrayJsonSchemaPropertyOutput
    )
    {
        switch (Type)
        {
            case "literalJsonSchemaProperty":
                onLiteralJsonSchemaProperty(AsLiteralJsonSchemaProperty());
                break;
            case "objectJsonSchemaPropertyOutput":
                onObjectJsonSchemaPropertyOutput(AsObjectJsonSchemaPropertyOutput());
                break;
            case "arrayJsonSchemaPropertyOutput":
                onArrayJsonSchemaPropertyOutput(AsArrayJsonSchemaPropertyOutput());
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
        if (obj is not ObjectJsonSchemaPropertyOutputProperties other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ObjectJsonSchemaPropertyOutputProperties(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    public static implicit operator ObjectJsonSchemaPropertyOutputProperties(
        global::ElevenLabs.ObjectJsonSchemaPropertyOutput value
    ) => new("objectJsonSchemaPropertyOutput", value);

    public static implicit operator ObjectJsonSchemaPropertyOutputProperties(
        global::ElevenLabs.ArrayJsonSchemaPropertyOutput value
    ) => new("arrayJsonSchemaPropertyOutput", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ObjectJsonSchemaPropertyOutputProperties>
    {
        public override ObjectJsonSchemaPropertyOutputProperties? Read(
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
                            typeof(global::ElevenLabs.ObjectJsonSchemaPropertyOutput),
                            options
                        );
                        if (value != null)
                        {
                            return new ObjectJsonSchemaPropertyOutputProperties(
                                "objectJsonSchemaPropertyOutput",
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
                            typeof(global::ElevenLabs.ArrayJsonSchemaPropertyOutput),
                            options
                        );
                        if (value != null)
                        {
                            return new ObjectJsonSchemaPropertyOutputProperties(
                                "arrayJsonSchemaPropertyOutput",
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
                        "Cannot deserialize JSON object into ObjectJsonSchemaPropertyOutputProperties: it carries a member's literal but does not deserialize as that member"
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
                        "objectJsonSchemaPropertyOutput",
                        typeof(global::ElevenLabs.ObjectJsonSchemaPropertyOutput),
                        new[]
                        {
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
                        "arrayJsonSchemaPropertyOutput",
                        typeof(global::ElevenLabs.ArrayJsonSchemaPropertyOutput),
                        new[]
                        {
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
                            return new ObjectJsonSchemaPropertyOutputProperties(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ObjectJsonSchemaPropertyOutputProperties"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ObjectJsonSchemaPropertyOutputProperties value,
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

        public override ObjectJsonSchemaPropertyOutputProperties ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ObjectJsonSchemaPropertyOutputProperties result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ObjectJsonSchemaPropertyOutputProperties value,
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
