namespace ElevenLabs;

/// <summary>
/// Fern-shape root client interface exposing the top-level sub-clients as their interface type. A
/// deeper client is reached through its parent (<c>client.Fleet.Attributes</c>), so only top-level
/// nodes appear here. FSM-144 / FSM-936.
/// </summary>
public partial interface IElevenLabsClient
{
    public IHistoryClient History { get; }
    public ITextToSoundEffectsClient TextToSoundEffects { get; }
    public IAudioIsolationClient AudioIsolation { get; }
    public IAudioEffectsClient AudioEffects { get; }
    public ElevenLabs.ISamplesClient Samples { get; }
    public IVoicesClient Voices { get; }
    public IDubbingClient Dubbing { get; }
    public IAgentsClient Agents { get; }
    public ElevenLabs.ITextToSpeechClient TextToSpeech { get; }
    public IFlowsClient Flows { get; }
    public ITextToDialogueClient TextToDialogue { get; }
    public ISpeechToSpeechClient SpeechToSpeech { get; }
    public ITextToVoiceClient TextToVoice { get; }
    public IUserClient User { get; }
    public IStudioClient Studio { get; }
    public ElevenLabs.IPronunciationDictionariesClient PronunciationDictionaries { get; }
    public ISpeechToTextClient SpeechToText { get; }
    public IModelsClient Models { get; }
    public IAudioNativeClient AudioNative { get; }
    public IWorkspacesClient Workspaces { get; }
    public IServiceAccountsClient ServiceAccounts { get; }
    public IWorkspaceClient Workspace { get; }
    public IWebhooksClient Webhooks { get; }
    public IMusicClient Music { get; }
    public ITokensClient Tokens { get; }
    public IForcedAlignmentClient ForcedAlignment { get; }
    public ISpeechEngineClient SpeechEngine { get; }
    public IEnvironmentVariablesClient EnvironmentVariables { get; }
    public IEnvironmentsClient Environments { get; }
    public IProductionsClient Productions { get; }
    public IAssetsClient Assets { get; }
    ITextToDialogueApi CreateTextToDialogueApi();
    ITextToDialogueApi CreateTextToDialogueApi(TextToDialogueApi.Options options);
    ITextToDialogueMultiContextApi CreateTextToDialogueMultiContextApi();
    ITextToDialogueMultiContextApi CreateTextToDialogueMultiContextApi(
        TextToDialogueMultiContextApi.Options options
    );
    ISpeechEngineApi CreateSpeechEngineApi();
    ISpeechEngineApi CreateSpeechEngineApi(SpeechEngineApi.Options options);
    ISpeechToTextApi CreateSpeechToTextApi(SpeechToTextApi.Options options);
    ITextToSpeechApi CreateTextToSpeechApi(TextToSpeechApi.Options options);
    ITextToSpeechMultiContextApi CreateTextToSpeechMultiContextApi(
        TextToSpeechMultiContextApi.Options options
    );
    ITranslationApi CreateTranslationApi(TranslationApi.Options options);
    IDubbingApi CreateDubbingApi(DubbingApi.Options options);
}
