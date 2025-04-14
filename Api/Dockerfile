FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]

RUN dotnet restore "WeddingApi/Api/Api.csproj"
COPY . .
WORKDIR "/src/WeddingApi/Api"
RUN dotnet build --no-restore "Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish --no-restore "Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update 

ENTRYPOINT ["dotnet", "WeddingApi.dll"]
