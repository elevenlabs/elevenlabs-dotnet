// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(QueryParamsJsonSchemaInputProperties.JsonConverter))]
[Serializable]
public class QueryParamsJsonSchemaInputProperties
{
    private QueryParamsJsonSchemaInputProperties(string type, object? value)
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
    /// Create a QueryParamsJsonSchemaInputProperties from a LiteralJsonSchemaProperty value.
    /// </summary>
    public static QueryParamsJsonSchemaInputProperties FromLiteralJsonSchemaProperty(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    /// <summary>
    /// Create a QueryParamsJsonSchemaInputProperties from a QueryArrayJsonSchemaPropertyInput value.
    /// </summary>
    public static QueryParamsJsonSchemaInputProperties FromQueryArrayJsonSchemaPropertyInput(
        global::ElevenLabs.QueryArrayJsonSchemaPropertyInput value
    ) => new("queryArrayJsonSchemaPropertyInput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "literalJsonSchemaProperty".
    /// </summary>
    public bool IsLiteralJsonSchemaProperty() => Type == "literalJsonSchemaProperty";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "queryArrayJsonSchemaPropertyInput".
    /// </summary>
    public bool IsQueryArrayJsonSchemaPropertyInput() =>
        Type == "queryArrayJsonSchemaPropertyInput";

    /// <summary>
    /// Returns the value as a LiteralJsonSchemaProperty if <see cref="Type"/> is "literalJsonSchemaProperty", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'literalJsonSchemaProperty'.</exception>
    public global::ElevenLabs.LiteralJsonSchemaProperty AsLiteralJsonSchemaProperty() =>
        IsLiteralJsonSchemaProperty()
            ? (global::ElevenLabs.LiteralJsonSchemaProperty)Value!
            : throw new ElevenLabsClientException("Union type is not 'literalJsonSchemaProperty'");

    /// <summary>
    /// Returns the value as a QueryArrayJsonSchemaPropertyInput if <see cref="Type"/> is "queryArrayJsonSchemaPropertyInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'queryArrayJsonSchemaPropertyInput'.</exception>
    public global::ElevenLabs.QueryArrayJsonSchemaPropertyInput AsQueryArrayJsonSchemaPropertyInput() =>
        IsQueryArrayJsonSchemaPropertyInput()
            ? (global::ElevenLabs.QueryArrayJsonSchemaPropertyInput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'queryArrayJsonSchemaPropertyInput'"
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
    /// Attempts to cast the value to a QueryArrayJsonSchemaPropertyInput and returns true if successful.
    /// </summary>
    public bool TryGetQueryArrayJsonSchemaPropertyInput(
        out global::ElevenLabs.QueryArrayJsonSchemaPropertyInput? value
    )
    {
        if (Type == "queryArrayJsonSchemaPropertyInput")
        {
            value = (global::ElevenLabs.QueryArrayJsonSchemaPropertyInput)Value!;
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
            global::ElevenLabs.QueryArrayJsonSchemaPropertyInput,
            T
        > onQueryArrayJsonSchemaPropertyInput
    )
    {
        return Type switch
        {
            "literalJsonSchemaProperty" => onLiteralJsonSchemaProperty(
                AsLiteralJsonSchemaProperty()
            ),
            "queryArrayJsonSchemaPropertyInput" => onQueryArrayJsonSchemaPropertyInput(
                AsQueryArrayJsonSchemaPropertyInput()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.LiteralJsonSchemaProperty> onLiteralJsonSchemaProperty,
        global::System.Action<global::ElevenLabs.QueryArrayJsonSchemaPropertyInput> onQueryArrayJsonSchemaPropertyInput
    )
    {
        switch (Type)
        {
            case "literalJsonSchemaProperty":
                onLiteralJsonSchemaProperty(AsLiteralJsonSchemaProperty());
                break;
            case "queryArrayJsonSchemaPropertyInput":
                onQueryArrayJsonSchemaPropertyInput(AsQueryArrayJsonSchemaPropertyInput());
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
        if (obj is not QueryParamsJsonSchemaInputProperties other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator QueryParamsJsonSchemaInputProperties(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    public static implicit operator QueryParamsJsonSchemaInputProperties(
        global::ElevenLabs.QueryArrayJsonSchemaPropertyInput value
    ) => new("queryArrayJsonSchemaPropertyInput", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<QueryParamsJsonSchemaInputProperties>
    {
        public override QueryParamsJsonSchemaInputProperties? Read(
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

                if (HasLiteral(document, "type", "array"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.QueryArrayJsonSchemaPropertyInput),
                            options
                        );
                        if (value != null)
                        {
                            return new QueryParamsJsonSchemaInputProperties(
                                "queryArrayJsonSchemaPropertyInput",
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
                        "Cannot deserialize JSON object into QueryParamsJsonSchemaInputProperties: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "literalJsonSchemaProperty",
                        typeof(global::ElevenLabs.LiteralJsonSchemaProperty)
                    ),
                    (
                        "queryArrayJsonSchemaPropertyInput",
                        typeof(global::ElevenLabs.QueryArrayJsonSchemaPropertyInput)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new QueryParamsJsonSchemaInputProperties(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into QueryParamsJsonSchemaInputProperties"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryParamsJsonSchemaInputProperties value,
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

        public override QueryParamsJsonSchemaInputProperties ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            QueryParamsJsonSchemaInputProperties result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryParamsJsonSchemaInputProperties value,
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
    }
}
