namespace NextGenOS.Hub.Assistant;

// What the assistant is made of. It is a fixed, short list of lookups (tools); the model never gets to run anything else, and every lookup is done as the person who asked.

/// <summary>One thing a lookup can be told, with the words a model is allowed to use for it (<see cref="Choices"/>) when it is a choice.</summary>
public sealed record ToolArg(string Name, string Describes, IReadOnlyList<string>? Choices = null);

/// <summary>A lookup as a screen (and the model's instructions) describe it.</summary>
public sealed record ToolInfo(string Id, string Title, string Describes, IReadOnlyList<ToolArg> Args);

/// <summary>A lookup that was chosen, with what it was told.</summary>
public sealed record ToolCall(string Tool, IReadOnlyDictionary<string, string> Args);

/// <summary>One line a lookup found, and, when it comes from one of the owner's notes, which note.</summary>
public sealed record ToolLine(string Text, string? Ref = null);

/// <summary>What a lookup found. <see cref="DataClass"/> is the kind of information in it, so that the answer is written only where that kind may go.</summary>
public sealed record ToolResult(IReadOnlyList<ToolLine> Lines, string DataClass, string? Note = null);

/// <summary>One numbered thing the answer rests on. The answer points at these numbers, and the screen shows them all so that a person can check.</summary>
public sealed record AssistantFact(int Number, string Tool, string Title, string Text, string? Ref);

/// <summary>A lookup that was tried: what it was told, how many facts it gave, or why it did not work.</summary>
public sealed record ToolRun(string Tool, string Title, IReadOnlyDictionary<string, string> Args, int Facts, string? Problem);

/// <summary>How a question ended.</summary>
public static class AssistantMode
{
    /// <summary>An AI service wrote an answer from the facts.</summary>
    public const string Answered = "answered";

    /// <summary>The facts were found, but no AI service could write the answer (none is set up, none may receive this kind of information, or it did not answer). The facts are shown as they are.</summary>
    public const string FactsOnly = "facts-only";

    /// <summary>The lookups found nothing to answer from. No AI service was asked, so nothing could be made up.</summary>
    public const string NothingFound = "nothing-found";

    public static readonly IReadOnlyList<string> All = [Answered, FactsOnly, NothingFound];
}

/// <summary>
/// A request the screen can offer for a thing the answer points at (a running-low warning): what it would do in plain words, and whether this person can ask for it now. The program builds it
/// from the warning's own figures and checks it with the same rules as the Buying page; a model never writes one. <see cref="Problem"/> says why it cannot be asked for (for example an order to
/// the same supplier for the same goods is still open).
/// </summary>
public sealed record AssistantOffer(long FindingId, string Action, string Title, string Summary, string? Problem, bool CanAsk);

/// <summary>The reply to one question.</summary>
/// <param name="Cited">The numbers of the facts the answer points at (only numbers that exist).</param>
/// <param name="Notes">Plain-word remarks about how the reply was made (a lookup skipped, search by words only, an AI service that did not answer).</param>
/// <param name="Offers">Requests a person could ask for from what the answer points at. Nothing is asked for until the person presses the button, and nothing is done until someone who may approve it does.</param>
public sealed record AssistantReply(
    long Id, string Question, string Mode, string? Text, IReadOnlyList<AssistantFact> Facts, IReadOnlyList<int> Cited, IReadOnlyList<ToolRun> Tools, IReadOnlyList<string> Notes, string? ProviderId, string? Model, IReadOnlyList<AssistantOffer> Offers);

/// <summary>A question that was asked, as the record keeps it (never the answer).</summary>
public sealed record AskedQuestion(
    long Id, DateTimeOffset At, long? UserId, string? UserName, string? Role, string Question, IReadOnlyList<string> Tools, IReadOnlyList<string> Sources, string Outcome, string? ProviderId, string? Model, string? Note);

/// <summary>The plan a model gave, read back: the lookups it chose (only known ones the person may use) and what had to be left out.</summary>
public sealed record AssistantPlan(IReadOnlyList<ToolCall> Calls, IReadOnlyList<string> Ignored, bool Understood);
