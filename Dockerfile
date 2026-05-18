FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /src
COPY MarsOnFireSite.API/ ./MarsOnFireSite.API/
RUN dotnet publish MarsOnFireSite.API/MarsOnFireSite.API.csproj -c Release -o /app/publish

FROM base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MarsOnFireSite.API.dll"]