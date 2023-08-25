#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["GitHubActionPlayGround/GitHubActionPlayGround.csproj", "GitHubActionPlayGround/"]
COPY ["GitHubActionPlayGroundTest/GitHubActionPlayGroundTest.csproj", "GitHubActionPlayGroundTest/"]

RUN dotnet restore "GitHubActionPlayGround/GitHubActionPlayGround.csproj"
COPY . .

WORKDIR "/src/GitHubActionPlayGround"
RUN dotnet build "GitHubActionPlayGround.csproj" -c Release -o /app/build

FROM build AS test
LABEL test=true
RUN dotnet test -c Release --results-directory /testresults --logger "trx;LogFileName=test_results.trx" GitHubActionPlayGroundTest.csproj /p:CollectCoverage=true /p:CoverletOutput=/testresults/coverage /p:CoverletOutputFormat=cobertura

FROM build AS publish
RUN dotnet publish "GitHubActionPlayGround.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitHubActionPlayGround.dll"]