#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RDFSharp.Try/RDFSharp.Try.csproj", "RDFSharp.Try/"]
COPY ["RDFSharp/RDFSharp.csproj", "RDFSharp/"]
RUN dotnet restore "RDFSharp.Try/RDFSharp.Try.csproj"
COPY . .
WORKDIR "/src/RDFSharp.Try"
RUN dotnet build "RDFSharp.Try.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RDFSharp.Try.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RDFSharp.Try.dll"]