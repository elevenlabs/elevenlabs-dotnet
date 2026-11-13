// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Flows;

[JsonConverter(typeof(ImageGenerationRequest.JsonConverter))]
[Serializable]
public record ImageGenerationRequest
{
    internal ImageGenerationRequest(string type, object? value)
    {
        ModelId = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.BytedanceSeedream5Lite"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.BytedanceSeedream5Lite value)
    {
        ModelId = "bytedance-seedream-5-lite";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.BytedanceSeedream5Pro"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.BytedanceSeedream5Pro value)
    {
        ModelId = "bytedance-seedream-5-pro";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.Gemini2_5FlashImage"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.Gemini2_5FlashImage value)
    {
        ModelId = "gemini-2.5-flash-image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.Gemini3ProImage"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.Gemini3ProImage value)
    {
        ModelId = "gemini-3-pro-image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.Gemini3_1FlashImage"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.Gemini3_1FlashImage value)
    {
        ModelId = "gemini-3.1-flash-image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.Gemini3_1FlashLiteImage"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.Gemini3_1FlashLiteImage value)
    {
        ModelId = "gemini-3.1-flash-lite-image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.GptImage1"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.GptImage1 value)
    {
        ModelId = "gpt-image-1";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.GptImage1_5"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.GptImage1_5 value)
    {
        ModelId = "gpt-image-1.5";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.GptImage2"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.GptImage2 value)
    {
        ModelId = "gpt-image-2";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.GptImage2_5Flare"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.GptImage2_5Flare value)
    {
        ModelId = "gpt-image-2.5-flare";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageGenerationRequest with <see cref="ImageGenerationRequest.GptImage2_5Sunburst"/>.
    /// </summary>
    public ImageGenerationRequest(ImageGenerationRequest.GptImage2_5Sunburst value)
    {
        ModelId = "gpt-image-2.5-sunburst";
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
    /// Returns true if <see cref="ModelId"/> is "bytedance-seedream-5-lite"
    /// </summary>
    public bool IsBytedanceSeedream5Lite => ModelId == "bytedance-seedream-5-lite";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "bytedance-seedream-5-pro"
    /// </summary>
    public bool IsBytedanceSeedream5Pro => ModelId == "bytedance-seedream-5-pro";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gemini-2.5-flash-image"
    /// </summary>
    public bool IsGemini2_5FlashImage => ModelId == "gemini-2.5-flash-image";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gemini-3-pro-image"
    /// </summary>
    public bool IsGemini3ProImage => ModelId == "gemini-3-pro-image";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gemini-3.1-flash-image"
    /// </summary>
    public bool IsGemini3_1FlashImage => ModelId == "gemini-3.1-flash-image";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gemini-3.1-flash-lite-image"
    /// </summary>
    public bool IsGemini3_1FlashLiteImage => ModelId == "gemini-3.1-flash-lite-image";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gpt-image-1"
    /// </summary>
    public bool IsGptImage1 => ModelId == "gpt-image-1";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gpt-image-1.5"
    /// </summary>
    public bool IsGptImage1_5 => ModelId == "gpt-image-1.5";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gpt-image-2"
    /// </summary>
    public bool IsGptImage2 => ModelId == "gpt-image-2";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gpt-image-2.5-flare"
    /// </summary>
    public bool IsGptImage2_5Flare => ModelId == "gpt-image-2.5-flare";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "gpt-image-2.5-sunburst"
    /// </summary>
    public bool IsGptImage2_5Sunburst => ModelId == "gpt-image-2.5-sunburst";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BytedanceSeedream5LiteRequest"/> if <see cref="ModelId"/> is 'bytedance-seedream-5-lite', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'bytedance-seedream-5-lite'.</exception>
    public global::ElevenLabs.BytedanceSeedream5LiteRequest AsBytedanceSeedream5Lite() =>
        IsBytedanceSeedream5Lite
            ? (global::ElevenLabs.BytedanceSeedream5LiteRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'bytedance-seedream-5-lite'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.BytedanceSeedream5ProRequest"/> if <see cref="ModelId"/> is 'bytedance-seedream-5-pro', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'bytedance-seedream-5-pro'.</exception>
    public global::ElevenLabs.BytedanceSeedream5ProRequest AsBytedanceSeedream5Pro() =>
        IsBytedanceSeedream5Pro
            ? (global::ElevenLabs.BytedanceSeedream5ProRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'bytedance-seedream-5-pro'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Gemini25FlashImageRequest"/> if <see cref="ModelId"/> is 'gemini-2.5-flash-image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gemini-2.5-flash-image'.</exception>
    public global::ElevenLabs.Gemini25FlashImageRequest AsGemini2_5FlashImage() =>
        IsGemini2_5FlashImage
            ? (global::ElevenLabs.Gemini25FlashImageRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gemini-2.5-flash-image'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Gemini3ProImageRequest"/> if <see cref="ModelId"/> is 'gemini-3-pro-image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gemini-3-pro-image'.</exception>
    public global::ElevenLabs.Gemini3ProImageRequest AsGemini3ProImage() =>
        IsGemini3ProImage
            ? (global::ElevenLabs.Gemini3ProImageRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gemini-3-pro-image'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Gemini31FlashImageRequest"/> if <see cref="ModelId"/> is 'gemini-3.1-flash-image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gemini-3.1-flash-image'.</exception>
    public global::ElevenLabs.Gemini31FlashImageRequest AsGemini3_1FlashImage() =>
        IsGemini3_1FlashImage
            ? (global::ElevenLabs.Gemini31FlashImageRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gemini-3.1-flash-image'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.Gemini31FlashLiteImageRequest"/> if <see cref="ModelId"/> is 'gemini-3.1-flash-lite-image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gemini-3.1-flash-lite-image'.</exception>
    public global::ElevenLabs.Gemini31FlashLiteImageRequest AsGemini3_1FlashLiteImage() =>
        IsGemini3_1FlashLiteImage
            ? (global::ElevenLabs.Gemini31FlashLiteImageRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gemini-3.1-flash-lite-image'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GptImage1Request"/> if <see cref="ModelId"/> is 'gpt-image-1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gpt-image-1'.</exception>
    public global::ElevenLabs.GptImage1Request AsGptImage1() =>
        IsGptImage1
            ? (global::ElevenLabs.GptImage1Request)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gpt-image-1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GptImage15Request"/> if <see cref="ModelId"/> is 'gpt-image-1.5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gpt-image-1.5'.</exception>
    public global::ElevenLabs.GptImage15Request AsGptImage1_5() =>
        IsGptImage1_5
            ? (global::ElevenLabs.GptImage15Request)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gpt-image-1.5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GptImage2Request"/> if <see cref="ModelId"/> is 'gpt-image-2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gpt-image-2'.</exception>
    public global::ElevenLabs.GptImage2Request AsGptImage2() =>
        IsGptImage2
            ? (global::ElevenLabs.GptImage2Request)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gpt-image-2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GptImage25FlareRequest"/> if <see cref="ModelId"/> is 'gpt-image-2.5-flare', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gpt-image-2.5-flare'.</exception>
    public global::ElevenLabs.GptImage25FlareRequest AsGptImage2_5Flare() =>
        IsGptImage2_5Flare
            ? (global::ElevenLabs.GptImage25FlareRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gpt-image-2.5-flare'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GptImage25SunburstRequest"/> if <see cref="ModelId"/> is 'gpt-image-2.5-sunburst', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'gpt-image-2.5-sunburst'.</exception>
    public global::ElevenLabs.GptImage25SunburstRequest AsGptImage2_5Sunburst() =>
        IsGptImage2_5Sunburst
            ? (global::ElevenLabs.GptImage25SunburstRequest)Value!
            : throw new global::System.Exception(
                "ImageGenerationRequest.ModelId is not 'gpt-image-2.5-sunburst'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.BytedanceSeedream5LiteRequest, T> onBytedanceSeedream5Lite,
        Func<global::ElevenLabs.BytedanceSeedream5ProRequest, T> onBytedanceSeedream5Pro,
        Func<global::ElevenLabs.Gemini25FlashImageRequest, T> onGemini2_5FlashImage,
        Func<global::ElevenLabs.Gemini3ProImageRequest, T> onGemini3ProImage,
        Func<global::ElevenLabs.Gemini31FlashImageRequest, T> onGemini3_1FlashImage,
        Func<global::ElevenLabs.Gemini31FlashLiteImageRequest, T> onGemini3_1FlashLiteImage,
        Func<global::ElevenLabs.GptImage1Request, T> onGptImage1,
        Func<global::ElevenLabs.GptImage15Request, T> onGptImage1_5,
        Func<global::ElevenLabs.GptImage2Request, T> onGptImage2,
        Func<global::ElevenLabs.GptImage25FlareRequest, T> onGptImage2_5Flare,
        Func<global::ElevenLabs.GptImage25SunburstRequest, T> onGptImage2_5Sunburst,
        Func<string, object?, T> onUnknown_
    )
    {
        return ModelId switch
        {
            "bytedance-seedream-5-lite" => onBytedanceSeedream5Lite(AsBytedanceSeedream5Lite()),
            "bytedance-seedream-5-pro" => onBytedanceSeedream5Pro(AsBytedanceSeedream5Pro()),
            "gemini-2.5-flash-image" => onGemini2_5FlashImage(AsGemini2_5FlashImage()),
            "gemini-3-pro-image" => onGemini3ProImage(AsGemini3ProImage()),
            "gemini-3.1-flash-image" => onGemini3_1FlashImage(AsGemini3_1FlashImage()),
            "gemini-3.1-flash-lite-image" => onGemini3_1FlashLiteImage(AsGemini3_1FlashLiteImage()),
            "gpt-image-1" => onGptImage1(AsGptImage1()),
            "gpt-image-1.5" => onGptImage1_5(AsGptImage1_5()),
            "gpt-image-2" => onGptImage2(AsGptImage2()),
            "gpt-image-2.5-flare" => onGptImage2_5Flare(AsGptImage2_5Flare()),
            "gpt-image-2.5-sunburst" => onGptImage2_5Sunburst(AsGptImage2_5Sunburst()),
            _ => onUnknown_(ModelId, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.BytedanceSeedream5LiteRequest> onBytedanceSeedream5Lite,
        Action<global::ElevenLabs.BytedanceSeedream5ProRequest> onBytedanceSeedream5Pro,
        Action<global::ElevenLabs.Gemini25FlashImageRequest> onGemini2_5FlashImage,
        Action<global::ElevenLabs.Gemini3ProImageRequest> onGemini3ProImage,
        Action<global::ElevenLabs.Gemini31FlashImageRequest> onGemini3_1FlashImage,
        Action<global::ElevenLabs.Gemini31FlashLiteImageRequest> onGemini3_1FlashLiteImage,
        Action<global::ElevenLabs.GptImage1Request> onGptImage1,
        Action<global::ElevenLabs.GptImage15Request> onGptImage1_5,
        Action<global::ElevenLabs.GptImage2Request> onGptImage2,
        Action<global::ElevenLabs.GptImage25FlareRequest> onGptImage2_5Flare,
        Action<global::ElevenLabs.GptImage25SunburstRequest> onGptImage2_5Sunburst,
        Action<string, object?> onUnknown_
    )
    {
        switch (ModelId)
        {
            case "bytedance-seedream-5-lite":
                onBytedanceSeedream5Lite(AsBytedanceSeedream5Lite());
                break;
            case "bytedance-seedream-5-pro":
                onBytedanceSeedream5Pro(AsBytedanceSeedream5Pro());
                break;
            case "gemini-2.5-flash-image":
                onGemini2_5FlashImage(AsGemini2_5FlashImage());
                break;
            case "gemini-3-pro-image":
                onGemini3ProImage(AsGemini3ProImage());
                break;
            case "gemini-3.1-flash-image":
                onGemini3_1FlashImage(AsGemini3_1FlashImage());
                break;
            case "gemini-3.1-flash-lite-image":
                onGemini3_1FlashLiteImage(AsGemini3_1FlashLiteImage());
                break;
            case "gpt-image-1":
                onGptImage1(AsGptImage1());
                break;
            case "gpt-image-1.5":
                onGptImage1_5(AsGptImage1_5());
                break;
            case "gpt-image-2":
                onGptImage2(AsGptImage2());
                break;
            case "gpt-image-2.5-flare":
                onGptImage2_5Flare(AsGptImage2_5Flare());
                break;
            case "gpt-image-2.5-sunburst":
                onGptImage2_5Sunburst(AsGptImage2_5Sunburst());
                break;
            default:
                onUnknown_(ModelId, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BytedanceSeedream5LiteRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsBytedanceSeedream5Lite(
        out global::ElevenLabs.BytedanceSeedream5LiteRequest? value
    )
    {
        if (ModelId == "bytedance-seedream-5-lite")
        {
            value = (global::ElevenLabs.BytedanceSeedream5LiteRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.BytedanceSeedream5ProRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsBytedanceSeedream5Pro(
        out global::ElevenLabs.BytedanceSeedream5ProRequest? value
    )
    {
        if (ModelId == "bytedance-seedream-5-pro")
        {
            value = (global::ElevenLabs.BytedanceSeedream5ProRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Gemini25FlashImageRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsGemini2_5FlashImage(out global::ElevenLabs.Gemini25FlashImageRequest? value)
    {
        if (ModelId == "gemini-2.5-flash-image")
        {
            value = (global::ElevenLabs.Gemini25FlashImageRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Gemini3ProImageRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsGemini3ProImage(out global::ElevenLabs.Gemini3ProImageRequest? value)
    {
        if (ModelId == "gemini-3-pro-image")
        {
            value = (global::ElevenLabs.Gemini3ProImageRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Gemini31FlashImageRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsGemini3_1FlashImage(out global::ElevenLabs.Gemini31FlashImageRequest? value)
    {
        if (ModelId == "gemini-3.1-flash-image")
        {
            value = (global::ElevenLabs.Gemini31FlashImageRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.Gemini31FlashLiteImageRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsGemini3_1FlashLiteImage(
        out global::ElevenLabs.Gemini31FlashLiteImageRequest? value
    )
    {
        if (ModelId == "gemini-3.1-flash-lite-image")
        {
            value = (global::ElevenLabs.Gemini31FlashLiteImageRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GptImage1Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsGptImage1(out global::ElevenLabs.GptImage1Request? value)
    {
        if (ModelId == "gpt-image-1")
        {
            value = (global::ElevenLabs.GptImage1Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GptImage15Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsGptImage1_5(out global::ElevenLabs.GptImage15Request? value)
    {
        if (ModelId == "gpt-image-1.5")
        {
            value = (global::ElevenLabs.GptImage15Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GptImage2Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsGptImage2(out global::ElevenLabs.GptImage2Request? value)
    {
        if (ModelId == "gpt-image-2")
        {
            value = (global::ElevenLabs.GptImage2Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GptImage25FlareRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsGptImage2_5Flare(out global::ElevenLabs.GptImage25FlareRequest? value)
    {
        if (ModelId == "gpt-image-2.5-flare")
        {
            value = (global::ElevenLabs.GptImage25FlareRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GptImage25SunburstRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsGptImage2_5Sunburst(out global::ElevenLabs.GptImage25SunburstRequest? value)
    {
        if (ModelId == "gpt-image-2.5-sunburst")
        {
            value = (global::ElevenLabs.GptImage25SunburstRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.BytedanceSeedream5Lite value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.BytedanceSeedream5Pro value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.Gemini2_5FlashImage value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.Gemini3ProImage value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.Gemini3_1FlashImage value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.Gemini3_1FlashLiteImage value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.GptImage1 value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.GptImage1_5 value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.GptImage2 value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.GptImage2_5Flare value
    ) => new(value);

    public static implicit operator ImageGenerationRequest(
        ImageGenerationRequest.GptImage2_5Sunburst value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ImageGenerationRequest>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ImageGenerationRequest).IsAssignableFrom(typeToConvert);

        public override ImageGenerationRequest Read(
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
                "bytedance-seedream-5-lite" =>
                    json.Deserialize<global::ElevenLabs.BytedanceSeedream5LiteRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.BytedanceSeedream5LiteRequest"
                        ),
                "bytedance-seedream-5-pro" =>
                    json.Deserialize<global::ElevenLabs.BytedanceSeedream5ProRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.BytedanceSeedream5ProRequest"
                        ),
                "gemini-2.5-flash-image" =>
                    json.Deserialize<global::ElevenLabs.Gemini25FlashImageRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.Gemini25FlashImageRequest"
                        ),
                "gemini-3-pro-image" =>
                    json.Deserialize<global::ElevenLabs.Gemini3ProImageRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.Gemini3ProImageRequest"
                        ),
                "gemini-3.1-flash-image" =>
                    json.Deserialize<global::ElevenLabs.Gemini31FlashImageRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.Gemini31FlashImageRequest"
                        ),
                "gemini-3.1-flash-lite-image" =>
                    json.Deserialize<global::ElevenLabs.Gemini31FlashLiteImageRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.Gemini31FlashLiteImageRequest"
                        ),
                "gpt-image-1" => json.Deserialize<global::ElevenLabs.GptImage1Request?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GptImage1Request"
                    ),
                "gpt-image-1.5" => json.Deserialize<global::ElevenLabs.GptImage15Request?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GptImage15Request"
                    ),
                "gpt-image-2" => json.Deserialize<global::ElevenLabs.GptImage2Request?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GptImage2Request"
                    ),
                "gpt-image-2.5-flare" =>
                    json.Deserialize<global::ElevenLabs.GptImage25FlareRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GptImage25FlareRequest"
                        ),
                "gpt-image-2.5-sunburst" =>
                    json.Deserialize<global::ElevenLabs.GptImage25SunburstRequest?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GptImage25SunburstRequest"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ImageGenerationRequest(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImageGenerationRequest value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.ModelId switch
                {
                    "bytedance-seedream-5-lite" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "bytedance-seedream-5-pro" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "gemini-2.5-flash-image" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "gemini-3-pro-image" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gemini-3.1-flash-image" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "gemini-3.1-flash-lite-image" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "gpt-image-1" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gpt-image-1.5" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gpt-image-2" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gpt-image-2.5-flare" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gpt-image-2.5-sunburst" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["model_id"] = value.ModelId;
            json.WriteTo(writer, options);
        }

        public override ImageGenerationRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ImageGenerationRequest(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImageGenerationRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.ModelId);
        }
    }

    /// <summary>
    /// Discriminated union type for bytedance-seedream-5-lite
    /// </summary>
    [Serializable]
    public struct BytedanceSeedream5Lite
    {
        public BytedanceSeedream5Lite(global::ElevenLabs.BytedanceSeedream5LiteRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BytedanceSeedream5LiteRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.BytedanceSeedream5Lite(
            global::ElevenLabs.BytedanceSeedream5LiteRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bytedance-seedream-5-pro
    /// </summary>
    [Serializable]
    public struct BytedanceSeedream5Pro
    {
        public BytedanceSeedream5Pro(global::ElevenLabs.BytedanceSeedream5ProRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.BytedanceSeedream5ProRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.BytedanceSeedream5Pro(
            global::ElevenLabs.BytedanceSeedream5ProRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gemini-2.5-flash-image
    /// </summary>
    [Serializable]
    public struct Gemini2_5FlashImage
    {
        public Gemini2_5FlashImage(global::ElevenLabs.Gemini25FlashImageRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Gemini25FlashImageRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.Gemini2_5FlashImage(
            global::ElevenLabs.Gemini25FlashImageRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gemini-3-pro-image
    /// </summary>
    [Serializable]
    public struct Gemini3ProImage
    {
        public Gemini3ProImage(global::ElevenLabs.Gemini3ProImageRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Gemini3ProImageRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.Gemini3ProImage(
            global::ElevenLabs.Gemini3ProImageRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gemini-3.1-flash-image
    /// </summary>
    [Serializable]
    public struct Gemini3_1FlashImage
    {
        public Gemini3_1FlashImage(global::ElevenLabs.Gemini31FlashImageRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Gemini31FlashImageRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.Gemini3_1FlashImage(
            global::ElevenLabs.Gemini31FlashImageRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gemini-3.1-flash-lite-image
    /// </summary>
    [Serializable]
    public struct Gemini3_1FlashLiteImage
    {
        public Gemini3_1FlashLiteImage(global::ElevenLabs.Gemini31FlashLiteImageRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.Gemini31FlashLiteImageRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.Gemini3_1FlashLiteImage(
            global::ElevenLabs.Gemini31FlashLiteImageRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gpt-image-1
    /// </summary>
    [Serializable]
    public struct GptImage1
    {
        public GptImage1(global::ElevenLabs.GptImage1Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GptImage1Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.GptImage1(
            global::ElevenLabs.GptImage1Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gpt-image-1.5
    /// </summary>
    [Serializable]
    public struct GptImage1_5
    {
        public GptImage1_5(global::ElevenLabs.GptImage15Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GptImage15Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.GptImage1_5(
            global::ElevenLabs.GptImage15Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gpt-image-2
    /// </summary>
    [Serializable]
    public struct GptImage2
    {
        public GptImage2(global::ElevenLabs.GptImage2Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GptImage2Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.GptImage2(
            global::ElevenLabs.GptImage2Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gpt-image-2.5-flare
    /// </summary>
    [Serializable]
    public struct GptImage2_5Flare
    {
        public GptImage2_5Flare(global::ElevenLabs.GptImage25FlareRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GptImage25FlareRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.GptImage2_5Flare(
            global::ElevenLabs.GptImage25FlareRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gpt-image-2.5-sunburst
    /// </summary>
    [Serializable]
    public struct GptImage2_5Sunburst
    {
        public GptImage2_5Sunburst(global::ElevenLabs.GptImage25SunburstRequest value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GptImage25SunburstRequest Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageGenerationRequest.GptImage2_5Sunburst(
            global::ElevenLabs.GptImage25SunburstRequest value
        ) => new(value);
    }
}
