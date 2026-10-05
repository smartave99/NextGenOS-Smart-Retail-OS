using Microsoft.AspNetCore.Components;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;
using NextGenOS.Hub.Web.Auth;

namespace NextGenOS.Hub.Web.Components;

/// <summary>What every screen needs: the shop, who is signed in, money and time as this country writes them, and one way to turn a refused action into a plain message.</summary>
public abstract class HubPage : ComponentBase
{
    [Inject] protected HubApp App { get; set; } = default!;
    [Inject] protected Session Sess { get; set; } = default!;
    [Inject] protected NavigationManager Nav { get; set; } = default!;
    [Inject] protected ILogger<HubPage> Log { get; set; } = default!;

    protected Me Me { get; private set; } = default!;
    protected string? Error { get; set; }
    protected string? Info { get; set; }

    protected ShopContext Shop => App.Shop.Current;

    protected override async Task OnInitializedAsync()
    {
        Me = await Sess.GetAsync();
        await Reload();
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

    protected static bool TryMoney(ShopContext shop, string? text, out long minor)
    {
        minor = 0;
        if (string.IsNullOrWhiteSpace(text)) return false;
        try { minor = shop.Minor(text.Trim().Replace(",", "")); return true; }
        catch (FormatException) { return false; }
        catch (OverflowException) { return false; }
    }
}
