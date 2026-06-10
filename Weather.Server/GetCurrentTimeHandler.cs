namespace Example.Weather;

internal sealed class GetCurrentTimeHandler : IGetCurrentTimeHandler
{
    public Task<GetCurrentTimeOutput> GetCurrentTimeAsync(
        GetCurrentTimeInput input,
        CancellationToken cancellationToken = default
    ) => Task.FromResult(new GetCurrentTimeOutput(DateTimeOffset.UtcNow));
}
