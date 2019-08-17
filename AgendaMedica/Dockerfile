FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

WORKDIR /app

# copy published
COPY AgendaMedica.API/bin/Debug/netcoreapp2.2/publish/ ./

# make entry point
ENTRYPOINT ["dotnet", "AgendaMedica.API.dll"]