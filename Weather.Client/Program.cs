using Example.Weather;
using NSmithy.Client;
using NSmithy.Core.Validation;

var debug = args.Contains("--debug");
var endpoint = args.FirstOrDefault(a => !a.StartsWith("--")) ?? "http://localhost:5000";

var client = debug
    ? new WeatherClient(new Uri(endpoint), new() { Interceptors = { new DebugInterceptor() } })
    : new WeatherClient(new Uri(endpoint));

var time = await client.GetCurrentTimeAsync(new GetCurrentTimeInput());
Console.WriteLine($"Current time: {time.Time:u}");

// Paginate through all cities, 3 per page
Console.WriteLine("All cities (paginated, page size 3):");
var page = 1;
await foreach (var result in client.ListCitiesPagesAsync(new ListCitiesInput(PageSize: 3)))
{
    Console.WriteLine($"  Page {page++}:");
    foreach (var city in result.Items)
        Console.WriteLine($"    {city.CityId}: {city.Name}");
}

var seattle = await client.GetCityAsync(new GetCityInput("SEA"));
Console.WriteLine($"Seattle: ({seattle.Coordinates.Latitude}, {seattle.Coordinates.Longitude})");

var forecast = await client.GetForecastAsync(new GetForecastInput("SEA"));
Console.WriteLine($"Forecast for SEA: {forecast.ChanceOfRain:P0} chance of rain");

// "Atlantis" satisfies the model, so it reaches the handler and comes back as the error the
// operation declares — a modeled error, surfaced as a typed exception.
try
{
    await client.GetCityAsync(new GetCityInput("Atlantis"));
}
catch (NoSuchResource error)
{
    Console.WriteLine($"No such {error.ResourceType}: Atlantis");
}

// CityId is @pattern("^[A-Za-z0-9 ]+$"), and constraints are enforced by the server — the client
// sends what it is handed. The rejection comes back as smithy.framework#ValidationException, an
// implicit modeled error on every operation, so it deserializes into a typed exception naming the
// member and the constraint it failed rather than a bare 400.
try
{
    await client.GetCityAsync(new GetCityInput("SEA!"));
}
catch (ValidationException error)
{
    Console.WriteLine($"Rejected \"SEA!\": {error.Message}");
    foreach (var field in error.FieldList)
        Console.WriteLine($"  {field.Path}: {field.Message}");
}
