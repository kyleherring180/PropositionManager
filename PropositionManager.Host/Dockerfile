FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Force SQL Server to use invariant culture
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true
# Prevent SQL Client from using specific culture
ENV MSSQL_LCID=127
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PropositionManager.Host/PropositionManager.Host.csproj", "PropositionManager.Host/"]
COPY ["PropositionManager.Data/PropositionManager.Data.csproj", "PropositionManager.Data/"]
COPY ["PropositionManager.Model/PropositionManager.Model.csproj", "PropositionManager.Model/"]
RUN dotnet restore "PropositionManager.Host/PropositionManager.Host.csproj"
COPY . .
WORKDIR "/src/PropositionManager.Host"
RUN dotnet build "PropositionManager.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PropositionManager.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PropositionManager.Host.dll"]