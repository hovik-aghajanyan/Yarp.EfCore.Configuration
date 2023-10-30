FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["example/Yarp.EfCore.Configuration.Example/Yarp.EfCore.Configuration.Example.csproj", "example/Yarp.EfCore.Configuration.Example/"]
RUN dotnet restore "example/Yarp.EfCore.Configuration.Example/Yarp.EfCore.Configuration.Example.csproj"
COPY . .
WORKDIR "/src/example/Yarp.EfCore.Configuration.Example"
RUN dotnet build "Yarp.EfCore.Configuration.Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yarp.EfCore.Configuration.Example.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yarp.EfCore.Configuration.Example.dll"]
