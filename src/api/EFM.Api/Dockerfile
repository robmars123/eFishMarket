# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/api/EFM.Api/EFM.Api.csproj", "src/api/EFM.Api/"]
COPY ["src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Api/EFM.Inventory.Api.csproj", "src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Api/"]
COPY ["src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Application/EFM.Inventory.Application.csproj", "src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Application/"]
COPY ["src/api/EFM.Common/EFM.Common.Application/EFM.Common.Application.csproj", "src/api/EFM.Common/EFM.Common.Application/"]
COPY ["src/api/EFM.Common/EFM.Common.Domain/EFM.Common.Domain.csproj", "src/api/EFM.Common/EFM.Common.Domain/"]
COPY ["src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Domain/EFM.Inventory.Domain.csproj", "src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Domain/"]
COPY ["src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Infrastructure/EFM.Inventory.Infrastructure.csproj", "src/api/EFM.BoundedContext/Inventory/EFM.Inventory.Infrastructure/"]
COPY ["src/api/EFM.Common/EFM.Common.Infrastructure/EFM.Common.Infrastructure.csproj", "src/api/EFM.Common/EFM.Common.Infrastructure/"]
COPY ["src/api/EFM.BoundedContext/Inventory/EFM.Inventory.PublicApi/EFM.Inventory.PublicApi.csproj", "src/api/EFM.BoundedContext/Inventory/EFM.Inventory.PublicApi/"]
COPY ["src/api/EFM.BoundedContext/Products/EFM.Products.Api/EFM.Products.Api.csproj", "src/api/EFM.BoundedContext/Products/EFM.Products.Api/"]
COPY ["src/api/EFM.BoundedContext/Products/EFM.Products.Application/EFM.Products.Application.csproj", "src/api/EFM.BoundedContext/Products/EFM.Products.Application/"]
COPY ["src/api/EFM.BoundedContext/Products/EFM.Products.Domain/EFM.Products.Domain.csproj", "src/api/EFM.BoundedContext/Products/EFM.Products.Domain/"]
COPY ["src/api/EFM.BoundedContext/Products/EFM.Products.Infrastructure/EFM.Products.Infrastructure.csproj", "src/api/EFM.BoundedContext/Products/EFM.Products.Infrastructure/"]
RUN dotnet restore "./src/api/EFM.Api/EFM.Api.csproj"
COPY . .
WORKDIR "/src/src/api/EFM.Api"
RUN dotnet build "./EFM.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EFM.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFM.Api.dll"]