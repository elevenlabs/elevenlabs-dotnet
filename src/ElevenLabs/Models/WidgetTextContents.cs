using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[Serializable]
public record WidgetTextContents : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Call to action displayed inside the compact and full variants.</value>
    [JsonPropertyName("main_label")]
    public string? MainLabel { get; set; }

    /// <value>Text and ARIA label for the start call button.</value>
    [JsonPropertyName("start_call")]
    public string? StartCall { get; set; }

    /// <value>Text and ARIA label for the start chat button (text only)</value>
    [JsonPropertyName("start_chat")]
    public string? StartChat { get; set; }

    /// <value>Text and ARIA label for the new call button. Displayed when the caller already finished at least one call in order ot start the next one.</value>
    [JsonPropertyName("new_call")]
    public string? NewCall { get; set; }

    /// <value>Text and ARIA label for the button that resumes the conversation.</value>
    [JsonPropertyName("resume_call")]
    public string? ResumeCall { get; set; }

    /// <value>Text and ARIA label for the end call button.</value>
    [JsonPropertyName("end_call")]
    public string? EndCall { get; set; }

    /// <value>Text and ARIA label for the end chat button.</value>
    [JsonPropertyName("end_chat")]
    public string? EndChat { get; set; }

    /// <value>ARIA label for the mute microphone button.</value>
    [JsonPropertyName("mute_microphone")]
    public string? MuteMicrophone { get; set; }

    /// <value>ARIA label for the change language dropdown.</value>
    [JsonPropertyName("change_language")]
    public string? ChangeLanguage { get; set; }

    /// <value>ARIA label for the collapse button.</value>
    [JsonPropertyName("collapse")]
    public string? Collapse { get; set; }

    /// <value>ARIA label for the expand button.</value>
    [JsonPropertyName("expand")]
    public string? Expand { get; set; }

    /// <value>ARIA label for the header button that expands the widget.</value>
    [JsonPropertyName("expand_widget")]
    public string? ExpandWidget { get; set; }

    /// <value>ARIA label for the header button that collapses the widget back to its compact size.</value>
    [JsonPropertyName("collapse_widget")]
    public string? CollapseWidget { get; set; }

    /// <value>ARIA label for the button that hides a dismissible widget.</value>
    [JsonPropertyName("dismiss")]
    public string? Dismiss { get; set; }

    /// <value>ARIA label for the launcher button that reopens a dismissed widget.</value>
    [JsonPropertyName("open_chat")]
    public string? OpenChat { get; set; }

    /// <value>Text displayed when the user copies a value using the copy button.</value>
    [JsonPropertyName("copied")]
    public string? Copied { get; set; }

    /// <value>Text and ARIA label for the accept terms button.</value>
    [JsonPropertyName("accept_terms")]
    public string? AcceptTerms { get; set; }

    /// <value>Text and ARIA label for the cancel terms button.</value>
    [JsonPropertyName("dismiss_terms")]
    public string? DismissTerms { get; set; }

    /// <value>Title displayed in the confirmation dialog before ending a chat.</value>
    [JsonPropertyName("end_chat_confirmation_title")]
    public string? EndChatConfirmationTitle { get; set; }

    /// <value>Description displayed in the confirmation dialog before ending a chat.</value>
    [JsonPropertyName("end_chat_confirmation_description")]
    public string? EndChatConfirmationDescription { get; set; }

    /// <value>Title displayed in the confirmation dialog before ending a call.</value>
    [JsonPropertyName("end_call_confirmation_title")]
    public string? EndCallConfirmationTitle { get; set; }

    /// <value>Description displayed in the confirmation dialog before ending a call.</value>
    [JsonPropertyName("end_call_confirmation_description")]
    public string? EndCallConfirmationDescription { get; set; }

    /// <value>Text and ARIA label for the button that confirms ending a call.</value>
    [JsonPropertyName("end_call_confirm")]
    public string? EndCallConfirm { get; set; }

    /// <value>Text and ARIA label for the button that cancels ending a chat or call.</value>
    [JsonPropertyName("cancel_end_confirmation")]
    public string? CancelEndConfirmation { get; set; }

    /// <value>Status displayed when the agent is listening.</value>
    [JsonPropertyName("listening_status")]
    public string? ListeningStatus { get; set; }

    /// <value>Status displayed when the agent is speaking.</value>
    [JsonPropertyName("speaking_status")]
    public string? SpeakingStatus { get; set; }

    /// <value>Status displayed when the agent is connecting.</value>
    [JsonPropertyName("connecting_status")]
    public string? ConnectingStatus { get; set; }

    /// <value>Status displayed when the agent is reconnecting.</value>
    [JsonPropertyName("reconnecting_status")]
    public string? ReconnectingStatus { get; set; }

    /// <value>Status displayed when the agent is chatting (text only)</value>
    [JsonPropertyName("chatting_status")]
    public string? ChattingStatus { get; set; }

    /// <value>Status displayed while waiting in the queue for an available agent.</value>
    [JsonPropertyName("queue_waiting_status")]
    public string? QueueWaitingStatus { get; set; }

    /// <value>Short status displayed while waiting for an available agent.</value>
    [JsonPropertyName("queue_waiting_status_short")]
    public string? QueueWaitingStatusShort { get; set; }

    /// <value>ARIA label for the text message input.</value>
    [JsonPropertyName("input_label")]
    public string? InputLabel { get; set; }

    /// <value>Placeholder text for the text message input.</value>
    [JsonPropertyName("input_placeholder")]
    public string? InputPlaceholder { get; set; }

    /// <value>Placeholder text for the text message input (text only)</value>
    [JsonPropertyName("input_placeholder_text_only")]
    public string? InputPlaceholderTextOnly { get; set; }

    /// <value>Placeholder text for the text message input when starting a new conversation (text only)</value>
    [JsonPropertyName("input_placeholder_new_conversation")]
    public string? InputPlaceholderNewConversation { get; set; }

    /// <value>Information message displayed when the user ends the conversation.</value>
    [JsonPropertyName("user_ended_conversation")]
    public string? UserEndedConversation { get; set; }

    /// <value>Information message displayed when the agent ends the conversation.</value>
    [JsonPropertyName("agent_ended_conversation")]
    public string? AgentEndedConversation { get; set; }

    /// <value>Text label used next to the conversation ID.</value>
    [JsonPropertyName("conversation_id")]
    public string? ConversationId { get; set; }

    /// <value>Text label used when an error occurs.</value>
    [JsonPropertyName("error_occurred")]
    public string? ErrorOccurred { get; set; }

    /// <value>Error message displayed when the queue wait times out.</value>
    [JsonPropertyName("queue_timed_out")]
    public string? QueueTimedOut { get; set; }

    /// <value>Text and ARIA label used for the copy ID button.</value>
    [JsonPropertyName("copy_id")]
    public string? CopyId { get; set; }

    /// <value>Text displayed to prompt the user for feedback.</value>
    [JsonPropertyName("initiate_feedback")]
    public string? InitiateFeedback { get; set; }

    /// <value>Text displayed to request additional feedback details.</value>
    [JsonPropertyName("request_follow_up_feedback")]
    public string? RequestFollowUpFeedback { get; set; }

    /// <value>Text displayed to thank the user for providing feedback.</value>
    [JsonPropertyName("thanks_for_feedback")]
    public string? ThanksForFeedback { get; set; }

    /// <value>Additional text displayed explaining the value of user feedback.</value>
    [JsonPropertyName("thanks_for_feedback_details")]
    public string? ThanksForFeedbackDetails { get; set; }

    /// <value>Placeholder text for the follow-up feedback input field.</value>
    [JsonPropertyName("follow_up_feedback_placeholder")]
    public string? FollowUpFeedbackPlaceholder { get; set; }

    /// <value>Text and ARIA label for the submit button.</value>
    [JsonPropertyName("submit")]
    public string? Submit { get; set; }

    /// <value>Text and ARIA label for the go back button.</value>
    [JsonPropertyName("go_back")]
    public string? GoBack { get; set; }

    /// <value>Text and ARIA label for the send message button.</value>
    [JsonPropertyName("send_message")]
    public string? SendMessage { get; set; }

    /// <value>Text and ARIA label for the switch to text mode button.</value>
    [JsonPropertyName("text_mode")]
    public string? TextMode { get; set; }

    /// <value>Text and ARIA label for the switch to voice mode button.</value>
    [JsonPropertyName("voice_mode")]
    public string? VoiceMode { get; set; }

    /// <value>Label for the voice option in the conversation mode toggle.</value>
    [JsonPropertyName("voice_mode_label")]
    public string? VoiceModeLabel { get; set; }

    /// <value>Label for the text option in the conversation mode toggle.</value>
    [JsonPropertyName("text_mode_label")]
    public string? TextModeLabel { get; set; }

    /// <value>Toast notification displayed when switching to text mode.</value>
    [JsonPropertyName("switched_to_text_mode")]
    public string? SwitchedToTextMode { get; set; }

    /// <value>Toast notification displayed when switching to voice mode.</value>
    [JsonPropertyName("switched_to_voice_mode")]
    public string? SwitchedToVoiceMode { get; set; }

    /// <value>Text and ARIA label for the copy button.</value>
    [JsonPropertyName("copy")]
    public string? Copy { get; set; }

    /// <value>Text and ARIA label for the download button.</value>
    [JsonPropertyName("download")]
    public string? Download { get; set; }

    /// <value>Text and ARIA label for the wrap toggle button.</value>
    [JsonPropertyName("wrap")]
    public string? Wrap { get; set; }

    /// <value>Status text displayed when the agent is processing a tool call.</value>
    [JsonPropertyName("agent_working")]
    public string? AgentWorking { get; set; }

    /// <value>Status text displayed when the agent finishes processing a tool call.</value>
    [JsonPropertyName("agent_done")]
    public string? AgentDone { get; set; }

    /// <value>Status text displayed when the agent encounters an error during a tool call.</value>
    [JsonPropertyName("agent_error")]
    public string? AgentError { get; set; }

    /// <value>Text and ARIA label for the attach file button.</value>
    [JsonPropertyName("attach_file")]
    public string? AttachFile { get; set; }

    /// <value>ARIA label for the remove file button.</value>
    [JsonPropertyName("remove_file")]
    public string? RemoveFile { get; set; }

    /// <value>Error message displayed when a file fails to upload.</value>
    [JsonPropertyName("file_upload_error")]
    public string? FileUploadError { get; set; }

    /// <value>Error message displayed when an unsupported file type is selected. Followed by the list of accepted types.</value>
    [JsonPropertyName("file_type_unsupported")]
    public string? FileTypeUnsupported { get; set; }

    /// <value>Error message displayed when a file exceeds the maximum size limit.</value>
    [JsonPropertyName("file_too_large")]
    public string? FileTooLarge { get; set; }

    /// <value>Error message displayed when the maximum number of files for a conversation is reached.</value>
    [JsonPropertyName("file_limit_reached")]
    public string? FileLimitReached { get; set; }

    /// <value>Status text displayed while the agent is typing.</value>
    [JsonPropertyName("typing_indicator")]
    public string? TypingIndicator { get; set; }

    /// <value>Status text displayed while the agent is thinking.</value>
    [JsonPropertyName("thinking_status")]
    public string? ThinkingStatus { get; set; }

    /// <value>Fallback message displayed when rich content cannot be rendered.</value>
    [JsonPropertyName("rich_content_unavailable")]
    public string? RichContentUnavailable { get; set; }

    /// <value>ARIA label for the previous button in a rich content carousel.</value>
    [JsonPropertyName("carousel_previous")]
    public string? CarouselPrevious { get; set; }

    /// <value>ARIA label for the next button in a rich content carousel.</value>
    [JsonPropertyName("carousel_next")]
    public string? CarouselNext { get; set; }

    /// <value>Label for the button that scrolls to one new message.</value>
    [JsonPropertyName("new_message")]
    public string? NewMessage { get; set; }

    /// <value>Label for the button that scrolls to new messages. Keep the count placeholder from the default, which is replaced with the number of messages.</value>
    [JsonPropertyName("new_messages")]
    public string? NewMessages { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(WidgetTextContents? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(MainLabel, other.MainLabel)
            && ValueEquality.AreEqual(StartCall, other.StartCall)
            && ValueEquality.AreEqual(StartChat, other.StartChat)
            && ValueEquality.AreEqual(NewCall, other.NewCall)
            && ValueEquality.AreEqual(ResumeCall, other.ResumeCall)
            && ValueEquality.AreEqual(EndCall, other.EndCall)
            && ValueEquality.AreEqual(EndChat, other.EndChat)
            && ValueEquality.AreEqual(MuteMicrophone, other.MuteMicrophone)
            && ValueEquality.AreEqual(ChangeLanguage, other.ChangeLanguage)
            && ValueEquality.AreEqual(Collapse, other.Collapse)
            && ValueEquality.AreEqual(Expand, other.Expand)
            && ValueEquality.AreEqual(ExpandWidget, other.ExpandWidget)
            && ValueEquality.AreEqual(CollapseWidget, other.CollapseWidget)
            && ValueEquality.AreEqual(Dismiss, other.Dismiss)
            && ValueEquality.AreEqual(OpenChat, other.OpenChat)
            && ValueEquality.AreEqual(Copied, other.Copied)
            && ValueEquality.AreEqual(AcceptTerms, other.AcceptTerms)
            && ValueEquality.AreEqual(DismissTerms, other.DismissTerms)
            && ValueEquality.AreEqual(EndChatConfirmationTitle, other.EndChatConfirmationTitle)
            && ValueEquality.AreEqual(
                EndChatConfirmationDescription,
                other.EndChatConfirmationDescription
            )
            && ValueEquality.AreEqual(EndCallConfirmationTitle, other.EndCallConfirmationTitle)
            && ValueEquality.AreEqual(
                EndCallConfirmationDescription,
                other.EndCallConfirmationDescription
            )
            && ValueEquality.AreEqual(EndCallConfirm, other.EndCallConfirm)
            && ValueEquality.AreEqual(CancelEndConfirmation, other.CancelEndConfirmation)
            && ValueEquality.AreEqual(ListeningStatus, other.ListeningStatus)
            && ValueEquality.AreEqual(SpeakingStatus, other.SpeakingStatus)
            && ValueEquality.AreEqual(ConnectingStatus, other.ConnectingStatus)
            && ValueEquality.AreEqual(ReconnectingStatus, other.ReconnectingStatus)
            && ValueEquality.AreEqual(ChattingStatus, other.ChattingStatus)
            && ValueEquality.AreEqual(QueueWaitingStatus, other.QueueWaitingStatus)
            && ValueEquality.AreEqual(QueueWaitingStatusShort, other.QueueWaitingStatusShort)
            && ValueEquality.AreEqual(InputLabel, other.InputLabel)
            && ValueEquality.AreEqual(InputPlaceholder, other.InputPlaceholder)
            && ValueEquality.AreEqual(InputPlaceholderTextOnly, other.InputPlaceholderTextOnly)
            && ValueEquality.AreEqual(
                InputPlaceholderNewConversation,
                other.InputPlaceholderNewConversation
            )
            && ValueEquality.AreEqual(UserEndedConversation, other.UserEndedConversation)
            && ValueEquality.AreEqual(AgentEndedConversation, other.AgentEndedConversation)
            && ValueEquality.AreEqual(ConversationId, other.ConversationId)
            && ValueEquality.AreEqual(ErrorOccurred, other.ErrorOccurred)
            && ValueEquality.AreEqual(QueueTimedOut, other.QueueTimedOut)
            && ValueEquality.AreEqual(CopyId, other.CopyId)
            && ValueEquality.AreEqual(InitiateFeedback, other.InitiateFeedback)
            && ValueEquality.AreEqual(RequestFollowUpFeedback, other.RequestFollowUpFeedback)
            && ValueEquality.AreEqual(ThanksForFeedback, other.ThanksForFeedback)
            && ValueEquality.AreEqual(ThanksForFeedbackDetails, other.ThanksForFeedbackDetails)
            && ValueEquality.AreEqual(
                FollowUpFeedbackPlaceholder,
                other.FollowUpFeedbackPlaceholder
            )
            && ValueEquality.AreEqual(Submit, other.Submit)
            && ValueEquality.AreEqual(GoBack, other.GoBack)
            && ValueEquality.AreEqual(SendMessage, other.SendMessage)
            && ValueEquality.AreEqual(TextMode, other.TextMode)
            && ValueEquality.AreEqual(VoiceMode, other.VoiceMode)
            && ValueEquality.AreEqual(VoiceModeLabel, other.VoiceModeLabel)
            && ValueEquality.AreEqual(TextModeLabel, other.TextModeLabel)
            && ValueEquality.AreEqual(SwitchedToTextMode, other.SwitchedToTextMode)
            && ValueEquality.AreEqual(SwitchedToVoiceMode, other.SwitchedToVoiceMode)
            && ValueEquality.AreEqual(Copy, other.Copy)
            && ValueEquality.AreEqual(Download, other.Download)
            && ValueEquality.AreEqual(Wrap, other.Wrap)
            && ValueEquality.AreEqual(AgentWorking, other.AgentWorking)
            && ValueEquality.AreEqual(AgentDone, other.AgentDone)
            && ValueEquality.AreEqual(AgentError, other.AgentError)
            && ValueEquality.AreEqual(AttachFile, other.AttachFile)
            && ValueEquality.AreEqual(RemoveFile, other.RemoveFile)
            && ValueEquality.AreEqual(FileUploadError, other.FileUploadError)
            && ValueEquality.AreEqual(FileTypeUnsupported, other.FileTypeUnsupported)
            && ValueEquality.AreEqual(FileTooLarge, other.FileTooLarge)
            && ValueEquality.AreEqual(FileLimitReached, other.FileLimitReached)
            && ValueEquality.AreEqual(TypingIndicator, other.TypingIndicator)
            && ValueEquality.AreEqual(ThinkingStatus, other.ThinkingStatus)
            && ValueEquality.AreEqual(RichContentUnavailable, other.RichContentUnavailable)
            && ValueEquality.AreEqual(CarouselPrevious, other.CarouselPrevious)
            && ValueEquality.AreEqual(CarouselNext, other.CarouselNext)
            && ValueEquality.AreEqual(NewMessage, other.NewMessage)
            && ValueEquality.AreEqual(NewMessages, other.NewMessages)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MainLabel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartChat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResumeCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndChat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MuteMicrophone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChangeLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Collapse);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Expand);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpandWidget);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CollapseWidget);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Dismiss);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OpenChat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Copied);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AcceptTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DismissTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndChatConfirmationTitle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndChatConfirmationDescription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndCallConfirmationTitle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndCallConfirmationDescription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndCallConfirm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CancelEndConfirmation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ListeningStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeakingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConnectingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReconnectingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChattingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueueWaitingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueueWaitingStatusShort);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputLabel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputPlaceholder);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputPlaceholderTextOnly);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputPlaceholderNewConversation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserEndedConversation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentEndedConversation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorOccurred);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueueTimedOut);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CopyId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InitiateFeedback);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestFollowUpFeedback);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThanksForFeedback);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThanksForFeedbackDetails);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FollowUpFeedbackPlaceholder);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Submit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GoBack);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SendMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceModeLabel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextModeLabel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SwitchedToTextMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SwitchedToVoiceMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Copy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Download);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Wrap);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentWorking);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentDone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentError);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AttachFile);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RemoveFile);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileUploadError);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileTypeUnsupported);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileTooLarge);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileLimitReached);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TypingIndicator);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThinkingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RichContentUnavailable);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CarouselPrevious);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CarouselNext);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewMessages);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
