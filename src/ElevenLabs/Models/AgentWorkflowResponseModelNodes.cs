// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentWorkflowResponseModelNodes.JsonConverter))]
[Serializable]
public record AgentWorkflowResponseModelNodes
{
    internal AgentWorkflowResponseModelNodes(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.End"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.End value)
    {
        Type = "end";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.OverrideAgent"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.OverrideAgent value)
    {
        Type = "override_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.PhoneNumber"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.PhoneNumber value)
    {
        Type = "phone_number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.StandaloneAgent"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.StandaloneAgent value)
    {
        Type = "standalone_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.Start"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.Start value)
    {
        Type = "start";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.Tool"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.Tool value)
    {
        Type = "tool";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.Say"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.Say value)
    {
        Type = "say";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentWorkflowResponseModelNodes with <see cref="AgentWorkflowResponseModelNodes.UpdateState"/>.
    /// </summary>
    public AgentWorkflowResponseModelNodes(AgentWorkflowResponseModelNodes.UpdateState value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowEndNodeModelOutput"/> if <see cref="Type"/> is 'end', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'end'.</exception>
    public global::ElevenLabs.WorkflowEndNodeModelOutput AsEnd() =>
        IsEnd
            ? (global::ElevenLabs.WorkflowEndNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'end'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput"/> if <see cref="Type"/> is 'override_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'override_agent'.</exception>
    public global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput AsOverrideAgent() =>
        IsOverrideAgent
            ? (global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'override_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput"/> if <see cref="Type"/> is 'phone_number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone_number'.</exception>
    public global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput AsPhoneNumber() =>
        IsPhoneNumber
            ? (global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'phone_number'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput"/> if <see cref="Type"/> is 'standalone_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'standalone_agent'.</exception>
    public global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput AsStandaloneAgent() =>
        IsStandaloneAgent
            ? (global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'standalone_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowStartNodeModelOutput"/> if <see cref="Type"/> is 'start', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'start'.</exception>
    public global::ElevenLabs.WorkflowStartNodeModelOutput AsStart() =>
        IsStart
            ? (global::ElevenLabs.WorkflowStartNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'start'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowToolNodeModelOutput"/> if <see cref="Type"/> is 'tool', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'tool'.</exception>
    public global::ElevenLabs.WorkflowToolNodeModelOutput AsTool() =>
        IsTool
            ? (global::ElevenLabs.WorkflowToolNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'tool'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowSayNodeModelOutput"/> if <see cref="Type"/> is 'say', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'say'.</exception>
    public global::ElevenLabs.WorkflowSayNodeModelOutput AsSay() =>
        IsSay
            ? (global::ElevenLabs.WorkflowSayNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'say'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowUpdateStateNodeModelOutput"/> if <see cref="Type"/> is 'update_state', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'update_state'.</exception>
    public global::ElevenLabs.WorkflowUpdateStateNodeModelOutput AsUpdateState() =>
        IsUpdateState
            ? (global::ElevenLabs.WorkflowUpdateStateNodeModelOutput)Value!
            : throw new global::System.Exception(
                "AgentWorkflowResponseModelNodes.Type is not 'update_state'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WorkflowEndNodeModelOutput, T> onEnd,
        Func<global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput, T> onOverrideAgent,
        Func<global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput, T> onPhoneNumber,
        Func<global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput, T> onStandaloneAgent,
        Func<global::ElevenLabs.WorkflowStartNodeModelOutput, T> onStart,
        Func<global::ElevenLabs.WorkflowToolNodeModelOutput, T> onTool,
        Func<global::ElevenLabs.WorkflowSayNodeModelOutput, T> onSay,
        Func<global::ElevenLabs.WorkflowUpdateStateNodeModelOutput, T> onUpdateState,
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
        Action<global::ElevenLabs.WorkflowEndNodeModelOutput> onEnd,
        Action<global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput> onOverrideAgent,
        Action<global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput> onPhoneNumber,
        Action<global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput> onStandaloneAgent,
        Action<global::ElevenLabs.WorkflowStartNodeModelOutput> onStart,
        Action<global::ElevenLabs.WorkflowToolNodeModelOutput> onTool,
        Action<global::ElevenLabs.WorkflowSayNodeModelOutput> onSay,
        Action<global::ElevenLabs.WorkflowUpdateStateNodeModelOutput> onUpdateState,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowEndNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsEnd(out global::ElevenLabs.WorkflowEndNodeModelOutput? value)
    {
        if (Type == "end")
        {
            value = (global::ElevenLabs.WorkflowEndNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsOverrideAgent(
        out global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput? value
    )
    {
        if (Type == "override_agent")
        {
            value = (global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneNumber(out global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput? value)
    {
        if (Type == "phone_number")
        {
            value = (global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsStandaloneAgent(
        out global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput? value
    )
    {
        if (Type == "standalone_agent")
        {
            value = (global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowStartNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsStart(out global::ElevenLabs.WorkflowStartNodeModelOutput? value)
    {
        if (Type == "start")
        {
            value = (global::ElevenLabs.WorkflowStartNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowToolNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTool(out global::ElevenLabs.WorkflowToolNodeModelOutput? value)
    {
        if (Type == "tool")
        {
            value = (global::ElevenLabs.WorkflowToolNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowSayNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSay(out global::ElevenLabs.WorkflowSayNodeModelOutput? value)
    {
        if (Type == "say")
        {
            value = (global::ElevenLabs.WorkflowSayNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowUpdateStateNodeModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsUpdateState(out global::ElevenLabs.WorkflowUpdateStateNodeModelOutput? value)
    {
        if (Type == "update_state")
        {
            value = (global::ElevenLabs.WorkflowUpdateStateNodeModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.End value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.OverrideAgent value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.PhoneNumber value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.StandaloneAgent value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.Start value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.Tool value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.Say value
    ) => new(value);

    public static implicit operator AgentWorkflowResponseModelNodes(
        AgentWorkflowResponseModelNodes.UpdateState value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentWorkflowResponseModelNodes>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AgentWorkflowResponseModelNodes).IsAssignableFrom(typeToConvert);

        public override AgentWorkflowResponseModelNodes Read(
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
                "end" => json.Deserialize<global::ElevenLabs.WorkflowEndNodeModelOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowEndNodeModelOutput"
                    ),
                "override_agent" =>
                    json.Deserialize<global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput"
                        ),
                "phone_number" =>
                    json.Deserialize<global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput"
                        ),
                "standalone_agent" =>
                    json.Deserialize<global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput"
                        ),
                "start" => json.Deserialize<global::ElevenLabs.WorkflowStartNodeModelOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowStartNodeModelOutput"
                    ),
                "tool" => json.Deserialize<global::ElevenLabs.WorkflowToolNodeModelOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowToolNodeModelOutput"
                    ),
                "say" => json.Deserialize<global::ElevenLabs.WorkflowSayNodeModelOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowSayNodeModelOutput"
                    ),
                "update_state" =>
                    json.Deserialize<global::ElevenLabs.WorkflowUpdateStateNodeModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowUpdateStateNodeModelOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentWorkflowResponseModelNodes(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentWorkflowResponseModelNodes value,
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

        public override AgentWorkflowResponseModelNodes ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AgentWorkflowResponseModelNodes(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentWorkflowResponseModelNodes value,
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
        public End(global::ElevenLabs.WorkflowEndNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowEndNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.End(
            global::ElevenLabs.WorkflowEndNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for override_agent
    /// </summary>
    [Serializable]
    public struct OverrideAgent
    {
        public OverrideAgent(global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.OverrideAgent(
            global::ElevenLabs.WorkflowOverrideAgentNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phone_number
    /// </summary>
    [Serializable]
    public struct PhoneNumber
    {
        public PhoneNumber(global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.PhoneNumber(
            global::ElevenLabs.WorkflowPhoneNumberNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for standalone_agent
    /// </summary>
    [Serializable]
    public struct StandaloneAgent
    {
        public StandaloneAgent(global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.StandaloneAgent(
            global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for start
    /// </summary>
    [Serializable]
    public struct Start
    {
        public Start(global::ElevenLabs.WorkflowStartNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowStartNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.Start(
            global::ElevenLabs.WorkflowStartNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for tool
    /// </summary>
    [Serializable]
    public struct Tool
    {
        public Tool(global::ElevenLabs.WorkflowToolNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowToolNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.Tool(
            global::ElevenLabs.WorkflowToolNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for say
    /// </summary>
    [Serializable]
    public struct Say
    {
        public Say(global::ElevenLabs.WorkflowSayNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowSayNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.Say(
            global::ElevenLabs.WorkflowSayNodeModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for update_state
    /// </summary>
    [Serializable]
    public struct UpdateState
    {
        public UpdateState(global::ElevenLabs.WorkflowUpdateStateNodeModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowUpdateStateNodeModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentWorkflowResponseModelNodes.UpdateState(
            global::ElevenLabs.WorkflowUpdateStateNodeModelOutput value
        ) => new(value);
    }
}
