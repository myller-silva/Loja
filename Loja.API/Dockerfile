FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Loja.API/Loja.API.csproj", "Loja.API/"]
RUN dotnet restore "Loja.API/Loja.API.csproj"
COPY . .
WORKDIR "/src/Loja.API"
RUN dotnet build "Loja.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Loja.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loja.API.dll"]
