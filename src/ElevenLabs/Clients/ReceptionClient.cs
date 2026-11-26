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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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
/// Fern-shape client for ReceptionClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IReceptionClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ReceptionClient
{
    internal ReceptionClient(global::ElevenLabs.Http.Client httpClient)
    {
        Receptionists = new ReceptionistsClient(httpClient);
        Team = new TeamClient(httpClient);
        PhoneNumbers = new ElevenLabs.Reception.PhoneNumbersClient(httpClient);
        Assets = new ElevenLabs.Reception.AssetsClient(httpClient);
        Services = new ServicesClient(httpClient);
        Products = new ProductsClient(httpClient);
        Staff = new StaffClient(httpClient);
        Holidays = new HolidaysClient(httpClient);
        Locations = new LocationsClient(httpClient);
        BusinessProfile = new BusinessProfileClient(httpClient);
        KnowledgeSources = new KnowledgeSourcesClient(httpClient);
        Workspaces = new ElevenLabs.Reception.WorkspacesClient(httpClient);
        Subscriptions = new SubscriptionsClient(httpClient);
        Tiers = new TiersClient(httpClient);
        Billing = new BillingClient(httpClient);
    }

    public IReceptionistsClient Receptionists { get; }
    public ITeamClient Team { get; }
    public ElevenLabs.Reception.IPhoneNumbersClient PhoneNumbers { get; }
    public ElevenLabs.Reception.IAssetsClient Assets { get; }
    public IServicesClient Services { get; }
    public IProductsClient Products { get; }
    public IStaffClient Staff { get; }
    public IHolidaysClient Holidays { get; }
    public ILocationsClient Locations { get; }
    public IBusinessProfileClient BusinessProfile { get; }
    public IKnowledgeSourcesClient KnowledgeSources { get; }
    public ElevenLabs.Reception.IWorkspacesClient Workspaces { get; }
    public ISubscriptionsClient Subscriptions { get; }
    public ITiersClient Tiers { get; }
    public IBillingClient Billing { get; }
}
