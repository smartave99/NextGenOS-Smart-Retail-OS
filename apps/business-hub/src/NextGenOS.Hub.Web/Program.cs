using NextGenOS.Hub.Web;

var builder = HubHost.CreateBuilder(args);
HubHost.AddHub(builder);
var app = builder.Build();
HubHost.UseHub(app);
app.Run();

// Lets the tests start the program.
public partial class Program;
