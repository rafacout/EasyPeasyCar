FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EasyPeasy.API/EasyPeasy.API.csproj", "EasyPeasy.API/"]
COPY ["EasyPeasy.Application/EasyPeasy.Application.csproj", "EasyPeasy.Application/"]
COPY ["EasyPeasy.Domain/EasyPeasy.Domain.csproj", "EasyPeasy.Domain/"]
COPY ["EasyPeasy.Infrastructure/EasyPeasy.Infrastructure.csproj", "EasyPeasy.Infrastructure/"]
RUN dotnet restore "EasyPeasy.API/EasyPeasy.API.csproj"
COPY . .
WORKDIR "/src/EasyPeasy.API"
RUN dotnet build "EasyPeasy.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EasyPeasy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyPeasy.API.dll"]
