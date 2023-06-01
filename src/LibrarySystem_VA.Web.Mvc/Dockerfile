FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/LibrarySystem_VA.Web.Mvc/LibrarySystem_VA.Web.Mvc.csproj", "src/LibrarySystem_VA.Web.Mvc/"]
COPY ["src/LibrarySystem_VA.Web.Core/LibrarySystem_VA.Web.Core.csproj", "src/LibrarySystem_VA.Web.Core/"]
COPY ["src/LibrarySystem_VA.Application/LibrarySystem_VA.Application.csproj", "src/LibrarySystem_VA.Application/"]
COPY ["src/LibrarySystem_VA.Core/LibrarySystem_VA.Core.csproj", "src/LibrarySystem_VA.Core/"]
COPY ["src/LibrarySystem_VA.EntityFrameworkCore/LibrarySystem_VA.EntityFrameworkCore.csproj", "src/LibrarySystem_VA.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystem_VA.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystem_VA.Web.Mvc", "src/LibrarySystem_VA.Web.Mvc"]
COPY ["src/LibrarySystem_VA.Web.Core", "src/LibrarySystem_VA.Web.Core"]
COPY ["src/LibrarySystem_VA.Application", "src/LibrarySystem_VA.Application"]
COPY ["src/LibrarySystem_VA.Core", "src/LibrarySystem_VA.Core"]
COPY ["src/LibrarySystem_VA.EntityFrameworkCore", "src/LibrarySystem_VA.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystem_VA.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystem_VA.Web.Mvc.dll"]
