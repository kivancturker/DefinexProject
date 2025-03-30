FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DefineX.Services.ChatAPI/DefineX.Services.ChatAPI.csproj", "DefineX.Services.ChatAPI/"]
RUN dotnet restore "DefineX.Services.ChatAPI/DefineX.Services.ChatAPI.csproj"
COPY . .
WORKDIR "/src/DefineX.Services.ChatAPI"
RUN dotnet build "DefineX.Services.ChatAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DefineX.Services.ChatAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefineX.Services.ChatAPI.dll"]
