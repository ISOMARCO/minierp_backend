FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/MiniErp.API/MiniErp.API.csproj", "Presentation/MiniErp.API/"]
COPY ["Infrastructure/MiniErp.Persistence/MiniErp.Persistence.csproj", "Infrastructure/MiniErp.Persistence/"]
COPY ["Core/MiniErp.Domain/MiniErp.Domain.csproj", "Core/MiniErp.Domain/"]
COPY ["Core/MiniErp.Application/MiniErp.Application.csproj", "Core/MiniErp.Application/"]
RUN dotnet restore "Presentation/MiniErp.API/MiniErp.API.csproj"
COPY . .
WORKDIR "/src/Presentation/MiniErp.API"
RUN dotnet build "MiniErp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MiniErp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniErp.API.dll"]
