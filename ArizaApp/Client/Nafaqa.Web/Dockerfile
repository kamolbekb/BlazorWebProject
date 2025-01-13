FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Client/Nafaqa.Web/Nafaqa.Web.csproj", "Client/Nafaqa.Web/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "Client/Nafaqa.Web/Nafaqa.Web.csproj"
COPY . .
WORKDIR "/src/Client/Nafaqa.Web"
RUN dotnet build "Nafaqa.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Nafaqa.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nafaqa.Web.dll"]
