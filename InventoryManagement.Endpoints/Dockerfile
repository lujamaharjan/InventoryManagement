# Use the official Microsoft ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official Microsoft ASP.NET Core SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InventoryManagement.Endpoints/InventoryManagement.Endpoints.csproj", "InventoryManagement.Endpoints/"]
RUN dotnet restore "InventoryManagement.Endpoints/InventoryManagement.Endpoints.csproj"
COPY . .
WORKDIR "/src/InventoryManagement.Endpoints"
RUN dotnet build "InventoryManagement.Endpoints.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventoryManagement.Endpoints.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryManagement.Endpoints.dll"]
