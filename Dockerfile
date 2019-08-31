FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /beermeAPI

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /beermeAPI
COPY --from=build-env beermeAPI/out .

CMD dotnet beermeAPI.dll --urls "http://*:$PORT"
