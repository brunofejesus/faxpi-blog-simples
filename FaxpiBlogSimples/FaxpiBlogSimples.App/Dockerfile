#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base


USER app
WORKDIR /app
EXPOSE 8090


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FaxpiBlogSimples.App/FaxpiBlogSimples.App.csproj", "FaxpiBlogSimples.App/"]
RUN dotnet restore "./FaxpiBlogSimples.App/FaxpiBlogSimples.App.csproj"
COPY . .
WORKDIR "/src/FaxpiBlogSimples.App"
RUN dotnet build "./FaxpiBlogSimples.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FaxpiBlogSimples.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8090
ENTRYPOINT ["dotnet", "FaxpiBlogSimples.App.dll"]