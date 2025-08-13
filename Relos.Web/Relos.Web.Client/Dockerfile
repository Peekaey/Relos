FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Relos.Web/Relos.Web.Client/Relos.Web.Client.csproj", "Relos.Web/Relos.Web.Client/"]
RUN dotnet restore "Relos.Web/Relos.Web.Client/Relos.Web.Client.csproj"
COPY . .
WORKDIR "/src/Relos.Web/Relos.Web.Client"
RUN dotnet build "./Relos.Web.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Relos.Web.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Relos.Web.Client.dll"]
