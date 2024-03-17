#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservice2Api.Containers.Demo/Microservice2Api.Containers.Demo.csproj", "Microservice2Api.Containers.Demo/"]
RUN dotnet restore "Microservice2Api.Containers.Demo/Microservice2Api.Containers.Demo.csproj"
COPY . .
WORKDIR "/src/Microservice2Api.Containers.Demo"
RUN dotnet build "Microservice2Api.Containers.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice2Api.Containers.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice2Api.Containers.Demo.dll"]