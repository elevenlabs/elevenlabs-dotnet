using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The LLM to query with the prompt and the chat history. If using data residency, the LLM must be supported in the data residency environment</summary>
[JsonConverter(
    typeof(ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm.ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlmSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm
    : IStringEnum
{
    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4OMini =
        new(Values.Gpt4OMini);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4O =
        new(Values.Gpt4O);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4 =
        new(Values.Gpt4);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4Turbo =
        new(Values.Gpt4Turbo);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt41 =
        new(Values.Gpt41);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt41Mini =
        new(Values.Gpt41Mini);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt41Nano =
        new(Values.Gpt41Nano);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5 =
        new(Values.Gpt5);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt51 =
        new(Values.Gpt51);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt52 =
        new(Values.Gpt52);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt52ChatLatest =
        new(Values.Gpt52ChatLatest);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt54 =
        new(Values.Gpt54);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt54Mini =
        new(Values.Gpt54Mini);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt54Nano =
        new(Values.Gpt54Nano);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt55 =
        new(Values.Gpt55);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt56Sol =
        new(Values.Gpt56Sol);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt56Terra =
        new(Values.Gpt56Terra);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt56Luna =
        new(Values.Gpt56Luna);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt6Astra =
        new(Values.Gpt6Astra);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt6Sol =
        new(Values.Gpt6Sol);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt6Luna =
        new(Values.Gpt6Luna);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt61Sol =
        new(Values.Gpt61Sol);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt61Terra =
        new(Values.Gpt61Terra);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt62Astra =
        new(Values.Gpt62Astra);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt62Sol =
        new(Values.Gpt62Sol);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5Mini =
        new(Values.Gpt5Mini);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5Nano =
        new(Values.Gpt5Nano);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt35Turbo =
        new(Values.Gpt35Turbo);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini15Pro =
        new(Values.Gemini15Pro);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini15Flash =
        new(Values.Gemini15Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini20Flash =
        new(Values.Gemini20Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini20FlashLite =
        new(Values.Gemini20FlashLite);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25FlashLite =
        new(Values.Gemini25FlashLite);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25Flash =
        new(Values.Gemini25Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini3ProPreview =
        new(Values.Gemini3ProPreview);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini3FlashPreview =
        new(Values.Gemini3FlashPreview);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini31ProPreview =
        new(Values.Gemini31ProPreview);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini31FlashLitePreview =
        new(Values.Gemini31FlashLitePreview);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini31FlashLite =
        new(Values.Gemini31FlashLite);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini35Flash =
        new(Values.Gemini35Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini35FlashLite =
        new(Values.Gemini35FlashLite);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini36Flash =
        new(Values.Gemini36Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini37Flash =
        new(Values.Gemini37Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini38Flash =
        new(Values.Gemini38Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini4Argon =
        new(Values.Gemini4Argon);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini4Hydrogen =
        new(Values.Gemini4Hydrogen);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini4Neon =
        new(Values.Gemini4Neon);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet45 =
        new(Values.ClaudeSonnet45);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeOpus46 =
        new(Values.ClaudeOpus46);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeOpus47 =
        new(Values.ClaudeOpus47);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeOpus48 =
        new(Values.ClaudeOpus48);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeOpus5 =
        new(Values.ClaudeOpus5);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeOpus55 =
        new(Values.ClaudeOpus55);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet46 =
        new(Values.ClaudeSonnet46);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet5 =
        new(Values.ClaudeSonnet5);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet55 =
        new(Values.ClaudeSonnet55);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet4 =
        new(Values.ClaudeSonnet4);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeHaiku45 =
        new(Values.ClaudeHaiku45);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeHaiku55 =
        new(Values.ClaudeHaiku55);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude37Sonnet =
        new(Values.Claude37Sonnet);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude35Sonnet =
        new(Values.Claude35Sonnet);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude35SonnetV1 =
        new(Values.Claude35SonnetV1);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude3Haiku =
        new(Values.Claude3Haiku);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm CustomLlm =
        new(Values.CustomLlm);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Qwen34B =
        new(Values.Qwen34B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Qwen330Ba3B =
        new(Values.Qwen330Ba3B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Qwen3635Ba3B =
        new(Values.Qwen3635Ba3B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Qwen35397Ba17B =
        new(Values.Qwen35397Ba17B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm GptOss20B =
        new(Values.GptOss20B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm GptOss120B =
        new(Values.GptOss120B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Glm45AirFp8 =
        new(Values.Glm45AirFp8);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Glm52 =
        new(Values.Glm52);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm DeepseekV41Flash =
        new(Values.DeepseekV41Flash);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Nemotron35SuperVlNvfp4 =
        new(Values.Nemotron35SuperVlNvfp4);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25FlashPreview092025 =
        new(Values.Gemini25FlashPreview092025);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25FlashLitePreview092025 =
        new(Values.Gemini25FlashLitePreview092025);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25FlashPreview0520 =
        new(Values.Gemini25FlashPreview0520);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25FlashPreview0417 =
        new(Values.Gemini25FlashPreview0417);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini25FlashLitePreview0617 =
        new(Values.Gemini25FlashLitePreview0617);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini20FlashLite001 =
        new(Values.Gemini20FlashLite001);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini20Flash001 =
        new(Values.Gemini20Flash001);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini15Flash002 =
        new(Values.Gemini15Flash002);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini15Flash001 =
        new(Values.Gemini15Flash001);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini15Pro002 =
        new(Values.Gemini15Pro002);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gemini15Pro001 =
        new(Values.Gemini15Pro001);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet420250514 =
        new(Values.ClaudeSonnet420250514);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeSonnet4520250929 =
        new(Values.ClaudeSonnet4520250929);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ClaudeHaiku4520251001 =
        new(Values.ClaudeHaiku4520251001);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude37Sonnet20250219 =
        new(Values.Claude37Sonnet20250219);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude35Sonnet20240620 =
        new(Values.Claude35Sonnet20240620);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude35SonnetV220241022 =
        new(Values.Claude35SonnetV220241022);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Claude3Haiku20240307 =
        new(Values.Claude3Haiku20240307);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt520250807 =
        new(Values.Gpt520250807);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5120251113 =
        new(Values.Gpt5120251113);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5220251211 =
        new(Values.Gpt5220251211);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5420260305 =
        new(Values.Gpt5420260305);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt54Mini20260317 =
        new(Values.Gpt54Mini20260317);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt54Nano20260317 =
        new(Values.Gpt54Nano20260317);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5520260423 =
        new(Values.Gpt5520260423);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5Mini20250807 =
        new(Values.Gpt5Mini20250807);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt5Nano20250807 =
        new(Values.Gpt5Nano20250807);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4120250414 =
        new(Values.Gpt4120250414);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt41Mini20250414 =
        new(Values.Gpt41Mini20250414);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt41Nano20250414 =
        new(Values.Gpt41Nano20250414);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4OMini20240718 =
        new(Values.Gpt4OMini20240718);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4O20241120 =
        new(Values.Gpt4O20241120);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4O20240806 =
        new(Values.Gpt4O20240806);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4O20240513 =
        new(Values.Gpt4O20240513);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt40613 =
        new(Values.Gpt40613);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt40314 =
        new(Values.Gpt40314);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt4Turbo20240409 =
        new(Values.Gpt4Turbo20240409);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt35Turbo0125 =
        new(Values.Gpt35Turbo0125);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Gpt35Turbo1106 =
        new(Values.Gpt35Turbo1106);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm WattTool8B =
        new(Values.WattTool8B);

    public static readonly ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm WattTool70B =
        new(Values.WattTool70B);

    public ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm(string value)
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
    public static ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm FromCustom(
        string value
    )
    {
        return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm(value);
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
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm value
    ) => value.Value;

    public static explicit operator ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm(
        string value
    ) => new(value);

    internal class ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlmSerializer
        : JsonConverter<ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm>
    {
        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm Read(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm ReadAsPropertyName(
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
            return new ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataConversationConfigOverrideAgentPromptLlm value,
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
        public const string Gpt4OMini = "gpt-4o-mini";

        public const string Gpt4O = "gpt-4o";

        public const string Gpt4 = "gpt-4";

        public const string Gpt4Turbo = "gpt-4-turbo";

        public const string Gpt41 = "gpt-4.1";

        public const string Gpt41Mini = "gpt-4.1-mini";

        public const string Gpt41Nano = "gpt-4.1-nano";

        public const string Gpt5 = "gpt-5";

        public const string Gpt51 = "gpt-5.1";

        public const string Gpt52 = "gpt-5.2";

        public const string Gpt52ChatLatest = "gpt-5.2-chat-latest";

        public const string Gpt54 = "gpt-5.4";

        public const string Gpt54Mini = "gpt-5.4-mini";

        public const string Gpt54Nano = "gpt-5.4-nano";

        public const string Gpt55 = "gpt-5.5";

        public const string Gpt56Sol = "gpt-5.6-sol";

        public const string Gpt56Terra = "gpt-5.6-terra";

        public const string Gpt56Luna = "gpt-5.6-luna";

        public const string Gpt6Astra = "gpt-6-astra";

        public const string Gpt6Sol = "gpt-6-sol";

        public const string Gpt6Luna = "gpt-6-luna";

        public const string Gpt61Sol = "gpt-6.1-sol";

        public const string Gpt61Terra = "gpt-6.1-terra";

        public const string Gpt62Astra = "gpt-6.2-astra";

        public const string Gpt62Sol = "gpt-6.2-sol";

        public const string Gpt5Mini = "gpt-5-mini";

        public const string Gpt5Nano = "gpt-5-nano";

        public const string Gpt35Turbo = "gpt-3.5-turbo";

        public const string Gemini15Pro = "gemini-1.5-pro";

        public const string Gemini15Flash = "gemini-1.5-flash";

        public const string Gemini20Flash = "gemini-2.0-flash";

        public const string Gemini20FlashLite = "gemini-2.0-flash-lite";

        public const string Gemini25FlashLite = "gemini-2.5-flash-lite";

        public const string Gemini25Flash = "gemini-2.5-flash";

        public const string Gemini3ProPreview = "gemini-3-pro-preview";

        public const string Gemini3FlashPreview = "gemini-3-flash-preview";

        public const string Gemini31ProPreview = "gemini-3.1-pro-preview";

        public const string Gemini31FlashLitePreview = "gemini-3.1-flash-lite-preview";

        public const string Gemini31FlashLite = "gemini-3.1-flash-lite";

        public const string Gemini35Flash = "gemini-3.5-flash";

        public const string Gemini35FlashLite = "gemini-3.5-flash-lite";

        public const string Gemini36Flash = "gemini-3.6-flash";

        public const string Gemini37Flash = "gemini-3.7-flash";

        public const string Gemini38Flash = "gemini-3.8-flash";

        public const string Gemini4Argon = "gemini-4-argon";

        public const string Gemini4Hydrogen = "gemini-4-hydrogen";

        public const string Gemini4Neon = "gemini-4-neon";

        public const string ClaudeSonnet45 = "claude-sonnet-4-5";

        public const string ClaudeOpus46 = "claude-opus-4-6";

        public const string ClaudeOpus47 = "claude-opus-4-7";

        public const string ClaudeOpus48 = "claude-opus-4-8";

        public const string ClaudeOpus5 = "claude-opus-5";

        public const string ClaudeOpus55 = "claude-opus-5-5";

        public const string ClaudeSonnet46 = "claude-sonnet-4-6";

        public const string ClaudeSonnet5 = "claude-sonnet-5";

        public const string ClaudeSonnet55 = "claude-sonnet-5-5";

        public const string ClaudeSonnet4 = "claude-sonnet-4";

        public const string ClaudeHaiku45 = "claude-haiku-4-5";

        public const string ClaudeHaiku55 = "claude-haiku-5-5";

        public const string Claude37Sonnet = "claude-3-7-sonnet";

        public const string Claude35Sonnet = "claude-3-5-sonnet";

        public const string Claude35SonnetV1 = "claude-3-5-sonnet-v1";

        public const string Claude3Haiku = "claude-3-haiku";

        public const string CustomLlm = "custom-llm";

        public const string Qwen34B = "qwen3-4b";

        public const string Qwen330Ba3B = "qwen3-30b-a3b";

        public const string Qwen3635Ba3B = "qwen36-35b-a3b";

        public const string Qwen35397Ba17B = "qwen35-397b-a17b";

        public const string GptOss20B = "gpt-oss-20b";

        public const string GptOss120B = "gpt-oss-120b";

        public const string Glm45AirFp8 = "glm-45-air-fp8";

        public const string Glm52 = "glm-52";

        public const string DeepseekV41Flash = "deepseek-v41-flash";

        public const string Nemotron35SuperVlNvfp4 = "nemotron-35-super-vl-nvfp4";

        public const string Gemini25FlashPreview092025 = "gemini-2.5-flash-preview-09-2025";

        public const string Gemini25FlashLitePreview092025 =
            "gemini-2.5-flash-lite-preview-09-2025";

        public const string Gemini25FlashPreview0520 = "gemini-2.5-flash-preview-05-20";

        public const string Gemini25FlashPreview0417 = "gemini-2.5-flash-preview-04-17";

        public const string Gemini25FlashLitePreview0617 = "gemini-2.5-flash-lite-preview-06-17";

        public const string Gemini20FlashLite001 = "gemini-2.0-flash-lite-001";

        public const string Gemini20Flash001 = "gemini-2.0-flash-001";

        public const string Gemini15Flash002 = "gemini-1.5-flash-002";

        public const string Gemini15Flash001 = "gemini-1.5-flash-001";

        public const string Gemini15Pro002 = "gemini-1.5-pro-002";

        public const string Gemini15Pro001 = "gemini-1.5-pro-001";

        public const string ClaudeSonnet420250514 = "claude-sonnet-4@20250514";

        public const string ClaudeSonnet4520250929 = "claude-sonnet-4-5@20250929";

        public const string ClaudeHaiku4520251001 = "claude-haiku-4-5@20251001";

        public const string Claude37Sonnet20250219 = "claude-3-7-sonnet@20250219";

        public const string Claude35Sonnet20240620 = "claude-3-5-sonnet@20240620";

        public const string Claude35SonnetV220241022 = "claude-3-5-sonnet-v2@20241022";

        public const string Claude3Haiku20240307 = "claude-3-haiku@20240307";

        public const string Gpt520250807 = "gpt-5-2025-08-07";

        public const string Gpt5120251113 = "gpt-5.1-2025-11-13";

        public const string Gpt5220251211 = "gpt-5.2-2025-12-11";

        public const string Gpt5420260305 = "gpt-5.4-2026-03-05";

        public const string Gpt54Mini20260317 = "gpt-5.4-mini-2026-03-17";

        public const string Gpt54Nano20260317 = "gpt-5.4-nano-2026-03-17";

        public const string Gpt5520260423 = "gpt-5.5-2026-04-23";

        public const string Gpt5Mini20250807 = "gpt-5-mini-2025-08-07";

        public const string Gpt5Nano20250807 = "gpt-5-nano-2025-08-07";

        public const string Gpt4120250414 = "gpt-4.1-2025-04-14";

        public const string Gpt41Mini20250414 = "gpt-4.1-mini-2025-04-14";

        public const string Gpt41Nano20250414 = "gpt-4.1-nano-2025-04-14";

        public const string Gpt4OMini20240718 = "gpt-4o-mini-2024-07-18";

        public const string Gpt4O20241120 = "gpt-4o-2024-11-20";

        public const string Gpt4O20240806 = "gpt-4o-2024-08-06";

        public const string Gpt4O20240513 = "gpt-4o-2024-05-13";

        public const string Gpt40613 = "gpt-4-0613";

        public const string Gpt40314 = "gpt-4-0314";

        public const string Gpt4Turbo20240409 = "gpt-4-turbo-2024-04-09";

        public const string Gpt35Turbo0125 = "gpt-3.5-turbo-0125";

        public const string Gpt35Turbo1106 = "gpt-3.5-turbo-1106";

        public const string WattTool8B = "watt-tool-8b";

        public const string WattTool70B = "watt-tool-70b";
    }
}
