namespace Example.Weather;

internal sealed class GetCityHandler : IGetCityHandler
{
    public Task<GetCityOutput> GetCityAsync(
        GetCityInput input,
        CancellationToken cancellationToken = default
    )
    {
        var city = CityData.Cities.FirstOrDefault(c => c.CityId == input.CityId);
        if (city == default)
            throw new NoSuchResource(null, "City");

        return Task.FromResult(
            new GetCityOutput(
                Coordinates: new CityCoordinates(city.Latitude, city.Longitude),
                Name: city.Name
            )
        );
    }
}
