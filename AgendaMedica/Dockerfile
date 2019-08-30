FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore
COPY . ./
RUN dotnet restore AgendaMedica.sln

# Build
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/AgendaMedica.API/out .
ENTRYPOINT ["dotnet", "AgendaMedica.API.dll"]