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
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.Services;
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
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape client for FlowsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IFlowsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class FlowsClient
{
    internal FlowsClient(global::ElevenLabs.Http.Client httpClient)
    {
        TextToSpeech = new ElevenLabs.Flows.TextToSpeechClient(httpClient);
        Video = new VideoClient(httpClient);
        Image = new ImageClient(httpClient);
        Templates = new TemplatesClient(httpClient);
    }

    public ElevenLabs.Flows.ITextToSpeechClient TextToSpeech { get; }
    public IVideoClient Video { get; }
    public IImageClient Image { get; }
    public ITemplatesClient Templates { get; }
}
