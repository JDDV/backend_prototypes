FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RoomReservation/RoomReservation.csproj", "RoomReservation/"]
RUN dotnet restore "RoomReservation/RoomReservation.csproj"
COPY . .
WORKDIR "/src/RoomReservation"
RUN dotnet build "RoomReservation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoomReservation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomReservation.dll"]
