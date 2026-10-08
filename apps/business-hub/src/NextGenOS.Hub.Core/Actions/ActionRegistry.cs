namespace NextGenOS.Hub.Actions;

/// <summary>
/// The closed list of requests the program can carry out (blueprint ACT-012). A request names one of these and a version; anything else is refused. Nothing here runs a query, a
/// command line or an address it is given. A new kind of request is a new handler written in code, with its own tests, added to this list.
/// </summary>
public sealed class ActionRegistry(IReadOnlyList<IActionHandler> handlers)
{
    public IReadOnlyList<IActionHandler> All { get; } = handlers;

    public IActionHandler? Find(string id, int version) => All.FirstOrDefault(h => h.Id == id && h.Version == version);

    /// <summary>Every permission that lets a person approve something.</summary>
    public IReadOnlyList<string> AnyApprove => All.SelectMany(h => h.ApproveAny).Distinct().ToList();

    /// <summary>Every permission that lets a person ask for something.</summary>
    public IReadOnlyList<string> AnyPropose => All.SelectMany(h => h.ProposeAny).Distinct().ToList();
}
