# Use official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy and restore dependencies
COPY DotNetSqlApp.csproj .
RUN dotnet restore

# Copy the rest and build
COPY . .

RUN dotnet publish -c Release -o  /app/out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "DotNetSqlApp.dll"]
