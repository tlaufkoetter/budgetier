FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM tlaufkoetter/dotnet.sdk.npm:3.1-12 AS build
WORKDIR /src
COPY ["BudgetierWeb.csproj", "./"]
RUN dotnet restore "./BudgetierWeb.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BudgetierWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BudgetierWeb.csproj" -c Release -o /app/publish
RUN dotnet dev-certs https -ep /app/publish/cert.cer

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ClientApp /app/
ENTRYPOINT ["dotnet", "BudgetierWeb.dll", "--urls", "https://*:5001;http://*:5000"]
