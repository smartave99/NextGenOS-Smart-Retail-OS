using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Web.Auth;

/// <summary>Every permission name, for the policies.</summary>
public static class Permissions
{
    public static readonly IReadOnlyList<string> All = new[]
    {
        Perm.Sell, Perm.Orders, Perm.Kitchen, Perm.Loans, Perm.Projects, Perm.Appointments, Perm.Catalog, Perm.Parties, Perm.Stock,
        Perm.Purchases, Perm.Reports, Perm.Void, Perm.Settings, Perm.Users, Perm.Ai,
    };
}

/// <summary>Who is signed in on this screen, and what they may do.</summary>
public sealed record Me(long Id, string Name, string Role)
{
    public bool Can(string permission) => Roles.Can(Role, permission);
}

public sealed class Session(AuthenticationStateProvider provider)
{
    private Me? _me;

    public async Task<Me> GetAsync()
    {
        if (_me is not null) return _me;
        var user = (await provider.GetAuthenticationStateAsync()).User;
        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(id, out var n)) throw new InvalidOperationException("Nobody is signed in.");
        _me = new Me(n, user.FindFirstValue(ClaimTypes.Name) ?? "", user.FindFirstValue(ClaimTypes.Role) ?? "");
        return _me;
    }

    public static ClaimsPrincipal Principal(User user) => new(new ClaimsIdentity(new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(System.Globalization.CultureInfo.InvariantCulture)),
        new Claim(ClaimTypes.Name, user.DisplayName),
        new Claim(ClaimTypes.Role, user.Role),
    }, Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme));
}
