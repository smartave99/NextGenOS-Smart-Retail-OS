using Microsoft.AspNetCore.Components;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;
using NextGenOS.Hub.Web.Auth;

namespace NextGenOS.Hub.Web.Components;

/// <summary>What every screen needs: the shop, who is signed in, money and time as this country writes them, and one way to turn a refused action into a plain message.</summary>
public abstract class HubPage : ComponentBase, IHandleEvent
{
    [Inject] protected HubApp App { get; set; } = default!;
    [Inject] protected Session Sess { get; set; } = default!;
    [Inject] protected NavigationManager Nav { get; set; } = default!;
    [Inject] protected ILogger<HubPage> Log { get; set; } = default!;

    protected Me Me { get; private set; } = default!;
    protected string? Error { get; set; }
    protected string? Info { get; set; }

    protected ShopContext Shop => App.Shop.Current;

    /// <summary>
    /// The screen opens, and everything it does while it starts (including reading and, for a few screens, a command such as making a bill from a quote) is done as the person signed
    /// in. Who that is becomes known a moment later, so the scope asks <see cref="Me"/> each time.
    /// </summary>
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        using var scope = App.Access.As(() => Me?.Id);
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        Me = await Sess.GetAsync();
        await Reload();
    }

    /// <summary>
    /// Every tap, click and key press on a screen is done on behalf of the person signed in here: the commands it starts are checked against that person's role by the Hub itself
    /// (<see cref="NextGenOS.Hub.Security.Access"/>), not only by what the screen chooses to show. This does what the base class does for an event (draw the screen again after it),
    /// with the person named for the time it runs.
    /// </summary>
    Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg)
    {
        using var scope = App.Access.As(() => Me?.Id);
        var task = callback.InvokeAsync(arg);
        var shouldAwait = task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Canceled;
        StateHasChanged();
        return shouldAwait ? DrawAgainWhenDone(task) : Task.CompletedTask;
    }

    private async Task DrawAgainWhenDone(Task task)
    {
        try { await task; }
        catch
        {
            if (task.IsCanceled) return;
            throw;
        }

        StateHasChanged();
    }

    /// <summary>Reads what the screen shows. Called once when it opens, and again by <see cref="Reload"/>.</summary>
    protected virtual Task LoadAsync() => Task.CompletedTask;

    /// <summary>Reads the screen again after a change. Messages already on the screen stay.</summary>
    protected async Task Reload()
    {
        try
        {
            await LoadAsync();
        }
        catch (HubException ex)
        {
            Error = ex.Message;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            Log.LogError(ex, "A screen could not be read.");
            Error = "Something went wrong reading this screen. Please try again.";
        }
    }

    protected string Money(long minor) => Shop.Money(minor);

    protected string Qty(long milli) => ShopContext.Qty(milli).TrimEnd('0').TrimEnd('.');

    protected string When(DateTimeOffset utc) => Shop.Time.ToLocal(utc).ToString("d MMM, HH:mm", System.Globalization.CultureInfo.InvariantCulture);

    protected string Day(DateTimeOffset utc) => Shop.Time.ToLocal(utc).ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture);

    protected DateOnly Today => Shop.Time.LocalDate(App.Clock.UtcNow);

    /// <summary>Runs something the person asked for. A refusal from the Hub is shown as it is worded; anything else is logged and shown as a short apology.</summary>
    protected async Task Run(Func<Task> work, string? done = null)
    {
        Error = null;
        Info = null;
        try
        {
            await work();
            if (done is not null) Info = done;
        }
        catch (HubException ex)
        {
            Error = ex.Message;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            Log.LogError(ex, "A screen could not do what was asked.");
            Error = "Something went wrong, and nothing was saved. Please try again.";
        }
    }

    protected Task Run(Action work, string? done = null) => Run(() => { work(); return Task.CompletedTask; }, done);

    /// <summary>
    /// Reads something for the person signed in, while the screen is being drawn. Drawing happens outside the scope that a screen's start and its events run in, and a read that shows
    /// different things to different people (the business map) must still know who is asking.
    /// </summary>
    protected T AsMe<T>(Func<T> read)
    {
        using var scope = App.Access.As(() => Me?.Id);
        return read();
    }

    protected static bool TryMoney(ShopContext shop, string? text, out long minor)
    {
        minor = 0;
        if (string.IsNullOrWhiteSpace(text)) return false;
        try { minor = shop.Minor(text.Trim().Replace(",", "")); return true; }
        catch (FormatException) { return false; }
        catch (OverflowException) { return false; }
    }
}
