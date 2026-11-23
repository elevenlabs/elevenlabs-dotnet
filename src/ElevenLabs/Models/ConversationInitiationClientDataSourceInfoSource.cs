using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Source of the conversation initiation</summary>
[JsonConverter(
    typeof(ConversationInitiationClientDataSourceInfoSource.ConversationInitiationClientDataSourceInfoSourceSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataSourceInfoSource : IStringEnum
{
    public static readonly ConversationInitiationClientDataSourceInfoSource Unknown = new(
        Values.Unknown
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource AndroidSdk = new(
        Values.AndroidSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource NodeJsSdk = new(
        Values.NodeJsSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource ReactNativeSdk = new(
        Values.ReactNativeSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource ReactSdk = new(
        Values.ReactSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource JsSdk = new(
        Values.JsSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource PythonSdk = new(
        Values.PythonSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Widget = new(
        Values.Widget
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource SipTrunk = new(
        Values.SipTrunk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Twilio = new(
        Values.Twilio
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Exotel = new(
        Values.Exotel
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Genesys = new(
        Values.Genesys
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Avaya = new(
        Values.Avaya
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Audiocodes = new(
        Values.Audiocodes
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource SwiftSdk = new(
        Values.SwiftSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource Whatsapp = new(
        Values.Whatsapp
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource TwilioSms = new(
        Values.TwilioSms
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource FlutterSdk = new(
        Values.FlutterSdk
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource ZendeskIntegration =
        new(Values.ZendeskIntegration);

    public static readonly ConversationInitiationClientDataSourceInfoSource SlackIntegration = new(
        Values.SlackIntegration
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource TelegramIntegration =
        new(Values.TelegramIntegration);

    public static readonly ConversationInitiationClientDataSourceInfoSource IntercomIntegration =
        new(Values.IntercomIntegration);

    public static readonly ConversationInitiationClientDataSourceInfoSource FreshdeskIntegration =
        new(Values.FreshdeskIntegration);

    public static readonly ConversationInitiationClientDataSourceInfoSource PlainIntegration = new(
        Values.PlainIntegration
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource SalesforceIntegration =
        new(Values.SalesforceIntegration);

    public static readonly ConversationInitiationClientDataSourceInfoSource TemplatePreview = new(
        Values.TemplatePreview
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource GenesysBotConnector =
        new(Values.GenesysBotConnector);

    public static readonly ConversationInitiationClientDataSourceInfoSource SubagentTool = new(
        Values.SubagentTool
    );

    public static readonly ConversationInitiationClientDataSourceInfoSource AgentMessagesApi = new(
        Values.AgentMessagesApi
    );

    public ConversationInitiationClientDataSourceInfoSource(string value)
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
    public static ConversationInitiationClientDataSourceInfoSource FromCustom(string value)
    {
        return new ConversationInitiationClientDataSourceInfoSource(value);
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

    public static bool operator ==(
        ConversationInitiationClientDataSourceInfoSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationInitiationClientDataSourceInfoSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationInitiationClientDataSourceInfoSource value
    ) => value.Value;

    public static explicit operator ConversationInitiationClientDataSourceInfoSource(
        string value
    ) => new(value);

    internal class ConversationInitiationClientDataSourceInfoSourceSerializer
        : JsonConverter<ConversationInitiationClientDataSourceInfoSource>
    {
        public override ConversationInitiationClientDataSourceInfoSource Read(
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
            return new ConversationInitiationClientDataSourceInfoSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataSourceInfoSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataSourceInfoSource ReadAsPropertyName(
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
            return new ConversationInitiationClientDataSourceInfoSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataSourceInfoSource value,
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

        public const string PlainIntegration = "plain_integration";

        public const string SalesforceIntegration = "salesforce_integration";

        public const string TemplatePreview = "template_preview";

        public const string GenesysBotConnector = "genesys_bot_connector";

        public const string SubagentTool = "subagent_tool";

        public const string AgentMessagesApi = "agent_messages_api";
    }
}
