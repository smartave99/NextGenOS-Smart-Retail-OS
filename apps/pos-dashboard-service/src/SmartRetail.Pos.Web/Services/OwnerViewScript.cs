namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The owner view's Supabase script (cloud/supabase-owner-view.sql), built into the app, so the owner can open it
/// from Settings and paste it into the project's SQL Editor, the first time and after each update.
/// </summary>
public static class OwnerViewScript
{
    public const string Address = "/supabase-owner-view.sql";

    public static void MapOwnerViewScript(this IEndpointRouteBuilder app) =>
        app.MapGet(Address, (HttpContext http) =>
        {
            if (typeof(OwnerViewScript).Assembly.GetManifestResourceStream("supabase-owner-view.sql") is not { } script)
            {
                return Results.NotFound();
            }

            http.Response.Headers.CacheControl = "no-cache";
            http.Response.Headers.XContentTypeOptions = "nosniff";
            return Results.Stream(script, "text/plain; charset=utf-8");
        });
}
