#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TN.Services.Bootstrapper.Notifications/TN.Services.Bootstrapper.Notifications.csproj", "TN.Services.Bootstrapper.Notifications/"]
COPY ["TN.Modules.Notifications.API/TN.Modules.Notifications.API.csproj", "TN.Modules.Notifications.API/"]
COPY ["TN.Modules.Notifications.Infrastructure/TN.Modules.Notifications.Infrastructure.csproj", "TN.Modules.Notifications.Infrastructure/"]
COPY ["TN.Modules.Notifications.Application/TN.Modules.Notifications.Application.csproj", "TN.Modules.Notifications.Application/"]
COPY ["TN.Modules.Notifications.Domain/TN.Modules.Notifications.Domain.csproj", "TN.Modules.Notifications.Domain/"]
COPY ["TN.Modules.Buildings.Shared/TN.Modules.Buildings.Shared.csproj", "TN.Modules.Buildings.Shared/"]
COPY ["TN.Shared.Utils.Misc/TN.Shared.Utils.Misc.csproj", "TN.Shared.Utils.Misc/"]
RUN dotnet restore "TN.Services.Bootstrapper.Notifications/TN.Services.Bootstrapper.Notifications.csproj"
COPY . .
WORKDIR "/src/TN.Services.Bootstrapper.Notifications"
RUN dotnet build "TN.Services.Bootstrapper.Notifications.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.Services.Bootstrapper.Notifications.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.Services.Bootstrapper.Notifications.dll"]