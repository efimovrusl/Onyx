FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
ARG APP_UID=64198
USER ${APP_UID}
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Onyx.API/Onyx.API.csproj", "Onyx.API/"]
COPY ["Onyx.Application/Onyx.Application.csproj", "Onyx.Application/"]
COPY ["Onyx.Domain/Onyx.Domain.csproj", "Onyx.Domain/"]
COPY ["Onyx.Infrastructure/Onyx.Infrastructure.csproj", "Onyx.Infrastructure/"]
RUN dotnet restore "Onyx.API/Onyx.API.csproj"
COPY . .
WORKDIR "/src/Onyx.API"
RUN dotnet build "./Onyx.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Onyx.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onyx.API.dll"]
