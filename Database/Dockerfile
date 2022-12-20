#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Database/Database.csproj", "Database/"]
RUN dotnet restore "Database/Database.csproj"
COPY . .
WORKDIR "/src/Database"
RUN dotnet build "Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Database.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Database.dll"]