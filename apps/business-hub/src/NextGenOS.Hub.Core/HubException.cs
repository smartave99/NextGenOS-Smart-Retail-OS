namespace NextGenOS.Hub;

/// <summary>
/// A refusal with words for the person using the program: "That barcode is already on another product." Screens show the message as it is.
/// <see cref="Code"/> is a short stable word for programs and tests ("duplicate-barcode", "over-limit").
/// </summary>
public sealed class HubException(string code, string message) : Exception(message)
{
    public string Code { get; } = code;
}
