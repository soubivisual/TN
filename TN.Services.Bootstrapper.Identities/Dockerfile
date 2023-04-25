#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TN.Services.Bootstrapper.Identities/TN.Services.Bootstrapper.Identities.csproj", "TN.Services.Bootstrapper.Identities/"]
COPY ["TN.Modules.Identities.API/TN.Modules.Identities.API.csproj", "TN.Modules.Identities.API/"]
COPY ["TN.Modules.Identities.Infrastructure/TN.Modules.Identities.Infrastructure.csproj", "TN.Modules.Identities.Infrastructure/"]
COPY ["TN.Modules.Identities.Application/TN.Modules.Identities.Application.csproj", "TN.Modules.Identities.Application/"]
COPY ["TN.Modules.Identities.Domain/TN.Modules.Identities.Domain.csproj", "TN.Modules.Identities.Domain/"]
COPY ["TN.Modules.Buildings.Shared/TN.Modules.Buildings.Shared.csproj", "TN.Modules.Buildings.Shared/"]
COPY ["TN.Shared.Utils.Misc/TN.Shared.Utils.Misc.csproj", "TN.Shared.Utils.Misc/"]
RUN dotnet restore "TN.Services.Bootstrapper.Identities/TN.Services.Bootstrapper.Identities.csproj"
COPY . .
WORKDIR "/src/TN.Services.Bootstrapper.Identities"
RUN dotnet build "TN.Services.Bootstrapper.Identities.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.Services.Bootstrapper.Identities.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.Services.Bootstrapper.Identities.dll"]