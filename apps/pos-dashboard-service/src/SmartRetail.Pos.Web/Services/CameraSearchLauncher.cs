namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The camera buttons in the search boxes of the top bar and the sidebar ask the layout's one camera search to open
/// (<see cref="Requested"/>), so every page can find a product with the camera and none repeats the screens.
/// One per browser window (Blazor circuit).
/// </summary>
public sealed class CameraSearchLauncher
{
    public event Action? Requested;

    public void Request() => Requested?.Invoke();
}
