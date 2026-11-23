using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily.ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamilySerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily
    : IStringEnum
{
    public static readonly ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily Turbo =
        new(Values.Turbo);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily Flash =
        new(Values.Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily Multilingual =
        new(Values.Multilingual);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily V3Conversational =
        new(Values.V3Conversational);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily V4 =
        new(Values.V4);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily V4Turbo =
        new(Values.V4Turbo);

    public ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily(
        string value
    )
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
    public static ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily FromCustom(
        string value
    )
    {
        return new ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily(
            value
        );
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
        ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily value
    ) => value.Value;

    public static explicit operator ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily(
        string value
    ) => new(value);

    internal class ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamilySerializer
        : JsonConverter<ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily>
    {
        public override ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily Read(
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
            return new ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily ReadAsPropertyName(
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
            return new ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideTtsSupportedVoicesItemModelFamily value,
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
        public const string Turbo = "turbo";

        public const string Flash = "flash";

        public const string Multilingual = "multilingual";

        public const string V3Conversational = "v3_conversational";

        public const string V4 = "v4";

        public const string V4Turbo = "v4_turbo";
    }
}
