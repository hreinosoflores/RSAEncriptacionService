FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
COPY ["private.key.pem", "./"]
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["RSAEncriptacionService.csproj", "./"]
RUN dotnet restore "./RSAEncriptacionService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RSAEncriptacionService.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "RSAEncriptacionService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RSAEncriptacionService.dll"]