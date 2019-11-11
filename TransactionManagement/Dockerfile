FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TransactionManagement/TransactionManagement.csproj", "TransactionManagement/"]
RUN dotnet restore "TransactionManagement/TransactionManagement.csproj"
COPY . .
WORKDIR "/src/TransactionManagement"
RUN dotnet build "TransactionManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransactionManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionManagement.dll"]