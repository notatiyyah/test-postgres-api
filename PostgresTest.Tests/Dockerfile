FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN

WORKDIR /app

# Copy csproj and nuget config and restore as distinct layers
COPY ./PostgresTest.sln ./
COPY ./PostgresTest/PostgresTest.csproj ./PostgresTest/
COPY ./PostgresTest.Tests/PostgresTest.Tests.csproj ./PostgresTest.Tests/
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./PostgresTest/PostgresTest.csproj
RUN dotnet restore ./PostgresTest.Tests/PostgresTest.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out PostgresTest.Tests/PostgresTest.Tests.csproj

CMD dotnet test
