# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ./entrypoint.sh ./
COPY Airflights/*.csproj Airflights/
COPY AirflightsDataAccess/*.csproj AirflightsDataAccess/
COPY AirflightsDomain/*.csproj AirflightsDomain/
COPY AirflightsShared/*.csproj AirflightsShared/
RUN dotnet restore Airflights/Airflights.csproj

# copy and build app and libraries
COPY Airflights/ Airflights/
COPY AirflightsDataAccess/ AirflightsDataAccess/
COPY AirflightsDomain/ AirflightsDomain/
COPY AirflightsShared/ AirflightsShared/
WORKDIR /source/Airflights
RUN dotnet build -c release --no-restore

# # test stage -- exposes optional entrypoint
# # target entrypoint with: docker build --target test
# FROM build AS test
# WORKDIR /source/tests
# COPY tests/ .
# ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

RUN chmod +x /source/entrypoint.sh
CMD /bin/bash /source/entrypoint.sh

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Airflights.dll"]