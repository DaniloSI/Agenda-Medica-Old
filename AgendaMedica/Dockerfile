FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

WORKDIR /app

# copy published
COPY AgendaMedica.API/Publicados/ ./

# make entry point
ENTRYPOINT ["dotnet", "AgendaMedica.API.dll"]