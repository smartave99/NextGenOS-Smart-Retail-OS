using NextGenOS.Hub.Web;
using NextGenOS.Hub.Web.Diagnostics;

// A note of how the program started, or why it could not (Diagnostics/StartupLog.cs): when the shop program does not open, the icon and the setup show it to the person.
StartupLog.Begin();
try
{
    var builder = HubHost.CreateBuilder(args);
    HubHost.AddHub(builder);
    var app = builder.Build();
    HubHost.UseHub(app);
    app.Lifetime.ApplicationStarted.Register(() => StartupLog.Write("Ready. It answers at " + string.Join(", ", app.Urls) + "."));
    app.Lifetime.ApplicationStopping.Register(() => StartupLog.Write("Stopping."));
    app.Run();
}
catch (Exception ex)
{
    StartupLog.Write("The program could not start: " + ex);
    throw;
}

// Lets the tests start the program.
public partial class Program;
