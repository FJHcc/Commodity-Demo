FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 51458
EXPOSE 44331

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY CommodityManagement.WebApi/CommodityManagement.WebApi.csproj CommodityManagement.WebApi/
RUN dotnet restore CommodityManagement.WebApi/CommodityManagement.WebApi.csproj
COPY . .
WORKDIR /src/CommodityManagement.WebApi
RUN dotnet build CommodityManagement.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CommodityManagement.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CommodityManagement.WebApi.dll"]
