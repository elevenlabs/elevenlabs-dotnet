// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MediaGenerationResponse.JsonConverter))]
[Serializable]
public record MediaGenerationResponse
{
    internal MediaGenerationResponse(string type, object? value)
    {
        Status = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of MediaGenerationResponse with <see cref="MediaGenerationResponse.Completed"/>.
    /// </summary>
    public MediaGenerationResponse(MediaGenerationResponse.Completed value)
    {
        Status = "completed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of MediaGenerationResponse with <see cref="MediaGenerationResponse.Failed"/>.
    /// </summary>
    public MediaGenerationResponse(MediaGenerationResponse.Failed value)
    {
        Status = "failed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of MediaGenerationResponse with <see cref="MediaGenerationResponse.Generating"/>.
    /// </summary>
    public MediaGenerationResponse(MediaGenerationResponse.Generating value)
    {
        Status = "generating";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of MediaGenerationResponse with <see cref="MediaGenerationResponse.Pending"/>.
    /// </summary>
    public MediaGenerationResponse(MediaGenerationResponse.Pending value)
    {
        Status = "pending";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Status"/> is "completed"
    /// </summary>
    public bool IsCompleted => Status == "completed";

    /// <summary>
    /// Returns true if <see cref="Status"/> is "failed"
    /// </summary>
    public bool IsFailed => Status == "failed";

    /// <summary>
    /// Returns true if <see cref="Status"/> is "generating"
    /// </summary>
    public bool IsGenerating => Status == "generating";

    /// <summary>
    /// Returns true if <see cref="Status"/> is "pending"
    /// </summary>
    public bool IsPending => Status == "pending";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MediaGenerationCompletedResponse"/> if <see cref="Status"/> is 'completed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'completed'.</exception>
    public global::ElevenLabs.MediaGenerationCompletedResponse AsCompleted() =>
        IsCompleted
            ? (global::ElevenLabs.MediaGenerationCompletedResponse)Value!
            : throw new global::System.Exception(
                "MediaGenerationResponse.Status is not 'completed'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MediaGenerationFailedResponse"/> if <see cref="Status"/> is 'failed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'failed'.</exception>
    public global::ElevenLabs.MediaGenerationFailedResponse AsFailed() =>
        IsFailed
            ? (global::ElevenLabs.MediaGenerationFailedResponse)Value!
            : throw new global::System.Exception("MediaGenerationResponse.Status is not 'failed'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MediaGenerationInProgressResponse"/> if <see cref="Status"/> is 'generating', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'generating'.</exception>
    public global::ElevenLabs.MediaGenerationInProgressResponse AsGenerating() =>
        IsGenerating
            ? (global::ElevenLabs.MediaGenerationInProgressResponse)Value!
            : throw new global::System.Exception(
                "MediaGenerationResponse.Status is not 'generating'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MediaGenerationInProgressResponse"/> if <see cref="Status"/> is 'pending', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'pending'.</exception>
    public global::ElevenLabs.MediaGenerationInProgressResponse AsPending() =>
        IsPending
            ? (global::ElevenLabs.MediaGenerationInProgressResponse)Value!
            : throw new global::System.Exception("MediaGenerationResponse.Status is not 'pending'");

    public T Match<T>(
        Func<global::ElevenLabs.MediaGenerationCompletedResponse, T> onCompleted,
        Func<global::ElevenLabs.MediaGenerationFailedResponse, T> onFailed,
        Func<global::ElevenLabs.MediaGenerationInProgressResponse, T> onGenerating,
        Func<global::ElevenLabs.MediaGenerationInProgressResponse, T> onPending,
        Func<string, object?, T> onUnknown_
    )
    {
        return Status switch
        {
            "completed" => onCompleted(AsCompleted()),
            "failed" => onFailed(AsFailed()),
            "generating" => onGenerating(AsGenerating()),
            "pending" => onPending(AsPending()),
            _ => onUnknown_(Status, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.MediaGenerationCompletedResponse> onCompleted,
        Action<global::ElevenLabs.MediaGenerationFailedResponse> onFailed,
        Action<global::ElevenLabs.MediaGenerationInProgressResponse> onGenerating,
        Action<global::ElevenLabs.MediaGenerationInProgressResponse> onPending,
        Action<string, object?> onUnknown_
    )
    {
        switch (Status)
        {
            case "completed":
                onCompleted(AsCompleted());
                break;
            case "failed":
                onFailed(AsFailed());
                break;
            case "generating":
                onGenerating(AsGenerating());
                break;
            case "pending":
                onPending(AsPending());
                break;
            default:
                onUnknown_(Status, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MediaGenerationCompletedResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsCompleted(out global::ElevenLabs.MediaGenerationCompletedResponse? value)
    {
        if (Status == "completed")
        {
            value = (global::ElevenLabs.MediaGenerationCompletedResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MediaGenerationFailedResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsFailed(out global::ElevenLabs.MediaGenerationFailedResponse? value)
    {
        if (Status == "failed")
        {
            value = (global::ElevenLabs.MediaGenerationFailedResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MediaGenerationInProgressResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsGenerating(out global::ElevenLabs.MediaGenerationInProgressResponse? value)
    {
        if (Status == "generating")
        {
            value = (global::ElevenLabs.MediaGenerationInProgressResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MediaGenerationInProgressResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsPending(out global::ElevenLabs.MediaGenerationInProgressResponse? value)
    {
        if (Status == "pending")
        {
            value = (global::ElevenLabs.MediaGenerationInProgressResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator MediaGenerationResponse(
        MediaGenerationResponse.Completed value
    ) => new(value);

    public static implicit operator MediaGenerationResponse(MediaGenerationResponse.Failed value) =>
        new(value);

    public static implicit operator MediaGenerationResponse(
        MediaGenerationResponse.Generating value
    ) => new(value);

    public static implicit operator MediaGenerationResponse(
        MediaGenerationResponse.Pending value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<MediaGenerationResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(MediaGenerationResponse).IsAssignableFrom(typeToConvert);

        public override MediaGenerationResponse Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("status", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'status'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'status' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'status' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'status' is null");

            var value = discriminator switch
            {
                "completed" =>
                    json.Deserialize<global::ElevenLabs.MediaGenerationCompletedResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.MediaGenerationCompletedResponse"
                        ),
                "failed" => json.Deserialize<global::ElevenLabs.MediaGenerationFailedResponse?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.MediaGenerationFailedResponse"
                    ),
                "generating" =>
                    json.Deserialize<global::ElevenLabs.MediaGenerationInProgressResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.MediaGenerationInProgressResponse"
                        ),
                "pending" =>
                    json.Deserialize<global::ElevenLabs.MediaGenerationInProgressResponse?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.MediaGenerationInProgressResponse"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new MediaGenerationResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MediaGenerationResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Status switch
                {
                    "completed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "failed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "generating" => JsonSerializer.SerializeToNode(value.Value, options),
                    "pending" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["status"] = value.Status;
            json.WriteTo(writer, options);
        }

        public override MediaGenerationResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new MediaGenerationResponse(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MediaGenerationResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Status);
        }
    }

    /// <summary>
    /// Discriminated union type for completed
    /// </summary>
    [Serializable]
    public struct Completed
    {
        public Completed(global::ElevenLabs.MediaGenerationCompletedResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MediaGenerationCompletedResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator MediaGenerationResponse.Completed(
            global::ElevenLabs.MediaGenerationCompletedResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for failed
    /// </summary>
    [Serializable]
    public struct Failed
    {
        public Failed(global::ElevenLabs.MediaGenerationFailedResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MediaGenerationFailedResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator MediaGenerationResponse.Failed(
            global::ElevenLabs.MediaGenerationFailedResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for generating
    /// </summary>
    [Serializable]
    public struct Generating
    {
        public Generating(global::ElevenLabs.MediaGenerationInProgressResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MediaGenerationInProgressResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator MediaGenerationResponse.Generating(
            global::ElevenLabs.MediaGenerationInProgressResponse value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for pending
    /// </summary>
    [Serializable]
    public struct Pending
    {
        public Pending(global::ElevenLabs.MediaGenerationInProgressResponse value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MediaGenerationInProgressResponse Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator MediaGenerationResponse.Pending(
            global::ElevenLabs.MediaGenerationInProgressResponse value
        ) => new(value);
    }
}
