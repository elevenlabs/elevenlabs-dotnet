// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Flows;

[JsonConverter(typeof(VideoGenerationRequest.JsonConverter))]
[Serializable]
public record VideoGenerationRequest
{
    internal VideoGenerationRequest(string type, object? value)
    {
        ModelId = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.BytedanceSeedanceV2"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.BytedanceSeedanceV2 value)
    {
        ModelId = "bytedance-seedance-v2";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.BytedanceSeedanceV2Fast"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.BytedanceSeedanceV2Fast value)
    {
        ModelId = "bytedance-seedance-v2-fast";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.BytedanceSeedanceV2Mini"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.BytedanceSeedanceV2Mini value)
    {
        ModelId = "bytedance-seedance-v2-mini";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.BytedanceSeedanceV2_5"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.BytedanceSeedanceV2_5 value)
    {
        ModelId = "bytedance-seedance-v2.5";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.CreatifyAurora"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.CreatifyAurora value)
    {
        ModelId = "creatify-aurora";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.Veo3_1FastGenerate001"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.Veo3_1FastGenerate001 value)
    {
        ModelId = "veo-3.1-fast-generate-001";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of VideoGenerationRequest with <see cref="VideoGenerationRequest.Veo3_1Generate001"/>.
    /// </summary>
    public VideoGenerationRequest(VideoGenerationRequest.Veo3_1Generate001 value)
    {
        ModelId = "veo-3.1-generate-001";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("model_id")]
    public string ModelId { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "bytedance-seedance-v2"
    /// </summary>
    public bool IsBytedanceSeedanceV2 => ModelId == "bytedance-seedance-v2";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "bytedance-seedance-v2-fast"
    /// </summary>
    public bool IsBytedanceSeedanceV2Fast => ModelId == "bytedance-seedance-v2-fast";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "bytedance-seedance-v2-mini"
    /// </summary>
    public bool IsBytedanceSeedanceV2Mini => ModelId == "bytedance-seedance-v2-mini";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "bytedance-seedance-v2.5"
    /// </summary>
    public bool IsBytedanceSeedanceV2_5 => ModelId == "bytedance-seedance-v2.5";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "creatify-aurora"
    /// </summary>
    public bool IsCreatifyAurora => ModelId == "creatify-aurora";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "veo-3.1-fast-generate-001"
    /// </summary>
    public bool IsVeo3_1FastGenerate001 => ModelId == "veo-3.1-fast-generate-001";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "veo-3.1-generate-001"
    /// </summary>
    public bool IsVeo3_1Generate001 => ModelId == "veo-3.1-generate-001";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BytedanceSeedance2Request"/> if <see cref="ModelId"/> is 'bytedance-seedance-v2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'bytedance-seedance-v2'.</exception>
    public global::ElevenLabs.BytedanceSeedance2Request AsBytedanceSeedanceV2() =>
        IsBytedanceSeedanceV2
            ? (global::ElevenLabs.BytedanceSeedance2Request)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'bytedance-seedance-v2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BytedanceSeedance2FastRequest"/> if <see cref="ModelId"/> is 'bytedance-seedance-v2-fast', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'bytedance-seedance-v2-fast'.</exception>
    public global::ElevenLabs.BytedanceSeedance2FastRequest AsBytedanceSeedanceV2Fast() =>
        IsBytedanceSeedanceV2Fast
            ? (global::ElevenLabs.BytedanceSeedance2FastRequest)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'bytedance-seedance-v2-fast'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BytedanceSeedance2MiniRequest"/> if <see cref="ModelId"/> is 'bytedance-seedance-v2-mini', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'bytedance-seedance-v2-mini'.</exception>
    public global::ElevenLabs.BytedanceSeedance2MiniRequest AsBytedanceSeedanceV2Mini() =>
        IsBytedanceSeedanceV2Mini
            ? (global::ElevenLabs.BytedanceSeedance2MiniRequest)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'bytedance-seedance-v2-mini'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BytedanceSeedance25Request"/> if <see cref="ModelId"/> is 'bytedance-seedance-v2.5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'bytedance-seedance-v2.5'.</exception>
    public global::ElevenLabs.BytedanceSeedance25Request AsBytedanceSeedanceV2_5() =>
        IsBytedanceSeedanceV2_5
            ? (global::ElevenLabs.BytedanceSeedance25Request)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'bytedance-seedance-v2.5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CreatifyAuroraRequest"/> if <see cref="ModelId"/> is 'creatify-aurora', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'creatify-aurora'.</exception>
    public global::ElevenLabs.CreatifyAuroraRequest AsCreatifyAurora() =>
        IsCreatifyAurora
            ? (global::ElevenLabs.CreatifyAuroraRequest)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'creatify-aurora'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Veo31FastRequest"/> if <see cref="ModelId"/> is 'veo-3.1-fast-generate-001', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'veo-3.1-fast-generate-001'.</exception>
    public global::ElevenLabs.Veo31FastRequest AsVeo3_1FastGenerate001() =>
        IsVeo3_1FastGenerate001
            ? (global::ElevenLabs.Veo31FastRequest)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'veo-3.1-fast-generate-001'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Veo31Request"/> if <see cref="ModelId"/> is 'veo-3.1-generate-001', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'veo-3.1-generate-001'.</exception>
    public global::ElevenLabs.Veo31Request AsVeo3_1Generate001() =>
        IsVeo3_1Generate001
            ? (global::ElevenLabs.Veo31Request)Value!
            : throw new global::System.Exception(
                "VideoGenerationRequest.ModelId is not 'veo-3.1-generate-001'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.BytedanceSeedance2Request, T> onBytedanceSeedanceV2,
        Func<global::ElevenLabs.BytedanceSeedance2FastRequest, T> onBytedanceSeedanceV2Fast,
        Func<global::ElevenLabs.BytedanceSeedance2MiniRequest, T> onBytedanceSeedanceV2Mini,
        Func<global::ElevenLabs.BytedanceSeedance25Request, T> onBytedanceSeedanceV2_5,
        Func<global::ElevenLabs.CreatifyAuroraRequest, T> onCreatifyAurora,
        Func<global::ElevenLabs.Veo31FastRequest, T> onVeo3_1FastGenerate001,
        Func<global::ElevenLabs.Veo31Request, T> onVeo3_1Generate001,
        Func<string, object?, T> onUnknown_
    )
    {
        return ModelId switch
        {
            "bytedance-seedance-v2" => onBytedanceSeedanceV2(AsBytedanceSeedanceV2()),
            "bytedance-seedance-v2-fast" => onBytedanceSeedanceV2Fast(AsBytedanceSeedanceV2Fast()),
            "bytedance-seedance-v2-mini" => onBytedanceSeedanceV2Mini(AsBytedanceSeedanceV2Mini()),
            "bytedance-seedance-v2.5" => onBytedanceSeedanceV2_5(AsBytedanceSeedanceV2_5()),
            "creatify-aurora" => onCreatifyAurora(AsCreatifyAurora()),
            "veo-3.1-fast-generate-001" => onVeo3_1FastGenerate001(AsVeo3_1FastGenerate001()),
            "veo-3.1-generate-001" => onVeo3_1Generate001(AsVeo3_1Generate001()),
            _ => onUnknown_(ModelId, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.BytedanceSeedance2Request> onBytedanceSeedanceV2,
        Action<global::ElevenLabs.BytedanceSeedance2FastRequest> onBytedanceSeedanceV2Fast,
        Action<global::ElevenLabs.BytedanceSeedance2MiniRequest> onBytedanceSeedanceV2Mini,
        Action<global::ElevenLabs.BytedanceSeedance25Request> onBytedanceSeedanceV2_5,
        Action<global::ElevenLabs.CreatifyAuroraRequest> onCreatifyAurora,
        Action<global::ElevenLabs.Veo31FastRequest> onVeo3_1FastGenerate001,
        Action<global::ElevenLabs.Veo31Request> onVeo3_1Generate001,
        Action<string, object?> onUnknown_
    )
    {
        switch (ModelId)
        {
            case "bytedance-seedance-v2":
                onBytedanceSeedanceV2(AsBytedanceSeedanceV2());
                break;
            case "bytedance-seedance-v2-fast":
                onBytedanceSeedanceV2Fast(AsBytedanceSeedanceV2Fast());
                break;
            case "bytedance-seedance-v2-mini":
                onBytedanceSeedanceV2Mini(AsBytedanceSeedanceV2Mini());
                break;
            case "bytedance-seedance-v2.5":
                onBytedanceSeedanceV2_5(AsBytedanceSeedanceV2_5());
                break;
            case "creatify-aurora":
                onCreatifyAurora(AsCreatifyAurora());
                break;
            case "veo-3.1-fast-generate-001":
                onVeo3_1FastGenerate001(AsVeo3_1FastGenerate001());
                break;
            case "veo-3.1-generate-001":
                onVeo3_1Generate001(AsVeo3_1Generate001());
                break;
            default:
                onUnknown_(ModelId, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BytedanceSeedance2Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsBytedanceSeedanceV2(out global::ElevenLabs.BytedanceSeedance2Request? value)
    {
        if (ModelId == "bytedance-seedance-v2")
        {
            value = (global::ElevenLabs.BytedanceSeedance2Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BytedanceSeedance2FastRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsBytedanceSeedanceV2Fast(
        out global::ElevenLabs.BytedanceSeedance2FastRequest? value
    )
    {
        if (ModelId == "bytedance-seedance-v2-fast")
        {
            value = (global::ElevenLabs.BytedanceSeedance2FastRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BytedanceSeedance2MiniRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsBytedanceSeedanceV2Mini(
        out global::ElevenLabs.BytedanceSeedance2MiniRequest? value
    )
    {
        if (ModelId == "bytedance-seedance-v2-mini")
        {
            value = (global::ElevenLabs.BytedanceSeedance2MiniRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BytedanceSeedance25Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsBytedanceSeedanceV2_5(out global::ElevenLabs.BytedanceSeedance25Request? value)
    {
        if (ModelId == "bytedance-seedance-v2.5")
        {
            value = (global::ElevenLabs.BytedanceSeedance25Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CreatifyAuroraRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsCreatifyAurora(out global::ElevenLabs.CreatifyAuroraRequest? value)
    {
        if (ModelId == "creatify-aurora")
        {
            value = (global::ElevenLabs.CreatifyAuroraRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Veo31FastRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsVeo3_1FastGenerate001(out global::ElevenLabs.Veo31FastRequest? value)
    {
        if (ModelId == "veo-3.1-fast-generate-001")
        {
            value = (global::ElevenLabs.Veo31FastRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Veo31Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsVeo3_1Generate001(out global::ElevenLabs.Veo31Request? value)
    {
        if (ModelId == "veo-3.1-generate-001")
        {
            value = (global::ElevenLabs.Veo31Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.BytedanceSeedanceV2 value
    ) => new(value);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.BytedanceSeedanceV2Fast value
    ) => new(value);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.BytedanceSeedanceV2Mini value
    ) => new(value);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.BytedanceSeedanceV2_5 value
    ) => new(value);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.CreatifyAurora value
    ) => new(value);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.Veo3_1FastGenerate001 value
    ) => new(value);

    public static implicit operator VideoGenerationRequest(
        VideoGenerationRequest.Veo3_1Generate001 value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<VideoGenerationRequest>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(VideoGenerationRequest).IsAssignableFrom(typeToConvert);

        public override VideoGenerationRequest Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("model_id", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'model_id'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'model_id' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'model_id' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'model_id' is null");

            var value = discriminator switch
            {
                "bytedance-seedance-v2" =>
                    json.Deserialize<global::ElevenLabs.BytedanceSeedance2Request?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.BytedanceSeedance2Request"
                        ),
                "bytedance-seedance-v2-fast" =>
                    json.Deserialize<global::ElevenLabs.BytedanceSeedance2FastRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.BytedanceSeedance2FastRequest"
                        ),
                "bytedance-seedance-v2-mini" =>
                    json.Deserialize<global::ElevenLabs.BytedanceSeedance2MiniRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.BytedanceSeedance2MiniRequest"
                        ),
                "bytedance-seedance-v2.5" =>
                    json.Deserialize<global::ElevenLabs.BytedanceSeedance25Request?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.BytedanceSeedance25Request"
                        ),
                "creatify-aurora" => json.Deserialize<global::ElevenLabs.CreatifyAuroraRequest?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CreatifyAuroraRequest"
                    ),
                "veo-3.1-fast-generate-001" =>
                    json.Deserialize<global::ElevenLabs.Veo31FastRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.Veo31FastRequest"
                        ),
                "veo-3.1-generate-001" => json.Deserialize<global::ElevenLabs.Veo31Request?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.Veo31Request"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new VideoGenerationRequest(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VideoGenerationRequest value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.ModelId switch
                {
                    "bytedance-seedance-v2" => JsonSerializer.SerializeToNode(value.Value, options),
                    "bytedance-seedance-v2-fast" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "bytedance-seedance-v2-mini" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "bytedance-seedance-v2.5" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "creatify-aurora" => JsonSerializer.SerializeToNode(value.Value, options),
                    "veo-3.1-fast-generate-001" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "veo-3.1-generate-001" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["model_id"] = value.ModelId;
            json.WriteTo(writer, options);
        }

        public override VideoGenerationRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new VideoGenerationRequest(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VideoGenerationRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.ModelId);
        }
    }

    /// <summary>
    /// Discriminated union type for bytedance-seedance-v2
    /// </summary>
    [Serializable]
    public struct BytedanceSeedanceV2
    {
        public BytedanceSeedanceV2(global::ElevenLabs.BytedanceSeedance2Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BytedanceSeedance2Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.BytedanceSeedanceV2(
            global::ElevenLabs.BytedanceSeedance2Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bytedance-seedance-v2-fast
    /// </summary>
    [Serializable]
    public struct BytedanceSeedanceV2Fast
    {
        public BytedanceSeedanceV2Fast(global::ElevenLabs.BytedanceSeedance2FastRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BytedanceSeedance2FastRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.BytedanceSeedanceV2Fast(
            global::ElevenLabs.BytedanceSeedance2FastRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bytedance-seedance-v2-mini
    /// </summary>
    [Serializable]
    public struct BytedanceSeedanceV2Mini
    {
        public BytedanceSeedanceV2Mini(global::ElevenLabs.BytedanceSeedance2MiniRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BytedanceSeedance2MiniRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.BytedanceSeedanceV2Mini(
            global::ElevenLabs.BytedanceSeedance2MiniRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bytedance-seedance-v2.5
    /// </summary>
    [Serializable]
    public struct BytedanceSeedanceV2_5
    {
        public BytedanceSeedanceV2_5(global::ElevenLabs.BytedanceSeedance25Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BytedanceSeedance25Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.BytedanceSeedanceV2_5(
            global::ElevenLabs.BytedanceSeedance25Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for creatify-aurora
    /// </summary>
    [Serializable]
    public struct CreatifyAurora
    {
        public CreatifyAurora(global::ElevenLabs.CreatifyAuroraRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CreatifyAuroraRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.CreatifyAurora(
            global::ElevenLabs.CreatifyAuroraRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for veo-3.1-fast-generate-001
    /// </summary>
    [Serializable]
    public struct Veo3_1FastGenerate001
    {
        public Veo3_1FastGenerate001(global::ElevenLabs.Veo31FastRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Veo31FastRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.Veo3_1FastGenerate001(
            global::ElevenLabs.Veo31FastRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for veo-3.1-generate-001
    /// </summary>
    [Serializable]
    public struct Veo3_1Generate001
    {
        public Veo3_1Generate001(global::ElevenLabs.Veo31Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Veo31Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator VideoGenerationRequest.Veo3_1Generate001(
            global::ElevenLabs.Veo31Request value
        ) => new(value);
    }
}
