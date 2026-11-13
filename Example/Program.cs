using ElevenLabs;

var client = new ElevenLabsClient();

await client.History.ListAsync(
    new global::ElevenLabs.ListHistoryRequest
    {
        PageSize = 100,
        StartAfterHistoryItemId = "start_after_history_item_id",
        VoiceId = "voice_id",
        ModelId = "model_id",
        DateBeforeUnix = 8,
        DateAfterUnix = 2,
        SortDirection = global::ElevenLabs.ListHistoryRequestSortDirection.Asc,
        Search = "search",
        Source = global::ElevenLabs.ListHistoryRequestSource.Tts,
        XiApiKey = "xi-api-key",
    }
);
