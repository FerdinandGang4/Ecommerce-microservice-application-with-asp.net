var builder = WebApplication.CreateBuilder(args);

//add services to container for dependency injection
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();



//piplilines configuration

app.MapCarter();

app.Run();
