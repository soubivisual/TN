#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TN.Services.Bootstrapper.Remittance/TN.Services.Bootstrapper.Remittance.csproj", "TN.Services.Bootstrapper.Remittance/"]
COPY ["TN.Modules.Remittances.API/TN.Modules.Remittances.API.csproj", "TN.Modules.Remittances.API/"]
COPY ["TN.Modules.Remittances.Infrastructure/TN.Modules.Remittances.Infrastructure.csproj", "TN.Modules.Remittances.Infrastructure/"]
COPY ["TN.Modules.Remittances.Application/TN.Modules.Remittances.Application.csproj", "TN.Modules.Remittances.Application/"]
COPY ["TN.Modules.Remittances.Domain/TN.Modules.Remittances.Domain.csproj", "TN.Modules.Remittances.Domain/"]
COPY ["TN.Modules.Buildings.Shared/TN.Modules.Buildings.Shared.csproj", "TN.Modules.Buildings.Shared/"]
COPY ["TN.Shared.Utils.Misc/TN.Shared.Utils.Misc.csproj", "TN.Shared.Utils.Misc/"]
RUN dotnet restore "TN.Services.Bootstrapper.Remittance/TN.Services.Bootstrapper.Remittance.csproj"
COPY . .
WORKDIR "/src/TN.Services.Bootstrapper.Remittance"
RUN dotnet build "TN.Services.Bootstrapper.Remittance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TN.Services.Bootstrapper.Remittance.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TN.Services.Bootstrapper.Remittance.dll"]