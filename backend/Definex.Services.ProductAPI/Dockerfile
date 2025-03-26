FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 60087

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Definex.Services.ProductAPI/Definex.Services.ProductAPI.csproj", "Definex.Services.ProductAPI/"]
RUN dotnet restore "Definex.Services.ProductAPI/Definex.Services.ProductAPI.csproj"
COPY . .
WORKDIR "/src/Definex.Services.ProductAPI"
RUN dotnet build "Definex.Services.ProductAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Definex.Services.ProductAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Definex.Services.ProductAPI.dll"]
