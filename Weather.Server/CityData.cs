namespace Example.Weather;

internal static class CityData
{
    internal static readonly List<(
        string CityId,
        string Name,
        float Latitude,
        float Longitude
    )> Cities =
    [
        ("SEA", "Seattle", 47.6f, -122.3f),
        ("NYC", "New York", 40.7f, -74.0f),
        ("LAX", "Los Angeles", 34.1f, -118.2f),
        ("CHI", "Chicago", 41.9f, -87.6f),
        ("HOU", "Houston", 29.8f, -95.4f),
        ("PHX", "Phoenix", 33.4f, -112.1f),
        ("PHL", "Philadelphia", 39.9f, -75.2f),
        ("SAN", "San Antonio", 29.4f, -98.5f),
        ("SDA", "San Diego", 32.7f, -117.2f),
        ("DAL", "Dallas", 32.8f, -96.8f),
    ];
}
