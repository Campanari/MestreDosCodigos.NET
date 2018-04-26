FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MestreDosCodigos.NET.3/MestreDosCodigos.NET.3.csproj MestreDosCodigos.NET.3/
RUN dotnet restore MestreDosCodigos.NET.3/MestreDosCodigos.NET.3.csproj
COPY . .
WORKDIR /src/MestreDosCodigos.NET.3
RUN dotnet build MestreDosCodigos.NET.3.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MestreDosCodigos.NET.3.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MestreDosCodigos.NET.3.dll"]
