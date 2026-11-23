// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(McpToolCallMcpToolCall.JsonConverter))]
[Serializable]
public class McpToolCallMcpToolCall
{
    private McpToolCallMcpToolCall(string type, object? value)
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
    /// Create a McpToolCallMcpToolCall from a Loading value.
    /// </summary>
    public static McpToolCallMcpToolCall FromLoading(global::ElevenLabs.Loading value) =>
        new("loading", value);

    /// <summary>
    /// Create a McpToolCallMcpToolCall from a AwaitingApproval value.
    /// </summary>
    public static McpToolCallMcpToolCall FromAwaitingApproval(
        global::ElevenLabs.AwaitingApproval value
    ) => new("awaitingApproval", value);

    /// <summary>
    /// Create a McpToolCallMcpToolCall from a Success value.
    /// </summary>
    public static McpToolCallMcpToolCall FromSuccess(global::ElevenLabs.Success value) =>
        new("success", value);

    /// <summary>
    /// Create a McpToolCallMcpToolCall from a Failure value.
    /// </summary>
    public static McpToolCallMcpToolCall FromFailure(global::ElevenLabs.Failure value) =>
        new("failure", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "loading".
    /// </summary>
    public bool IsLoading() => Type == "loading";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "awaitingApproval".
    /// </summary>
    public bool IsAwaitingApproval() => Type == "awaitingApproval";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "success".
    /// </summary>
    public bool IsSuccess() => Type == "success";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "failure".
    /// </summary>
    public bool IsFailure() => Type == "failure";

    /// <summary>
    /// Returns the value as a Loading if <see cref="Type"/> is "loading", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'loading'.</exception>
    public global::ElevenLabs.Loading AsLoading() =>
        IsLoading()
            ? (global::ElevenLabs.Loading)Value!
            : throw new ElevenLabsClientException("Union type is not 'loading'");

    /// <summary>
    /// Returns the value as a AwaitingApproval if <see cref="Type"/> is "awaitingApproval", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'awaitingApproval'.</exception>
    public global::ElevenLabs.AwaitingApproval AsAwaitingApproval() =>
        IsAwaitingApproval()
            ? (global::ElevenLabs.AwaitingApproval)Value!
            : throw new ElevenLabsClientException("Union type is not 'awaitingApproval'");

    /// <summary>
    /// Returns the value as a Success if <see cref="Type"/> is "success", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'success'.</exception>
    public global::ElevenLabs.Success AsSuccess() =>
        IsSuccess()
            ? (global::ElevenLabs.Success)Value!
            : throw new ElevenLabsClientException("Union type is not 'success'");

    /// <summary>
    /// Returns the value as a Failure if <see cref="Type"/> is "failure", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'failure'.</exception>
    public global::ElevenLabs.Failure AsFailure() =>
        IsFailure()
            ? (global::ElevenLabs.Failure)Value!
            : throw new ElevenLabsClientException("Union type is not 'failure'");

    /// <summary>
    /// Attempts to cast the value to a Loading and returns true if successful.
    /// </summary>
    public bool TryGetLoading(out global::ElevenLabs.Loading? value)
    {
        if (Type == "loading")
        {
            value = (global::ElevenLabs.Loading)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AwaitingApproval and returns true if successful.
    /// </summary>
    public bool TryGetAwaitingApproval(out global::ElevenLabs.AwaitingApproval? value)
    {
        if (Type == "awaitingApproval")
        {
            value = (global::ElevenLabs.AwaitingApproval)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Success and returns true if successful.
    /// </summary>
    public bool TryGetSuccess(out global::ElevenLabs.Success? value)
    {
        if (Type == "success")
        {
            value = (global::ElevenLabs.Success)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Failure and returns true if successful.
    /// </summary>
    public bool TryGetFailure(out global::ElevenLabs.Failure? value)
    {
        if (Type == "failure")
        {
            value = (global::ElevenLabs.Failure)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.Loading, T> onLoading,
        global::System.Func<global::ElevenLabs.AwaitingApproval, T> onAwaitingApproval,
        global::System.Func<global::ElevenLabs.Success, T> onSuccess,
        global::System.Func<global::ElevenLabs.Failure, T> onFailure
    )
    {
        return Type switch
        {
            "loading" => onLoading(AsLoading()),
            "awaitingApproval" => onAwaitingApproval(AsAwaitingApproval()),
            "success" => onSuccess(AsSuccess()),
            "failure" => onFailure(AsFailure()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.Loading> onLoading,
        global::System.Action<global::ElevenLabs.AwaitingApproval> onAwaitingApproval,
        global::System.Action<global::ElevenLabs.Success> onSuccess,
        global::System.Action<global::ElevenLabs.Failure> onFailure
    )
    {
        switch (Type)
        {
            case "loading":
                onLoading(AsLoading());
                break;
            case "awaitingApproval":
                onAwaitingApproval(AsAwaitingApproval());
                break;
            case "success":
                onSuccess(AsSuccess());
                break;
            case "failure":
                onFailure(AsFailure());
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
        if (obj is not McpToolCallMcpToolCall other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator McpToolCallMcpToolCall(global::ElevenLabs.Loading value) =>
        new("loading", value);

    public static implicit operator McpToolCallMcpToolCall(
        global::ElevenLabs.AwaitingApproval value
    ) => new("awaitingApproval", value);

    public static implicit operator McpToolCallMcpToolCall(global::ElevenLabs.Success value) =>
        new("success", value);

    public static implicit operator McpToolCallMcpToolCall(global::ElevenLabs.Failure value) =>
        new("failure", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<McpToolCallMcpToolCall>
    {
        public override McpToolCallMcpToolCall? Read(
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

                if (HasLiteral(document, "state", "loading"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.Loading),
                            options
                        );
                        if (value != null)
                        {
                            return new McpToolCallMcpToolCall("loading", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "state", "awaiting_approval"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.AwaitingApproval),
                            options
                        );
                        if (value != null)
                        {
                            return new McpToolCallMcpToolCall("awaitingApproval", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "state", "success"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.Success),
                            options
                        );
                        if (value != null)
                        {
                            return new McpToolCallMcpToolCall("success", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "state", "failure"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.Failure),
                            options
                        );
                        if (value != null)
                        {
                            return new McpToolCallMcpToolCall("failure", value);
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
                        "Cannot deserialize JSON object into McpToolCallMcpToolCall: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("loading", typeof(global::ElevenLabs.Loading)),
                    ("awaitingApproval", typeof(global::ElevenLabs.AwaitingApproval)),
                    ("success", typeof(global::ElevenLabs.Success)),
                    ("failure", typeof(global::ElevenLabs.Failure)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new McpToolCallMcpToolCall(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into McpToolCallMcpToolCall"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpToolCallMcpToolCall value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override McpToolCallMcpToolCall ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            McpToolCallMcpToolCall result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpToolCallMcpToolCall value,
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
