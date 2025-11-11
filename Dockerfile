FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files
COPY src/StringCalculator/*.csproj src/StringCalculator/
COPY tests/StringCalculator.Tests/*.csproj tests/StringCalculator.Tests/
COPY StringCalculatorSolution.sln .

RUN dotnet restore StringCalculatorSolution.sln

# Copy source code
COPY src/StringCalculator/. src/StringCalculator/
COPY tests/StringCalculator.Tests/. tests/StringCalculator.Tests/

# Build and publish (build the solution to include tests and projects)
RUN dotnet build StringCalculatorSolution.sln --configuration Release --no-restore
RUN dotnet publish src/StringCalculator/StringCalculator.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "StringCalculator.dll"]