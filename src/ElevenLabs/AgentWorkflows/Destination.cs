using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

/// <summary>Where a <c>Transfer()</c> node hands the conversation off to. Built with the static constructors.</summary>
public sealed class Destination
{
    private readonly JsonObject _model;

    private Destination(JsonObject model) => _model = model;

    /// <summary>A phone number in E.164 format.</summary>
    public static Destination Phone(string phoneNumber) =>
        new(
            new JsonObject
            {
                ["type"] = "phone_number",
                ["transfer_destination"] = new JsonObject { ["type"] = "phone", ["phone_number"] = phoneNumber },
            }
        );

    /// <summary>A phone number read from a dynamic variable at transfer time.</summary>
    public static Destination PhoneVariable(string variableName) =>
        new(
            new JsonObject
            {
                ["type"] = "phone_number",
                ["transfer_destination"] = new JsonObject
                {
                    ["type"] = "phone_dynamic_variable",
                    ["phone_number"] = variableName,
                },
            }
        );

    /// <summary>A SIP URI.</summary>
    public static Destination Sip(string sipUri) =>
        new(
            new JsonObject
            {
                ["type"] = "phone_number",
                ["transfer_destination"] = new JsonObject { ["type"] = "sip_uri", ["sip_uri"] = sipUri },
            }
        );

    /// <summary>A SIP URI read from a dynamic variable at transfer time.</summary>
    public static Destination SipVariable(string variableName) =>
        new(
            new JsonObject
            {
                ["type"] = "phone_number",
                ["transfer_destination"] = new JsonObject
                {
                    ["type"] = "sip_uri_dynamic_variable",
                    ["sip_uri"] = variableName,
                },
            }
        );

    /// <summary>Another ElevenLabs agent. <paramref name="nodeId"/> is the node in its workflow to start from.</summary>
    public static Destination Agent(string agentId, string? nodeId = null)
    {
        var model = new JsonObject { ["type"] = "standalone_agent", ["agent_id"] = agentId };
        if (nodeId != null)
        {
            model["node_id"] = nodeId;
        }
        return new Destination(model);
    }

    /// <summary>The node fields this destination sets, in API wire format.</summary>
    internal JsonObject ToWire() => (JsonObject)_model.DeepClone();
}
