# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY *.csproj ./
# Restore project packages
RUN dotnet restore
COPY . ./
# Create a release build
RUN dotnet build -c Release -o 

# Run the application and make it available on port 80
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80
# Assets and views
COPY --from=build /app/out ./
ENTRYPOINT [ "dotnet", "rpg.dll" ]