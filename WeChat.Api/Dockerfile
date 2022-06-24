#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WeChat.Api/WeChat.Api.csproj", "WeChat.Api/"]
COPY ["WeChat.Core/WeChat.Core.csproj", "WeChat.Core/"]
RUN dotnet restore "WeChat.Api/WeChat.Api.csproj"
COPY . .
WORKDIR "/src/WeChat.Api"
RUN dotnet build "WeChat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeChat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeChat.Api.dll"]