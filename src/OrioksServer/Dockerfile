FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/OrioksServer/OrioksServer.csproj", "src/OrioksServer/"]
COPY ["src/OrioksServer.Domain/OrioksServer.Domain.csproj", "src/OrioksServer.Domain/"]
COPY ["src/OrioksServer.Abstractions/OrioksServer.Abstractions.csproj", "src/OrioksServer.Abstractions/"]
COPY ["src/OrioksServer.Persistance/OrioksServer.Persistance.csproj", "src/OrioksServer.Persistance/"]
RUN dotnet restore "src/OrioksServer/OrioksServer.csproj"
COPY . .
WORKDIR "/src/src/OrioksServer"
RUN dotnet build "OrioksServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrioksServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrioksServer.dll"]
