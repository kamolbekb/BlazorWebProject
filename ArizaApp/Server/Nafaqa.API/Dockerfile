FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Server/Nafaqa.API/Nafaqa.API.csproj", "Server/Nafaqa.API/"]
COPY ["Server/Nafaqa.Application/Nafaqa.Application.csproj", "Server/Nafaqa.Application/"]
COPY ["Server/Nafaqa.DataAccess/Nafaqa.DataAccess.csproj", "Server/Nafaqa.DataAccess/"]
COPY ["Server/Nafaqa.Core/Nafaqa.Core.csproj", "Server/Nafaqa.Core/"]
RUN dotnet restore "Server/Nafaqa.API/Nafaqa.API.csproj"
COPY . .
WORKDIR "/src/Server/Nafaqa.API"
RUN dotnet build "Nafaqa.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Nafaqa.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nafaqa.API.dll"]
