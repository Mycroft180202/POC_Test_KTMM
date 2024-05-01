
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5272

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["POC_Test_KTMM_MayAoMariaDB/POC_Test_KTMM_MayAoMariaDB.csproj", "POC_Test_KTMM_MayAoMariaDB/"]
RUN dotnet restore "./POC_Test_KTMM_MayAoMariaDB/POC_Test_KTMM_MayAoMariaDB.csproj"
COPY . .
WORKDIR "/src/POC_Test_KTMM_MayAoMariaDB"
RUN dotnet build "./POC_Test_KTMM_MayAoMariaDB.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./POC_Test_KTMM_MayAoMariaDB.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC_Test_KTMM_MayAoMariaDB.dll"] 