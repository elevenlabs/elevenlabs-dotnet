// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.JsonConverter)
)]
[Serializable]
public record ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult
{
    internal ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        string type,
        object? value
    )
    {
        ResultType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.Dummy"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.Dummy value
    )
    {
        ResultType = "dummy";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndCallSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndCallSuccess value
    )
    {
        ResultType = "end_call_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureError"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureError value
    )
    {
        ResultType = "end_procedure_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureSuccess value
    )
    {
        ResultType = "end_procedure_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseRagSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseRagSuccess value
    )
    {
        ResultType = "knowledge_base_rag_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseSuccess value
    )
    {
        ResultType = "knowledge_base_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.LanguageDetectionSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.LanguageDetectionSuccess value
    )
    {
        ResultType = "language_detection_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfError"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfError value
    )
    {
        ResultType = "play_dtmf_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfSuccess value
    )
    {
        ResultType = "play_dtmf_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.SkipTurnSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.SkipTurnSuccess value
    )
    {
        ResultType = "skip_turn_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureError"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureError value
    )
    {
        ResultType = "start_procedure_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureSuccess value
    )
    {
        ResultType = "start_procedure_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TestingToolResult"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TestingToolResult value
    )
    {
        ResultType = "testing_tool_result";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentError"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentError value
    )
    {
        ResultType = "transfer_to_agent_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentSuccess value
    )
    {
        ResultType = "transfer_to_agent_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberAmazonConnectSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberAmazonConnectSuccess value
    )
    {
        ResultType = "transfer_to_number_amazon_connect_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberError"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberError value
    )
    {
        ResultType = "transfer_to_number_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberExotelSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberExotelSuccess value
    )
    {
        ResultType = "transfer_to_number_exotel_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberSipSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberSipSuccess value
    )
    {
        ResultType = "transfer_to_number_sip_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberTwilioSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberTwilioSuccess value
    )
    {
        ResultType = "transfer_to_number_twilio_success";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult with <see cref="ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.VoicemailDetectionSuccess"/>.
    /// </summary>
    public ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.VoicemailDetectionSuccess value
    )
    {
        ResultType = "voicemail_detection_success";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("result_type")]
    public string ResultType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "dummy"
    /// </summary>
    public bool IsDummy => ResultType == "dummy";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "end_call_success"
    /// </summary>
    public bool IsEndCallSuccess => ResultType == "end_call_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "end_procedure_error"
    /// </summary>
    public bool IsEndProcedureError => ResultType == "end_procedure_error";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "end_procedure_success"
    /// </summary>
    public bool IsEndProcedureSuccess => ResultType == "end_procedure_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "knowledge_base_rag_success"
    /// </summary>
    public bool IsKnowledgeBaseRagSuccess => ResultType == "knowledge_base_rag_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "knowledge_base_success"
    /// </summary>
    public bool IsKnowledgeBaseSuccess => ResultType == "knowledge_base_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "language_detection_success"
    /// </summary>
    public bool IsLanguageDetectionSuccess => ResultType == "language_detection_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "play_dtmf_error"
    /// </summary>
    public bool IsPlayDtmfError => ResultType == "play_dtmf_error";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "play_dtmf_success"
    /// </summary>
    public bool IsPlayDtmfSuccess => ResultType == "play_dtmf_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "skip_turn_success"
    /// </summary>
    public bool IsSkipTurnSuccess => ResultType == "skip_turn_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "start_procedure_error"
    /// </summary>
    public bool IsStartProcedureError => ResultType == "start_procedure_error";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "start_procedure_success"
    /// </summary>
    public bool IsStartProcedureSuccess => ResultType == "start_procedure_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "testing_tool_result"
    /// </summary>
    public bool IsTestingToolResult => ResultType == "testing_tool_result";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_agent_error"
    /// </summary>
    public bool IsTransferToAgentError => ResultType == "transfer_to_agent_error";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_agent_success"
    /// </summary>
    public bool IsTransferToAgentSuccess => ResultType == "transfer_to_agent_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_number_amazon_connect_success"
    /// </summary>
    public bool IsTransferToNumberAmazonConnectSuccess =>
        ResultType == "transfer_to_number_amazon_connect_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_number_error"
    /// </summary>
    public bool IsTransferToNumberError => ResultType == "transfer_to_number_error";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_number_exotel_success"
    /// </summary>
    public bool IsTransferToNumberExotelSuccess =>
        ResultType == "transfer_to_number_exotel_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_number_sip_success"
    /// </summary>
    public bool IsTransferToNumberSipSuccess => ResultType == "transfer_to_number_sip_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "transfer_to_number_twilio_success"
    /// </summary>
    public bool IsTransferToNumberTwilioSuccess =>
        ResultType == "transfer_to_number_twilio_success";

    /// <summary>
    /// Returns true if <see cref="ResultType"/> is "voicemail_detection_success"
    /// </summary>
    public bool IsVoicemailDetectionSuccess => ResultType == "voicemail_detection_success";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DummyToolResultModel"/> if <see cref="ResultType"/> is 'dummy', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'dummy'.</exception>
    public global::ElevenLabs.DummyToolResultModel AsDummy() =>
        IsDummy
            ? (global::ElevenLabs.DummyToolResultModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'dummy'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EndCallToolResultModel"/> if <see cref="ResultType"/> is 'end_call_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'end_call_success'.</exception>
    public global::ElevenLabs.EndCallToolResultModel AsEndCallSuccess() =>
        IsEndCallSuccess
            ? (global::ElevenLabs.EndCallToolResultModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'end_call_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EndProcedureToolResultErrorModel"/> if <see cref="ResultType"/> is 'end_procedure_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'end_procedure_error'.</exception>
    public global::ElevenLabs.EndProcedureToolResultErrorModel AsEndProcedureError() =>
        IsEndProcedureError
            ? (global::ElevenLabs.EndProcedureToolResultErrorModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'end_procedure_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.EndProcedureToolResultSuccessModel"/> if <see cref="ResultType"/> is 'end_procedure_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'end_procedure_success'.</exception>
    public global::ElevenLabs.EndProcedureToolResultSuccessModel AsEndProcedureSuccess() =>
        IsEndProcedureSuccess
            ? (global::ElevenLabs.EndProcedureToolResultSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'end_procedure_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.KnowledgeBaseRagToolResultModel"/> if <see cref="ResultType"/> is 'knowledge_base_rag_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'knowledge_base_rag_success'.</exception>
    public global::ElevenLabs.KnowledgeBaseRagToolResultModel AsKnowledgeBaseRagSuccess() =>
        IsKnowledgeBaseRagSuccess
            ? (global::ElevenLabs.KnowledgeBaseRagToolResultModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'knowledge_base_rag_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.KnowledgeBaseToolResultModel"/> if <see cref="ResultType"/> is 'knowledge_base_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'knowledge_base_success'.</exception>
    public global::ElevenLabs.KnowledgeBaseToolResultModel AsKnowledgeBaseSuccess() =>
        IsKnowledgeBaseSuccess
            ? (global::ElevenLabs.KnowledgeBaseToolResultModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'knowledge_base_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.LanguageDetectionToolResultModel"/> if <see cref="ResultType"/> is 'language_detection_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'language_detection_success'.</exception>
    public global::ElevenLabs.LanguageDetectionToolResultModel AsLanguageDetectionSuccess() =>
        IsLanguageDetectionSuccess
            ? (global::ElevenLabs.LanguageDetectionToolResultModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'language_detection_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PlayDtmfResultErrorModel"/> if <see cref="ResultType"/> is 'play_dtmf_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'play_dtmf_error'.</exception>
    public global::ElevenLabs.PlayDtmfResultErrorModel AsPlayDtmfError() =>
        IsPlayDtmfError
            ? (global::ElevenLabs.PlayDtmfResultErrorModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'play_dtmf_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PlayDtmfResultSuccessModel"/> if <see cref="ResultType"/> is 'play_dtmf_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'play_dtmf_success'.</exception>
    public global::ElevenLabs.PlayDtmfResultSuccessModel AsPlayDtmfSuccess() =>
        IsPlayDtmfSuccess
            ? (global::ElevenLabs.PlayDtmfResultSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'play_dtmf_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SkipTurnToolResponseModel"/> if <see cref="ResultType"/> is 'skip_turn_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'skip_turn_success'.</exception>
    public global::ElevenLabs.SkipTurnToolResponseModel AsSkipTurnSuccess() =>
        IsSkipTurnSuccess
            ? (global::ElevenLabs.SkipTurnToolResponseModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'skip_turn_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StartProcedureToolResultErrorModel"/> if <see cref="ResultType"/> is 'start_procedure_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'start_procedure_error'.</exception>
    public global::ElevenLabs.StartProcedureToolResultErrorModel AsStartProcedureError() =>
        IsStartProcedureError
            ? (global::ElevenLabs.StartProcedureToolResultErrorModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'start_procedure_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StartProcedureToolResultSuccessModel"/> if <see cref="ResultType"/> is 'start_procedure_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'start_procedure_success'.</exception>
    public global::ElevenLabs.StartProcedureToolResultSuccessModel AsStartProcedureSuccess() =>
        IsStartProcedureSuccess
            ? (global::ElevenLabs.StartProcedureToolResultSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'start_procedure_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TestToolResultModel"/> if <see cref="ResultType"/> is 'testing_tool_result', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'testing_tool_result'.</exception>
    public global::ElevenLabs.TestToolResultModel AsTestingToolResult() =>
        IsTestingToolResult
            ? (global::ElevenLabs.TestToolResultModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'testing_tool_result'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToAgentToolResultErrorModel"/> if <see cref="ResultType"/> is 'transfer_to_agent_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_agent_error'.</exception>
    public global::ElevenLabs.TransferToAgentToolResultErrorModel AsTransferToAgentError() =>
        IsTransferToAgentError
            ? (global::ElevenLabs.TransferToAgentToolResultErrorModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_agent_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput"/> if <see cref="ResultType"/> is 'transfer_to_agent_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_agent_success'.</exception>
    public global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput AsTransferToAgentSuccess() =>
        IsTransferToAgentSuccess
            ? (global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_agent_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel"/> if <see cref="ResultType"/> is 'transfer_to_number_amazon_connect_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_number_amazon_connect_success'.</exception>
    public global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel AsTransferToNumberAmazonConnectSuccess() =>
        IsTransferToNumberAmazonConnectSuccess
            ? (global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_number_amazon_connect_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToNumberResultErrorModel"/> if <see cref="ResultType"/> is 'transfer_to_number_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_number_error'.</exception>
    public global::ElevenLabs.TransferToNumberResultErrorModel AsTransferToNumberError() =>
        IsTransferToNumberError
            ? (global::ElevenLabs.TransferToNumberResultErrorModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_number_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToNumberResultExotelSuccessModel"/> if <see cref="ResultType"/> is 'transfer_to_number_exotel_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_number_exotel_success'.</exception>
    public global::ElevenLabs.TransferToNumberResultExotelSuccessModel AsTransferToNumberExotelSuccess() =>
        IsTransferToNumberExotelSuccess
            ? (global::ElevenLabs.TransferToNumberResultExotelSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_number_exotel_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToNumberResultSipSuccessModel"/> if <see cref="ResultType"/> is 'transfer_to_number_sip_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_number_sip_success'.</exception>
    public global::ElevenLabs.TransferToNumberResultSipSuccessModel AsTransferToNumberSipSuccess() =>
        IsTransferToNumberSipSuccess
            ? (global::ElevenLabs.TransferToNumberResultSipSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_number_sip_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TransferToNumberResultTwilioSuccessModel"/> if <see cref="ResultType"/> is 'transfer_to_number_twilio_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'transfer_to_number_twilio_success'.</exception>
    public global::ElevenLabs.TransferToNumberResultTwilioSuccessModel AsTransferToNumberTwilioSuccess() =>
        IsTransferToNumberTwilioSuccess
            ? (global::ElevenLabs.TransferToNumberResultTwilioSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'transfer_to_number_twilio_success'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.VoiceMailDetectionResultSuccessModel"/> if <see cref="ResultType"/> is 'voicemail_detection_success', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ResultType"/> is not 'voicemail_detection_success'.</exception>
    public global::ElevenLabs.VoiceMailDetectionResultSuccessModel AsVoicemailDetectionSuccess() =>
        IsVoicemailDetectionSuccess
            ? (global::ElevenLabs.VoiceMailDetectionResultSuccessModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.ResultType is not 'voicemail_detection_success'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.DummyToolResultModel, T> onDummy,
        Func<global::ElevenLabs.EndCallToolResultModel, T> onEndCallSuccess,
        Func<global::ElevenLabs.EndProcedureToolResultErrorModel, T> onEndProcedureError,
        Func<global::ElevenLabs.EndProcedureToolResultSuccessModel, T> onEndProcedureSuccess,
        Func<global::ElevenLabs.KnowledgeBaseRagToolResultModel, T> onKnowledgeBaseRagSuccess,
        Func<global::ElevenLabs.KnowledgeBaseToolResultModel, T> onKnowledgeBaseSuccess,
        Func<global::ElevenLabs.LanguageDetectionToolResultModel, T> onLanguageDetectionSuccess,
        Func<global::ElevenLabs.PlayDtmfResultErrorModel, T> onPlayDtmfError,
        Func<global::ElevenLabs.PlayDtmfResultSuccessModel, T> onPlayDtmfSuccess,
        Func<global::ElevenLabs.SkipTurnToolResponseModel, T> onSkipTurnSuccess,
        Func<global::ElevenLabs.StartProcedureToolResultErrorModel, T> onStartProcedureError,
        Func<global::ElevenLabs.StartProcedureToolResultSuccessModel, T> onStartProcedureSuccess,
        Func<global::ElevenLabs.TestToolResultModel, T> onTestingToolResult,
        Func<global::ElevenLabs.TransferToAgentToolResultErrorModel, T> onTransferToAgentError,
        Func<
            global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput,
            T
        > onTransferToAgentSuccess,
        Func<
            global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel,
            T
        > onTransferToNumberAmazonConnectSuccess,
        Func<global::ElevenLabs.TransferToNumberResultErrorModel, T> onTransferToNumberError,
        Func<
            global::ElevenLabs.TransferToNumberResultExotelSuccessModel,
            T
        > onTransferToNumberExotelSuccess,
        Func<
            global::ElevenLabs.TransferToNumberResultSipSuccessModel,
            T
        > onTransferToNumberSipSuccess,
        Func<
            global::ElevenLabs.TransferToNumberResultTwilioSuccessModel,
            T
        > onTransferToNumberTwilioSuccess,
        Func<
            global::ElevenLabs.VoiceMailDetectionResultSuccessModel,
            T
        > onVoicemailDetectionSuccess,
        Func<string, object?, T> onUnknown_
    )
    {
        return ResultType switch
        {
            "dummy" => onDummy(AsDummy()),
            "end_call_success" => onEndCallSuccess(AsEndCallSuccess()),
            "end_procedure_error" => onEndProcedureError(AsEndProcedureError()),
            "end_procedure_success" => onEndProcedureSuccess(AsEndProcedureSuccess()),
            "knowledge_base_rag_success" => onKnowledgeBaseRagSuccess(AsKnowledgeBaseRagSuccess()),
            "knowledge_base_success" => onKnowledgeBaseSuccess(AsKnowledgeBaseSuccess()),
            "language_detection_success" => onLanguageDetectionSuccess(
                AsLanguageDetectionSuccess()
            ),
            "play_dtmf_error" => onPlayDtmfError(AsPlayDtmfError()),
            "play_dtmf_success" => onPlayDtmfSuccess(AsPlayDtmfSuccess()),
            "skip_turn_success" => onSkipTurnSuccess(AsSkipTurnSuccess()),
            "start_procedure_error" => onStartProcedureError(AsStartProcedureError()),
            "start_procedure_success" => onStartProcedureSuccess(AsStartProcedureSuccess()),
            "testing_tool_result" => onTestingToolResult(AsTestingToolResult()),
            "transfer_to_agent_error" => onTransferToAgentError(AsTransferToAgentError()),
            "transfer_to_agent_success" => onTransferToAgentSuccess(AsTransferToAgentSuccess()),
            "transfer_to_number_amazon_connect_success" => onTransferToNumberAmazonConnectSuccess(
                AsTransferToNumberAmazonConnectSuccess()
            ),
            "transfer_to_number_error" => onTransferToNumberError(AsTransferToNumberError()),
            "transfer_to_number_exotel_success" => onTransferToNumberExotelSuccess(
                AsTransferToNumberExotelSuccess()
            ),
            "transfer_to_number_sip_success" => onTransferToNumberSipSuccess(
                AsTransferToNumberSipSuccess()
            ),
            "transfer_to_number_twilio_success" => onTransferToNumberTwilioSuccess(
                AsTransferToNumberTwilioSuccess()
            ),
            "voicemail_detection_success" => onVoicemailDetectionSuccess(
                AsVoicemailDetectionSuccess()
            ),
            _ => onUnknown_(ResultType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DummyToolResultModel> onDummy,
        Action<global::ElevenLabs.EndCallToolResultModel> onEndCallSuccess,
        Action<global::ElevenLabs.EndProcedureToolResultErrorModel> onEndProcedureError,
        Action<global::ElevenLabs.EndProcedureToolResultSuccessModel> onEndProcedureSuccess,
        Action<global::ElevenLabs.KnowledgeBaseRagToolResultModel> onKnowledgeBaseRagSuccess,
        Action<global::ElevenLabs.KnowledgeBaseToolResultModel> onKnowledgeBaseSuccess,
        Action<global::ElevenLabs.LanguageDetectionToolResultModel> onLanguageDetectionSuccess,
        Action<global::ElevenLabs.PlayDtmfResultErrorModel> onPlayDtmfError,
        Action<global::ElevenLabs.PlayDtmfResultSuccessModel> onPlayDtmfSuccess,
        Action<global::ElevenLabs.SkipTurnToolResponseModel> onSkipTurnSuccess,
        Action<global::ElevenLabs.StartProcedureToolResultErrorModel> onStartProcedureError,
        Action<global::ElevenLabs.StartProcedureToolResultSuccessModel> onStartProcedureSuccess,
        Action<global::ElevenLabs.TestToolResultModel> onTestingToolResult,
        Action<global::ElevenLabs.TransferToAgentToolResultErrorModel> onTransferToAgentError,
        Action<global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput> onTransferToAgentSuccess,
        Action<global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel> onTransferToNumberAmazonConnectSuccess,
        Action<global::ElevenLabs.TransferToNumberResultErrorModel> onTransferToNumberError,
        Action<global::ElevenLabs.TransferToNumberResultExotelSuccessModel> onTransferToNumberExotelSuccess,
        Action<global::ElevenLabs.TransferToNumberResultSipSuccessModel> onTransferToNumberSipSuccess,
        Action<global::ElevenLabs.TransferToNumberResultTwilioSuccessModel> onTransferToNumberTwilioSuccess,
        Action<global::ElevenLabs.VoiceMailDetectionResultSuccessModel> onVoicemailDetectionSuccess,
        Action<string, object?> onUnknown_
    )
    {
        switch (ResultType)
        {
            case "dummy":
                onDummy(AsDummy());
                break;
            case "end_call_success":
                onEndCallSuccess(AsEndCallSuccess());
                break;
            case "end_procedure_error":
                onEndProcedureError(AsEndProcedureError());
                break;
            case "end_procedure_success":
                onEndProcedureSuccess(AsEndProcedureSuccess());
                break;
            case "knowledge_base_rag_success":
                onKnowledgeBaseRagSuccess(AsKnowledgeBaseRagSuccess());
                break;
            case "knowledge_base_success":
                onKnowledgeBaseSuccess(AsKnowledgeBaseSuccess());
                break;
            case "language_detection_success":
                onLanguageDetectionSuccess(AsLanguageDetectionSuccess());
                break;
            case "play_dtmf_error":
                onPlayDtmfError(AsPlayDtmfError());
                break;
            case "play_dtmf_success":
                onPlayDtmfSuccess(AsPlayDtmfSuccess());
                break;
            case "skip_turn_success":
                onSkipTurnSuccess(AsSkipTurnSuccess());
                break;
            case "start_procedure_error":
                onStartProcedureError(AsStartProcedureError());
                break;
            case "start_procedure_success":
                onStartProcedureSuccess(AsStartProcedureSuccess());
                break;
            case "testing_tool_result":
                onTestingToolResult(AsTestingToolResult());
                break;
            case "transfer_to_agent_error":
                onTransferToAgentError(AsTransferToAgentError());
                break;
            case "transfer_to_agent_success":
                onTransferToAgentSuccess(AsTransferToAgentSuccess());
                break;
            case "transfer_to_number_amazon_connect_success":
                onTransferToNumberAmazonConnectSuccess(AsTransferToNumberAmazonConnectSuccess());
                break;
            case "transfer_to_number_error":
                onTransferToNumberError(AsTransferToNumberError());
                break;
            case "transfer_to_number_exotel_success":
                onTransferToNumberExotelSuccess(AsTransferToNumberExotelSuccess());
                break;
            case "transfer_to_number_sip_success":
                onTransferToNumberSipSuccess(AsTransferToNumberSipSuccess());
                break;
            case "transfer_to_number_twilio_success":
                onTransferToNumberTwilioSuccess(AsTransferToNumberTwilioSuccess());
                break;
            case "voicemail_detection_success":
                onVoicemailDetectionSuccess(AsVoicemailDetectionSuccess());
                break;
            default:
                onUnknown_(ResultType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DummyToolResultModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsDummy(out global::ElevenLabs.DummyToolResultModel? value)
    {
        if (ResultType == "dummy")
        {
            value = (global::ElevenLabs.DummyToolResultModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EndCallToolResultModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndCallSuccess(out global::ElevenLabs.EndCallToolResultModel? value)
    {
        if (ResultType == "end_call_success")
        {
            value = (global::ElevenLabs.EndCallToolResultModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EndProcedureToolResultErrorModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndProcedureError(
        out global::ElevenLabs.EndProcedureToolResultErrorModel? value
    )
    {
        if (ResultType == "end_procedure_error")
        {
            value = (global::ElevenLabs.EndProcedureToolResultErrorModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.EndProcedureToolResultSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsEndProcedureSuccess(
        out global::ElevenLabs.EndProcedureToolResultSuccessModel? value
    )
    {
        if (ResultType == "end_procedure_success")
        {
            value = (global::ElevenLabs.EndProcedureToolResultSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.KnowledgeBaseRagToolResultModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsKnowledgeBaseRagSuccess(
        out global::ElevenLabs.KnowledgeBaseRagToolResultModel? value
    )
    {
        if (ResultType == "knowledge_base_rag_success")
        {
            value = (global::ElevenLabs.KnowledgeBaseRagToolResultModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.KnowledgeBaseToolResultModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsKnowledgeBaseSuccess(
        out global::ElevenLabs.KnowledgeBaseToolResultModel? value
    )
    {
        if (ResultType == "knowledge_base_success")
        {
            value = (global::ElevenLabs.KnowledgeBaseToolResultModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.LanguageDetectionToolResultModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsLanguageDetectionSuccess(
        out global::ElevenLabs.LanguageDetectionToolResultModel? value
    )
    {
        if (ResultType == "language_detection_success")
        {
            value = (global::ElevenLabs.LanguageDetectionToolResultModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PlayDtmfResultErrorModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlayDtmfError(out global::ElevenLabs.PlayDtmfResultErrorModel? value)
    {
        if (ResultType == "play_dtmf_error")
        {
            value = (global::ElevenLabs.PlayDtmfResultErrorModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PlayDtmfResultSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsPlayDtmfSuccess(out global::ElevenLabs.PlayDtmfResultSuccessModel? value)
    {
        if (ResultType == "play_dtmf_success")
        {
            value = (global::ElevenLabs.PlayDtmfResultSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SkipTurnToolResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsSkipTurnSuccess(out global::ElevenLabs.SkipTurnToolResponseModel? value)
    {
        if (ResultType == "skip_turn_success")
        {
            value = (global::ElevenLabs.SkipTurnToolResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.StartProcedureToolResultErrorModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsStartProcedureError(
        out global::ElevenLabs.StartProcedureToolResultErrorModel? value
    )
    {
        if (ResultType == "start_procedure_error")
        {
            value = (global::ElevenLabs.StartProcedureToolResultErrorModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.StartProcedureToolResultSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsStartProcedureSuccess(
        out global::ElevenLabs.StartProcedureToolResultSuccessModel? value
    )
    {
        if (ResultType == "start_procedure_success")
        {
            value = (global::ElevenLabs.StartProcedureToolResultSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TestToolResultModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTestingToolResult(out global::ElevenLabs.TestToolResultModel? value)
    {
        if (ResultType == "testing_tool_result")
        {
            value = (global::ElevenLabs.TestToolResultModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToAgentToolResultErrorModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToAgentError(
        out global::ElevenLabs.TransferToAgentToolResultErrorModel? value
    )
    {
        if (ResultType == "transfer_to_agent_error")
        {
            value = (global::ElevenLabs.TransferToAgentToolResultErrorModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToAgentSuccess(
        out global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput? value
    )
    {
        if (ResultType == "transfer_to_agent_success")
        {
            value = (global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToNumberAmazonConnectSuccess(
        out global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel? value
    )
    {
        if (ResultType == "transfer_to_number_amazon_connect_success")
        {
            value = (global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToNumberResultErrorModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToNumberError(
        out global::ElevenLabs.TransferToNumberResultErrorModel? value
    )
    {
        if (ResultType == "transfer_to_number_error")
        {
            value = (global::ElevenLabs.TransferToNumberResultErrorModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToNumberResultExotelSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToNumberExotelSuccess(
        out global::ElevenLabs.TransferToNumberResultExotelSuccessModel? value
    )
    {
        if (ResultType == "transfer_to_number_exotel_success")
        {
            value = (global::ElevenLabs.TransferToNumberResultExotelSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToNumberResultSipSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToNumberSipSuccess(
        out global::ElevenLabs.TransferToNumberResultSipSuccessModel? value
    )
    {
        if (ResultType == "transfer_to_number_sip_success")
        {
            value = (global::ElevenLabs.TransferToNumberResultSipSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TransferToNumberResultTwilioSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTransferToNumberTwilioSuccess(
        out global::ElevenLabs.TransferToNumberResultTwilioSuccessModel? value
    )
    {
        if (ResultType == "transfer_to_number_twilio_success")
        {
            value = (global::ElevenLabs.TransferToNumberResultTwilioSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.VoiceMailDetectionResultSuccessModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsVoicemailDetectionSuccess(
        out global::ElevenLabs.VoiceMailDetectionResultSuccessModel? value
    )
    {
        if (ResultType == "voicemail_detection_success")
        {
            value = (global::ElevenLabs.VoiceMailDetectionResultSuccessModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.Dummy value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndCallSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureError value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseRagSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.LanguageDetectionSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfError value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.SkipTurnSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureError value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TestingToolResult value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentError value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberAmazonConnectSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberError value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberExotelSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberSipSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberTwilioSuccess value
    ) => new(value);

    public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
        ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.VoicemailDetectionSuccess value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult).IsAssignableFrom(
                typeToConvert
            );

        public override ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("result_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'result_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'result_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'result_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'result_type' is null");

            var value = discriminator switch
            {
                "dummy" => json.Deserialize<global::ElevenLabs.DummyToolResultModel?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DummyToolResultModel"
                    ),
                "end_call_success" => json.Deserialize<global::ElevenLabs.EndCallToolResultModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.EndCallToolResultModel"
                    ),
                "end_procedure_error" =>
                    json.Deserialize<global::ElevenLabs.EndProcedureToolResultErrorModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.EndProcedureToolResultErrorModel"
                        ),
                "end_procedure_success" =>
                    json.Deserialize<global::ElevenLabs.EndProcedureToolResultSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.EndProcedureToolResultSuccessModel"
                        ),
                "knowledge_base_rag_success" =>
                    json.Deserialize<global::ElevenLabs.KnowledgeBaseRagToolResultModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.KnowledgeBaseRagToolResultModel"
                        ),
                "knowledge_base_success" =>
                    json.Deserialize<global::ElevenLabs.KnowledgeBaseToolResultModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.KnowledgeBaseToolResultModel"
                        ),
                "language_detection_success" =>
                    json.Deserialize<global::ElevenLabs.LanguageDetectionToolResultModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.LanguageDetectionToolResultModel"
                        ),
                "play_dtmf_error" => json.Deserialize<global::ElevenLabs.PlayDtmfResultErrorModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PlayDtmfResultErrorModel"
                    ),
                "play_dtmf_success" =>
                    json.Deserialize<global::ElevenLabs.PlayDtmfResultSuccessModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PlayDtmfResultSuccessModel"
                        ),
                "skip_turn_success" =>
                    json.Deserialize<global::ElevenLabs.SkipTurnToolResponseModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SkipTurnToolResponseModel"
                        ),
                "start_procedure_error" =>
                    json.Deserialize<global::ElevenLabs.StartProcedureToolResultErrorModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.StartProcedureToolResultErrorModel"
                        ),
                "start_procedure_success" =>
                    json.Deserialize<global::ElevenLabs.StartProcedureToolResultSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.StartProcedureToolResultSuccessModel"
                        ),
                "testing_tool_result" => json.Deserialize<global::ElevenLabs.TestToolResultModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TestToolResultModel"
                    ),
                "transfer_to_agent_error" =>
                    json.Deserialize<global::ElevenLabs.TransferToAgentToolResultErrorModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToAgentToolResultErrorModel"
                        ),
                "transfer_to_agent_success" =>
                    json.Deserialize<global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput"
                        ),
                "transfer_to_number_amazon_connect_success" =>
                    json.Deserialize<global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel"
                        ),
                "transfer_to_number_error" =>
                    json.Deserialize<global::ElevenLabs.TransferToNumberResultErrorModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToNumberResultErrorModel"
                        ),
                "transfer_to_number_exotel_success" =>
                    json.Deserialize<global::ElevenLabs.TransferToNumberResultExotelSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToNumberResultExotelSuccessModel"
                        ),
                "transfer_to_number_sip_success" =>
                    json.Deserialize<global::ElevenLabs.TransferToNumberResultSipSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToNumberResultSipSuccessModel"
                        ),
                "transfer_to_number_twilio_success" =>
                    json.Deserialize<global::ElevenLabs.TransferToNumberResultTwilioSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TransferToNumberResultTwilioSuccessModel"
                        ),
                "voicemail_detection_success" =>
                    json.Deserialize<global::ElevenLabs.VoiceMailDetectionResultSuccessModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.VoiceMailDetectionResultSuccessModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.ResultType switch
                {
                    "dummy" => JsonSerializer.SerializeToNode(value.Value, options),
                    "end_call_success" => JsonSerializer.SerializeToNode(value.Value, options),
                    "end_procedure_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "end_procedure_success" => JsonSerializer.SerializeToNode(value.Value, options),
                    "knowledge_base_rag_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "knowledge_base_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "language_detection_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "play_dtmf_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "play_dtmf_success" => JsonSerializer.SerializeToNode(value.Value, options),
                    "skip_turn_success" => JsonSerializer.SerializeToNode(value.Value, options),
                    "start_procedure_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "start_procedure_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "testing_tool_result" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transfer_to_agent_error" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "transfer_to_agent_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "transfer_to_number_amazon_connect_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "transfer_to_number_error" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "transfer_to_number_exotel_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "transfer_to_number_sip_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "transfer_to_number_twilio_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "voicemail_detection_success" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["result_type"] = value.ResultType;
            json.WriteTo(writer, options);
        }

        public override ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.ResultType);
        }
    }

    /// <summary>
    /// Discriminated union type for dummy
    /// </summary>
    [Serializable]
    public struct Dummy
    {
        public Dummy(global::ElevenLabs.DummyToolResultModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DummyToolResultModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.Dummy(
            global::ElevenLabs.DummyToolResultModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end_call_success
    /// </summary>
    [Serializable]
    public struct EndCallSuccess
    {
        public EndCallSuccess(global::ElevenLabs.EndCallToolResultModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EndCallToolResultModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndCallSuccess(
            global::ElevenLabs.EndCallToolResultModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end_procedure_error
    /// </summary>
    [Serializable]
    public struct EndProcedureError
    {
        public EndProcedureError(global::ElevenLabs.EndProcedureToolResultErrorModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EndProcedureToolResultErrorModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureError(
            global::ElevenLabs.EndProcedureToolResultErrorModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end_procedure_success
    /// </summary>
    [Serializable]
    public struct EndProcedureSuccess
    {
        public EndProcedureSuccess(global::ElevenLabs.EndProcedureToolResultSuccessModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.EndProcedureToolResultSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.EndProcedureSuccess(
            global::ElevenLabs.EndProcedureToolResultSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for knowledge_base_rag_success
    /// </summary>
    [Serializable]
    public struct KnowledgeBaseRagSuccess
    {
        public KnowledgeBaseRagSuccess(global::ElevenLabs.KnowledgeBaseRagToolResultModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.KnowledgeBaseRagToolResultModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseRagSuccess(
            global::ElevenLabs.KnowledgeBaseRagToolResultModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for knowledge_base_success
    /// </summary>
    [Serializable]
    public struct KnowledgeBaseSuccess
    {
        public KnowledgeBaseSuccess(global::ElevenLabs.KnowledgeBaseToolResultModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.KnowledgeBaseToolResultModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.KnowledgeBaseSuccess(
            global::ElevenLabs.KnowledgeBaseToolResultModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for language_detection_success
    /// </summary>
    [Serializable]
    public struct LanguageDetectionSuccess
    {
        public LanguageDetectionSuccess(global::ElevenLabs.LanguageDetectionToolResultModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.LanguageDetectionToolResultModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.LanguageDetectionSuccess(
            global::ElevenLabs.LanguageDetectionToolResultModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for play_dtmf_error
    /// </summary>
    [Serializable]
    public struct PlayDtmfError
    {
        public PlayDtmfError(global::ElevenLabs.PlayDtmfResultErrorModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PlayDtmfResultErrorModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfError(
            global::ElevenLabs.PlayDtmfResultErrorModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for play_dtmf_success
    /// </summary>
    [Serializable]
    public struct PlayDtmfSuccess
    {
        public PlayDtmfSuccess(global::ElevenLabs.PlayDtmfResultSuccessModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PlayDtmfResultSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.PlayDtmfSuccess(
            global::ElevenLabs.PlayDtmfResultSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for skip_turn_success
    /// </summary>
    [Serializable]
    public struct SkipTurnSuccess
    {
        public SkipTurnSuccess(global::ElevenLabs.SkipTurnToolResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SkipTurnToolResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.SkipTurnSuccess(
            global::ElevenLabs.SkipTurnToolResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for start_procedure_error
    /// </summary>
    [Serializable]
    public struct StartProcedureError
    {
        public StartProcedureError(global::ElevenLabs.StartProcedureToolResultErrorModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.StartProcedureToolResultErrorModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureError(
            global::ElevenLabs.StartProcedureToolResultErrorModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for start_procedure_success
    /// </summary>
    [Serializable]
    public struct StartProcedureSuccess
    {
        public StartProcedureSuccess(global::ElevenLabs.StartProcedureToolResultSuccessModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.StartProcedureToolResultSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.StartProcedureSuccess(
            global::ElevenLabs.StartProcedureToolResultSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for testing_tool_result
    /// </summary>
    [Serializable]
    public struct TestingToolResult
    {
        public TestingToolResult(global::ElevenLabs.TestToolResultModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TestToolResultModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TestingToolResult(
            global::ElevenLabs.TestToolResultModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_agent_error
    /// </summary>
    [Serializable]
    public struct TransferToAgentError
    {
        public TransferToAgentError(global::ElevenLabs.TransferToAgentToolResultErrorModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToAgentToolResultErrorModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentError(
            global::ElevenLabs.TransferToAgentToolResultErrorModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_agent_success
    /// </summary>
    [Serializable]
    public struct TransferToAgentSuccess
    {
        public TransferToAgentSuccess(
            global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToAgentSuccess(
            global::ElevenLabs.TransferToAgentToolResultSuccessModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_number_amazon_connect_success
    /// </summary>
    [Serializable]
    public struct TransferToNumberAmazonConnectSuccess
    {
        public TransferToNumberAmazonConnectSuccess(
            global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberAmazonConnectSuccess(
            global::ElevenLabs.TransferToNumberResultAmazonConnectSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_number_error
    /// </summary>
    [Serializable]
    public struct TransferToNumberError
    {
        public TransferToNumberError(global::ElevenLabs.TransferToNumberResultErrorModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToNumberResultErrorModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberError(
            global::ElevenLabs.TransferToNumberResultErrorModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_number_exotel_success
    /// </summary>
    [Serializable]
    public struct TransferToNumberExotelSuccess
    {
        public TransferToNumberExotelSuccess(
            global::ElevenLabs.TransferToNumberResultExotelSuccessModel value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToNumberResultExotelSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberExotelSuccess(
            global::ElevenLabs.TransferToNumberResultExotelSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_number_sip_success
    /// </summary>
    [Serializable]
    public struct TransferToNumberSipSuccess
    {
        public TransferToNumberSipSuccess(
            global::ElevenLabs.TransferToNumberResultSipSuccessModel value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToNumberResultSipSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberSipSuccess(
            global::ElevenLabs.TransferToNumberResultSipSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transfer_to_number_twilio_success
    /// </summary>
    [Serializable]
    public struct TransferToNumberTwilioSuccess
    {
        public TransferToNumberTwilioSuccess(
            global::ElevenLabs.TransferToNumberResultTwilioSuccessModel value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.TransferToNumberResultTwilioSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.TransferToNumberTwilioSuccess(
            global::ElevenLabs.TransferToNumberResultTwilioSuccessModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for voicemail_detection_success
    /// </summary>
    [Serializable]
    public struct VoicemailDetectionSuccess
    {
        public VoicemailDetectionSuccess(
            global::ElevenLabs.VoiceMailDetectionResultSuccessModel value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.VoiceMailDetectionResultSuccessModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryTranscriptSystemToolResultCommonModelOutputResult.VoicemailDetectionSuccess(
            global::ElevenLabs.VoiceMailDetectionResultSuccessModel value
        ) => new(value);
    }
}
