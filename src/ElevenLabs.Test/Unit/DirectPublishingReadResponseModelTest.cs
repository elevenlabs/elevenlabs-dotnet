using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.DirectPublishingReadResponseModel</c>.
/// </summary>
/// <remarks>
/// Asserts the wire document the model was built from comes back out of it unchanged — not merely
/// that serialization runs. Starting from JSON rather than from a constructed instance is what
/// makes one emitter cover both output modes: the legacy positional record and the fernMode
/// `required`/`init` record are constructed differently but deserialize from the same document, so
/// nothing here has to know which shape it is looking at. It is also the stronger assertion, since
/// a property whose C# name diverges from its wire name fails this and would pass a test that only
/// compared an instance to itself.
/// </remarks>
[TestFixture]
public class DirectPublishingReadResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"read_id\":\"read_id\",\"created_at_unix\":2,\"updated_at_unix\":9,\"word_count\":7,\"char_count\":5,\"chapters\":[{\"chapter_name\":\"chapter_name\",\"word_count\":8,\"char_count\":6,\"starting_char_offset\":1,\"has_parsed_html\":true,\"has_summary\":false,\"duration_seconds\":9.41,\"file_number\":\"file_number\",\"is_fallback_name\":false,\"chapter_id\":\"chapter_id\"}],\"title\":\"title\",\"author\":\"author\",\"description\":\"description\",\"article_image_url\":\"article_image_url\",\"language\":\"language\",\"locale\":\"locale\",\"display_mode\":\"text\",\"genre\":[\"Fantasy\"],\"fiction\":\"fiction\",\"content_type\":\"content_type\",\"original_file_type\":\"original_file_type\",\"target_audience\":\"children\",\"mature_content\":true,\"safesearch_adult\":false,\"origin\":\"origin\",\"publication_date\":\"publication_date\",\"isbn\":\"isbn\",\"ean\":\"ean\",\"legal_terms\":{\"terms\":\"terms\",\"start_date\":\"start_date\",\"end_date\":\"end_date\"},\"content_guidelines_terms\":{\"terms\":\"terms\",\"start_date\":\"start_date\",\"end_date\":\"end_date\"},\"last_updated_from_project_unix\":1,\"publishing_project_id\":\"publishing_project_id\",\"publishing_state\":\"published\",\"publisher_profile_id\":\"publisher_profile_id\",\"quality_score\":5,\"publisher\":\"publisher\",\"copyright\":\"copyright\",\"subtitle\":\"subtitle\",\"distribution_territories\":[\"distribution_territories\"],\"edition\":\"edition\",\"contributors\":[{\"name\":\"name\",\"role\":\"role\",\"bio\":\"bio\",\"profile_id\":\"profile_id\"}],\"payout_type\":\"none\",\"list_price\":1.41,\"currency\":\"usd\",\"original_audio_project_export_id\":\"original_audio_project_export_id\",\"original_audio_document_id\":\"original_audio_document_id\",\"series_id\":\"series_id\",\"volume\":6,\"published_at_unix\":6,\"read_slug\":\"read_slug\",\"preview_audio_object\":{\"voice_id\":\"voice_id\",\"text\":\"text\",\"audio_url\":\"audio_url\",\"hls_manifest_url\":\"hls_manifest_url\",\"dash_manifest_url\":\"dash_manifest_url\",\"is_auto_generated\":false,\"generated_at_unix\":2},\"sample_config\":{\"is_sample\":false,\"parent_id\":\"parent_id\",\"parent_type\":\"read\",\"chapter_ids\":[\"chapter_ids\"]},\"review\":{\"review_status\":\"approved\",\"reviewed_at_unix\":9,\"reviewed_by\":\"reviewed_by\",\"reject_reasons\":[\"lacks_structure\"],\"scores_breakdown\":{\"key\":10},\"rejected_details\":\"rejected_details\",\"explanation\":\"explanation\"},\"voice_id\":\"voice_id\",\"can_use_assistant\":true,\"is_voice_changer_on\":false,\"restricted_to_user_email_domains\":[\"restricted_to_user_email_domains\"]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.DirectPublishingReadResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.DirectPublishingReadResponseModel did not round-trip."
        );
    }
}
