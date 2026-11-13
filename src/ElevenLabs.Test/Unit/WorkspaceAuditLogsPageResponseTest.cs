using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkspaceAuditLogsPageResponse</c>.
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
public class WorkspaceAuditLogsPageResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"entries\":[{\"metadata\":{\"key\":{}},\"time\":9,\"activity_id\":1,\"activity_name\":\"activity_name\",\"category_name\":\"Identity & Access Management\",\"category_uid\":3,\"class_name\":\"class_name\",\"class_uid\":1,\"severity_id\":5,\"status_id\":2,\"actor\":{\"user\":{\"name\":\"name\",\"uid\":\"uid\",\"type_id\":0,\"type\":\"type\",\"email_addr\":\"email_addr\",\"full_name\":\"full_name\",\"domain\":\"domain\"},\"app_name\":\"app_name\",\"app_uid\":\"app_uid\",\"session\":{\"key\":{}}},\"device\":{\"ip\":\"ip\",\"hostname\":\"hostname\",\"type_id\":99},\"http_request\":{\"http_method\":\"http_method\",\"url\":{\"url_string\":\"url_string\",\"scheme\":\"scheme\",\"hostname\":\"hostname\",\"port\":2,\"path\":\"path\",\"query_string\":\"query_string\"},\"user_agent\":\"user_agent\",\"x_forwarded_for\":[\"x_forwarded_for\"]},\"message\":\"message\",\"unmapped\":{\"key\":{}},\"id\":\"id\"}],\"has_more\":true,\"next_cursor\":\"next_cursor\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WorkspaceAuditLogsPageResponse>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkspaceAuditLogsPageResponse did not round-trip."
        );
    }
}
