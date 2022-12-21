#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Washyn.Web/Washyn.Web.csproj", "src/Washyn.Web/"]
COPY ["src/Washyn.Application/Washyn.Application.csproj", "src/Washyn.Application/"]
COPY ["src/Washyn.Domain/Washyn.Domain.csproj", "src/Washyn.Domain/"]
COPY ["src/Washyn.EntityFrameworkCore/Washyn.EntityFrameworkCore.csproj", "src/Washyn.EntityFrameworkCore/"]
RUN dotnet restore "src/Washyn.Web/Washyn.Web.csproj"
COPY . .
WORKDIR "/src/src/Washyn.Web"
RUN dotnet build "Washyn.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Washyn.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Washyn.Web.dll"]