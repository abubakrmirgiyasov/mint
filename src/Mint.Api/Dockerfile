FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mint.Api/Mint.Api.csproj", "Mint.Api/"]
RUN dotnet restore "Mint.Api/Mint.Api.csproj"
COPY . .
WORKDIR "/src/Mint.Api"
RUN dotnet build "Mint.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mint.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mint.Api.dll"]