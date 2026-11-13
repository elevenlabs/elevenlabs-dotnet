// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentTransferOp.JsonConverter))]
[Serializable]
public record AgentTransferOp
{
    internal AgentTransferOp(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AgentTransferOp with <see cref="AgentTransferOp.Pop"/>.
    /// </summary>
    public AgentTransferOp(AgentTransferOp.Pop value)
    {
        Type = "pop";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentTransferOp with <see cref="AgentTransferOp.Push"/>.
    /// </summary>
    public AgentTransferOp(AgentTransferOp.Push value)
    {
        Type = "push";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AgentTransferOp with <see cref="AgentTransferOp.Replace"/>.
    /// </summary>
    public AgentTransferOp(AgentTransferOp.Replace value)
    {
        Type = "replace";
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
    /// Returns true if <see cref="Type"/> is "pop"
    /// </summary>
    public bool IsPop => Type == "pop";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "push"
    /// </summary>
    public bool IsPush => Type == "push";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "replace"
    /// </summary>
    public bool IsReplace => Type == "replace";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentTransferOpPop"/> if <see cref="Type"/> is 'pop', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'pop'.</exception>
    public global::ElevenLabs.AgentTransferOpPop AsPop() =>
        IsPop
            ? (global::ElevenLabs.AgentTransferOpPop)Value!
            : throw new global::System.Exception("AgentTransferOp.Type is not 'pop'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentTransferOpPush"/> if <see cref="Type"/> is 'push', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'push'.</exception>
    public global::ElevenLabs.AgentTransferOpPush AsPush() =>
        IsPush
            ? (global::ElevenLabs.AgentTransferOpPush)Value!
            : throw new global::System.Exception("AgentTransferOp.Type is not 'push'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AgentTransferOpReplace"/> if <see cref="Type"/> is 'replace', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'replace'.</exception>
    public global::ElevenLabs.AgentTransferOpReplace AsReplace() =>
        IsReplace
            ? (global::ElevenLabs.AgentTransferOpReplace)Value!
            : throw new global::System.Exception("AgentTransferOp.Type is not 'replace'");

    public T Match<T>(
        Func<global::ElevenLabs.AgentTransferOpPop, T> onPop,
        Func<global::ElevenLabs.AgentTransferOpPush, T> onPush,
        Func<global::ElevenLabs.AgentTransferOpReplace, T> onReplace,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "pop" => onPop(AsPop()),
            "push" => onPush(AsPush()),
            "replace" => onReplace(AsReplace()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.AgentTransferOpPop> onPop,
        Action<global::ElevenLabs.AgentTransferOpPush> onPush,
        Action<global::ElevenLabs.AgentTransferOpReplace> onReplace,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "pop":
                onPop(AsPop());
                break;
            case "push":
                onPush(AsPush());
                break;
            case "replace":
                onReplace(AsReplace());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentTransferOpPop"/> and returns true if successful.
    /// </summary>
    public bool TryAsPop(out global::ElevenLabs.AgentTransferOpPop? value)
    {
        if (Type == "pop")
        {
            value = (global::ElevenLabs.AgentTransferOpPop)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentTransferOpPush"/> and returns true if successful.
    /// </summary>
    public bool TryAsPush(out global::ElevenLabs.AgentTransferOpPush? value)
    {
        if (Type == "push")
        {
            value = (global::ElevenLabs.AgentTransferOpPush)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AgentTransferOpReplace"/> and returns true if successful.
    /// </summary>
    public bool TryAsReplace(out global::ElevenLabs.AgentTransferOpReplace? value)
    {
        if (Type == "replace")
        {
            value = (global::ElevenLabs.AgentTransferOpReplace)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AgentTransferOp(AgentTransferOp.Pop value) => new(value);

    public static implicit operator AgentTransferOp(AgentTransferOp.Push value) => new(value);

    public static implicit operator AgentTransferOp(AgentTransferOp.Replace value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AgentTransferOp>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AgentTransferOp).IsAssignableFrom(typeToConvert);

        public override AgentTransferOp Read(
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
                "pop" => json.Deserialize<global::ElevenLabs.AgentTransferOpPop?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AgentTransferOpPop"
                    ),
                "push" => json.Deserialize<global::ElevenLabs.AgentTransferOpPush?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AgentTransferOpPush"
                    ),
                "replace" => json.Deserialize<global::ElevenLabs.AgentTransferOpReplace?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AgentTransferOpReplace"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new AgentTransferOp(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentTransferOp value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "pop" => JsonSerializer.SerializeToNode(value.Value, options),
                    "push" => JsonSerializer.SerializeToNode(value.Value, options),
                    "replace" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override AgentTransferOp ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AgentTransferOp(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentTransferOp value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for pop
    /// </summary>
    [Serializable]
    public struct Pop
    {
        public Pop(global::ElevenLabs.AgentTransferOpPop value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentTransferOpPop Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentTransferOp.Pop(
            global::ElevenLabs.AgentTransferOpPop value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for push
    /// </summary>
    [Serializable]
    public struct Push
    {
        public Push(global::ElevenLabs.AgentTransferOpPush value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentTransferOpPush Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentTransferOp.Push(
            global::ElevenLabs.AgentTransferOpPush value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for replace
    /// </summary>
    [Serializable]
    public struct Replace
    {
        public Replace(global::ElevenLabs.AgentTransferOpReplace value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AgentTransferOpReplace Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AgentTransferOp.Replace(
            global::ElevenLabs.AgentTransferOpReplace value
        ) => new(value);
    }
}
