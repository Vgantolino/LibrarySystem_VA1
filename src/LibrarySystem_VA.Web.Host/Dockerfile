FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LibrarySystem_VA.Web.Host/LibrarySystem_VA.Web.Host.csproj", "src/LibrarySystem_VA.Web.Host/"]
COPY ["src/LibrarySystem_VA.Web.Core/LibrarySystem_VA.Web.Core.csproj", "src/LibrarySystem_VA.Web.Core/"]
COPY ["src/LibrarySystem_VA.Application/LibrarySystem_VA.Application.csproj", "src/LibrarySystem_VA.Application/"]
COPY ["src/LibrarySystem_VA.Core/LibrarySystem_VA.Core.csproj", "src/LibrarySystem_VA.Core/"]
COPY ["src/LibrarySystem_VA.EntityFrameworkCore/LibrarySystem_VA.EntityFrameworkCore.csproj", "src/LibrarySystem_VA.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystem_VA.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystem_VA.Web.Host", "src/LibrarySystem_VA.Web.Host"]
COPY ["src/LibrarySystem_VA.Web.Core", "src/LibrarySystem_VA.Web.Core"]
COPY ["src/LibrarySystem_VA.Application", "src/LibrarySystem_VA.Application"]
COPY ["src/LibrarySystem_VA.Core", "src/LibrarySystem_VA.Core"]
COPY ["src/LibrarySystem_VA.EntityFrameworkCore", "src/LibrarySystem_VA.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystem_VA.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystem_VA.Web.Host.dll"]
