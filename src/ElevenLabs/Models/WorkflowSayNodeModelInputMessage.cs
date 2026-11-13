// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Message spoken by this node. Use `literal` for exact text or `prompt` to have the LLM generate the message from a description.</summary>
[JsonConverter(typeof(WorkflowSayNodeModelInputMessage.JsonConverter))]
[Serializable]
public record WorkflowSayNodeModelInputMessage
{
    internal WorkflowSayNodeModelInputMessage(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WorkflowSayNodeModelInputMessage with <see cref="WorkflowSayNodeModelInputMessage.Literal"/>.
    /// </summary>
    public WorkflowSayNodeModelInputMessage(WorkflowSayNodeModelInputMessage.Literal value)
    {
        Type = "literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowSayNodeModelInputMessage with <see cref="WorkflowSayNodeModelInputMessage.Prompt"/>.
    /// </summary>
    public WorkflowSayNodeModelInputMessage(WorkflowSayNodeModelInputMessage.Prompt value)
    {
        Type = "prompt";
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
    /// Returns true if <see cref="Type"/> is "literal"
    /// </summary>
    public bool IsLiteral => Type == "literal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "prompt"
    /// </summary>
    public bool IsPrompt => Type == "prompt";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SayNodeLiteralMessageInput"/> if <see cref="Type"/> is 'literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'literal'.</exception>
    public global::ElevenLabs.SayNodeLiteralMessageInput AsLiteral() =>
        IsLiteral
            ? (global::ElevenLabs.SayNodeLiteralMessageInput)Value!
            : throw new global::System.Exception(
                "WorkflowSayNodeModelInputMessage.Type is not 'literal'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SayNodePromptMessageInput"/> if <see cref="Type"/> is 'prompt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'prompt'.</exception>
    public global::ElevenLabs.SayNodePromptMessageInput AsPrompt() =>
        IsPrompt
            ? (global::ElevenLabs.SayNodePromptMessageInput)Value!
            : throw new global::System.Exception(
                "WorkflowSayNodeModelInputMessage.Type is not 'prompt'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.SayNodeLiteralMessageInput, T> onLiteral,
        Func<global::ElevenLabs.SayNodePromptMessageInput, T> onPrompt,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "literal" => onLiteral(AsLiteral()),
            "prompt" => onPrompt(AsPrompt()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.SayNodeLiteralMessageInput> onLiteral,
        Action<global::ElevenLabs.SayNodePromptMessageInput> onPrompt,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "literal":
                onLiteral(AsLiteral());
                break;
            case "prompt":
                onPrompt(AsPrompt());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SayNodeLiteralMessageInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLiteral(out global::ElevenLabs.SayNodeLiteralMessageInput? value)
    {
        if (Type == "literal")
        {
            value = (global::ElevenLabs.SayNodeLiteralMessageInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SayNodePromptMessageInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPrompt(out global::ElevenLabs.SayNodePromptMessageInput? value)
    {
        if (Type == "prompt")
        {
            value = (global::ElevenLabs.SayNodePromptMessageInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WorkflowSayNodeModelInputMessage(
        WorkflowSayNodeModelInputMessage.Literal value
    ) => new(value);

    public static implicit operator WorkflowSayNodeModelInputMessage(
        WorkflowSayNodeModelInputMessage.Prompt value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WorkflowSayNodeModelInputMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WorkflowSayNodeModelInputMessage).IsAssignableFrom(typeToConvert);

        public override WorkflowSayNodeModelInputMessage Read(
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
                "literal" => json.Deserialize<global::ElevenLabs.SayNodeLiteralMessageInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SayNodeLiteralMessageInput"
                    ),
                "prompt" => json.Deserialize<global::ElevenLabs.SayNodePromptMessageInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SayNodePromptMessageInput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new WorkflowSayNodeModelInputMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowSayNodeModelInputMessage value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "literal" => JsonSerializer.SerializeToNode(value.Value, options),
                    "prompt" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override WorkflowSayNodeModelInputMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WorkflowSayNodeModelInputMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowSayNodeModelInputMessage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for literal
    /// </summary>
    [Serializable]
    public struct Literal
    {
        public Literal(global::ElevenLabs.SayNodeLiteralMessageInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SayNodeLiteralMessageInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowSayNodeModelInputMessage.Literal(
            global::ElevenLabs.SayNodeLiteralMessageInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for prompt
    /// </summary>
    [Serializable]
    public struct Prompt
    {
        public Prompt(global::ElevenLabs.SayNodePromptMessageInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SayNodePromptMessageInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowSayNodeModelInputMessage.Prompt(
            global::ElevenLabs.SayNodePromptMessageInput value
        ) => new(value);
    }
}
