using OnlineSurvey.WebApp.Service;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
var services = builder.Services;

startup.ConfigureServices(services);

var app = builder.Build();

var webHostEnvironment = app.Environment;
startup.Configure(webHostEnvironment, app);

app.Run();


