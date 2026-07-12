server:
    dotnet run --project Weather.Server

client *args:
    dotnet run --project Weather.Client -- {{args}}

client-debug *args:
    dotnet run --project Weather.Client -- --debug {{args}}
