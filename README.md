# NSmithy Minimal Example

A minimal example of [NSmithy](https://github.com/thomaslaich/nsmithy) — a C# implementation of the [Smithy](https://smithy.io) IDL.

The service is the Weather example from the [Smithy quickstart](https://smithy.io/2.0/quickstart.html): a REST API that exposes city resources with paginated listing and per-city weather forecasts.

## Projects

- **Weather.Contracts** — Smithy model (`model/weather.smithy`). Builds the contract and generates C# types used by both the server and client.
- **Weather.Server** — ASP.NET Core server with a hardcoded in-memory implementation.
- **Weather.Client** — Console app that exercises the API end-to-end.

## Prerequisites

Requires the [.NET SDK](https://dotnet.microsoft.com/download) (10.0+) and Python (for Smithy doc generation).

Alternatively, use [pixi](https://pixi.sh) to drop into a dev shell that provides both:

```sh
pixi shell
```

## Running

[just](https://github.com/casey/just) is available in the pixi shell:

```sh
just server   # start the server
just client   # run the client against http://localhost:5000
```

Or directly with the .NET CLI:

```sh
dotnet run --project Weather.Server
dotnet run --project Weather.Client
```

The client connects to `http://localhost:5000` by default. Pass a different URL as the first argument if needed:

```sh
just client http://localhost:8080
# or
dotnet run --project Weather.Client -- http://localhost:8080
```

Once the server is running, the following endpoints are also available:

- **Scalar API explorer** — `http://localhost:5000/openapi`
- **Smithy docs** — `http://localhost:5000/docs`
