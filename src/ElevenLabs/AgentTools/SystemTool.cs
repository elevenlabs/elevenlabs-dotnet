using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.AgentTools;

/// <summary>
/// A built-in tool the agent runs itself, such as ending the call or transferring it. Its name defaults to its
/// <see cref="SystemToolType"/>, and its description is left out so the API uses its own; both can be set with
/// <see cref="Options"/>. Add it to an agent with <see cref="BuildConfig"/>.
/// </summary>
public sealed class SystemTool : Tool
{
    private static readonly HashSet<string> Allowed = WithCommonOptions();

    private static readonly string[] PhoneTransferOptions =
    {
        "TransferType",
        "CustomSipHeaders",
        "SipReferPlayDialtone",
        "Uui",
        "PostDialDigits",
    };

    private static readonly string[] AgentTransferOptions =
    {
        "DelayMs",
        "TransferMessage",
        "EnableTransferredAgentFirstMessage",
        "PreserveClientTtsOverrides",
        "PreserveVoiceSettings",
    };

    /// <summary>The <c>params</c> fields other than <c>system_tool_type</c>, in wire format.</summary>
    private readonly JsonObject _params;

    internal SystemTool(string systemToolType, JsonObject config, JsonObject systemParams)
        : base(config)
    {
        SystemToolType = systemToolType;
        _params = systemParams;
    }

    public override ToolKind Kind => ToolKind.System;

    /// <summary>The API's <c>system_tool_type</c>, e.g. <c>"end_call"</c>.</summary>
    public string SystemToolType { get; }

    /// <summary>Lets the agent end the call.</summary>
    public static SystemTool EndCall() => Create("end_call", new List<KeyValuePair<string, JsonNode>>());

    /// <summary>Lets the agent stay quiet when the user asks for a moment.</summary>
    public static SystemTool SkipTurn(SkipTurnOptions? options = null)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "WaitTimeoutSecs", options?.WaitTimeoutSecs);
        return Create("skip_turn", entries);
    }

    /// <summary>Lets the agent switch language.</summary>
    public static SystemTool LanguageDetection(LanguageDetectionOptions? options = null)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "OnlyAtConversationStart", options?.OnlyAtConversationStart);
        return Create("language_detection", entries);
    }

    /// <summary>Lets the agent play keypad tones, for phone menus.</summary>
    public static SystemTool PlayKeypadTouchTone(PlayKeypadTouchToneOptions? options = null)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "UseOutOfBandDtmf", options?.UseOutOfBandDtmf);
        Put(entries, "SuppressTurnAfterDtmf", options?.SuppressTurnAfterDtmf);
        return Create("play_keypad_touch_tone", entries);
    }

    /// <summary>Lets the agent detect voicemail and leave a message or hang up.</summary>
    public static SystemTool VoicemailDetection(VoicemailDetectionOptions? options = null)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "VoicemailMessage", options?.VoicemailMessage);
        return Create("voicemail_detection", entries);
    }

    /// <summary>Lets the agent search its knowledge base.</summary>
    public static SystemTool KnowledgeBase(KnowledgeBaseToolOptions? options = null)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "EnabledStrategies", options?.EnabledStrategies);
        return Create("knowledge_base", entries);
    }

    /// <summary>Lets the agent transfer the call to a phone number or SIP URI. Add destinations with <see cref="Transfer"/>.</summary>
    public static SystemTool TransferToNumber(TransferToNumberOptions? options = null)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "EnableClientMessage", options?.EnableClientMessage);
        entries.Add(new KeyValuePair<string, JsonNode>("Transfers", new JsonArray()));
        return Create("transfer_to_number", entries);
    }

    /// <summary>Lets the agent hand the conversation to another agent. Add destinations with <see cref="Transfer"/>.</summary>
    public static SystemTool TransferToAgent() =>
        Create(
            "transfer_to_agent",
            new List<KeyValuePair<string, JsonNode>> { new("Transfers", new JsonArray()) }
        );

    /// <summary>
    /// Adds a destination to a transfer tool. <paramref name="condition"/> is plain text telling the LLM when to
    /// transfer there. <c>TransferToNumber()</c> takes phone and SIP destinations, <c>TransferToAgent()</c> agent
    /// destinations. A SIP URI destination needs <c>TransferType = "sip_refer"</c>.
    /// </summary>
    public SystemTool Transfer(string condition, Destination destination, SystemTransferOptions? options = null)
    {
        var model = destination.ToWire();
        var toNumber = SystemToolType == "transfer_to_number";
        if (!toNumber && SystemToolType != "transfer_to_agent")
        {
            Issues.Add(
                ToolValidation.Error(
                    "invalid_option",
                    "transfer",
                    $"Transfer() only applies to transfer tools, not {SystemToolType}"
                )
            );
            return this;
        }
        if ((ToolWire.Str(model["type"]) == "phone_number") != toNumber)
        {
            Issues.Add(
                ToolValidation.Error(
                    "invalid_destination",
                    "transfer",
                    toNumber
                        ? $"TransferToNumber() needs a phone or SIP destination, not an agent (\"{condition}\")"
                        : $"TransferToAgent() needs an agent destination (\"{condition}\")"
                )
            );
            return this;
        }
        var allowed = toNumber ? PhoneTransferOptions : AgentTransferOptions;
        var settings = new List<KeyValuePair<string, JsonNode>>();
        foreach (var entry in TransferEntries(options ?? new SystemTransferOptions()))
        {
            if (allowed.Contains(entry.Key))
            {
                settings.Add(entry);
            }
            else
            {
                Issues.Add(
                    ToolValidation.Error(
                        "invalid_option",
                        entry.Key,
                        $"Option \"{entry.Key}\" doesn't apply to {SystemToolType}"
                    )
                );
            }
        }
        // A SIP URI held in a dynamic variable resolves to a SIP URI too, so it also needs SIP REFER.
        var destinationType = ToolWire.Str(model["transfer_destination"]?["type"]);
        var sipUri = destinationType == "sip_uri" || destinationType == "sip_uri_dynamic_variable";
        if (sipUri && options?.TransferType != "sip_refer")
        {
            Issues.Add(
                ToolValidation.Error(
                    "invalid_destination",
                    "transfer",
                    $"A SIP URI destination needs TransferType = \"sip_refer\" (\"{condition}\")"
                )
            );
            return this;
        }
        var transfer = new JsonObject();
        foreach (var field in model)
        {
            if (field.Key != "type")
            {
                transfer[field.Key] = field.Value?.DeepClone();
            }
        }
        foreach (var setting in settings)
        {
            transfer[SnakeCase(setting.Key)] = setting.Value;
        }
        transfer["condition"] = condition;
        var transfers = _params["transfers"] as JsonArray ?? new JsonArray();
        transfers.Add(transfer);
        _params["transfers"] = transfers;
        return this;
    }

    /// <summary>Merges the options every tool accepts. An option that doesn't apply is reported by <c>Build()</c>.</summary>
    public new SystemTool Options(CommonToolOptions options)
    {
        ApplyOptions(options);
        return this;
    }

    /// <summary>
    /// Validates the tool and returns its entry for the agent's <c>prompt.built_in_tools</c>, e.g.
    /// <c>new BuiltInToolsInput { EndCall = SystemTool.EndCall().BuildConfig() }</c>.
    /// </summary>
    /// <exception cref="ToolValidationException">Listing every problem, if the tool is invalid.</exception>
    public new SystemToolConfigInput BuildConfig(Action<ToolIssue>? onWarning = null) =>
        base.BuildConfig(onWarning).AsSystem();

    private protected override ICollection<string> AllowedOptions => Allowed;

    private protected override List<ToolIssue> Validate()
    {
        var issues = new List<ToolIssue>();
        var isTransfer = SystemToolType == "transfer_to_number" || SystemToolType == "transfer_to_agent";
        if (!isTransfer)
        {
            return issues;
        }
        // A loaded transfer_to_number tool may use transfer_rules instead of transfers; the API takes exactly one.
        var hasTransfers = _params["transfers"] is JsonArray { Count: > 0 };
        // Only transfer_to_number has transfer_rules; transfer_to_agent needs transfers.
        var hasRules =
            SystemToolType == "transfer_to_number" && _params["transfer_rules"] is JsonArray { Count: > 0 };
        if (!hasTransfers && !hasRules)
        {
            issues.Add(
                ToolValidation.Error("no_transfers", "transfer", $"{SystemToolType} needs at least one Transfer()")
            );
        }
        else if (hasTransfers && hasRules)
        {
            issues.Add(
                ToolValidation.Error(
                    "conflicting_transfers",
                    "transfer",
                    $"{SystemToolType} has both transfers and transfer_rules; the API takes only one"
                )
            );
        }
        return issues;
    }

    private protected override JsonObject ToModel()
    {
        var systemParams = new JsonObject { ["system_tool_type"] = SystemToolType };
        foreach (var field in _params)
        {
            systemParams[field.Key] = field.Value?.DeepClone();
        }
        var model = CopyConfig();
        model["type"] = "system";
        model["params"] = systemParams;
        return model;
    }

    private static SystemTool Create(string systemToolType, List<KeyValuePair<string, JsonNode>> entries)
    {
        var systemParams = new JsonObject();
        foreach (var entry in entries)
        {
            systemParams[SnakeCase(entry.Key)] = entry.Value;
        }
        return new SystemTool(systemToolType, new JsonObject { ["name"] = systemToolType }, systemParams);
    }

    private static List<KeyValuePair<string, JsonNode>> TransferEntries(SystemTransferOptions options)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "TransferType", options.TransferType);
        Put(entries, "CustomSipHeaders", options.CustomSipHeaders);
        Put(entries, "SipReferPlayDialtone", options.SipReferPlayDialtone);
        Put(entries, "Uui", options.Uui);
        Put(entries, "PostDialDigits", options.PostDialDigits);
        Put(entries, "DelayMs", options.DelayMs);
        Put(entries, "TransferMessage", options.TransferMessage);
        Put(entries, "EnableTransferredAgentFirstMessage", options.EnableTransferredAgentFirstMessage);
        Put(entries, "PreserveClientTtsOverrides", options.PreserveClientTtsOverrides);
        Put(entries, "PreserveVoiceSettings", options.PreserveVoiceSettings);
        return entries;
    }
}
