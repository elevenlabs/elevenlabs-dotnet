# Reference

## HistoryService

### `ListAsync`

`GET /v1/history`

Get generated items

**Parameters:**

- `pageSize`
- `startAfterHistoryItemId`
- `voiceId`
- `modelId`
- `dateBeforeUnix`
- `dateAfterUnix`
- `sortDirection`
- `search`
- `source`

### `GetAsync`

`GET /v1/history/{history_item_id}`

Get history item

**Parameters:**

- `historyItemId` (required)

### `DeleteAsync`

`DELETE /v1/history/{history_item_id}`

Delete history item

**Parameters:**

- `historyItemId` (required)

### `GetAudioAsync`

`GET /v1/history/{history_item_id}/audio`

Get audio from history item

**Parameters:**

- `historyItemId` (required)

### `DownloadAsync`

`POST /v1/history/download`

Download history items

## TextToSoundEffectsService

### `ConvertAsync`

`POST /v1/sound-generation`

Create sound effect

**Parameters:**

- `outputFormat`
- `enableLogging`

## AudioIsolationService

### `ConvertAsync`

`POST /v1/audio-isolation`

Audio isolation

### `ListAsync`

`GET /v1/audio-isolation/history`

Get Audio Isolation History

**Parameters:**

- `pageSize`
- `page`
- `search`

### `DeleteAsync`

`DELETE /v1/audio-isolation/history/{history_item_id}`

Delete Audio Isolation History Item

**Parameters:**

- `historyItemId` (required)

### `StreamAsync`

`POST /v1/audio-isolation/stream`

Audio isolation stream

## AudioEffectsService

### `GetCatalogAsync`

`GET /v1/audio-effects/catalog`

Get Audio Effects Catalog

## SamplesService

### `DeleteAsync`

`DELETE /v1/voices/{voice_id}/samples/{sample_id}`

Delete voice sample

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

### `CreateAsync`

`POST /v1/voices/pvc/{voice_id}/samples`

Add Samples To Pvc Voice

**Parameters:**

- `voiceId` (required)

### `UpdateAsync`

`POST /v1/voices/pvc/{voice_id}/samples/{sample_id}`

Update Pvc Voice Sample

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

### `DeleteAsync1`

`DELETE /v1/voices/pvc/{voice_id}/samples/{sample_id}`

Delete Pvc Voice Sample

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

## AudioService

### `GetAsync`

`GET /v1/voices/{voice_id}/samples/{sample_id}/audio`

Get audio from sample

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

### `GetAsync1`

`GET /v1/dubbing/{dubbing_id}/audio/{language_code}`

Get dubbed audio

**Parameters:**

- `dubbingId` (required)
- `languageCode` (required)

### `GetAsync2`

`GET /v1/convai/conversations/{conversation_id}/audio`

Get Conversation Audio

**Parameters:**

- `conversationId` (required)

### `GetAsync3`

`GET /v1/voices/pvc/{voice_id}/samples/{sample_id}/audio`

Retrieve Voice Sample Audio

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)
- `removeBackgroundNoise`

### `GetAsync4`

`GET /v1/voices/pvc/{voice_id}/samples/{sample_id}/speakers/{speaker_id}/audio`

Retrieve Separated Speaker Audio

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)
- `speakerId` (required)

## TextToSpeechService

### `ConvertAsync`

`POST /v1/text-to-speech/{voice_id}`

Create speech

**Parameters:**

- `voiceId` (required)
- `enableLogging`
- `optimizeStreamingLatency`
- `outputFormat`

### `ConvertWithTimestampsAsync`

`POST /v1/text-to-speech/{voice_id}/with-timestamps`

Create speech with timing

**Parameters:**

- `voiceId` (required)
- `enableLogging`
- `optimizeStreamingLatency`
- `outputFormat`

### `StreamAsync`

`POST /v1/text-to-speech/{voice_id}/stream`

Stream speech

**Parameters:**

- `voiceId` (required)
- `enableLogging`
- `optimizeStreamingLatency`
- `outputFormat`

### `StreamWithTimestampsAsync`

`POST /v1/text-to-speech/{voice_id}/stream/with-timestamps`

Stream speech with timing

**Parameters:**

- `voiceId` (required)
- `enableLogging`
- `optimizeStreamingLatency`
- `outputFormat`

### `ListAsync`

`GET /v1/flows/text-to-speech`

List Speech Generations

**Parameters:**

- `cursor`
- `pageSize`
- `status`
- `modelId`

### `CreateAsync`

`POST /v1/flows/text-to-speech`

Create Speech Generation

### `GetAsync`

`GET /v1/flows/text-to-speech/{generation_id}`

Get Speech Generation

**Parameters:**

- `generationId` (required)

## TextToDialogueService

### `ConvertAsync`

`POST /v1/text-to-dialogue`

Create dialogue

**Parameters:**

- `outputFormat`
- `enableLogging`

### `StreamAsync`

`POST /v1/text-to-dialogue/stream`

Stream dialogue

**Parameters:**

- `outputFormat`
- `enableLogging`

### `StreamWithTimestampsAsync`

`POST /v1/text-to-dialogue/stream/with-timestamps`

Text To Dialogue Streaming With Timestamps

**Parameters:**

- `outputFormat`
- `enableLogging`

### `ConvertWithTimestampsAsync`

`POST /v1/text-to-dialogue/with-timestamps`

Text To Dialogue With Timestamps

**Parameters:**

- `outputFormat`
- `enableLogging`

## SpeechToSpeechService

### `ConvertAsync`

`POST /v1/voice-changer/{voice_id}`

Voice changer

**Parameters:**

- `voiceId` (required)
- `enableLogging`
- `optimizeStreamingLatency`
- `outputFormat`

### `StreamAsync`

`POST /v1/voice-changer/{voice_id}/stream`

Voice changer stream

**Parameters:**

- `voiceId` (required)
- `enableLogging`
- `optimizeStreamingLatency`
- `outputFormat`

## TextToVoiceService

### `CreateAsync`

`POST /v1/text-to-voice`

Create A New Voice From Voice Preview

### `DesignAsync`

`POST /v1/text-to-voice/design`

Design A Voice.

**Parameters:**

- `outputFormat`

### `RemixAsync`

`POST /v1/text-to-voice/{voice_id}/remix`

Remix A Voice.

**Parameters:**

- `voiceId` (required)
- `outputFormat`

## PreviewService

### `StreamAsync`

`GET /v1/text-to-voice/{generated_voice_id}/stream`

Text To Voice Preview Streaming

**Parameters:**

- `generatedVoiceId` (required)

## UserService

### `GetAsync`

`GET /v1/user`

Get user

## SubscriptionService

### `GetAsync`

`GET /v1/user/subscription`

Get user subscription

## CollectionsService

### `ListAsync`

`GET /v1/voices/collections`

List Voice Collections

### `CreateAsync`

`POST /v1/voices/collections`

Create Voice Collection

### `GetAsync`

`GET /v1/voices/collections/{collection_id}`

Get Voice Collection

**Parameters:**

- `collectionId` (required)

### `UpdateAsync`

`PATCH /v1/voices/collections/{collection_id}`

Update Voice Collection

**Parameters:**

- `collectionId` (required)

### `DeleteAsync`

`DELETE /v1/voices/collections/{collection_id}`

Delete Voice Collection

**Parameters:**

- `collectionId` (required)

### `AddVoiceAsync`

`POST /v1/voices/collections/{collection_id}/voice/{voice_id}`

Add Voice To Collection

**Parameters:**

- `collectionId` (required)
- `voiceId` (required)

### `RemoveVoiceAsync`

`DELETE /v1/voices/collections/{collection_id}/voice/{voice_id}`

Remove Voice From Collection

**Parameters:**

- `collectionId` (required)
- `voiceId` (required)

## SettingsService

### `GetDefaultAsync`

`GET /v1/voices/settings/default`

Get default voice settings

### `GetAsync`

`GET /v1/voices/{voice_id}/settings`

Get voice settings

**Parameters:**

- `voiceId` (required)

### `UpdateAsync`

`POST /v1/voices/{voice_id}/settings/edit`

Edit voice settings

**Parameters:**

- `voiceId` (required)

### `GetAsync1`

`GET /v1/convai/settings`

Get Convai Settings

### `UpdateAsync1`

`PATCH /v1/convai/settings`

Update Convai Settings

### `GetAsync2`

`GET /v1/convai/settings/dashboard`

Get Convai Dashboard Settings

### `UpdateAsync2`

`PATCH /v1/convai/settings/dashboard`

Update Convai Dashboard Settings

## AccentsService

### `GetAsync`

`GET /v1/voices/accents`

Get Voice Accents

**Parameters:**

- `language`
- `modelId`

## VoicesService

### `GetAsync`

`GET /v1/voices/{voice_id}`

Get voice

**Parameters:**

- `voiceId` (required)
- `withSettings`

### `DeleteAsync`

`DELETE /v1/voices/{voice_id}`

Delete voice

**Parameters:**

- `voiceId` (required)

### `UpdateAsync`

`POST /v1/voices/{voice_id}/edit`

Edit voice

**Parameters:**

- `voiceId` (required)

### `SearchAsync`

`GET /v2/voices`

List voices

**Parameters:**

- `nextPageToken`
- `pageSize`
- `search`
- `sort`
- `sortDirection`
- `voiceType`
- `category`
- `fineTuningState`
- `collectionId`
- `gender`
- `age`
- `language`
- `accent`
- `useCases`
- `minNoticePeriodDays`
- `includeCustomRates`
- `includeLiveModerated`
- `highQuality`
- `includeTotalCount`
- `voiceIds`

### `ReplicateToIsolatedEnvironmentAsync`

`POST /v1/voices/{voice_id}/replicate-to-isolated-environment`

Replicate Voice To Isolated Environment

**Parameters:**

- `voiceId` (required)

### `ShareAsync`

`POST /v1/voices/add/{public_user_id}/{voice_id}`

Add shared voice

**Parameters:**

- `publicUserId` (required)
- `voiceId` (required)

### `FindSimilarVoicesAsync`

`POST /v1/similar-voices`

List similar voices

### `GetSharedAsync`

`GET /v1/shared-voices`

Get shared voices

**Parameters:**

- `pageSize`
- `category`
- `gender`
- `age`
- `accent`
- `language`
- `locale`
- `search`
- `useCases`
- `descriptives`
- `featured`
- `minNoticePeriodDays`
- `includeCustomRates`
- `includeLiveModerated`
- `readerAppEnabled`
- `ownerId`
- `sort`
- `page`

## IvcService

### `CreateAsync`

`POST /v1/voices/add`

Create voice clone

## StudioService

### `CreatePodcastAsync`

`POST /v1/studio/podcasts`

Create Podcast

## PronunciationDictionariesService

### `CreateAsync`

`POST /v1/studio/projects/{project_id}/pronunciation-dictionaries`

Create Pronunciation Dictionaries

**Parameters:**

- `projectId` (required)

### `CreateFromFileAsync`

`POST /v1/pronunciation-dictionaries/add-from-file`

Create a pronunciation dictionary from a file

### `CreateFromRulesAsync`

`POST /v1/pronunciation-dictionaries/add-from-rules`

Create a pronunciation dictionary from rules

### `GetAsync`

`GET /v1/pronunciation-dictionaries/{pronunciation_dictionary_id}`

Get pronunciation dictionary

**Parameters:**

- `pronunciationDictionaryId` (required)

### `UpdateAsync`

`PATCH /v1/pronunciation-dictionaries/{pronunciation_dictionary_id}`

Update Pronunciation Dictionary

**Parameters:**

- `pronunciationDictionaryId` (required)

### `DownloadAsync`

`GET /v1/pronunciation-dictionaries/{dictionary_id}/{version_id}/download`

Get pronunciation dictionary by version

**Parameters:**

- `dictionaryId` (required)
- `versionId` (required)

### `ListAsync`

`GET /v1/pronunciation-dictionaries`

List pronunciation dictionaries

**Parameters:**

- `cursor`
- `pageSize`
- `sort`
- `sortDirection`
- `includeArchived`

## ProjectsService

### `ListAsync`

`GET /v1/studio/projects`

List Studio Projects

### `CreateAsync`

`POST /v1/studio/projects`

Create Studio Project

### `GetAsync`

`GET /v1/studio/projects/{project_id}`

Get Studio Project

**Parameters:**

- `projectId` (required)
- `shareId`

### `UpdateAsync`

`POST /v1/studio/projects/{project_id}`

Update Studio Project

**Parameters:**

- `projectId` (required)

### `DeleteAsync`

`DELETE /v1/studio/projects/{project_id}`

Delete Studio Project

**Parameters:**

- `projectId` (required)

### `ConvertAsync`

`POST /v1/studio/projects/{project_id}/convert`

Convert Studio Project

**Parameters:**

- `projectId` (required)

### `GetMutedTracksAsync`

`GET /v1/studio/projects/{project_id}/muted-tracks`

Get Project Muted Tracks

**Parameters:**

- `projectId` (required)

## ContentService

### `UpdateAsync`

`POST /v1/studio/projects/{project_id}/content`

Update Studio Project Content

**Parameters:**

- `projectId` (required)

## SnapshotsService

### `ListAsync`

`GET /v1/studio/projects/{project_id}/snapshots`

List Studio Project Snapshots

**Parameters:**

- `projectId` (required)

### `GetAsync`

`GET /v1/studio/projects/{project_id}/snapshots/{project_snapshot_id}`

Get Project Snapshot

**Parameters:**

- `projectId` (required)
- `projectSnapshotId` (required)

### `StreamAsync`

`POST /v1/studio/projects/{project_id}/snapshots/{project_snapshot_id}/stream`

Stream Studio Project Audio

**Parameters:**

- `projectId` (required)
- `projectSnapshotId` (required)

### `StreamArchiveAsync`

`POST /v1/studio/projects/{project_id}/snapshots/{project_snapshot_id}/archive`

Stream Archive With Studio Project Audio

**Parameters:**

- `projectId` (required)
- `projectSnapshotId` (required)

### `ListAsync1`

`GET /v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots`

List Chapter Snapshots

**Parameters:**

- `projectId` (required)
- `chapterId` (required)

### `GetAsync1`

`GET /v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots/{chapter_snapshot_id}`

Get Chapter Snapshot

**Parameters:**

- `projectId` (required)
- `chapterId` (required)
- `chapterSnapshotId` (required)

### `StreamAsync1`

`POST /v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots/{chapter_snapshot_id}/stream`

Stream Chapter Audio

**Parameters:**

- `projectId` (required)
- `chapterId` (required)
- `chapterSnapshotId` (required)

## ChaptersService

### `ListAsync`

`GET /v1/studio/projects/{project_id}/chapters`

List Chapters

**Parameters:**

- `projectId` (required)

### `CreateAsync`

`POST /v1/studio/projects/{project_id}/chapters`

Create Chapter

**Parameters:**

- `projectId` (required)

### `GetAsync`

`GET /v1/studio/projects/{project_id}/chapters/{chapter_id}`

Get Chapter

**Parameters:**

- `projectId` (required)
- `chapterId` (required)

### `UpdateAsync`

`POST /v1/studio/projects/{project_id}/chapters/{chapter_id}`

Update Chapter

**Parameters:**

- `projectId` (required)
- `chapterId` (required)

### `DeleteAsync`

`DELETE /v1/studio/projects/{project_id}/chapters/{chapter_id}`

Delete Chapter

**Parameters:**

- `projectId` (required)
- `chapterId` (required)

### `ConvertAsync`

`POST /v1/studio/projects/{project_id}/chapters/{chapter_id}/convert`

Convert Chapter

**Parameters:**

- `projectId` (required)
- `chapterId` (required)

## ProjectService

### `ListAsync`

`GET /v1/dubbing/project`

List Dubbing Projects

**Parameters:**

- `cursor`
- `pageSize`
- `status`
- `sortDirection`

### `CreateAsync`

`POST /v1/dubbing/project`

Create Dubbing Project

### `GetAsync`

`GET /v1/dubbing/project/{project_id}`

Get Dubbing Project

**Parameters:**

- `projectId` (required)

### `DeleteAsync`

`DELETE /v1/dubbing/project/{project_id}`

Delete Dubbing Project

**Parameters:**

- `projectId` (required)

## LanguageService

### `ListAsync`

`GET /v1/dubbing/project/{project_id}/language`

List Dubbing Language Targets

**Parameters:**

- `projectId` (required)
- `cursor`
- `pageSize`
- `status`

### `CreateAsync`

`POST /v1/dubbing/project/{project_id}/language`

Create Dubbing Language Target

**Parameters:**

- `projectId` (required)

### `GetAsync`

`GET /v1/dubbing/project/{project_id}/language/{language_id}`

Get Dubbing Language Target

**Parameters:**

- `projectId` (required)
- `languageId` (required)

### `DeleteAsync`

`DELETE /v1/dubbing/project/{project_id}/language/{language_id}`

Delete Dubbing Language Target

**Parameters:**

- `projectId` (required)
- `languageId` (required)

## TranscriptService

### `GetAsync`

`GET /v1/dubbing/project/{project_id}/transcript`

Get Dubbing Transcript

**Parameters:**

- `projectId` (required)

### `UpdateSegmentAsync`

`PATCH /v1/dubbing/project/{project_id}/transcript/segment/{segment_id}`

Update Dubbing Transcript Segment

**Parameters:**

- `projectId` (required)
- `segmentId` (required)

### `DeleteSegmentAsync`

`DELETE /v1/dubbing/project/{project_id}/transcript/segment/{segment_id}`

Delete Dubbing Transcript Segment

**Parameters:**

- `projectId` (required)
- `segmentId` (required)

### `UpdateSegmentsAsync`

`PATCH /v1/dubbing/project/{project_id}/transcript/segments`

Update Dubbing Transcript Segments

**Parameters:**

- `projectId` (required)

### `CreateSegmentAsync`

`POST /v1/dubbing/project/{project_id}/transcript/segment`

Add Dubbing Transcript Segment

**Parameters:**

- `projectId` (required)

### `GetAsync1`

`GET /v1/dubbing/project/{project_id}/language/{language_id}/transcript`

Get Dubbing Target Transcript

**Parameters:**

- `projectId` (required)
- `languageId` (required)

### `UpdateSegmentAsync1`

`PATCH /v1/dubbing/project/{project_id}/language/{language_id}/transcript/segment/{segment_id}`

Update Dubbing Target Transcript Segment

**Parameters:**

- `projectId` (required)
- `languageId` (required)
- `segmentId` (required)

### `UpdateSegmentsAsync1`

`PATCH /v1/dubbing/project/{project_id}/language/{language_id}/transcript/segments`

Update Dubbing Target Transcript Segments

**Parameters:**

- `projectId` (required)
- `languageId` (required)

### `RegenerateAsync`

`POST /v1/dubbing/project/{project_id}/language/{language_id}/transcript/regenerate`

Regenerate Dubbing Target

**Parameters:**

- `projectId` (required)
- `languageId` (required)

## DubbingService

### `ListAsync`

`GET /v1/dubbing`

List Dubs

**Parameters:**

- `cursor`
- `pageSize`
- `dubbingStatus`
- `dubbingStatuses`
- `dubbingModels`
- `targetLanguageCodes`
- `creationSources`
- `filterByCreator`
- `orderBy`
- `orderDirection`

### `CreateAsync`

`POST /v1/dubbing`

Dub a video or audio file

### `GetAsync`

`GET /v1/dubbing/{dubbing_id}`

Get dubbing

**Parameters:**

- `dubbingId` (required)

### `DeleteAsync`

`DELETE /v1/dubbing/{dubbing_id}`

Delete dubbing

**Parameters:**

- `dubbingId` (required)

## TranscriptsService

### `GetAsync`

`GET /v1/dubbing/{dubbing_id}/transcripts/{language_code}/format/{format_type}`

Retrieve A Transcript

**Parameters:**

- `dubbingId` (required)
- `languageCode` (required)
- `formatType` (required)

### `GetAsync1`

`GET /v1/speech-to-text/transcripts/{transcription_id}`

Get Transcript By Id

**Parameters:**

- `transcriptionId` (required)

### `DeleteAsync`

`DELETE /v1/speech-to-text/transcripts/{transcription_id}`

Delete Transcript By Id

**Parameters:**

- `transcriptionId` (required)

## ModelsService

### `ListAsync`

`GET /v1/models`

List models

## AudioNativeService

### `CreateAsync`

`POST /v1/audio-native`

Create audio native project

### `GetSettingsAsync`

`GET /v1/audio-native/{project_id}/settings`

Get Audio Native Project Settings

**Parameters:**

- `projectId` (required)

### `UpdateAsync`

`POST /v1/audio-native/{project_id}/content`

Update audio native project

**Parameters:**

- `projectId` (required)

### `UpdateContentFromUrlAsync`

`POST /v1/audio-native/content`

Update Audio-Native Content From Url

## RulesService

### `SetAsync`

`POST /v1/pronunciation-dictionaries/{pronunciation_dictionary_id}/set-rules`

Set pronunciation dictionary rules

**Parameters:**

- `pronunciationDictionaryId` (required)

### `AddAsync`

`POST /v1/pronunciation-dictionaries/{pronunciation_dictionary_id}/add-rules`

Add pronunciation dictionary rules

**Parameters:**

- `pronunciationDictionaryId` (required)

### `RemoveAsync`

`POST /v1/pronunciation-dictionaries/{pronunciation_dictionary_id}/remove-rules`

Remove pronunciation dictionary rules

**Parameters:**

- `pronunciationDictionaryId` (required)

## ApiKeysService

### `DisableAsync`

`POST /v1/workspaces/api-keys/disable`

Disable API key

**Parameters:**

- `apiKeyName` (required)

### `ListAsync`

`GET /v1/service-accounts/{service_account_user_id}/api-keys`

Get API keys

**Parameters:**

- `serviceAccountUserId` (required)

### `CreateAsync`

`POST /v1/service-accounts/{service_account_user_id}/api-keys`

Create API key

**Parameters:**

- `serviceAccountUserId` (required)

### `UpdateAsync`

`PATCH /v1/service-accounts/{service_account_user_id}/api-keys/{api_key_id}`

Update API key

**Parameters:**

- `serviceAccountUserId` (required)
- `apiKeyId` (required)

### `DeleteAsync`

`DELETE /v1/service-accounts/{service_account_user_id}/api-keys/{api_key_id}`

Delete API key

**Parameters:**

- `serviceAccountUserId` (required)
- `apiKeyId` (required)

### `DisableAsync1`

`POST /v1/service-accounts/{service_account_user_id}/api-keys/{api_key_id}/disable`

Disable Service Account Api Key

**Parameters:**

- `serviceAccountUserId` (required)
- `apiKeyId` (required)

## WorkspaceService

### `SetThirdPartyDisablingPolicyAsync`

`POST /v1/workspaces/api-keys/third-party-disabling`

Set Workspace Third-Party Disabling Policy

## AuditLogsService

### `ListAsync`

`GET /v1/workspace/audit-logs`

Get Workspace Audit Logs

**Parameters:**

- `limit`
- `cursor`
- `timeFromUnixMs`
- `timeToUnixMs`
- `actorUid`
- `className`
- `activityName`

## AuthConnectionsService

### `ListAsync`

`GET /v1/workspace/auth-connections`

Get Workspace Auth Connections

### `CreateAsync`

`POST /v1/workspace/auth-connections`

Create Workspace Auth Connection

### `UpdateAsync`

`PATCH /v1/workspace/auth-connections/{auth_connection_id}`

Update Workspace Auth Connection

**Parameters:**

- `authConnectionId` (required)

### `DeleteAsync`

`DELETE /v1/workspace/auth-connections/{auth_connection_id}`

Delete Workspace Auth Connection

**Parameters:**

- `authConnectionId` (required)

## ServiceAccountsService

### `ListAsync`

`GET /v1/service-accounts`

Get service accounts

### `CreateAsync`

`POST /v1/service-accounts`

Create Service Account

## GroupsService

### `ListAsync`

`GET /v1/workspace/groups`

List workspace groups

### `SearchAsync`

`GET /v1/workspace/groups/search`

Search user group

**Parameters:**

- `name` (required)

## MembersService

### `RemoveAsync`

`POST /v1/workspace/groups/{group_id}/members/remove`

Remove member from user group

**Parameters:**

- `groupId` (required)

### `AddAsync`

`POST /v1/workspace/groups/{group_id}/members`

Add member to user group

**Parameters:**

- `groupId` (required)

### `ListAsync`

`GET /v1/workspace/members`

Get Workspace Members

### `UpdateAsync`

`POST /v1/workspace/members`

Update member

### `UpdateUsageLimitAsync`

`PUT /v1/workspace/members/{user_id}/usage-limit`

Update Member Usage Limit

**Parameters:**

- `userId` (required)

## InvitesService

### `CreateAsync`

`POST /v1/workspace/invites/add`

Invite user

### `CreateBatchAsync`

`POST /v1/workspace/invites/add-bulk`

Invite Multiple Users

### `DeleteAsync`

`DELETE /v1/workspace/invites`

Delete invite

## ResourcesService

### `GetAsync`

`GET /v1/workspace/resources/{resource_id}`

Get Resource

**Parameters:**

- `resourceId` (required)
- `resourceType` (required)

### `ShareAsync`

`POST /v1/workspace/resources/{resource_id}/share`

Share Workspace Resource

**Parameters:**

- `resourceId` (required)

### `UnshareAsync`

`POST /v1/workspace/resources/{resource_id}/unshare`

Unshare Workspace Resource

**Parameters:**

- `resourceId` (required)

## WebhooksService

### `ListAsync`

`GET /v1/workspace/webhooks`

List Workspace Webhooks

**Parameters:**

- `includeUsages`

### `CreateAsync`

`POST /v1/workspace/webhooks`

Create Workspace Webhook

### `UpdateAsync`

`PATCH /v1/workspace/webhooks/{webhook_id}`

Update Workspace Webhook

**Parameters:**

- `webhookId` (required)

### `DeleteAsync`

`DELETE /v1/workspace/webhooks/{webhook_id}`

Delete Workspace Webhook

**Parameters:**

- `webhookId` (required)

## MusicService

### `VideoToMusicAsync`

`POST /v1/music/video-to-music`

Video To Music

**Parameters:**

- `outputFormat`
- `enableLogging`

### `ComposeAsync`

`POST /v1/music`

Compose Music

**Parameters:**

- `outputFormat`
- `enableLogging`

### `ComposeDetailedAsync`

`POST /v1/music/detailed`

Compose Music With A Detailed Response

**Parameters:**

- `outputFormat`
- `enableLogging`

### `ComposeDetailedStreamAsync`

`POST /v1/music/detailed/stream`

Stream Composed Music With A Detailed Response

**Parameters:**

- `outputFormat`
- `enableLogging`

### `StreamAsync`

`POST /v1/music/stream`

Stream Composed Music

**Parameters:**

- `outputFormat`
- `enableLogging`

### `UploadAsync`

`POST /v1/music/upload`

Upload Music

### `SeparateStemsAsync`

`POST /v1/music/stem-separation`

Stem Separation

**Parameters:**

- `outputFormat`
- `enableLogging`

## SpeechToTextService

### `ConvertAsync`

`POST /v1/speech-to-text`

Create transcript

**Parameters:**

- `token`
- `enableLogging`

## SingleUseService

### `CreateAsync`

`POST /v1/single-use-token/{token_type}`

Create Single Use Token

**Parameters:**

- `tokenType` (required)

## ForcedAlignmentService

### `CreateAsync`

`POST /v1/forced-alignment`

Create Forced Alignment

## ConversationsService

### `GetSignedUrlAsync`

`GET /v1/convai/conversation/get-signed-url`

Get Signed Url

**Parameters:**

- `agentId` (required)
- `includeConversationId`
- `branchId`
- `versionId`
- `environment`
- `debugEventsRequest`

### `GetWebrtcTokenAsync`

`GET /v1/convai/conversation/token`

Get a webrtc token to start a conversation with an agent that requires authorization

**Parameters:**

- `agentId` (required)
- `participantName`
- `branchId`
- `versionId`
- `environment`
- `debugEventsRequest`

### `ListAsync`

`GET /v1/convai/conversations`

List conversations

**Parameters:**

- `cursor`
- `agentId`
- `visitedAgentIds`
- `visitedAgentBranchIds`
- `triggeredProcedureIds`
- `callSuccessful`
- `callStartBeforeUnix`
- `callStartAfterUnix`
- `callDurationMinSecs`
- `callDurationMaxSecs`
- `ratingMax`
- `ratingMin`
- `hasFeedbackComment`
- `userId`
- `evaluationParams`
- `dataCollectionParams`
- `dynamicVariableParams`
- `dataCollectionFilter`
- `dynamicVariableFilter`
- `dataCollectionIds`
- `evaluationCriteriaIds`
- `toolNames`
- `toolNamesSuccessful`
- `toolNamesErrored`
- `toolIds`
- `toolIdsSuccessful`
- `toolIdsErrored`
- `includeInvalidToolCalls`
- `mainLanguages`
- `phoneNumberIds`
- `whatsappPhoneNumberIds`
- `pageSize`
- `summaryMode`
- `search`
- `conversationInitiationSource`
- `textOnly`
- `conversationProductType`
- `branchId`
- `versionId`
- `parentConversationId`
- `topicIds`
- `excludeStatuses`
- `tagIds`
- `workflowNodeEnteredId`
- `terminationReasons`
- `guardrailTypes`
- `customGuardrailNames`
- `sortDirection`

### `ResolveAsync`

`GET /v1/convai/conversations/resolve`

Resolve Conversation Reference

**Parameters:**

- `agentId` (required)
- `reference` (required)

### `GetAsync`

`GET /v1/convai/conversations/{conversation_id}`

Get Conversation Details

**Parameters:**

- `conversationId` (required)
- `format`

### `DeleteAsync`

`DELETE /v1/convai/conversations/{conversation_id}`

Delete Conversation

**Parameters:**

- `conversationId` (required)

### `GetSummaryAsync`

`GET /v1/convai/conversations/{conversation_id}/summary`

Get Conversation Summary

**Parameters:**

- `conversationId` (required)
- `maxMessages`

### `GetSipMessagesAsync`

`GET /v1/convai/conversations/{conversation_id}/sip-messages`

Get Sip Messages For A Conversation

**Parameters:**

- `conversationId` (required)
- `pageSize`
- `cursor`

## TwilioService

### `OutboundCallAsync`

`POST /v1/convai/twilio/outbound-call`

Handle An Outbound Call Via Twilio

### `RegisterCallAsync`

`POST /v1/convai/twilio/register-call`

Register A Twilio Call And Return Twiml

## ExotelService

### `OutboundCallAsync`

`POST /v1/convai/exotel/outbound-call`

Handle An Outbound Call Via Exotel

## WhatsappService

### `OutboundCallAsync`

`POST /v1/convai/whatsapp/outbound-call`

Make An Outbound Call Via Whatsapp

### `OutboundMessageAsync`

`POST /v1/convai/whatsapp/outbound-message`

Send An Outbound Message Via Whatsapp

## AgentsService

### `CreateAsync`

`POST /v1/convai/agents/create`

Create agent

**Parameters:**

- `enableVersioning`

### `GetAsync`

`GET /v1/convai/agents/{agent_id}`

Get agent

**Parameters:**

- `agentId` (required)
- `versionId`
- `branchId`
- `includeProcedureGeneratedWorkflowElements`

### `UpdateAsync`

`PATCH /v1/convai/agents/{agent_id}`

Update agent

**Parameters:**

- `agentId` (required)
- `enableVersioningIfNotEnabled`
- `branchId`
- `includeProcedureGeneratedWorkflowElements`

### `DeleteAsync`

`DELETE /v1/convai/agents/{agent_id}`

Delete agent

**Parameters:**

- `agentId` (required)
- `force`

### `ListAsync`

`GET /v1/convai/agents`

List Agents

**Parameters:**

- `pageSize`
- `search`
- `archived`
- `showOnlyOwnedAgents`
- `createdByUserId`
- `tags`
- `sortDirection`
- `sortBy`
- `cursor`

### `DuplicateAsync`

`POST /v1/convai/agents/{agent_id}/duplicate`

Duplicate Agent

**Parameters:**

- `agentId` (required)

### `RunTestsAsync`

`POST /v1/convai/agents/{agent_id}/run-tests`

Run Tests On The Agent

**Parameters:**

- `agentId` (required)

### `RagIndexOverviewAsync`

`GET /v1/convai/knowledge-base/rag-index`

Get Rag Index Overview.

### `GetDocumentRagIndexesAsync`

`GET /v1/convai/knowledge-base/{documentation_id}/rag-index`

Get Rag Indexes Of The Specified Knowledgebase Document.

**Parameters:**

- `documentationId` (required)

### `DeleteDocumentRagIndexAsync`

`DELETE /v1/convai/knowledge-base/{documentation_id}/rag-index/{rag_index_id}`

Delete Rag Index.

**Parameters:**

- `documentationId` (required)
- `ragIndexId` (required)

## SummariesService

### `GetAsync`

`GET /v1/convai/agents/summaries`

Get Agent Summaries

**Parameters:**

- `agentIds` (required)

### `GetAsync1`

`GET /v1/convai/knowledge-base/summaries`

Get Knowledge Base Summaries By Ids

**Parameters:**

- `documentIds` (required)

## WidgetService

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/widget`

Get Agent Widget Config

**Parameters:**

- `agentId` (required)
- `conversationSignature`

## LinkService

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/link`

Get Shareable Agent Link

**Parameters:**

- `agentId` (required)

## AvatarService

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/avatar`

Post Agent Avatar

**Parameters:**

- `agentId` (required)

## HoldAudioService

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/hold-audio`

Post Agent Hold Audio

**Parameters:**

- `agentId` (required)

### `DeleteAsync`

`DELETE /v1/convai/agents/{agent_id}/hold-audio`

Delete Agent Hold Audio

**Parameters:**

- `agentId` (required)

## KnowledgeBaseService

### `SizeAsync`

`GET /v1/convai/agent/{agent_id}/knowledge-base/size`

Returns The Size Of The Agent'S Knowledge Base

**Parameters:**

- `agentId` (required)

### `ListAsync`

`GET /v1/convai/knowledge-base`

Get Knowledge Base List

**Parameters:**

- `pageSize`
- `search`
- `showOnlyOwnedDocuments`
- `createdByUserId`
- `types`
- `parentFolderId`
- `ancestorFolderId`
- `foldersFirst`
- `sortDirection`
- `sortBy`
- `cursor`

### `GetOrCreateRagIndexesAsync`

`POST /v1/convai/knowledge-base/rag-index`

Compute Rag Indexes In Batch

### `SearchAsync`

`GET /v1/convai/knowledge-base/search`

Search Knowledge Base Content

**Parameters:**

- `query` (required)
- `pageSize`
- `types`
- `cursor`

## LlmUsageService

### `CalculateForAgentAsync`

`POST /v1/convai/agent/{agent_id}/llm-usage/calculate`

Calculate Expected Llm Usage For An Agent

**Parameters:**

- `agentId` (required)

### `CalculateAsync`

`POST /v1/convai/llm-usage/calculate`

Calculate Expected Llm Usage

## TestsService

### `CreateAsync`

`POST /v1/convai/agent-testing/create`

Create Agent Response Test

### `MoveAsync`

`POST /v1/convai/agent-testing/bulk-move`

Bulk Move Tests To Folder

### `GetAsync`

`GET /v1/convai/agent-testing/{test_id}`

Get Agent Response Test By Id

**Parameters:**

- `testId` (required)

### `UpdateAsync`

`PUT /v1/convai/agent-testing/{test_id}`

Update Agent Response Test

**Parameters:**

- `testId` (required)

### `DeleteAsync`

`DELETE /v1/convai/agent-testing/{test_id}`

Delete Agent Response Test

**Parameters:**

- `testId` (required)

### `SummariesAsync`

`POST /v1/convai/agent-testing/summaries`

Get Agent Response Test Summaries By Ids

### `ListAsync`

`GET /v1/convai/agent-testing`

List Agent Response Tests

**Parameters:**

- `cursor`
- `pageSize`
- `search`
- `parentFolderId`
- `types`
- `includeFolders`
- `sortMode`
- `sharingMode`
- `createdByUserId`

## FoldersService

### `CreateAsync`

`POST /v1/convai/agent-testing/folders`

Create Agent Test Folder

### `GetAsync`

`GET /v1/convai/agent-testing/folders/{folder_id}`

Get Agent Test Folder By Id

**Parameters:**

- `folderId` (required)

### `UpdateAsync`

`PATCH /v1/convai/agent-testing/folders/{folder_id}`

Update Agent Test Folder

**Parameters:**

- `folderId` (required)

### `DeleteAsync`

`DELETE /v1/convai/agent-testing/folders/{folder_id}`

Delete Agent Test Folder

**Parameters:**

- `folderId` (required)
- `force`

## InvocationsService

### `ListAsync`

`GET /v1/convai/test-invocations`

List Test Invocations

**Parameters:**

- `agentId`
- `branchId`
- `createdByUserId`
- `testId`
- `startTime`
- `endTime`
- `versionId`
- `pageSize`
- `search`
- `cursor`

### `GetAsync`

`GET /v1/convai/test-invocations/{test_invocation_id}`

Get Test Invocation

**Parameters:**

- `testInvocationId` (required)

### `UpdateAsync`

`PATCH /v1/convai/test-invocations/{test_invocation_id}`

Update Test Invocation

**Parameters:**

- `testInvocationId` (required)

### `CancelAsync`

`POST /v1/convai/test-invocations/{test_invocation_id}/cancel`

Cancel Test Invocation

**Parameters:**

- `testInvocationId` (required)

### `ResubmitAsync`

`POST /v1/convai/test-invocations/{test_invocation_id}/resubmit`

Resubmit Tests

**Parameters:**

- `testInvocationId` (required)

## UsersService

### `ListAsync`

`GET /v1/convai/users`

Get Conversation Users

**Parameters:**

- `agentId`
- `branchId`
- `callStartBeforeUnix`
- `callStartAfterUnix`
- `search`
- `pageSize`
- `sortBy`
- `sortDirection`
- `cursor`

## FilesService

### `GetAsync`

`GET /v1/convai/conversations/{conversation_id}/files/{file_id}`

Get Conversation File

**Parameters:**

- `conversationId` (required)
- `fileId` (required)

### `DeleteAsync`

`DELETE /v1/convai/conversations/{conversation_id}/files/{file_id}`

Delete File Upload

**Parameters:**

- `fileId` (required)
- `conversationId` (required)

### `CreateAsync`

`POST /v1/convai/conversations/{conversation_id}/files`

Upload File

**Parameters:**

- `conversationId` (required)

## FeedbackService

### `CreateAsync`

`POST /v1/convai/conversations/{conversation_id}/feedback`

Send Conversation Feedback

**Parameters:**

- `conversationId` (required)

## MessagesService

### `TextSearchAsync`

`GET /v1/convai/conversations/messages/text-search`

Text Search Conversation Messages

**Parameters:**

- `textQuery` (required)
- `agentId`
- `visitedAgentIds`
- `visitedAgentBranchIds`
- `triggeredProcedureIds`
- `callSuccessful`
- `callStartBeforeUnix`
- `callStartAfterUnix`
- `callDurationMinSecs`
- `callDurationMaxSecs`
- `ratingMax`
- `ratingMin`
- `hasFeedbackComment`
- `userId`
- `evaluationParams`
- `dataCollectionParams`
- `dynamicVariableParams`
- `toolNames`
- `toolNamesSuccessful`
- `toolNamesErrored`
- `toolIds`
- `toolIdsSuccessful`
- `toolIdsErrored`
- `includeInvalidToolCalls`
- `mainLanguages`
- `phoneNumberIds`
- `whatsappPhoneNumberIds`
- `excludeStatuses`
- `terminationReasons`
- `pageSize`
- `summaryMode`
- `conversationInitiationSource`
- `textOnly`
- `conversationProductType`
- `branchId`
- `versionId`
- `topicIds`
- `sortBy`
- `cursor`

### `SearchAsync`

`GET /v1/convai/conversations/messages/smart-search`

Smart Search Conversation Messages

**Parameters:**

- `textQuery` (required)
- `agentId`
- `branchId`
- `pageSize`
- `cursor`

## TagsService

### `AssignAsync`

`POST /v1/convai/conversations/{conversation_id}/tags`

Assign Conversation Tags

**Parameters:**

- `conversationId` (required)

### `UnassignAsync`

`DELETE /v1/convai/conversations/{conversation_id}/tags/{tag_id}`

Unassign Conversation Tag

**Parameters:**

- `conversationId` (required)
- `tagId` (required)

### `ListAsync`

`GET /v1/convai/tags`

List Conversation Tags

**Parameters:**

- `pageSize`
- `cursor`

### `CreateAsync`

`POST /v1/convai/tags`

Create Conversation Tag

### `GetAsync`

`GET /v1/convai/tags/{tag_id}`

Get Conversation Tag

**Parameters:**

- `tagId` (required)

### `UpdateAsync`

`PATCH /v1/convai/tags/{tag_id}`

Update Conversation Tag

**Parameters:**

- `tagId` (required)

### `DeleteAsync`

`DELETE /v1/convai/tags/{tag_id}`

Delete Conversation Tag

**Parameters:**

- `tagId` (required)

## TriageTicketsService

### `ListAsync`

`GET /v1/convai/agents/{agent_id}/triage-tickets`

List Agent Conversation Tickets

**Parameters:**

- `agentId` (required)
- `pageSize`
- `conversationId`
- `status`
- `sources`
- `priorities`
- `sortBy`
- `ownerUserId`
- `assigneeUserId`
- `issueType`
- `label`
- `mergedIntoTicketId`
- `search`
- `cursor`

### `CreateManualAsync`

`POST /v1/convai/agents/{agent_id}/triage-tickets`

Create Manual Agent Ticket

**Parameters:**

- `agentId` (required)

### `ListForWorkspaceAsync`

`GET /v1/convai/triage-tickets`

List Workspace Conversation Tickets

**Parameters:**

- `pageSize`
- `agentId`
- `status`
- `sources`
- `priorities`
- `sortBy`
- `ownerUserId`
- `assigneeUserId`
- `issueType`
- `label`
- `mergedIntoTicketId`
- `search`
- `cursor`

### `CreateAsync`

`POST /v1/convai/triage-tickets`

Create Agent Conversation Ticket

### `ListAssignableUsersAsync`

`GET /v1/convai/agents/{agent_id}/triage-tickets/assignable-users`

Get Agent Conversation Ticket Assignable Users

**Parameters:**

- `agentId` (required)

### `GetAsync`

`GET /v1/convai/triage-tickets/{agentqa_ticket_id}`

Get Agent Conversation Ticket

**Parameters:**

- `agentqaTicketId` (required)

### `UpdateAsync`

`PATCH /v1/convai/triage-tickets/{agentqa_ticket_id}`

Update Agent Conversation Ticket

**Parameters:**

- `agentqaTicketId` (required)

### `DeleteAsync`

`DELETE /v1/convai/triage-tickets/{agentqa_ticket_id}`

Delete Agent Conversation Ticket

**Parameters:**

- `agentqaTicketId` (required)

### `AddCommentAsync`

`POST /v1/convai/triage-tickets/{agentqa_ticket_id}/comments`

Add Comment To Agent Conversation Ticket

**Parameters:**

- `agentqaTicketId` (required)

### `MergeAsync`

`POST /v1/convai/triage-tickets/{agentqa_ticket_id}/merge`

Merge Agent Conversation Tickets

**Parameters:**

- `agentqaTicketId` (required)

### `AddTurnCommentAsync`

`POST /v1/convai/triage-tickets/{agentqa_ticket_id}/turn-comments`

Add Turn Comment To Agent Conversation Ticket

**Parameters:**

- `agentqaTicketId` (required)

## PhoneNumbersService

### `ListAsync`

`GET /v1/convai/phone-numbers`

List Phone Numbers

**Parameters:**

- `provider`
- `agentId`
- `branchId`

### `CreateAsync`

`POST /v1/convai/phone-numbers`

Import Phone Number

### `GetAsync`

`GET /v1/convai/phone-numbers/{phone_number_id}`

Get Phone Number

**Parameters:**

- `phoneNumberId` (required)

### `UpdateAsync`

`PATCH /v1/convai/phone-numbers/{phone_number_id}`

Update Phone Number

**Parameters:**

- `phoneNumberId` (required)

### `DeleteAsync`

`DELETE /v1/convai/phone-numbers/{phone_number_id}`

Delete Phone Number

**Parameters:**

- `phoneNumberId` (required)

### `ListV2Async`

`GET /v1/convai/v2/phone-numbers`

List Phone Numbers Page

**Parameters:**

- `pageSize`
- `search`
- `label`
- `phoneNumber`
- `provider`
- `supportsOutbound`
- `agentId`
- `branchId`
- `sortBy`
- `sortDirection`
- `cursor`

### `GetSipMessagesAsync`

`GET /v1/convai/phone-numbers/{phone_number_id}/sip-messages`

Get Sip Messages For A Phone Number

**Parameters:**

- `phoneNumberId` (required)
- `pageSize`
- `cursor`

## LlmService

### `ListAsync`

`GET /v1/convai/llm/list`

List Available Llms

## LiveCountService

### `GetAsync`

`GET /v1/convai/analytics/live-count`

Get Live Count

**Parameters:**

- `agentId`
- `agentIds`

## DocumentsService

### `CreateFromUrlAsync`

`POST /v1/convai/knowledge-base/url`

Create Url Document

### `CreateFromFileAsync`

`POST /v1/convai/knowledge-base/file`

Create File Document

### `CreateFromTextAsync`

`POST /v1/convai/knowledge-base/text`

Create Text Document

### `CreateFolderAsync`

`POST /v1/convai/knowledge-base/folder`

Create Folder

### `GetAsync`

`GET /v1/convai/knowledge-base/{documentation_id}`

Get Documentation From Knowledge Base

**Parameters:**

- `documentationId` (required)
- `agentId`

### `UpdateAsync`

`PATCH /v1/convai/knowledge-base/{documentation_id}`

Update Document

**Parameters:**

- `documentationId` (required)

### `DeleteAsync`

`DELETE /v1/convai/knowledge-base/{documentation_id}`

Delete Knowledge Base Document Or Folder

**Parameters:**

- `documentationId` (required)
- `force`

### `GetAgentsAsync`

`GET /v1/convai/knowledge-base/{documentation_id}/dependent-agents`

Get Dependent Agents List

**Parameters:**

- `documentationId` (required)
- `dependentType`
- `pageSize`
- `cursor`

### `GetBulkAgentsAsync`

`POST /v1/convai/knowledge-base/dependent-agents`

Get Dependent Agents For Multiple Documents

**Parameters:**

- `dependentType`
- `pageSize`
- `cursor`

### `GetContentAsync`

`GET /v1/convai/knowledge-base/{documentation_id}/content`

Get Document Content

**Parameters:**

- `documentationId` (required)

### `GetSourceFileUrlAsync`

`GET /v1/convai/knowledge-base/{documentation_id}/source-file-url`

Get Document Source File Url

**Parameters:**

- `documentationId` (required)

### `MoveAsync`

`POST /v1/convai/knowledge-base/{document_id}/move`

Move Entity To Folder

**Parameters:**

- `documentId` (required)

### `BulkMoveAsync`

`POST /v1/convai/knowledge-base/bulk-move`

Bulk Move Entities To Folder

### `BulkDeleteAsync`

`POST /v1/convai/knowledge-base/bulk-delete`

Bulk Delete Knowledge Base Documents

## CrawlJobsService

### `ListAsync`

`GET /v1/convai/knowledge-base/crawl`

List Ongoing And Recent Crawl Jobs Created By A User

**Parameters:**

- `includeJobIds`
- `pageSize`
- `cursor`

### `CreateAsync`

`POST /v1/convai/knowledge-base/crawl`

Create Crawl Job

### `GetAsync`

`GET /v1/convai/knowledge-base/crawl/{crawl_job_id}`

Get Crawl Job Details

**Parameters:**

- `crawlJobId` (required)

### `CancelAsync`

`POST /v1/convai/knowledge-base/crawl/{crawl_job_id}/cancel`

Cancel Crawl Job

**Parameters:**

- `crawlJobId` (required)

## DocumentService

### `UpdateFileAsync`

`PATCH /v1/convai/knowledge-base/{documentation_id}/update-file`

Update File Document

**Parameters:**

- `documentationId` (required)

### `RefreshAsync`

`POST /v1/convai/knowledge-base/{documentation_id}/refresh`

Refresh Url Document Content

**Parameters:**

- `documentationId` (required)

### `ComputeRagIndexAsync`

`POST /v1/convai/knowledge-base/{documentation_id}/rag-index`

Compute Rag Index.

**Parameters:**

- `documentationId` (required)

## ChunkService

### `GetAsync`

`GET /v1/convai/knowledge-base/{documentation_id}/chunk/{chunk_id}`

Get Documentation Chunk From Knowledge Base

**Parameters:**

- `documentationId` (required)
- `chunkId` (required)
- `embeddingModel`

## ChunksService

### `ListAsync`

`GET /v1/convai/knowledge-base/{documentation_id}/chunks`

Get All Rag Chunks For A Document

**Parameters:**

- `documentationId` (required)
- `embeddingModel` (required)
- `pageSize`
- `cursor`

## TopicsService

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/topics`

Get Agent Conversation Topics

**Parameters:**

- `agentId` (required)
- `pageSize`
- `sortBy`
- `sortDirection`
- `fromUnixSecs`
- `toUnixSecs`
- `includeEvaluationCriteria`
- `cursor`

## ToolsService

### `ListAsync`

`GET /v1/convai/tools`

Get Tools

**Parameters:**

- `search`
- `pageSize`
- `showOnlyOwnedDocuments`
- `createdByUserId`
- `types`
- `sortDirection`
- `sortBy`
- `usedByAgentId`
- `cursor`

### `CreateAsync`

`POST /v1/convai/tools`

Add Tool

### `GetAsync`

`GET /v1/convai/tools/{tool_id}`

Get Tool

**Parameters:**

- `toolId` (required)
- `environment`

### `UpdateAsync`

`PATCH /v1/convai/tools/{tool_id}`

Update Tool

**Parameters:**

- `toolId` (required)

### `DeleteAsync`

`DELETE /v1/convai/tools/{tool_id}`

Delete Tool

**Parameters:**

- `toolId` (required)
- `force`

### `GetDependentAgentsAsync`

`GET /v1/convai/tools/{tool_id}/dependent-agents`

Get Dependent Agents List

**Parameters:**

- `toolId` (required)
- `cursor`
- `pageSize`

### `ListAsync1`

`GET /v1/convai/mcp-servers/{mcp_server_id}/tools`

List Mcp Server Tools

**Parameters:**

- `mcpServerId` (required)
- `environment`

## ExecutionsService

### `GetAsync`

`GET /v1/convai/tools/{tool_id}/executions`

Get Tool Executions

**Parameters:**

- `toolId` (required)
- `cursor`
- `pageSize`
- `isError`
- `agentId`
- `branchId`
- `startTime`
- `endTime`

## AnalysisItemsService

### `ListAsync`

`GET /v1/convai/analysis-items`

List Analysis Items

**Parameters:**

- `search`
- `pageSize`
- `kind`
- `analysisItemIds`
- `createdByUserId`
- `sortDirection`
- `cursor`

### `CreateAsync`

`POST /v1/convai/analysis-items`

Create Analysis Item

### `UpdateAttachmentsAsync`

`PATCH /v1/convai/analysis-items/{analysis_item_id}/attachments`

Update Analysis Item Attachments

**Parameters:**

- `analysisItemId` (required)

### `GetAsync`

`GET /v1/convai/analysis-items/{analysis_item_id}`

Get Analysis Item

**Parameters:**

- `analysisItemId` (required)

### `UpdateAsync`

`PATCH /v1/convai/analysis-items/{analysis_item_id}`

Update Analysis Item

**Parameters:**

- `analysisItemId` (required)

### `DeleteAsync`

`DELETE /v1/convai/analysis-items/{analysis_item_id}`

Delete Analysis Item

**Parameters:**

- `analysisItemId` (required)
- `force`

### `ListVersionsAsync`

`GET /v1/convai/analysis-items/{analysis_item_id}/versions`

List Analysis Item Versions

**Parameters:**

- `analysisItemId` (required)
- `pageSize`
- `cursor`

### `CopyAsync`

`POST /v1/convai/analysis-items/{analysis_item_id}/copy`

Copy Analysis Item

**Parameters:**

- `analysisItemId` (required)

## DependentAgentsService

### `GetAsync`

`GET /v1/convai/analysis-items/{analysis_item_id}/dependent-agents`

Get Analysis Item Dependent Agents

**Parameters:**

- `analysisItemId` (required)
- `pageSize`
- `cursor`

## SecretsService

### `ListAsync`

`GET /v1/convai/secrets`

Get Convai Workspace Secrets

**Parameters:**

- `pageSize`
- `dependencyLimit`
- `search`
- `cursor`

### `CreateAsync`

`POST /v1/convai/secrets`

Create Convai Workspace Secret

### `GetAsync`

`GET /v1/convai/secrets/{secret_id}`

Get Convai Workspace Secret

**Parameters:**

- `secretId` (required)

### `UpdateAsync`

`PATCH /v1/convai/secrets/{secret_id}`

Update Convai Workspace Secret

**Parameters:**

- `secretId` (required)

### `DeleteAsync`

`DELETE /v1/convai/secrets/{secret_id}`

Delete Convai Workspace Secret

**Parameters:**

- `secretId` (required)

### `GetDependenciesAsync`

`GET /v1/convai/secrets/{secret_id}/dependencies/{resource_type}`

Get Secret Dependencies By Type

**Parameters:**

- `secretId` (required)
- `resourceType` (required)
- `pageSize`
- `cursor`

## BatchCallsService

### `CreateAsync`

`POST /v1/convai/batch-calling/submit`

Submit A Batch Call Request.

### `ListAsync`

`GET /v1/convai/batch-calling/workspace`

Get All Batch Calls For A Workspace.

**Parameters:**

- `limit`
- `lastDoc`
- `agentId`

### `GetAsync`

`GET /v1/convai/batch-calling/{batch_id}`

Get A Batch Call By Id.

**Parameters:**

- `batchId` (required)

### `DeleteAsync`

`DELETE /v1/convai/batch-calling/{batch_id}`

Delete A Batch Call.

**Parameters:**

- `batchId` (required)

### `CancelAsync`

`POST /v1/convai/batch-calling/{batch_id}/cancel`

Cancel A Batch Call.

**Parameters:**

- `batchId` (required)

### `RetryAsync`

`POST /v1/convai/batch-calling/{batch_id}/retry`

Retry A Batch Call.

**Parameters:**

- `batchId` (required)

### `ExportAsync`

`GET /v1/convai/batch-calling/{batch_id}/export`

Export Batch Call Results

**Parameters:**

- `batchId` (required)
- `limit`

## SipTrunkService

### `OutboundCallAsync`

`POST /v1/convai/sip-trunk/outbound-call`

Handle An Outbound Call Via Sip Trunk

## McpServersService

### `ListAsync`

`GET /v1/convai/mcp-servers`

List Mcp Servers

### `CreateAsync`

`POST /v1/convai/mcp-servers`

Create Mcp Server

### `GetAsync`

`GET /v1/convai/mcp-servers/{mcp_server_id}`

Get Mcp Server

**Parameters:**

- `mcpServerId` (required)

### `UpdateAsync`

`PATCH /v1/convai/mcp-servers/{mcp_server_id}`

Update Mcp Server Configuration

**Parameters:**

- `mcpServerId` (required)

### `DeleteAsync`

`DELETE /v1/convai/mcp-servers/{mcp_server_id}`

Delete Mcp Server

**Parameters:**

- `mcpServerId` (required)

## ToolApprovalsService

### `CreateAsync`

`POST /v1/convai/mcp-servers/{mcp_server_id}/tool-approvals`

Create Mcp Server Tool Approval

**Parameters:**

- `mcpServerId` (required)

### `DeleteAsync`

`DELETE /v1/convai/mcp-servers/{mcp_server_id}/tool-approvals/{tool_name}`

Delete Mcp Server Tool Approval

**Parameters:**

- `mcpServerId` (required)
- `toolName` (required)

## ToolConfigsService

### `CreateAsync`

`POST /v1/convai/mcp-servers/{mcp_server_id}/tool-configs`

Create Mcp Tool Configuration Override

**Parameters:**

- `mcpServerId` (required)
- `environment`

### `GetAsync`

`GET /v1/convai/mcp-servers/{mcp_server_id}/tool-configs/{tool_name}`

Get Mcp Tool Configuration Override

**Parameters:**

- `mcpServerId` (required)
- `toolName` (required)

### `UpdateAsync`

`PATCH /v1/convai/mcp-servers/{mcp_server_id}/tool-configs/{tool_name}`

Update Mcp Tool Configuration Override

**Parameters:**

- `mcpServerId` (required)
- `toolName` (required)
- `environment`

### `DeleteAsync`

`DELETE /v1/convai/mcp-servers/{mcp_server_id}/tool-configs/{tool_name}`

Delete Mcp Tool Configuration Override

**Parameters:**

- `mcpServerId` (required)
- `toolName` (required)

## WhatsappAccountsService

### `GetAsync`

`GET /v1/convai/whatsapp-accounts/{phone_number_id}`

Get Whatsapp Account

**Parameters:**

- `phoneNumberId` (required)

### `UpdateAsync`

`PATCH /v1/convai/whatsapp-accounts/{phone_number_id}`

Update Whatsapp Account

**Parameters:**

- `phoneNumberId` (required)

### `DeleteAsync`

`DELETE /v1/convai/whatsapp-accounts/{phone_number_id}`

Delete Whatsapp Account

**Parameters:**

- `phoneNumberId` (required)

### `ListAsync`

`GET /v1/convai/whatsapp-accounts`

List Whatsapp Accounts

**Parameters:**

- `agentId`

## BranchesService

### `ListAsync`

`GET /v1/convai/agents/{agent_id}/branches`

List Agent Branches

**Parameters:**

- `agentId` (required)
- `includeArchived`
- `limit`
- `includeCommitStatus`

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/branches`

Create A New Branch

**Parameters:**

- `agentId` (required)

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/branches/{branch_id}`

Get Agent Branch

**Parameters:**

- `agentId` (required)
- `branchId` (required)

### `UpdateAsync`

`PATCH /v1/convai/agents/{agent_id}/branches/{branch_id}`

Update Agent Branch

**Parameters:**

- `agentId` (required)
- `branchId` (required)

### `PreviewMergeAsync`

`GET /v1/convai/agents/{agent_id}/branches/{source_branch_id}/merge-preview`

Preview Merged Configuration

**Parameters:**

- `agentId` (required)
- `sourceBranchId` (required)
- `targetBranchId` (required)
- `force`
- `includeProcedureGeneratedWorkflowElements`

### `MergeAsync`

`POST /v1/convai/agents/{agent_id}/branches/{source_branch_id}/merge`

Merge A Branch Into A Target Branch

**Parameters:**

- `agentId` (required)
- `sourceBranchId` (required)
- `targetBranchId` (required)

### `PreviewRebaseAsync`

`GET /v1/convai/agents/{agent_id}/branches/{branch_id}/rebase-preview`

Preview Rebased Configuration

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `sourceBranchId`
- `includeProcedureGeneratedWorkflowElements`

### `RebaseAsync`

`POST /v1/convai/agents/{agent_id}/branches/{branch_id}/rebase`

Rebase A Branch Onto Main

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `sourceBranchId`

## VersionsService

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/versions/{version_id}`

Get Agent Version Metadata

**Parameters:**

- `agentId` (required)
- `versionId` (required)

## DeploymentsService

### `ListAsync`

`GET /v1/convai/agents/{agent_id}/deployments`

List Agent Deployments

**Parameters:**

- `agentId` (required)
- `page`
- `pageSize`

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/deployments`

Create Or Update Deployments

**Parameters:**

- `agentId` (required)

## DraftsService

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/drafts`

Create Agent Draft

**Parameters:**

- `agentId` (required)
- `branchId` (required)

### `DeleteAsync`

`DELETE /v1/convai/agents/{agent_id}/drafts`

Delete Agent Draft

**Parameters:**

- `agentId` (required)
- `branchId` (required)

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures/{procedure_id}/draft`

Get Procedure Draft

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `procedureId` (required)

### `UpdateAsync`

`PATCH /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures/{procedure_id}/draft`

Update Procedure Draft

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `procedureId` (required)

### `DeleteAsync1`

`DELETE /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures/{procedure_id}/draft`

Delete Procedure Draft

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `procedureId` (required)

## MergeProposalsService

### `ListAsync`

`GET /v1/convai/agents/{agent_id}/merge-proposals`

List Proposals

**Parameters:**

- `agentId` (required)
- `status`
- `sourceBranchId`
- `targetBranchId`
- `search`
- `pageSize`
- `cursor`

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/merge-proposals`

Create A Merge Proposal

**Parameters:**

- `agentId` (required)

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}`

Get A Merge Proposal

**Parameters:**

- `agentId` (required)
- `mergeProposalId` (required)

### `UpdateAsync`

`PATCH /v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}`

Update A Merge Proposal

**Parameters:**

- `agentId` (required)
- `mergeProposalId` (required)

### `SubmitReviewAsync`

`POST /v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}/reviews`

Review A Merge Proposal

**Parameters:**

- `agentId` (required)
- `mergeProposalId` (required)

### `AddCommentAsync`

`POST /v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}/comments`

Comment On A Merge Proposal

**Parameters:**

- `agentId` (required)
- `mergeProposalId` (required)

### `MergeAsync`

`POST /v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}/merge`

Merge A Merge Proposal

**Parameters:**

- `agentId` (required)
- `mergeProposalId` (required)

## ConfigService

### `GetAsync`

`GET /v1/convai/outbound-campaigns/config`

Get Outbound Campaign Configuration

### `UpdateAsync`

`PUT /v1/convai/outbound-campaigns/config`

Replace Outbound Campaign Configuration

## OutboundCampaignsService

### `ListAsync`

`GET /v1/convai/outbound-campaigns/campaigns`

List Outbound Campaigns

**Parameters:**

- `pageSize`
- `status`
- `agentId`
- `channel`
- `mode`
- `search`
- `cursor`

### `PauseAllAsync`

`POST /v1/convai/outbound-campaigns/campaigns/pause-all`

Pause All Outbound Campaigns

### `StopAllAsync`

`POST /v1/convai/outbound-campaigns/campaigns/stop-all`

Stop All Outbound Campaigns

### `CreateAsync`

`POST /v1/convai/outbound-campaigns/campaigns/submit`

Create An Outbound Campaign

### `GetAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}`

Get An Outbound Campaign

**Parameters:**

- `campaignId` (required)

### `GetProgressAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}/progress`

Get Outbound Campaign Progress

**Parameters:**

- `campaignId` (required)

### `GetFollowUpRequestsAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}/follow-up-requests`

Get Outbound Campaign Follow-Up Requests

**Parameters:**

- `campaignId` (required)

### `PauseAsync`

`POST /v1/convai/outbound-campaigns/campaigns/{campaign_id}/pause`

Pause An Outbound Campaign

**Parameters:**

- `campaignId` (required)

### `ResumeAsync`

`POST /v1/convai/outbound-campaigns/campaigns/{campaign_id}/resume`

Resume An Outbound Campaign

**Parameters:**

- `campaignId` (required)

### `StopAsync`

`POST /v1/convai/outbound-campaigns/campaigns/{campaign_id}/stop`

Stop An Outbound Campaign

**Parameters:**

- `campaignId` (required)

## LeadsService

### `ListAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}/leads`

List Outbound Campaign Leads

**Parameters:**

- `campaignId` (required)
- `pageSize`
- `search`
- `status`
- `disposition`
- `cursor`

### `GetAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}/leads/{lead_id}`

Get An Outbound Campaign Lead

**Parameters:**

- `campaignId` (required)
- `leadId` (required)

### `DeleteAsync`

`DELETE /v1/convai/outbound-campaigns/campaigns/{campaign_id}/leads/{lead_id}`

Remove An Outbound Campaign Lead

**Parameters:**

- `campaignId` (required)
- `leadId` (required)

## CallsService

### `ListAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}/calls`

List Outbound Campaign Calls

**Parameters:**

- `campaignId` (required)
- `pageSize`
- `leadId`
- `status`
- `callResult`
- `stage`
- `cursor`

### `ExportAsync`

`GET /v1/convai/outbound-campaigns/campaigns/{campaign_id}/export`

Export Outbound Campaign Calls

**Parameters:**

- `campaignId` (required)
- `limit`

## AttentionService

### `ListAsync`

`GET /v1/convai/outbound-campaigns/attention`

List Outbound Campaign Attention Items

**Parameters:**

- `campaignId`
- `includeResolved`
- `pageSize`
- `cursor`

### `RetryAsync`

`POST /v1/convai/outbound-campaigns/attention/{attention_id}/retry`

Retry An Outbound Campaign Attention Item

**Parameters:**

- `attentionId` (required)

### `ResolveAsync`

`POST /v1/convai/outbound-campaigns/attention/{attention_id}/resolve`

Resolve An Outbound Campaign Attention Item

**Parameters:**

- `attentionId` (required)

## SpeechEngineService

### `ListAsync`

`GET /v1/speech-engine`

List Speech Engines

**Parameters:**

- `pageSize`
- `search`
- `sortDirection`
- `sortBy`
- `cursor`

### `CreateAsync`

`POST /v1/speech-engine`

Create Speech Engine

### `GetAsync`

`GET /v1/speech-engine/{speech_engine_id}`

Get Speech Engine

**Parameters:**

- `speechEngineId` (required)

### `UpdateAsync`

`PATCH /v1/speech-engine/{speech_engine_id}`

Update Speech Engine

**Parameters:**

- `speechEngineId` (required)

### `DeleteAsync`

`DELETE /v1/speech-engine/{speech_engine_id}`

Delete Speech Engine

**Parameters:**

- `speechEngineId` (required)

### `DuplicateAsync`

`POST /v1/speech-engine/{speech_engine_id}/duplicate`

Duplicate Speech Engine

**Parameters:**

- `speechEngineId` (required)

## ProceduresService

### `ListAsync`

`GET /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures`

List Procedures

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `agentVersionId`

### `CreateAsync`

`POST /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures`

Create Procedure

**Parameters:**

- `agentId` (required)
- `branchId` (required)

### `CompileAsync`

`POST /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures/compile`

Legacy: Compile Procedures

**Parameters:**

- `agentId` (required)
- `branchId` (required)

### `GetAsync`

`GET /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures/{procedure_id}`

Get Procedure

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `procedureId` (required)
- `versionId`
- `agentVersionId`

### `RemoveAsync`

`DELETE /v1/convai/agents/{agent_id}/branches/{branch_id}/procedures/{procedure_id}`

Remove Procedure

**Parameters:**

- `agentId` (required)
- `branchId` (required)
- `procedureId` (required)

## AnalysisService

### `RunAsync`

`POST /v1/convai/conversations/{conversation_id}/analysis/run`

Run Conversation Analysis

**Parameters:**

- `conversationId` (required)

### `RunEvaluationAsync`

`POST /v1/convai/conversations/{conversation_id}/analysis/evaluations/run`

Run Conversation Evaluation

**Parameters:**

- `conversationId` (required)

## EnvironmentVariablesService

### `ListAsync`

`GET /v1/convai/environment-variables`

List Environment Variables

**Parameters:**

- `cursor`
- `pageSize`
- `label`
- `environment`
- `type`

### `CreateAsync`

`POST /v1/convai/environment-variables`

Create Environment Variable

### `GetAsync`

`GET /v1/convai/environment-variables/{env_var_id}`

Get Environment Variable

**Parameters:**

- `envVarId` (required)

### `UpdateAsync`

`PATCH /v1/convai/environment-variables/{env_var_id}`

Update Environment Variable

**Parameters:**

- `envVarId` (required)

### `DeleteAsync`

`DELETE /v1/convai/environment-variables/{env_var_id}`

Delete Environment Variable

**Parameters:**

- `envVarId` (required)

## EnvironmentsService

### `ListAsync`

`GET /v1/convai/environments`

List Environments

### `CreateAsync`

`POST /v1/convai/environments`

Create Environment

### `DeleteAsync`

`DELETE /v1/convai/environments/{environment}`

Delete Environment

**Parameters:**

- `environment` (required)

## RealtimeService

### `ListConversationGroupsAsync`

`GET /v1/convai/realtime/conversation-groups`

List Realtime Conversation Groups

**Parameters:**

- `pageSize`
- `search`
- `cursor`

### `CreateConversationGroupAsync`

`POST /v1/convai/realtime/conversation-groups`

Create Realtime Conversation Group

### `GetConversationGroupAsync`

`GET /v1/convai/realtime/conversation-groups/{conversation_group_id}`

Get Realtime Conversation Group

**Parameters:**

- `conversationGroupId` (required)

### `UpdateConversationGroupAsync`

`PATCH /v1/convai/realtime/conversation-groups/{conversation_group_id}`

Update Realtime Conversation Group

**Parameters:**

- `conversationGroupId` (required)

### `DeleteConversationGroupAsync`

`DELETE /v1/convai/realtime/conversation-groups/{conversation_group_id}`

Delete Realtime Conversation Group

**Parameters:**

- `conversationGroupId` (required)

### `SetConversationGroupAsync`

`PUT /v1/convai/realtime/conversations/{conversation_id}/conversation-group`

Set Realtime Conversation Group

**Parameters:**

- `conversationId` (required)

### `ClearConversationGroupAsync`

`DELETE /v1/convai/realtime/conversations/{conversation_id}/conversation-group`

Clear Realtime Conversation Group

**Parameters:**

- `conversationId` (required)

### `CreateClientSecretAsync`

`POST /v1/convai/realtime/client_secrets`

Create Realtime Client Secret

## CompositionPlanService

### `CreateAsync`

`POST /v1/music/plan`

Generate Composition Plan

**Parameters:**

- `enableLogging`

## FinetunesService

### `ListAsync`

`GET /v1/music/finetunes`

Get Music Finetunes

**Parameters:**

- `cursor`
- `pageSize`
- `visibility`
- `createdBy`
- `sort`
- `sortDirection`

### `CreateAsync`

`POST /v1/music/finetunes`

Create Music Finetune

### `GetAsync`

`GET /v1/music/finetunes/{finetune_id}`

Get Music Finetune

**Parameters:**

- `finetuneId` (required)

### `UpdateAsync`

`PATCH /v1/music/finetunes/{finetune_id}`

Update Music Finetune

**Parameters:**

- `finetuneId` (required)

### `DeleteAsync`

`DELETE /v1/music/finetunes/{finetune_id}`

Delete Music Finetune

**Parameters:**

- `finetuneId` (required)

## OrdersService

### `ListAsync`

`GET /v1/productions/orders`

List Orders

**Parameters:**

- `pageSize`
- `offset`
- `status`
- `startDate`
- `endDate`

### `CreateAsync`

`POST /v1/productions/orders`

Create Order

### `GetAsync`

`GET /v1/productions/orders/{order_id}`

Get Order

**Parameters:**

- `orderId` (required)

### `UpdateAsync`

`PATCH /v1/productions/orders/{order_id}`

Update Order

**Parameters:**

- `orderId` (required)

### `SubmitAsync`

`POST /v1/productions/orders/{order_id}/submit`

Submit Order

**Parameters:**

- `orderId` (required)

## MediaService

### `RegisterAsync`

`POST /v1/productions/orders/{order_id}/media`

Register Media

**Parameters:**

- `orderId` (required)

### `GetAsync`

`GET /v1/productions/orders/{order_id}/media/{media_id}`

Get Media Info

**Parameters:**

- `orderId` (required)
- `mediaId` (required)

## ItemsService

### `UpsertAsync`

`POST /v1/productions/orders/{order_id}/items`

Upsert Order Item

**Parameters:**

- `orderId` (required)

### `RemoveAsync`

`DELETE /v1/productions/orders/{order_id}/items/{item_id}`

Remove Order Item

**Parameters:**

- `orderId` (required)
- `itemId` (required)

## DeliverablesService

### `ListAsync`

`GET /v1/productions/orders/{order_id}/deliverables`

Get Order Deliverables

**Parameters:**

- `orderId` (required)

## LanguagesService

### `ListAsync`

`GET /v1/productions/orders/languages/{order_item_kind}`

Get Available Languages

**Parameters:**

- `orderItemKind` (required)

## PvcService

### `CreateAsync`

`POST /v1/voices/pvc`

Create PVC voice

### `UpdateAsync`

`POST /v1/voices/pvc/{voice_id}`

Edit Pvc Voice

**Parameters:**

- `voiceId` (required)

### `TrainAsync`

`POST /v1/voices/pvc/{voice_id}/train`

Run Pvc Training

**Parameters:**

- `voiceId` (required)

## WaveformService

### `GetAsync`

`GET /v1/voices/pvc/{voice_id}/samples/{sample_id}/waveform`

Retrieve Voice Sample Visual Waveform

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

## SpeakersService

### `GetAsync`

`GET /v1/voices/pvc/{voice_id}/samples/{sample_id}/speakers`

Retrieve Speaker Separation Status

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

### `SeparateAsync`

`POST /v1/voices/pvc/{voice_id}/samples/{sample_id}/separate-speakers`

Start Speaker Separation

**Parameters:**

- `voiceId` (required)
- `sampleId` (required)

## CaptchaService

### `GetAsync`

`GET /v1/voices/pvc/{voice_id}/captcha`

Get Pvc Voice Captcha

**Parameters:**

- `voiceId` (required)

### `VerifyAsync`

`POST /v1/voices/pvc/{voice_id}/captcha`

Verify Pvc Voice Captcha

**Parameters:**

- `voiceId` (required)

## VerificationService

### `RequestAsync`

`POST /v1/voices/pvc/{voice_id}/verification`

Request Manual Verification

**Parameters:**

- `voiceId` (required)

## VideoService

### `ListAsync`

`GET /v1/flows/video`

List Video Generations

**Parameters:**

- `cursor`
- `pageSize`
- `status`
- `modelId`

### `CreateAsync`

`POST /v1/flows/video`

Create Video Generation

### `GetAsync`

`GET /v1/flows/video/{generation_id}`

Get Video Generation

**Parameters:**

- `generationId` (required)

## ImageService

### `ListAsync`

`GET /v1/flows/image`

List Image Generations

**Parameters:**

- `cursor`
- `pageSize`
- `status`
- `modelId`

### `CreateAsync`

`POST /v1/flows/image`

Create Image Generation

### `GetAsync`

`GET /v1/flows/image/{generation_id}`

Get Image Generation

**Parameters:**

- `generationId` (required)

## RunsService

### `ListAsync`

`GET /v1/flows/templates/{template_id}/runs`

List Template Runs

**Parameters:**

- `templateId` (required)
- `cursor`
- `pageSize`
- `versionId`

### `CreateAsync`

`POST /v1/flows/templates/{template_id}/runs`

Create Template Run

**Parameters:**

- `templateId` (required)

### `GetAsync`

`GET /v1/flows/templates/{template_id}/runs/{run_id}`

Get Template Run

**Parameters:**

- `templateId` (required)
- `runId` (required)

## TemplatesService

### `ListAsync`

`GET /v1/flows/templates`

List Templates

**Parameters:**

- `cursor`
- `pageSize`
- `versionsPerTemplate`
- `search`

### `GetAsync`

`GET /v1/flows/templates/{template_id}`

Get Template

**Parameters:**

- `templateId` (required)
- `versionsPerTemplate`

## AssetsService

### `ListAsync`

`GET /v1/assets`

List Assets

**Parameters:**

- `pageSize`
- `cursor`
- `search`

### `CreateAsync`

`POST /v1/assets`

Upload Asset

### `GetAsync`

`GET /v1/assets/{asset_id}`

Get Asset

**Parameters:**

- `assetId` (required)

### `DeleteAsync`

`DELETE /v1/assets/{asset_id}`

Delete Asset

**Parameters:**

- `assetId` (required)

## UsageService

### `GetUsageByProductOverTimeAsync`

`POST /v1/workspace/analytics/query/usage-by-product-over-time`

Get Workspace Usage

### `GetUsageAsync`

`POST /v1/workspace/analytics/usage`

Get Workspace Cost Usage

## RequestsService

### `GetAsync`

`POST /v1/workspace/analytics/requests`

List Api Requests
