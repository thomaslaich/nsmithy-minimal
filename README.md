# NSmithy Minimal Example

A minimal example of [NSmithy](https://github.com/thomaslaich/nsmithy) — a C# implementation of the [Smithy](https://smithy.io) IDL.

The service is the Weather example from the [Smithy quickstart](https://smithy.io/2.0/quickstart.html): a REST API that exposes city resources with paginated listing and per-city weather forecasts.

## Projects

- **Weather.Contracts** — Smithy model (`model/weather.smithy`). Builds the contract and generates C# types used by both the server and client.
- **Weather.Server** — ASP.NET Core server with a hardcoded in-memory implementation.
- **Weather.Client** — Console app that exercises the API end-to-end.

## Running

Start the server:

```sh
dotnet run --project Weather.Server
```

In a second terminal, run the client:

```sh
dotnet run --project Weather.Client
```

The client connects to `http://localhost:5000` by default. Pass a different URL as the first argument if needed:

```sh
dotnet run --project Weather.Client -- http://localhost:8080
```
