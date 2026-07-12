FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["AuthApi/AuthApi.csproj", "AuthApi/"]
RUN dotnet restore "AuthApi/AuthApi.csproj"

COPY . .
WORKDIR /src/AuthApi
RUN dotnet publish "AuthApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "AuthApi.dll"]
