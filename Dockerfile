FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore TrainReservation.Api/TrainReservation.Api.csproj
RUN dotnet publish TrainReservation.Api/TrainReservation.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["sh","-c","dotnet TrainReservation.Api.dll --urls http://0.0.0.0:${PORT:-8080}"]
