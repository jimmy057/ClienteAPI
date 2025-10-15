# Etapa 1: Imagen base para correr ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etapa 2: Imagen para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ClienteAPI.csproj", "./"]
RUN dotnet restore "./ClienteAPI.csproj"
COPY . .
RUN dotnet publish "ClienteAPI.csproj" -c Release -o /app/publish

# Etapa 3: Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ClienteAPI.dll"]

