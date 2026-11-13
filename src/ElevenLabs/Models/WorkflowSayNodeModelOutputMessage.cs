// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Message spoken by this node. Use `literal` for exact text or `prompt` to have the LLM generate the message from a description.</summary>
[JsonConverter(typeof(WorkflowSayNodeModelOutputMessage.JsonConverter))]
[Serializable]
public record WorkflowSayNodeModelOutputMessage
{
    internal WorkflowSayNodeModelOutputMessage(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WorkflowSayNodeModelOutputMessage with <see cref="WorkflowSayNodeModelOutputMessage.Literal"/>.
    /// </summary>
    public WorkflowSayNodeModelOutputMessage(WorkflowSayNodeModelOutputMessage.Literal value)
    {
        Type = "literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowSayNodeModelOutputMessage with <see cref="WorkflowSayNodeModelOutputMessage.Prompt"/>.
    /// </summary>
    public WorkflowSayNodeModelOutputMessage(WorkflowSayNodeModelOutputMessage.Prompt value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.SayNodeLiteralMessageOutput"/> if <see cref="Type"/> is 'literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'literal'.</exception>
    public global::ElevenLabs.SayNodeLiteralMessageOutput AsLiteral() =>
        IsLiteral
            ? (global::ElevenLabs.SayNodeLiteralMessageOutput)Value!
            : throw new global::System.Exception(
                "WorkflowSayNodeModelOutputMessage.Type is not 'literal'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SayNodePromptMessageOutput"/> if <see cref="Type"/> is 'prompt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'prompt'.</exception>
    public global::ElevenLabs.SayNodePromptMessageOutput AsPrompt() =>
        IsPrompt
            ? (global::ElevenLabs.SayNodePromptMessageOutput)Value!
            : throw new global::System.Exception(
                "WorkflowSayNodeModelOutputMessage.Type is not 'prompt'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.SayNodeLiteralMessageOutput, T> onLiteral,
        Func<global::ElevenLabs.SayNodePromptMessageOutput, T> onPrompt,
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
        Action<global::ElevenLabs.SayNodeLiteralMessageOutput> onLiteral,
        Action<global::ElevenLabs.SayNodePromptMessageOutput> onPrompt,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SayNodeLiteralMessageOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLiteral(out global::ElevenLabs.SayNodeLiteralMessageOutput? value)
    {
        if (Type == "literal")
        {
            value = (global::ElevenLabs.SayNodeLiteralMessageOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SayNodePromptMessageOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPrompt(out global::ElevenLabs.SayNodePromptMessageOutput? value)
    {
        if (Type == "prompt")
        {
            value = (global::ElevenLabs.SayNodePromptMessageOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WorkflowSayNodeModelOutputMessage(
        WorkflowSayNodeModelOutputMessage.Literal value
    ) => new(value);

    public static implicit operator WorkflowSayNodeModelOutputMessage(
        WorkflowSayNodeModelOutputMessage.Prompt value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WorkflowSayNodeModelOutputMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WorkflowSayNodeModelOutputMessage).IsAssignableFrom(typeToConvert);

        public override WorkflowSayNodeModelOutputMessage Read(
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
                "literal" => json.Deserialize<global::ElevenLabs.SayNodeLiteralMessageOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SayNodeLiteralMessageOutput"
                    ),
                "prompt" => json.Deserialize<global::ElevenLabs.SayNodePromptMessageOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SayNodePromptMessageOutput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new WorkflowSayNodeModelOutputMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowSayNodeModelOutputMessage value,
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

        public override WorkflowSayNodeModelOutputMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WorkflowSayNodeModelOutputMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowSayNodeModelOutputMessage value,
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
        public Literal(global::ElevenLabs.SayNodeLiteralMessageOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SayNodeLiteralMessageOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowSayNodeModelOutputMessage.Literal(
            global::ElevenLabs.SayNodeLiteralMessageOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for prompt
    /// </summary>
    [Serializable]
    public struct Prompt
    {
        public Prompt(global::ElevenLabs.SayNodePromptMessageOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SayNodePromptMessageOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowSayNodeModelOutputMessage.Prompt(
            global::ElevenLabs.SayNodePromptMessageOutput value
        ) => new(value);
    }
}
