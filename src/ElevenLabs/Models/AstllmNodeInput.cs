// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstllmNodeInput.JsonConverter))]
[Serializable]
public class AstllmNodeInput
{
    private AstllmNodeInput(string type, object? value)
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
    /// Create a AstllmNodeInput from a AstllmNodeInput1 value.
    /// </summary>
    public static AstllmNodeInput FromAstllmNodeInput1(global::ElevenLabs.AstllmNodeInput1 value) =>
        new("astllmNodeInput1", value);

    /// <summary>
    /// Create a AstllmNodeInput from a AstllmNodeInput2 value.
    /// </summary>
    public static AstllmNodeInput FromAstllmNodeInput2(global::ElevenLabs.AstllmNodeInput2 value) =>
        new("astllmNodeInput2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "astllmNodeInput1".
    /// </summary>
    public bool IsAstllmNodeInput1() => Type == "astllmNodeInput1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "astllmNodeInput2".
    /// </summary>
    public bool IsAstllmNodeInput2() => Type == "astllmNodeInput2";

    /// <summary>
    /// Returns the value as a AstllmNodeInput1 if <see cref="Type"/> is "astllmNodeInput1", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'astllmNodeInput1'.</exception>
    public global::ElevenLabs.AstllmNodeInput1 AsAstllmNodeInput1() =>
        IsAstllmNodeInput1()
            ? (global::ElevenLabs.AstllmNodeInput1)Value!
            : throw new ElevenLabsClientException("Union type is not 'astllmNodeInput1'");

    /// <summary>
    /// Returns the value as a AstllmNodeInput2 if <see cref="Type"/> is "astllmNodeInput2", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'astllmNodeInput2'.</exception>
    public global::ElevenLabs.AstllmNodeInput2 AsAstllmNodeInput2() =>
        IsAstllmNodeInput2()
            ? (global::ElevenLabs.AstllmNodeInput2)Value!
            : throw new ElevenLabsClientException("Union type is not 'astllmNodeInput2'");

    /// <summary>
    /// Attempts to cast the value to a AstllmNodeInput1 and returns true if successful.
    /// </summary>
    public bool TryGetAstllmNodeInput1(out global::ElevenLabs.AstllmNodeInput1? value)
    {
        if (Type == "astllmNodeInput1")
        {
            value = (global::ElevenLabs.AstllmNodeInput1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AstllmNodeInput2 and returns true if successful.
    /// </summary>
    public bool TryGetAstllmNodeInput2(out global::ElevenLabs.AstllmNodeInput2? value)
    {
        if (Type == "astllmNodeInput2")
        {
            value = (global::ElevenLabs.AstllmNodeInput2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.AstllmNodeInput1, T> onAstllmNodeInput1,
        global::System.Func<global::ElevenLabs.AstllmNodeInput2, T> onAstllmNodeInput2
    )
    {
        return Type switch
        {
            "astllmNodeInput1" => onAstllmNodeInput1(AsAstllmNodeInput1()),
            "astllmNodeInput2" => onAstllmNodeInput2(AsAstllmNodeInput2()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AstllmNodeInput1> onAstllmNodeInput1,
        global::System.Action<global::ElevenLabs.AstllmNodeInput2> onAstllmNodeInput2
    )
    {
        switch (Type)
        {
            case "astllmNodeInput1":
                onAstllmNodeInput1(AsAstllmNodeInput1());
                break;
            case "astllmNodeInput2":
                onAstllmNodeInput2(AsAstllmNodeInput2());
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
        if (obj is not AstllmNodeInput other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AstllmNodeInput(global::ElevenLabs.AstllmNodeInput1 value) =>
        new("astllmNodeInput1", value);

    public static implicit operator AstllmNodeInput(global::ElevenLabs.AstllmNodeInput2 value) =>
        new("astllmNodeInput2", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AstllmNodeInput>
    {
        public override AstllmNodeInput? Read(
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
                            typeof(global::ElevenLabs.AstllmNodeInput1),
                            options
                        );
                        if (value != null)
                        {
                            return new AstllmNodeInput("astllmNodeInput1", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "type", "llm"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AstllmNodeInput2),
                            options
                        );
                        if (value != null)
                        {
                            return new AstllmNodeInput("astllmNodeInput2", value);
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
                        "Cannot deserialize JSON object into AstllmNodeInput: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("astllmNodeInput1", typeof(global::ElevenLabs.AstllmNodeInput1)),
                    ("astllmNodeInput2", typeof(global::ElevenLabs.AstllmNodeInput2)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new AstllmNodeInput(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into AstllmNodeInput"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstllmNodeInput value,
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

        public override AstllmNodeInput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AstllmNodeInput result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstllmNodeInput value,
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
