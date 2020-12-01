#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Loja.Ecommerce.API/Loja.Ecommerce.API.csproj", "Loja.Ecommerce.API/"]
COPY ["Loja.Ecommerce.Infra/Loja.Ecommerce.Infra.csproj", "Loja.Ecommerce.Infra/"]
COPY ["Loja.Ecommerce.Domain/Loja.Ecommerce.Domain.csproj", "Loja.Ecommerce.Domain/"]
COPY ["Loja.Ecommerce.Services/Loja.Ecommerce.Services.csproj", "Loja.Ecommerce.Services/"]
RUN dotnet restore "Loja.Ecommerce.API/Loja.Ecommerce.API.csproj"
COPY . .
WORKDIR "/src/Loja.Ecommerce.API"
RUN dotnet build "Loja.Ecommerce.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Loja.Ecommerce.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loja.Ecommerce.API.dll"]