namespace Example.Weather;

internal sealed class ListCitiesHandler : IListCitiesHandler
{
    public Task<ListCitiesOutput> ListCitiesAsync(
        ListCitiesInput input,
        CancellationToken cancellationToken = default
    )
    {
        var pageSize = input.PageSize ?? 3;
        var startIndex = 0;

        if (input.NextToken is { } token)
        {
            var idx = CityData.Cities.FindIndex(c => c.CityId == token);
            startIndex = idx < 0 ? 0 : idx + 1;
        }

        var page = CityData.Cities.Skip(startIndex).Take(pageSize).ToList();
        var nextToken = startIndex + page.Count < CityData.Cities.Count ? page.Last().CityId : null;

        return Task.FromResult(
            new ListCitiesOutput(
                Items: new CitySummaries(
                    page.Select(c => new CitySummary(c.CityId, c.Name)).ToList()
                ),
                NextToken: nextToken
            )
        );
    }
}
