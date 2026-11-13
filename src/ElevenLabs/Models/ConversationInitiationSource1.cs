using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Enum representing the possible sources for conversation initiation.</summary>
[JsonConverter(typeof(ConversationInitiationSource1.ConversationInitiationSource1Serializer))]
[Serializable]
public readonly record struct ConversationInitiationSource1 : IStringEnum
{
    public static readonly ConversationInitiationSource1 Unknown = new(Values.Unknown);

    public static readonly ConversationInitiationSource1 AndroidSdk = new(Values.AndroidSdk);

    public static readonly ConversationInitiationSource1 NodeJsSdk = new(Values.NodeJsSdk);

    public static readonly ConversationInitiationSource1 ReactNativeSdk = new(
        Values.ReactNativeSdk
    );

    public static readonly ConversationInitiationSource1 ReactSdk = new(Values.ReactSdk);

    public static readonly ConversationInitiationSource1 JsSdk = new(Values.JsSdk);

    public static readonly ConversationInitiationSource1 PythonSdk = new(Values.PythonSdk);

    public static readonly ConversationInitiationSource1 Widget = new(Values.Widget);

    public static readonly ConversationInitiationSource1 SipTrunk = new(Values.SipTrunk);

    public static readonly ConversationInitiationSource1 Twilio = new(Values.Twilio);

    public static readonly ConversationInitiationSource1 Exotel = new(Values.Exotel);

    public static readonly ConversationInitiationSource1 Genesys = new(Values.Genesys);

    public static readonly ConversationInitiationSource1 Avaya = new(Values.Avaya);

    public static readonly ConversationInitiationSource1 Audiocodes = new(Values.Audiocodes);

    public static readonly ConversationInitiationSource1 SwiftSdk = new(Values.SwiftSdk);

    public static readonly ConversationInitiationSource1 Whatsapp = new(Values.Whatsapp);

    public static readonly ConversationInitiationSource1 TwilioSms = new(Values.TwilioSms);

    public static readonly ConversationInitiationSource1 FlutterSdk = new(Values.FlutterSdk);

    public static readonly ConversationInitiationSource1 ZendeskIntegration = new(
        Values.ZendeskIntegration
    );

    public static readonly ConversationInitiationSource1 SlackIntegration = new(
        Values.SlackIntegration
    );

    public static readonly ConversationInitiationSource1 TelegramIntegration = new(
        Values.TelegramIntegration
    );

    public static readonly ConversationInitiationSource1 IntercomIntegration = new(
        Values.IntercomIntegration
    );

    public static readonly ConversationInitiationSource1 FreshdeskIntegration = new(
        Values.FreshdeskIntegration
    );

    public static readonly ConversationInitiationSource1 SalesforceIntegration = new(
        Values.SalesforceIntegration
    );

    public static readonly ConversationInitiationSource1 TemplatePreview = new(
        Values.TemplatePreview
    );

    public static readonly ConversationInitiationSource1 GenesysBotConnector = new(
        Values.GenesysBotConnector
    );

    public static readonly ConversationInitiationSource1 SubagentTool = new(Values.SubagentTool);

    public ConversationInitiationSource1(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ConversationInitiationSource1 FromCustom(string value)
    {
        return new ConversationInitiationSource1(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(ConversationInitiationSource1 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationInitiationSource1 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationInitiationSource1 value) => value.Value;

    public static explicit operator ConversationInitiationSource1(string value) => new(value);

    internal class ConversationInitiationSource1Serializer
        : JsonConverter<ConversationInitiationSource1>
    {
        public override ConversationInitiationSource1 Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new ConversationInitiationSource1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationSource1 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationSource1 ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ConversationInitiationSource1(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationSource1 value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Unknown = "unknown";

        public const string AndroidSdk = "android_sdk";

        public const string NodeJsSdk = "node_js_sdk";

        public const string ReactNativeSdk = "react_native_sdk";

        public const string ReactSdk = "react_sdk";

        public const string JsSdk = "js_sdk";

        public const string PythonSdk = "python_sdk";

        public const string Widget = "widget";

        public const string SipTrunk = "sip_trunk";

        public const string Twilio = "twilio";

        public const string Exotel = "exotel";

        public const string Genesys = "genesys";

        public const string Avaya = "avaya";

        public const string Audiocodes = "audiocodes";

        public const string SwiftSdk = "swift_sdk";

        public const string Whatsapp = "whatsapp";

        public const string TwilioSms = "twilio_sms";

        public const string FlutterSdk = "flutter_sdk";

        public const string ZendeskIntegration = "zendesk_integration";

        public const string SlackIntegration = "slack_integration";

        public const string TelegramIntegration = "telegram_integration";

        public const string IntercomIntegration = "intercom_integration";

        public const string FreshdeskIntegration = "freshdesk_integration";

        public const string SalesforceIntegration = "salesforce_integration";

        public const string TemplatePreview = "template_preview";

        public const string GenesysBotConnector = "genesys_bot_connector";

        public const string SubagentTool = "subagent_tool";
    }
}
