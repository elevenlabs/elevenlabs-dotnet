// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentWorkflowRequestModelNodes.JsonConverter))]
[Serializable]
public record AgentWorkflowRequestModelNodes
{
    internal AgentWorkflowRequestModelNodes(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.End"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.End value)
    {
        Type = "end";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.OverrideAgent"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.OverrideAgent value)
    {
        Type = "override_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.PhoneNumber"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.PhoneNumber value)
    {
        Type = "phone_number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.StandaloneAgent"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.StandaloneAgent value)
    {
        Type = "standalone_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.Start"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.Start value)
    {
        Type = "start";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.Tool"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.Tool value)
    {
        Type = "tool";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.Say"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.Say value)
    {
        Type = "say";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowRequestModelNodes with <see cref="AgentWorkflowRequestModelNodes.UpdateState"/>.
    /// </summary>
    public AgentWorkflowRequestModelNodes(AgentWorkflowRequestModelNodes.UpdateState value)
    {
        Type = "update_state";
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
    /// Returns true if <see cref="Type"/> is "end"
    /// </summary>
    public bool IsEnd => Type == "end";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "override_agent"
    /// </summary>
    public bool IsOverrideAgent => Type == "override_agent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "phone_number"
    /// </summary>
    public bool IsPhoneNumber => Type == "phone_number";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "standalone_agent"
    /// </summary>
    public bool IsStandaloneAgent => Type == "standalone_agent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "start"
    /// </summary>
    public bool IsStart => Type == "start";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "tool"
    /// </summary>
    public bool IsTool => Type == "tool";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "say"
    /// </summary>
    public bool IsSay => Type == "say";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "update_state"
    /// </summary>
    public bool IsUpdateState => Type == "update_state";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowEndNodeModelInput"/> if <see cref="Type"/> is 'end', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'end'.</exception>
    public global::ElevenLabs.WorkflowEndNodeModelInput AsEnd() =>
        IsEnd
            ? (global::ElevenLabs.WorkflowEndNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'end'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowOverrideAgentNodeModelInput"/> if <see cref="Type"/> is 'override_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'override_agent'.</exception>
    public global::ElevenLabs.WorkflowOverrideAgentNodeModelInput AsOverrideAgent() =>
        IsOverrideAgent
            ? (global::ElevenLabs.WorkflowOverrideAgentNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'override_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowPhoneNumberNodeModelInput"/> if <see cref="Type"/> is 'phone_number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone_number'.</exception>
    public global::ElevenLabs.WorkflowPhoneNumberNodeModelInput AsPhoneNumber() =>
        IsPhoneNumber
            ? (global::ElevenLabs.WorkflowPhoneNumberNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'phone_number'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput"/> if <see cref="Type"/> is 'standalone_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'standalone_agent'.</exception>
    public global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput AsStandaloneAgent() =>
        IsStandaloneAgent
            ? (global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'standalone_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowStartNodeModelInput"/> if <see cref="Type"/> is 'start', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'start'.</exception>
    public global::ElevenLabs.WorkflowStartNodeModelInput AsStart() =>
        IsStart
            ? (global::ElevenLabs.WorkflowStartNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'start'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowToolNodeModelInput"/> if <see cref="Type"/> is 'tool', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'tool'.</exception>
    public global::ElevenLabs.WorkflowToolNodeModelInput AsTool() =>
        IsTool
            ? (global::ElevenLabs.WorkflowToolNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'tool'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowSayNodeModelInput"/> if <see cref="Type"/> is 'say', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'say'.</exception>
    public global::ElevenLabs.WorkflowSayNodeModelInput AsSay() =>
        IsSay
            ? (global::ElevenLabs.WorkflowSayNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'say'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowUpdateStateNodeModelInput"/> if <see cref="Type"/> is 'update_state', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'update_state'.</exception>
    public global::ElevenLabs.WorkflowUpdateStateNodeModelInput AsUpdateState() =>
        IsUpdateState
            ? (global::ElevenLabs.WorkflowUpdateStateNodeModelInput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowRequestModelNodes.Type is not 'update_state'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WorkflowEndNodeModelInput, T> onEnd,
        Func<global::ElevenLabs.WorkflowOverrideAgentNodeModelInput, T> onOverrideAgent,
        Func<global::ElevenLabs.WorkflowPhoneNumberNodeModelInput, T> onPhoneNumber,
        Func<global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput, T> onStandaloneAgent,
        Func<global::ElevenLabs.WorkflowStartNodeModelInput, T> onStart,
        Func<global::ElevenLabs.WorkflowToolNodeModelInput, T> onTool,
        Func<global::ElevenLabs.WorkflowSayNodeModelInput, T> onSay,
        Func<global::ElevenLabs.WorkflowUpdateStateNodeModelInput, T> onUpdateState,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "end" => onEnd(AsEnd()),
            "override_agent" => onOverrideAgent(AsOverrideAgent()),
            "phone_number" => onPhoneNumber(AsPhoneNumber()),
            "standalone_agent" => onStandaloneAgent(AsStandaloneAgent()),
            "start" => onStart(AsStart()),
            "tool" => onTool(AsTool()),
            "say" => onSay(AsSay()),
            "update_state" => onUpdateState(AsUpdateState()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WorkflowEndNodeModelInput> onEnd,
        Action<global::ElevenLabs.WorkflowOverrideAgentNodeModelInput> onOverrideAgent,
        Action<global::ElevenLabs.WorkflowPhoneNumberNodeModelInput> onPhoneNumber,
        Action<global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput> onStandaloneAgent,
        Action<global::ElevenLabs.WorkflowStartNodeModelInput> onStart,
        Action<global::ElevenLabs.WorkflowToolNodeModelInput> onTool,
        Action<global::ElevenLabs.WorkflowSayNodeModelInput> onSay,
        Action<global::ElevenLabs.WorkflowUpdateStateNodeModelInput> onUpdateState,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "end":
                onEnd(AsEnd());
                break;
            case "override_agent":
                onOverrideAgent(AsOverrideAgent());
                break;
            case "phone_number":
                onPhoneNumber(AsPhoneNumber());
                break;
            case "standalone_agent":
                onStandaloneAgent(AsStandaloneAgent());
                break;
            case "start":
                onStart(AsStart());
                break;
            case "tool":
                onTool(AsTool());
                break;
            case "say":
                onSay(AsSay());
                break;
            case "update_state":
                onUpdateState(AsUpdateState());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowEndNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsEnd(out global::ElevenLabs.WorkflowEndNodeModelInput? value)
    {
        if (Type == "end")
        {
            value = (global::ElevenLabs.WorkflowEndNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowOverrideAgentNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsOverrideAgent(
        out global::ElevenLabs.WorkflowOverrideAgentNodeModelInput? value
    )
    {
        if (Type == "override_agent")
        {
            value = (global::ElevenLabs.WorkflowOverrideAgentNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowPhoneNumberNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneNumber(out global::ElevenLabs.WorkflowPhoneNumberNodeModelInput? value)
    {
        if (Type == "phone_number")
        {
            value = (global::ElevenLabs.WorkflowPhoneNumberNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsStandaloneAgent(
        out global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput? value
    )
    {
        if (Type == "standalone_agent")
        {
            value = (global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowStartNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsStart(out global::ElevenLabs.WorkflowStartNodeModelInput? value)
    {
        if (Type == "start")
        {
            value = (global::ElevenLabs.WorkflowStartNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowToolNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTool(out global::ElevenLabs.WorkflowToolNodeModelInput? value)
    {
        if (Type == "tool")
        {
            value = (global::ElevenLabs.WorkflowToolNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowSayNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSay(out global::ElevenLabs.WorkflowSayNodeModelInput? value)
    {
        if (Type == "say")
        {
            value = (global::ElevenLabs.WorkflowSayNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowUpdateStateNodeModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateState(out global::ElevenLabs.WorkflowUpdateStateNodeModelInput? value)
    {
        if (Type == "update_state")
        {
            value = (global::ElevenLabs.WorkflowUpdateStateNodeModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.End value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.OverrideAgent value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.PhoneNumber value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.StandaloneAgent value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.Start value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.Tool value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.Say value
    ) => new(value);

    public static implicit operator AgentWorkflowRequestModelNodes(
        AgentWorkflowRequestModelNodes.UpdateState value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentWorkflowRequestModelNodes>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AgentWorkflowRequestModelNodes).IsAssignableFrom(typeToConvert);

        public override AgentWorkflowRequestModelNodes Read(
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
                "end" => json.Deserialize<global::ElevenLabs.WorkflowEndNodeModelInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowEndNodeModelInput"
                    ),
                "override_agent" =>
                    json.Deserialize<global::ElevenLabs.WorkflowOverrideAgentNodeModelInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowOverrideAgentNodeModelInput"
                        ),
                "phone_number" =>
                    json.Deserialize<global::ElevenLabs.WorkflowPhoneNumberNodeModelInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowPhoneNumberNodeModelInput"
                        ),
                "standalone_agent" =>
                    json.Deserialize<global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput"
                        ),
                "start" => json.Deserialize<global::ElevenLabs.WorkflowStartNodeModelInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowStartNodeModelInput"
                    ),
                "tool" => json.Deserialize<global::ElevenLabs.WorkflowToolNodeModelInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowToolNodeModelInput"
                    ),
                "say" => json.Deserialize<global::ElevenLabs.WorkflowSayNodeModelInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowSayNodeModelInput"
                    ),
                "update_state" =>
                    json.Deserialize<global::ElevenLabs.WorkflowUpdateStateNodeModelInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowUpdateStateNodeModelInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentWorkflowRequestModelNodes(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentWorkflowRequestModelNodes value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "end" => JsonSerializer.SerializeToNode(value.Value, options),
                    "override_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "phone_number" => JsonSerializer.SerializeToNode(value.Value, options),
                    "standalone_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "start" => JsonSerializer.SerializeToNode(value.Value, options),
                    "tool" => JsonSerializer.SerializeToNode(value.Value, options),
                    "say" => JsonSerializer.SerializeToNode(value.Value, options),
                    "update_state" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override AgentWorkflowRequestModelNodes ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AgentWorkflowRequestModelNodes(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentWorkflowRequestModelNodes value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for end
    /// </summary>
    [Serializable]
    public struct End
    {
        public End(global::ElevenLabs.WorkflowEndNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowEndNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.End(
            global::ElevenLabs.WorkflowEndNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for override_agent
    /// </summary>
    [Serializable]
    public struct OverrideAgent
    {
        public OverrideAgent(global::ElevenLabs.WorkflowOverrideAgentNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowOverrideAgentNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.OverrideAgent(
            global::ElevenLabs.WorkflowOverrideAgentNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phone_number
    /// </summary>
    [Serializable]
    public struct PhoneNumber
    {
        public PhoneNumber(global::ElevenLabs.WorkflowPhoneNumberNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowPhoneNumberNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.PhoneNumber(
            global::ElevenLabs.WorkflowPhoneNumberNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for standalone_agent
    /// </summary>
    [Serializable]
    public struct StandaloneAgent
    {
        public StandaloneAgent(global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.StandaloneAgent(
            global::ElevenLabs.WorkflowStandaloneAgentNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for start
    /// </summary>
    [Serializable]
    public struct Start
    {
        public Start(global::ElevenLabs.WorkflowStartNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowStartNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.Start(
            global::ElevenLabs.WorkflowStartNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for tool
    /// </summary>
    [Serializable]
    public struct Tool
    {
        public Tool(global::ElevenLabs.WorkflowToolNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowToolNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.Tool(
            global::ElevenLabs.WorkflowToolNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for say
    /// </summary>
    [Serializable]
    public struct Say
    {
        public Say(global::ElevenLabs.WorkflowSayNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowSayNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.Say(
            global::ElevenLabs.WorkflowSayNodeModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_state
    /// </summary>
    [Serializable]
    public struct UpdateState
    {
        public UpdateState(global::ElevenLabs.WorkflowUpdateStateNodeModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowUpdateStateNodeModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowRequestModelNodes.UpdateState(
            global::ElevenLabs.WorkflowUpdateStateNodeModelInput value
        ) => new(value);
    }
}
