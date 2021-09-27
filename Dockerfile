FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "ppp.csproj"
RUN dotnet build "ppp.csproj" --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish "ppp.csproj" --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "ppp.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ppp.dll