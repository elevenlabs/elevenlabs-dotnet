// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GetOrCreateRagIndexesKnowledgeBaseResponse.JsonConverter))]
[Serializable]
public record GetOrCreateRagIndexesKnowledgeBaseResponse
{
    internal GetOrCreateRagIndexesKnowledgeBaseResponse(string type, object? value)
    {
        Status = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of GetOrCreateRagIndexesKnowledgeBaseResponse with <see cref="GetOrCreateRagIndexesKnowledgeBaseResponse.Success"/>.
    /// </summary>
    public GetOrCreateRagIndexesKnowledgeBaseResponse(
        GetOrCreateRagIndexesKnowledgeBaseResponse.Success value
    )
    {
        Status = "success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of GetOrCreateRagIndexesKnowledgeBaseResponse with <see cref="GetOrCreateRagIndexesKnowledgeBaseResponse.Failure"/>.
    /// </summary>
    public GetOrCreateRagIndexesKnowledgeBaseResponse(
        GetOrCreateRagIndexesKnowledgeBaseResponse.Failure value
    )
    {
        Status = "failure";
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
    /// Returns true if <see cref="Status"/> is "success"
    /// </summary>
    public bool IsSuccess => Status == "success";

    /// <summary>
    /// Returns true if <see cref="Status"/> is "failure"
    /// </summary>
    public bool IsFailure => Status == "failure";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.RagIndexBatchSuccessfulResponseModel"/> if <see cref="Status"/> is 'success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'success'.</exception>
    public global::ElevenLabs.RagIndexBatchSuccessfulResponseModel AsSuccess() =>
        IsSuccess
            ? (global::ElevenLabs.RagIndexBatchSuccessfulResponseModel)Value!
            : throw new global::System.Exception(
                "GetOrCreateRagIndexesKnowledgeBaseResponse.Status is not 'success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BatchFailureResponseModel"/> if <see cref="Status"/> is 'failure', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Status"/> is not 'failure'.</exception>
    public global::ElevenLabs.BatchFailureResponseModel AsFailure() =>
        IsFailure
            ? (global::ElevenLabs.BatchFailureResponseModel)Value!
            : throw new global::System.Exception(
                "GetOrCreateRagIndexesKnowledgeBaseResponse.Status is not 'failure'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.RagIndexBatchSuccessfulResponseModel, T> onSuccess,
        Func<global::ElevenLabs.BatchFailureResponseModel, T> onFailure,
        Func<string, object?, T> onUnknown_
    )
    {
        return Status switch
        {
            "success" => onSuccess(AsSuccess()),
            "failure" => onFailure(AsFailure()),
            _ => onUnknown_(Status, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.RagIndexBatchSuccessfulResponseModel> onSuccess,
        Action<global::ElevenLabs.BatchFailureResponseModel> onFailure,
        Action<string, object?> onUnknown_
    )
    {
        switch (Status)
        {
            case "success":
                onSuccess(AsSuccess());
                break;
            case "failure":
                onFailure(AsFailure());
                break;
            default:
                onUnknown_(Status, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.RagIndexBatchSuccessfulResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsSuccess(out global::ElevenLabs.RagIndexBatchSuccessfulResponseModel? value)
    {
        if (Status == "success")
        {
            value = (global::ElevenLabs.RagIndexBatchSuccessfulResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BatchFailureResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsFailure(out global::ElevenLabs.BatchFailureResponseModel? value)
    {
        if (Status == "failure")
        {
            value = (global::ElevenLabs.BatchFailureResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator GetOrCreateRagIndexesKnowledgeBaseResponse(
        GetOrCreateRagIndexesKnowledgeBaseResponse.Success value
    ) => new(value);

    public static implicit operator GetOrCreateRagIndexesKnowledgeBaseResponse(
        GetOrCreateRagIndexesKnowledgeBaseResponse.Failure value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GetOrCreateRagIndexesKnowledgeBaseResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(GetOrCreateRagIndexesKnowledgeBaseResponse).IsAssignableFrom(typeToConvert);

        public override GetOrCreateRagIndexesKnowledgeBaseResponse Read(
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
                "success" =>
                    json.Deserialize<global::ElevenLabs.RagIndexBatchSuccessfulResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.RagIndexBatchSuccessfulResponseModel"
                        ),
                "failure" => json.Deserialize<global::ElevenLabs.BatchFailureResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.BatchFailureResponseModel"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new GetOrCreateRagIndexesKnowledgeBaseResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrCreateRagIndexesKnowledgeBaseResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Status switch
                {
                    "success" => JsonSerializer.SerializeToNode(value.Value, options),
                    "failure" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["status"] = value.Status;
            json.WriteTo(writer, options);
        }

        public override GetOrCreateRagIndexesKnowledgeBaseResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new GetOrCreateRagIndexesKnowledgeBaseResponse(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrCreateRagIndexesKnowledgeBaseResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Status);
        }
    }

    /// <summary>
    /// Discriminated union type for success
    /// </summary>
    [Serializable]
    public struct Success
    {
        public Success(global::ElevenLabs.RagIndexBatchSuccessfulResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.RagIndexBatchSuccessfulResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetOrCreateRagIndexesKnowledgeBaseResponse.Success(
            global::ElevenLabs.RagIndexBatchSuccessfulResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for failure
    /// </summary>
    [Serializable]
    public struct Failure
    {
        public Failure(global::ElevenLabs.BatchFailureResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BatchFailureResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator GetOrCreateRagIndexesKnowledgeBaseResponse.Failure(
            global::ElevenLabs.BatchFailureResponseModel value
        ) => new(value);
    }
}
