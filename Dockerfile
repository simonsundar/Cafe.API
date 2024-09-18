# Use the official .NET Core SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GICCafe.API/GICCafe.API.csproj", "GICCafe.API/"]
COPY ["GICCafe.Domain/GICCafe.Domain.csproj", "GICCafe.Domain/"]
COPY ["GICCafe.Application/GICCafe.Application.csproj", "GICCafe.Application/"]
COPY ["GICCafe.Infrastructure/GICCafe.Infrastructure.csproj", "GICCafe.Infrastructure/"]
RUN dotnet restore "GICCafe.API/GICCafe.API.csproj"

COPY . .
WORKDIR "/src/GICCafe.API"
RUN dotnet build "GICCafe.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GICCafe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GICCafe.API.dll"]
