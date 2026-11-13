// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SystemToolConfigInputParams.JsonConverter))]
[Serializable]
public record SystemToolConfigInputParams
{
    internal SystemToolConfigInputParams(string type, object? value)
    {
        SystemToolType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.EndCall"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.EndCall value)
    {
        SystemToolType = "end_call";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.EndProcedure"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.EndProcedure value)
    {
        SystemToolType = "end_procedure";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.KnowledgeBase"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.KnowledgeBase value)
    {
        SystemToolType = "knowledge_base";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.KnowledgeBaseRag"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.KnowledgeBaseRag value)
    {
        SystemToolType = "knowledge_base_rag";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.LanguageDetection"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.LanguageDetection value)
    {
        SystemToolType = "language_detection";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.PlayKeypadTouchTone"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.PlayKeypadTouchTone value)
    {
        SystemToolType = "play_keypad_touch_tone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.SkipTurn"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.SkipTurn value)
    {
        SystemToolType = "skip_turn";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.StartProcedure"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.StartProcedure value)
    {
        SystemToolType = "start_procedure";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.TransferToAgent"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.TransferToAgent value)
    {
        SystemToolType = "transfer_to_agent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.TransferToNumber"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.TransferToNumber value)
    {
        SystemToolType = "transfer_to_number";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SystemToolConfigInputParams with <see cref="SystemToolConfigInputParams.VoicemailDetection"/>.
    /// </summary>
    public SystemToolConfigInputParams(SystemToolConfigInputParams.VoicemailDetection value)
    {
        SystemToolType = "voicemail_detection";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("system_tool_type")]
    public string SystemToolType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "end_call"
    /// </summary>
    public bool IsEndCall => SystemToolType == "end_call";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "end_procedure"
    /// </summary>
    public bool IsEndProcedure => SystemToolType == "end_procedure";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "knowledge_base"
    /// </summary>
    public bool IsKnowledgeBase => SystemToolType == "knowledge_base";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "knowledge_base_rag"
    /// </summary>
    public bool IsKnowledgeBaseRag => SystemToolType == "knowledge_base_rag";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "language_detection"
    /// </summary>
    public bool IsLanguageDetection => SystemToolType == "language_detection";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "play_keypad_touch_tone"
    /// </summary>
    public bool IsPlayKeypadTouchTone => SystemToolType == "play_keypad_touch_tone";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "skip_turn"
    /// </summary>
    public bool IsSkipTurn => SystemToolType == "skip_turn";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "start_procedure"
    /// </summary>
    public bool IsStartProcedure => SystemToolType == "start_procedure";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "transfer_to_agent"
    /// </summary>
    public bool IsTransferToAgent => SystemToolType == "transfer_to_agent";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "transfer_to_number"
    /// </summary>
    public bool IsTransferToNumber => SystemToolType == "transfer_to_number";

    /// <summary>
    /// Returns true if <see cref="SystemToolType"/> is "voicemail_detection"
    /// </summary>
    public bool IsVoicemailDetection => SystemToolType == "voicemail_detection";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EndCallToolConfig"/> if <see cref="SystemToolType"/> is 'end_call', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'end_call'.</exception>
    public global::ElevenLabs.EndCallToolConfig AsEndCall() =>
        IsEndCall
            ? (global::ElevenLabs.EndCallToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'end_call'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EndProcedureToolConfig"/> if <see cref="SystemToolType"/> is 'end_procedure', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'end_procedure'.</exception>
    public global::ElevenLabs.EndProcedureToolConfig AsEndProcedure() =>
        IsEndProcedure
            ? (global::ElevenLabs.EndProcedureToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'end_procedure'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.KnowledgeBaseToolConfig"/> if <see cref="SystemToolType"/> is 'knowledge_base', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'knowledge_base'.</exception>
    public global::ElevenLabs.KnowledgeBaseToolConfig AsKnowledgeBase() =>
        IsKnowledgeBase
            ? (global::ElevenLabs.KnowledgeBaseToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'knowledge_base'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.KnowledgeBaseRagToolConfig"/> if <see cref="SystemToolType"/> is 'knowledge_base_rag', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'knowledge_base_rag'.</exception>
    public global::ElevenLabs.KnowledgeBaseRagToolConfig AsKnowledgeBaseRag() =>
        IsKnowledgeBaseRag
            ? (global::ElevenLabs.KnowledgeBaseRagToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'knowledge_base_rag'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.LanguageDetectionToolConfig"/> if <see cref="SystemToolType"/> is 'language_detection', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'language_detection'.</exception>
    public global::ElevenLabs.LanguageDetectionToolConfig AsLanguageDetection() =>
        IsLanguageDetection
            ? (global::ElevenLabs.LanguageDetectionToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'language_detection'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PlayDtmfToolConfig"/> if <see cref="SystemToolType"/> is 'play_keypad_touch_tone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'play_keypad_touch_tone'.</exception>
    public global::ElevenLabs.PlayDtmfToolConfig AsPlayKeypadTouchTone() =>
        IsPlayKeypadTouchTone
            ? (global::ElevenLabs.PlayDtmfToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'play_keypad_touch_tone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SkipTurnToolConfig"/> if <see cref="SystemToolType"/> is 'skip_turn', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'skip_turn'.</exception>
    public global::ElevenLabs.SkipTurnToolConfig AsSkipTurn() =>
        IsSkipTurn
            ? (global::ElevenLabs.SkipTurnToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'skip_turn'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StartProcedureToolConfig"/> if <see cref="SystemToolType"/> is 'start_procedure', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'start_procedure'.</exception>
    public global::ElevenLabs.StartProcedureToolConfig AsStartProcedure() =>
        IsStartProcedure
            ? (global::ElevenLabs.StartProcedureToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'start_procedure'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToAgentToolConfigInput"/> if <see cref="SystemToolType"/> is 'transfer_to_agent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'transfer_to_agent'.</exception>
    public global::ElevenLabs.TransferToAgentToolConfigInput AsTransferToAgent() =>
        IsTransferToAgent
            ? (global::ElevenLabs.TransferToAgentToolConfigInput)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'transfer_to_agent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToNumberToolConfigInput"/> if <see cref="SystemToolType"/> is 'transfer_to_number', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'transfer_to_number'.</exception>
    public global::ElevenLabs.TransferToNumberToolConfigInput AsTransferToNumber() =>
        IsTransferToNumber
            ? (global::ElevenLabs.TransferToNumberToolConfigInput)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'transfer_to_number'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.VoicemailDetectionToolConfig"/> if <see cref="SystemToolType"/> is 'voicemail_detection', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SystemToolType"/> is not 'voicemail_detection'.</exception>
    public global::ElevenLabs.VoicemailDetectionToolConfig AsVoicemailDetection() =>
        IsVoicemailDetection
            ? (global::ElevenLabs.VoicemailDetectionToolConfig)Value!
            : throw new global::System.Exception(
                "SystemToolConfigInputParams.SystemToolType is not 'voicemail_detection'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.EndCallToolConfig, T> onEndCall,
        Func<global::ElevenLabs.EndProcedureToolConfig, T> onEndProcedure,
        Func<global::ElevenLabs.KnowledgeBaseToolConfig, T> onKnowledgeBase,
        Func<global::ElevenLabs.KnowledgeBaseRagToolConfig, T> onKnowledgeBaseRag,
        Func<global::ElevenLabs.LanguageDetectionToolConfig, T> onLanguageDetection,
        Func<global::ElevenLabs.PlayDtmfToolConfig, T> onPlayKeypadTouchTone,
        Func<global::ElevenLabs.SkipTurnToolConfig, T> onSkipTurn,
        Func<global::ElevenLabs.StartProcedureToolConfig, T> onStartProcedure,
        Func<global::ElevenLabs.TransferToAgentToolConfigInput, T> onTransferToAgent,
        Func<global::ElevenLabs.TransferToNumberToolConfigInput, T> onTransferToNumber,
        Func<global::ElevenLabs.VoicemailDetectionToolConfig, T> onVoicemailDetection,
        Func<string, object?, T> onUnknown_
    )
    {
        return SystemToolType switch
        {
            "end_call" => onEndCall(AsEndCall()),
            "end_procedure" => onEndProcedure(AsEndProcedure()),
            "knowledge_base" => onKnowledgeBase(AsKnowledgeBase()),
            "knowledge_base_rag" => onKnowledgeBaseRag(AsKnowledgeBaseRag()),
            "language_detection" => onLanguageDetection(AsLanguageDetection()),
            "play_keypad_touch_tone" => onPlayKeypadTouchTone(AsPlayKeypadTouchTone()),
            "skip_turn" => onSkipTurn(AsSkipTurn()),
            "start_procedure" => onStartProcedure(AsStartProcedure()),
            "transfer_to_agent" => onTransferToAgent(AsTransferToAgent()),
            "transfer_to_number" => onTransferToNumber(AsTransferToNumber()),
            "voicemail_detection" => onVoicemailDetection(AsVoicemailDetection()),
            _ => onUnknown_(SystemToolType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.EndCallToolConfig> onEndCall,
        Action<global::ElevenLabs.EndProcedureToolConfig> onEndProcedure,
        Action<global::ElevenLabs.KnowledgeBaseToolConfig> onKnowledgeBase,
        Action<global::ElevenLabs.KnowledgeBaseRagToolConfig> onKnowledgeBaseRag,
        Action<global::ElevenLabs.LanguageDetectionToolConfig> onLanguageDetection,
        Action<global::ElevenLabs.PlayDtmfToolConfig> onPlayKeypadTouchTone,
        Action<global::ElevenLabs.SkipTurnToolConfig> onSkipTurn,
        Action<global::ElevenLabs.StartProcedureToolConfig> onStartProcedure,
        Action<global::ElevenLabs.TransferToAgentToolConfigInput> onTransferToAgent,
        Action<global::ElevenLabs.TransferToNumberToolConfigInput> onTransferToNumber,
        Action<global::ElevenLabs.VoicemailDetectionToolConfig> onVoicemailDetection,
        Action<string, object?> onUnknown_
    )
    {
        switch (SystemToolType)
        {
            case "end_call":
                onEndCall(AsEndCall());
                break;
            case "end_procedure":
                onEndProcedure(AsEndProcedure());
                break;
            case "knowledge_base":
                onKnowledgeBase(AsKnowledgeBase());
                break;
            case "knowledge_base_rag":
                onKnowledgeBaseRag(AsKnowledgeBaseRag());
                break;
            case "language_detection":
                onLanguageDetection(AsLanguageDetection());
                break;
            case "play_keypad_touch_tone":
                onPlayKeypadTouchTone(AsPlayKeypadTouchTone());
                break;
            case "skip_turn":
                onSkipTurn(AsSkipTurn());
                break;
            case "start_procedure":
                onStartProcedure(AsStartProcedure());
                break;
            case "transfer_to_agent":
                onTransferToAgent(AsTransferToAgent());
                break;
            case "transfer_to_number":
                onTransferToNumber(AsTransferToNumber());
                break;
            case "voicemail_detection":
                onVoicemailDetection(AsVoicemailDetection());
                break;
            default:
                onUnknown_(SystemToolType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EndCallToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndCall(out global::ElevenLabs.EndCallToolConfig? value)
    {
        if (SystemToolType == "end_call")
        {
            value = (global::ElevenLabs.EndCallToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EndProcedureToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndProcedure(out global::ElevenLabs.EndProcedureToolConfig? value)
    {
        if (SystemToolType == "end_procedure")
        {
            value = (global::ElevenLabs.EndProcedureToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.KnowledgeBaseToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsKnowledgeBase(out global::ElevenLabs.KnowledgeBaseToolConfig? value)
    {
        if (SystemToolType == "knowledge_base")
        {
            value = (global::ElevenLabs.KnowledgeBaseToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.KnowledgeBaseRagToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsKnowledgeBaseRag(out global::ElevenLabs.KnowledgeBaseRagToolConfig? value)
    {
        if (SystemToolType == "knowledge_base_rag")
        {
            value = (global::ElevenLabs.KnowledgeBaseRagToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.LanguageDetectionToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsLanguageDetection(out global::ElevenLabs.LanguageDetectionToolConfig? value)
    {
        if (SystemToolType == "language_detection")
        {
            value = (global::ElevenLabs.LanguageDetectionToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PlayDtmfToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlayKeypadTouchTone(out global::ElevenLabs.PlayDtmfToolConfig? value)
    {
        if (SystemToolType == "play_keypad_touch_tone")
        {
            value = (global::ElevenLabs.PlayDtmfToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SkipTurnToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsSkipTurn(out global::ElevenLabs.SkipTurnToolConfig? value)
    {
        if (SystemToolType == "skip_turn")
        {
            value = (global::ElevenLabs.SkipTurnToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.StartProcedureToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsStartProcedure(out global::ElevenLabs.StartProcedureToolConfig? value)
    {
        if (SystemToolType == "start_procedure")
        {
            value = (global::ElevenLabs.StartProcedureToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToAgentToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToAgent(out global::ElevenLabs.TransferToAgentToolConfigInput? value)
    {
        if (SystemToolType == "transfer_to_agent")
        {
            value = (global::ElevenLabs.TransferToAgentToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToNumberToolConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToNumber(out global::ElevenLabs.TransferToNumberToolConfigInput? value)
    {
        if (SystemToolType == "transfer_to_number")
        {
            value = (global::ElevenLabs.TransferToNumberToolConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.VoicemailDetectionToolConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsVoicemailDetection(out global::ElevenLabs.VoicemailDetectionToolConfig? value)
    {
        if (SystemToolType == "voicemail_detection")
        {
            value = (global::ElevenLabs.VoicemailDetectionToolConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.EndCall value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.EndProcedure value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.KnowledgeBase value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.KnowledgeBaseRag value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.LanguageDetection value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.PlayKeypadTouchTone value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.SkipTurn value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.StartProcedure value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.TransferToAgent value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.TransferToNumber value
    ) => new(value);

    public static implicit operator SystemToolConfigInputParams(
        SystemToolConfigInputParams.VoicemailDetection value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SystemToolConfigInputParams>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SystemToolConfigInputParams).IsAssignableFrom(typeToConvert);

        public override SystemToolConfigInputParams Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("system_tool_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'system_tool_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'system_tool_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'system_tool_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'system_tool_type' is null");

            var value = discriminator switch
            {
                "end_call" => json.Deserialize<global::ElevenLabs.EndCallToolConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.EndCallToolConfig"
                    ),
                "end_procedure" => json.Deserialize<global::ElevenLabs.EndProcedureToolConfig?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.EndProcedureToolConfig"
                    ),
                "knowledge_base" => json.Deserialize<global::ElevenLabs.KnowledgeBaseToolConfig?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.KnowledgeBaseToolConfig"
                    ),
                "knowledge_base_rag" =>
                    json.Deserialize<global::ElevenLabs.KnowledgeBaseRagToolConfig?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.KnowledgeBaseRagToolConfig"
                        ),
                "language_detection" =>
                    json.Deserialize<global::ElevenLabs.LanguageDetectionToolConfig?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.LanguageDetectionToolConfig"
                        ),
                "play_keypad_touch_tone" =>
                    json.Deserialize<global::ElevenLabs.PlayDtmfToolConfig?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PlayDtmfToolConfig"
                        ),
                "skip_turn" => json.Deserialize<global::ElevenLabs.SkipTurnToolConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SkipTurnToolConfig"
                    ),
                "start_procedure" => json.Deserialize<global::ElevenLabs.StartProcedureToolConfig?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.StartProcedureToolConfig"
                    ),
                "transfer_to_agent" =>
                    json.Deserialize<global::ElevenLabs.TransferToAgentToolConfigInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToAgentToolConfigInput"
                        ),
                "transfer_to_number" =>
                    json.Deserialize<global::ElevenLabs.TransferToNumberToolConfigInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToNumberToolConfigInput"
                        ),
                "voicemail_detection" =>
                    json.Deserialize<global::ElevenLabs.VoicemailDetectionToolConfig?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.VoicemailDetectionToolConfig"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SystemToolConfigInputParams(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SystemToolConfigInputParams value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.SystemToolType switch
                {
                    "end_call" => JsonSerializer.SerializeToNode(value.Value, options),
                    "end_procedure" => JsonSerializer.SerializeToNode(value.Value, options),
                    "knowledge_base" => JsonSerializer.SerializeToNode(value.Value, options),
                    "knowledge_base_rag" => JsonSerializer.SerializeToNode(value.Value, options),
                    "language_detection" => JsonSerializer.SerializeToNode(value.Value, options),
                    "play_keypad_touch_tone" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "skip_turn" => JsonSerializer.SerializeToNode(value.Value, options),
                    "start_procedure" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transfer_to_agent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transfer_to_number" => JsonSerializer.SerializeToNode(value.Value, options),
                    "voicemail_detection" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["system_tool_type"] = value.SystemToolType;
            json.WriteTo(writer, options);
        }

        public override SystemToolConfigInputParams ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SystemToolConfigInputParams(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SystemToolConfigInputParams value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.SystemToolType);
        }
    }

    /// <summary>
    /// Discriminated union type for end_call
    /// </summary>
    [Serializable]
    public struct EndCall
    {
        public EndCall(global::ElevenLabs.EndCallToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EndCallToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.EndCall(
            global::ElevenLabs.EndCallToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end_procedure
    /// </summary>
    [Serializable]
    public struct EndProcedure
    {
        public EndProcedure(global::ElevenLabs.EndProcedureToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EndProcedureToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.EndProcedure(
            global::ElevenLabs.EndProcedureToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for knowledge_base
    /// </summary>
    [Serializable]
    public struct KnowledgeBase
    {
        public KnowledgeBase(global::ElevenLabs.KnowledgeBaseToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.KnowledgeBaseToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.KnowledgeBase(
            global::ElevenLabs.KnowledgeBaseToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for knowledge_base_rag
    /// </summary>
    [Serializable]
    public struct KnowledgeBaseRag
    {
        public KnowledgeBaseRag(global::ElevenLabs.KnowledgeBaseRagToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.KnowledgeBaseRagToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.KnowledgeBaseRag(
            global::ElevenLabs.KnowledgeBaseRagToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for language_detection
    /// </summary>
    [Serializable]
    public struct LanguageDetection
    {
        public LanguageDetection(global::ElevenLabs.LanguageDetectionToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.LanguageDetectionToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.LanguageDetection(
            global::ElevenLabs.LanguageDetectionToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for play_keypad_touch_tone
    /// </summary>
    [Serializable]
    public struct PlayKeypadTouchTone
    {
        public PlayKeypadTouchTone(global::ElevenLabs.PlayDtmfToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PlayDtmfToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.PlayKeypadTouchTone(
            global::ElevenLabs.PlayDtmfToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for skip_turn
    /// </summary>
    [Serializable]
    public struct SkipTurn
    {
        public SkipTurn(global::ElevenLabs.SkipTurnToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SkipTurnToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.SkipTurn(
            global::ElevenLabs.SkipTurnToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for start_procedure
    /// </summary>
    [Serializable]
    public struct StartProcedure
    {
        public StartProcedure(global::ElevenLabs.StartProcedureToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.StartProcedureToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.StartProcedure(
            global::ElevenLabs.StartProcedureToolConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_agent
    /// </summary>
    [Serializable]
    public struct TransferToAgent
    {
        public TransferToAgent(global::ElevenLabs.TransferToAgentToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToAgentToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.TransferToAgent(
            global::ElevenLabs.TransferToAgentToolConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_number
    /// </summary>
    [Serializable]
    public struct TransferToNumber
    {
        public TransferToNumber(global::ElevenLabs.TransferToNumberToolConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToNumberToolConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.TransferToNumber(
            global::ElevenLabs.TransferToNumberToolConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for voicemail_detection
    /// </summary>
    [Serializable]
    public struct VoicemailDetection
    {
        public VoicemailDetection(global::ElevenLabs.VoicemailDetectionToolConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.VoicemailDetectionToolConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SystemToolConfigInputParams.VoicemailDetection(
            global::ElevenLabs.VoicemailDetectionToolConfig value
        ) => new(value);
    }
}
