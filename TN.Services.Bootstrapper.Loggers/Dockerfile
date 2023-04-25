#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TN.Services.Bootstrapper.Loggers/TN.Services.Bootstrapper.Loggers.csproj", "TN.Services.Bootstrapper.Loggers/"]
COPY ["TN.Modules.Loggers.API/TN.Modules.Loggers.API.csproj", "TN.Modules.Loggers.API/"]
COPY ["TN.Modules.Loggers.Infrastructure/TN.Modules.Loggers.Infrastructure.csproj", "TN.Modules.Loggers.Infrastructure/"]
COPY ["TN.Modules.Buildings.Shared/TN.Modules.Buildings.Shared.csproj", "TN.Modules.Buildings.Shared/"]
COPY ["TN.Shared.Utils.Misc/TN.Shared.Utils.Misc.csproj", "TN.Shared.Utils.Misc/"]
COPY ["TN.Modules.Loggers.Application/TN.Modules.Loggers.Application.csproj", "TN.Modules.Loggers.Application/"]
COPY ["TN.Modules.Loggers.Domain/TN.Modules.Loggers.Domain.csproj", "TN.Modules.Loggers.Domain/"]
RUN dotnet restore "TN.Services.Bootstrapper.Loggers/TN.Services.Bootstrapper.Loggers.csproj"
COPY . .
WORKDIR "/src/TN.Services.Bootstrapper.Loggers"
RUN dotnet build "TN.Services.Bootstrapper.Loggers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.Services.Bootstrapper.Loggers.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.Services.Bootstrapper.Loggers.dll"]