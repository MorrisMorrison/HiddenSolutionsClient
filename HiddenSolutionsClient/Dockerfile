FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY HiddenSolutionsClient.csproj ./
RUN dotnet restore "HiddenSolutionsClient.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "HiddenSolutionsClient.csproj" -c Release -o /app/build
RUN dotnet publish "HiddenSolutionsClient.csproj" -c Release -o /app/publish


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://*:$PORT

#ENTRYPOINT ["dotnet", "HiddenSolutionsClient.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT ASPNETCORE_ENVIRONMENT=Development dotnet HiddenSolutionsClient.dll