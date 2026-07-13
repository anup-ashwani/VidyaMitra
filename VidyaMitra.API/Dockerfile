FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy only the solution and project files first for better layer caching
COPY ["VidyaMitra.BuildAll.slnx", "./"]
COPY ["VidyaMitra.API/VidyaMitra.API.csproj", "VidyaMitra.API/"]
COPY ["VidyaMitra.Application/VidyaMitra.Application.csproj", "VidyaMitra.Application/"]
COPY ["VidyaMitra.Repository/VidyaMitra.Repository.csproj", "VidyaMitra.Repository/"]
COPY ["VidyaMitra.Domain/VidyaMitra.Domain.csproj", "VidyaMitra.Domain/"]
COPY ["AuthApi/AuthApi.csproj", "AuthApi/"]
COPY ["VidyaMitra.Client/VidyaMitra.Client.csproj", "VidyaMitra.Client/"]

RUN dotnet restore "VidyaMitra.BuildAll.slnx"

# Copy the rest of the source code and publish
COPY . .
WORKDIR /src/VidyaMitra.API
RUN dotnet publish "VidyaMitra.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "VidyaMitra.API.dll"]
