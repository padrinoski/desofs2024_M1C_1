# Use the official .NET 8 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /DESOFT.Server

# Copy the .csproj file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore DESOFT.Server.csproj

# Copy the entire project and build it
COPY . ./
WORKDIR /DESOFT.Server
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image as the base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /DESOFT.Server
COPY --from=build-env /DESOFT.Server/out .

# Expose the port
EXPOSE 5265

# Define the entrypoint for the container - run the .NET Core runtime and specify the compiled .NET application to execute.
ENTRYPOINT ["dotnet", "DESOFT.Server.dll"]
