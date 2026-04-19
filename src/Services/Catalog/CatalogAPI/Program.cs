var builder = WebApplication.CreateBuilder(args);

//add services to container for dependency injection

var app = builder.Build();

//piplilines configuration

app.MapGet("/", () => "Hello World!");

app.Run();
