FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HMUniversity.Profiles/HMUniversity.Profiles.csproj", "HMUniversity.Profiles/"]
RUN dotnet restore "HMUniversity.Profiles/HMUniversity.Profiles.csproj"
COPY . .
WORKDIR "/src/HMUniversity.Profiles"
RUN dotnet build "HMUniversity.Profiles.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HMUniversity.Profiles.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HMUniversity.Profiles.dll"]
