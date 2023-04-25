#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TN.Services.Bootstrapper.Configurations/TN.Services.Bootstrapper.Configurations.csproj", "TN.Services.Bootstrapper.Configurations/"]
COPY ["TN.Modules.Configurations.API/TN.Modules.Configurations.API.csproj", "TN.Modules.Configurations.API/"]
COPY ["TN.Modules.Configurations.Infrastructure/TN.Modules.Configurations.Infrastructure.csproj", "TN.Modules.Configurations.Infrastructure/"]
COPY ["TN.Modules.Configurations.Application/TN.Modules.Configurations.Application.csproj", "TN.Modules.Configurations.Application/"]
COPY ["TN.Modules.Configurations.Domain/TN.Modules.Configurations.Domain.csproj", "TN.Modules.Configurations.Domain/"]
COPY ["TN.Modules.Buildings.Shared/TN.Modules.Buildings.Shared.csproj", "TN.Modules.Buildings.Shared/"]
COPY ["TN.Shared.Utils.Misc/TN.Shared.Utils.Misc.csproj", "TN.Shared.Utils.Misc/"]
RUN dotnet restore "TN.Services.Bootstrapper.Configurations/TN.Services.Bootstrapper.Configurations.csproj"
COPY . .
WORKDIR "/src/TN.Services.Bootstrapper.Configurations"
RUN dotnet build "TN.Services.Bootstrapper.Configurations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.Services.Bootstrapper.Configurations.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.Services.Bootstrapper.Configurations.dll"]