FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SP.CRUD.Dapper.UnidadeTerra.CS/SP.CRUD.Dapper.UnidadeTerra.CS.csproj", "SP.CRUD.Dapper.UnidadeTerra.CS/"]
RUN dotnet restore "SP.CRUD.Dapper.UnidadeTerra.CS/SP.CRUD.Dapper.UnidadeTerra.CS.csproj"
COPY . .
WORKDIR "/src/SP.CRUD.Dapper.UnidadeTerra.CS"
RUN dotnet build "SP.CRUD.Dapper.UnidadeTerra.CS.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SP.CRUD.Dapper.UnidadeTerra.CS.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SP.CRUD.Dapper.UnidadeTerra.CS.dll"]
