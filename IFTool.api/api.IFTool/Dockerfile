FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY api.IFTool.csproj ./
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/
RUN dotnet build api.IFTool.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish api.IFTool.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api.IFTool.dll"]

ENV TZ=Asia/Bangkok
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone