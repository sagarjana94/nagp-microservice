FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ServiceRequestManagement/ServiceRequestManagement.csproj", "ServiceRequestManagement/"]
RUN dotnet restore "ServiceRequestManagement/ServiceRequestManagement.csproj"
COPY . .
WORKDIR "/src/ServiceRequestManagement"
RUN dotnet build "ServiceRequestManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceRequestManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceRequestManagement.dll"]