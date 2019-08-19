#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["IFSP.Plataforma.Identity/IFSP.Plataforma.Identity.csproj", "IFSP.Plataforma.Identity/"]
RUN dotnet restore "IFSP.Plataforma.Identity/IFSP.Plataforma.Identity.csproj"
COPY . .
WORKDIR "/src/IFSP.Plataforma.Identity"
RUN dotnet build "IFSP.Plataforma.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IFSP.Plataforma.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IFSP.Plataforma.Identity.dll"]