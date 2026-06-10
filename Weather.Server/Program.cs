using Example.Weather;
using NSmithy.Server.AspNetCore.Docs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGetCurrentTimeHandler, GetCurrentTimeHandler>();
builder.Services.AddSingleton<IGetCityHandler, GetCityHandler>();
builder.Services.AddSingleton<IListCitiesHandler, ListCitiesHandler>();
builder.Services.AddSingleton<IGetForecastHandler, GetForecastHandler>();

var app = builder.Build();
app.MapSmithyOpenApi();
app.MapSmithyDocs();
app.MapWeatherServiceHttp();
app.Run();
