// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Eval.JsonConverter))]
[Serializable]
public record Eval
{
    internal Eval(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Eval with <see cref="Eval.Anything"/>.
    /// </summary>
    public Eval(Eval.Anything value)
    {
        Type = "anything";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Eval with <see cref="Eval.Exact"/>.
    /// </summary>
    public Eval(Eval.Exact value)
    {
        Type = "exact";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Eval with <see cref="Eval.Llm"/>.
    /// </summary>
    public Eval(Eval.Llm value)
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Eval with <see cref="Eval.Regex"/>.
    /// </summary>
    public Eval(Eval.Regex value)
    {
        Type = "regex";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "anything"
    /// </summary>
    public bool IsAnything => Type == "anything";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "exact"
    /// </summary>
    public bool IsExact => Type == "exact";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llm"
    /// </summary>
    public bool IsLlm => Type == "llm";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "regex"
    /// </summary>
    public bool IsRegex => Type == "regex";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MatchAnythingParameterEvaluationStrategy"/> if <see cref="Type"/> is 'anything', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'anything'.</exception>
    public global::ElevenLabs.MatchAnythingParameterEvaluationStrategy AsAnything() =>
        IsAnything
            ? (global::ElevenLabs.MatchAnythingParameterEvaluationStrategy)Value!
            : throw new global::System.Exception("Eval.Type is not 'anything'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ExactParameterEvaluationStrategy"/> if <see cref="Type"/> is 'exact', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exact'.</exception>
    public global::ElevenLabs.ExactParameterEvaluationStrategy AsExact() =>
        IsExact
            ? (global::ElevenLabs.ExactParameterEvaluationStrategy)Value!
            : throw new global::System.Exception("Eval.Type is not 'exact'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.LlmParameterEvaluationStrategy"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.LlmParameterEvaluationStrategy AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.LlmParameterEvaluationStrategy)Value!
            : throw new global::System.Exception("Eval.Type is not 'llm'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.RegexParameterEvaluationStrategy"/> if <see cref="Type"/> is 'regex', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'regex'.</exception>
    public global::ElevenLabs.RegexParameterEvaluationStrategy AsRegex() =>
        IsRegex
            ? (global::ElevenLabs.RegexParameterEvaluationStrategy)Value!
            : throw new global::System.Exception("Eval.Type is not 'regex'");

    public T Match<T>(
        Func<global::ElevenLabs.MatchAnythingParameterEvaluationStrategy, T> onAnything,
        Func<global::ElevenLabs.ExactParameterEvaluationStrategy, T> onExact,
        Func<global::ElevenLabs.LlmParameterEvaluationStrategy, T> onLlm,
        Func<global::ElevenLabs.RegexParameterEvaluationStrategy, T> onRegex,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "anything" => onAnything(AsAnything()),
            "exact" => onExact(AsExact()),
            "llm" => onLlm(AsLlm()),
            "regex" => onRegex(AsRegex()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.MatchAnythingParameterEvaluationStrategy> onAnything,
        Action<global::ElevenLabs.ExactParameterEvaluationStrategy> onExact,
        Action<global::ElevenLabs.LlmParameterEvaluationStrategy> onLlm,
        Action<global::ElevenLabs.RegexParameterEvaluationStrategy> onRegex,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "anything":
                onAnything(AsAnything());
                break;
            case "exact":
                onExact(AsExact());
                break;
            case "llm":
                onLlm(AsLlm());
                break;
            case "regex":
                onRegex(AsRegex());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MatchAnythingParameterEvaluationStrategy"/> and returns true if successful.
    /// </summary>
    public bool TryAsAnything(
        out global::ElevenLabs.MatchAnythingParameterEvaluationStrategy? value
    )
    {
        if (Type == "anything")
        {
            value = (global::ElevenLabs.MatchAnythingParameterEvaluationStrategy)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExactParameterEvaluationStrategy"/> and returns true if successful.
    /// </summary>
    public bool TryAsExact(out global::ElevenLabs.ExactParameterEvaluationStrategy? value)
    {
        if (Type == "exact")
        {
            value = (global::ElevenLabs.ExactParameterEvaluationStrategy)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.LlmParameterEvaluationStrategy"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.LlmParameterEvaluationStrategy? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.LlmParameterEvaluationStrategy)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.RegexParameterEvaluationStrategy"/> and returns true if successful.
    /// </summary>
    public bool TryAsRegex(out global::ElevenLabs.RegexParameterEvaluationStrategy? value)
    {
        if (Type == "regex")
        {
            value = (global::ElevenLabs.RegexParameterEvaluationStrategy)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Eval(Eval.Anything value) => new(value);

    public static implicit operator Eval(Eval.Exact value) => new(value);

    public static implicit operator Eval(Eval.Llm value) => new(value);

    public static implicit operator Eval(Eval.Regex value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Eval>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Eval).IsAssignableFrom(typeToConvert);

        public override Eval Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "anything" =>
                    json.Deserialize<global::ElevenLabs.MatchAnythingParameterEvaluationStrategy?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.MatchAnythingParameterEvaluationStrategy"
                        ),
                "exact" => json.Deserialize<global::ElevenLabs.ExactParameterEvaluationStrategy?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ExactParameterEvaluationStrategy"
                    ),
                "llm" => json.Deserialize<global::ElevenLabs.LlmParameterEvaluationStrategy?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.LlmParameterEvaluationStrategy"
                    ),
                "regex" => json.Deserialize<global::ElevenLabs.RegexParameterEvaluationStrategy?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.RegexParameterEvaluationStrategy"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Eval(discriminator, value);
        }

        public override void Write(Utf8JsonWriter writer, Eval value, JsonSerializerOptions options)
        {
            JsonNode json =
                value.Type switch
                {
                    "anything" => JsonSerializer.SerializeToNode(value.Value, options),
                    "exact" => JsonSerializer.SerializeToNode(value.Value, options),
                    "llm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "regex" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override Eval ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new Eval(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Eval value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for anything
    /// </summary>
    [Serializable]
    public struct Anything
    {
        public Anything(global::ElevenLabs.MatchAnythingParameterEvaluationStrategy value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MatchAnythingParameterEvaluationStrategy Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Eval.Anything(
            global::ElevenLabs.MatchAnythingParameterEvaluationStrategy value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for exact
    /// </summary>
    [Serializable]
    public struct Exact
    {
        public Exact(global::ElevenLabs.ExactParameterEvaluationStrategy value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExactParameterEvaluationStrategy Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Eval.Exact(
            global::ElevenLabs.ExactParameterEvaluationStrategy value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.LlmParameterEvaluationStrategy value)
        {
            Value = value;
        }

        internal global::ElevenLabs.LlmParameterEvaluationStrategy Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Eval.Llm(
            global::ElevenLabs.LlmParameterEvaluationStrategy value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for regex
    /// </summary>
    [Serializable]
    public struct Regex
    {
        public Regex(global::ElevenLabs.RegexParameterEvaluationStrategy value)
        {
            Value = value;
        }

        internal global::ElevenLabs.RegexParameterEvaluationStrategy Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator Eval.Regex(
            global::ElevenLabs.RegexParameterEvaluationStrategy value
        ) => new(value);
    }
}
