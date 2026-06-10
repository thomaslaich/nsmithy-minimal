namespace Example.Weather;

internal sealed class GetForecastHandler : IGetForecastHandler
{
    public Task<GetForecastOutput> GetForecastAsync(
        GetForecastInput input,
        CancellationToken cancellationToken = default
    ) => Task.FromResult(new GetForecastOutput(ChanceOfRain: 0.4f));
}
