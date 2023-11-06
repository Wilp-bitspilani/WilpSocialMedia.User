FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WilpSocialMedia.User/WilpSocialMedia.User.csproj", "WilpSocialMedia.User/"]
COPY ["WilpSocialMedia.Common/WilpSocialMedia.Common.csproj", "WilpSocialMedia.Common/"]
RUN dotnet restore "WilpSocialMedia.User/WilpSocialMedia.User.csproj"
COPY . .
WORKDIR "/src/WilpSocialMedia.User"
RUN dotnet build "WilpSocialMedia.User.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WilpSocialMedia.User.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WilpSocialMedia.User.dll"]
