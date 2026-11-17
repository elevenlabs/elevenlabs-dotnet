namespace ElevenLabs.SpeechEngine;

/// <summary>
/// A single message in a Speech Engine conversation transcript.
/// </summary>
/// <remarks>
/// Hand-written (see <c>.fernignore</c>): the server-side session surface is not part of the
/// generated client. Mirrors <c>ConversationMessage</c> in the Python/TypeScript/PHP SDKs.
/// </remarks>
public sealed record ConversationMessage
{
    /// <summary>Either <c>"user"</c> or <c>"agent"</c>.</summary>
    public required string Role { get; init; }

    /// <summary>The text content of the message.</summary>
    public required string Content { get; init; }

    public ConversationMessage() { }

    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public ConversationMessage(string role, string content)
    {
        Role = role;
        Content = content;
    }
}
