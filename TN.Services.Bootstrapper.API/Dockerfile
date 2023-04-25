#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TN.Services.Bootstrapper.API/TN.Services.Bootstrapper.API.csproj", "TN.Services.Bootstrapper.API/"]
COPY ["TN.Modules.Configurations.API/TN.Modules.Configurations.API.csproj", "TN.Modules.Configurations.API/"]
COPY ["TN.Modules.Configurations.Infrastructure/TN.Modules.Configurations.Infrastructure.csproj", "TN.Modules.Configurations.Infrastructure/"]
COPY ["TN.Modules.Configurations.Application/TN.Modules.Configurations.Application.csproj", "TN.Modules.Configurations.Application/"]
COPY ["TN.Modules.Configurations.Domain/TN.Modules.Configurations.Domain.csproj", "TN.Modules.Configurations.Domain/"]
COPY ["TN.Modules.Buildings.Shared/TN.Modules.Buildings.Shared.csproj", "TN.Modules.Buildings.Shared/"]
COPY ["TN.Shared.Utils.Misc/TN.Shared.Utils.Misc.csproj", "TN.Shared.Utils.Misc/"]
COPY ["TN.Modules.Identities.API/TN.Modules.Identities.API.csproj", "TN.Modules.Identities.API/"]
COPY ["TN.Modules.Identities.Infrastructure/TN.Modules.Identities.Infrastructure.csproj", "TN.Modules.Identities.Infrastructure/"]
COPY ["TN.Modules.Identities.Application/TN.Modules.Identities.Application.csproj", "TN.Modules.Identities.Application/"]
COPY ["TN.Modules.Identities.Domain/TN.Modules.Identities.Domain.csproj", "TN.Modules.Identities.Domain/"]
COPY ["TN.Modules.Loggers.API/TN.Modules.Loggers.API.csproj", "TN.Modules.Loggers.API/"]
COPY ["TN.Modules.Loggers.Infrastructure/TN.Modules.Loggers.Infrastructure.csproj", "TN.Modules.Loggers.Infrastructure/"]
COPY ["TN.Modules.Loggers.Application/TN.Modules.Loggers.Application.csproj", "TN.Modules.Loggers.Application/"]
COPY ["TN.Modules.Loggers.Domain/TN.Modules.Loggers.Domain.csproj", "TN.Modules.Loggers.Domain/"]
COPY ["TN.Modules.Notifications.API/TN.Modules.Notifications.API.csproj", "TN.Modules.Notifications.API/"]
COPY ["TN.Modules.Notifications.Infrastructure/TN.Modules.Notifications.Infrastructure.csproj", "TN.Modules.Notifications.Infrastructure/"]
COPY ["TN.Modules.Notifications.Application/TN.Modules.Notifications.Application.csproj", "TN.Modules.Notifications.Application/"]
COPY ["TN.Modules.Notifications.Domain/TN.Modules.Notifications.Domain.csproj", "TN.Modules.Notifications.Domain/"]
COPY ["TN.Modules.Remittances.API/TN.Modules.Remittances.API.csproj", "TN.Modules.Remittances.API/"]
COPY ["TN.Modules.Remittances.Infrastructure/TN.Modules.Remittances.Infrastructure.csproj", "TN.Modules.Remittances.Infrastructure/"]
COPY ["TN.Modules.Remittances.Application/TN.Modules.Remittances.Application.csproj", "TN.Modules.Remittances.Application/"]
COPY ["TN.Modules.Remittances.Domain/TN.Modules.Remittances.Domain.csproj", "TN.Modules.Remittances.Domain/"]
RUN dotnet restore "TN.Services.Bootstrapper.API/TN.Services.Bootstrapper.API.csproj"
COPY . .
WORKDIR "/src/TN.Services.Bootstrapper.API"
RUN dotnet build "TN.Services.Bootstrapper.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.Services.Bootstrapper.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.Services.Bootstrapper.API.dll"]