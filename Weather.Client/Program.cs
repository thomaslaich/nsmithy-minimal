using Example.Weather;
using NSmithy.Client;

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
    foreach (var city in result.Items.Values)
        Console.WriteLine($"    {city.CityId}: {city.Name}");
}

var seattle = await client.GetCityAsync(new GetCityInput("SEA"));
Console.WriteLine($"Seattle: ({seattle.Coordinates.Latitude}, {seattle.Coordinates.Longitude})");

var forecast = await client.GetForecastAsync(new GetForecastInput("SEA"));
Console.WriteLine($"Forecast for SEA: {forecast.ChanceOfRain:P0} chance of rain");
