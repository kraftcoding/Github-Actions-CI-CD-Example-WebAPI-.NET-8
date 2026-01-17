var builder = WebApplication.CreateBuilder(args);

string id = Guid.NewGuid().ToString();
string osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
DateTime startUpTime = DateTime.Now;
const string ver = "v1.0.2";

var app = builder.Build();

app.MapGet("/", () => $"Id {id}\nOperating System {osDescription}\nStarted at {startUpTime}\n\nCurrent time {DateTime.Now}\nVer {ver}");

app.Run();