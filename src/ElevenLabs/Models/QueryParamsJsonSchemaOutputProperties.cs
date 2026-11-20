// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(QueryParamsJsonSchemaOutputProperties.JsonConverter))]
[Serializable]
public class QueryParamsJsonSchemaOutputProperties
{
    private QueryParamsJsonSchemaOutputProperties(string type, object? value)
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
    /// Create a QueryParamsJsonSchemaOutputProperties from a LiteralJsonSchemaProperty value.
    /// </summary>
    public static QueryParamsJsonSchemaOutputProperties FromLiteralJsonSchemaProperty(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    /// <summary>
    /// Create a QueryParamsJsonSchemaOutputProperties from a QueryArrayJsonSchemaPropertyOutput value.
    /// </summary>
    public static QueryParamsJsonSchemaOutputProperties FromQueryArrayJsonSchemaPropertyOutput(
        global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput value
    ) => new("queryArrayJsonSchemaPropertyOutput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "literalJsonSchemaProperty".
    /// </summary>
    public bool IsLiteralJsonSchemaProperty() => Type == "literalJsonSchemaProperty";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "queryArrayJsonSchemaPropertyOutput".
    /// </summary>
    public bool IsQueryArrayJsonSchemaPropertyOutput() =>
        Type == "queryArrayJsonSchemaPropertyOutput";

    /// <summary>
    /// Returns the value as a LiteralJsonSchemaProperty if <see cref="Type"/> is "literalJsonSchemaProperty", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'literalJsonSchemaProperty'.</exception>
    public global::ElevenLabs.LiteralJsonSchemaProperty AsLiteralJsonSchemaProperty() =>
        IsLiteralJsonSchemaProperty()
            ? (global::ElevenLabs.LiteralJsonSchemaProperty)Value!
            : throw new ElevenLabsClientException("Union type is not 'literalJsonSchemaProperty'");

    /// <summary>
    /// Returns the value as a QueryArrayJsonSchemaPropertyOutput if <see cref="Type"/> is "queryArrayJsonSchemaPropertyOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'queryArrayJsonSchemaPropertyOutput'.</exception>
    public global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput AsQueryArrayJsonSchemaPropertyOutput() =>
        IsQueryArrayJsonSchemaPropertyOutput()
            ? (global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'queryArrayJsonSchemaPropertyOutput'"
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
    /// Attempts to cast the value to a QueryArrayJsonSchemaPropertyOutput and returns true if successful.
    /// </summary>
    public bool TryGetQueryArrayJsonSchemaPropertyOutput(
        out global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput? value
    )
    {
        if (Type == "queryArrayJsonSchemaPropertyOutput")
        {
            value = (global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput)Value!;
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
            global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput,
            T
        > onQueryArrayJsonSchemaPropertyOutput
    )
    {
        return Type switch
        {
            "literalJsonSchemaProperty" => onLiteralJsonSchemaProperty(
                AsLiteralJsonSchemaProperty()
            ),
            "queryArrayJsonSchemaPropertyOutput" => onQueryArrayJsonSchemaPropertyOutput(
                AsQueryArrayJsonSchemaPropertyOutput()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.LiteralJsonSchemaProperty> onLiteralJsonSchemaProperty,
        global::System.Action<global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput> onQueryArrayJsonSchemaPropertyOutput
    )
    {
        switch (Type)
        {
            case "literalJsonSchemaProperty":
                onLiteralJsonSchemaProperty(AsLiteralJsonSchemaProperty());
                break;
            case "queryArrayJsonSchemaPropertyOutput":
                onQueryArrayJsonSchemaPropertyOutput(AsQueryArrayJsonSchemaPropertyOutput());
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
        if (obj is not QueryParamsJsonSchemaOutputProperties other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator QueryParamsJsonSchemaOutputProperties(
        global::ElevenLabs.LiteralJsonSchemaProperty value
    ) => new("literalJsonSchemaProperty", value);

    public static implicit operator QueryParamsJsonSchemaOutputProperties(
        global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput value
    ) => new("queryArrayJsonSchemaPropertyOutput", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<QueryParamsJsonSchemaOutputProperties>
    {
        public override QueryParamsJsonSchemaOutputProperties? Read(
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
                            typeof(global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput),
                            options
                        );
                        if (value != null)
                        {
                            return new QueryParamsJsonSchemaOutputProperties(
                                "queryArrayJsonSchemaPropertyOutput",
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
                        "Cannot deserialize JSON object into QueryParamsJsonSchemaOutputProperties: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "literalJsonSchemaProperty",
                        typeof(global::ElevenLabs.LiteralJsonSchemaProperty)
                    ),
                    (
                        "queryArrayJsonSchemaPropertyOutput",
                        typeof(global::ElevenLabs.QueryArrayJsonSchemaPropertyOutput)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new QueryParamsJsonSchemaOutputProperties(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into QueryParamsJsonSchemaOutputProperties"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryParamsJsonSchemaOutputProperties value,
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

        public override QueryParamsJsonSchemaOutputProperties ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            QueryParamsJsonSchemaOutputProperties result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryParamsJsonSchemaOutputProperties value,
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
