FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Nummora.Api/Nummora.Api.csproj", "src/Nummora.Api/"]
COPY ["src/Nummora.Application/Nummora.Application.csproj", "src/Nummora.Application/"]
COPY ["src/Nummora.Domain/Nummora.Domain.csproj", "src/Nummora.Domain/"]
COPY ["src/Nummora.Contracts/Nummora.Contracts.csproj", "src/Nummora.Contracts/"]
COPY ["src/Nummora.Infrastructure/Nummora.Infrastructure.csproj", "src/Nummora.Infrastructure/"]
RUN dotnet restore "src/Nummora.Api/Nummora.Api.csproj"
COPY . .
WORKDIR "/src/src/Nummora.Api"
RUN dotnet build "Nummora.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Nummora.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nummora.Api.dll"]
