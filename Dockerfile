# Imagen base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiniCoreComision.csproj", "./"]
RUN dotnet restore "./MiniCoreComision.csproj"
COPY . .
RUN dotnet build "MiniCoreComision.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniCoreComision.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniCoreComision.dll"]
