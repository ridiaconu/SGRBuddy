FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8443
ENV ASPNETCORE_URLS=http://+:8080;https://+:8443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["SGRBuddy.API/SGRBuddy.API.csproj", "SGRBuddy.API/"]
COPY ["SGRBuddy.BusinessLogic/SGRBuddy.BusinessLogic.csproj", "SGRBuddy.BusinessLogic/"]
COPY ["SGRBuddy.DataAccess/SGRBuddy.DataAccess.csproj", "SGRBuddy.DataAccess/"]
COPY ["SGRBuddy.Domain/SGRBuddy.Domain.csproj", "SGRBuddy.Domain/"]

# Restore dependencies
RUN dotnet restore "SGRBuddy.API/SGRBuddy.API.csproj"

# Copy remaining files
COPY . .

# Build
WORKDIR "/src/SGRBuddy.API"
RUN dotnet build "SGRBuddy.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SGRBuddy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGRBuddy.API.dll"]
