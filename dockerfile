FROM microsoft/dotnet:sdk
WORKDIR /app

# Copy files to the container
COPY ./ ./

# Restore packages
RUN dotnet restore ./profile-c-sharp-microservice.csproj
RUN dotnet publish -c Release ./profile-c-sharp-microservice.csproj -o out

# Run the app
CMD dotnet ./out/profile-c-sharp-microservice.dll
