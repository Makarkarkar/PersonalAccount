FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Personal Account/Personal Account.csproj", "Personal Account/"]
RUN dotnet restore "Personal Account/Personal Account.csproj"
COPY . .
WORKDIR "/src/Personal Account"
RUN dotnet build "Personal Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Personal Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Personal Account.dll"]