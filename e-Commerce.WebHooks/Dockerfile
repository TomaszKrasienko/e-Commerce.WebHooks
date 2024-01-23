FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY src/e-Commerce.WebHooks.Core/e-Commerce.WebHooks.Core.csproj ./e-Commerce.WebHooks.Core/
COPY src/e-Commerce.WebHooks.Application/e-Commerce.WebHooks.Application.csproj ./e-Commerce.WebHooks.Application/
COPY src/e-Commerce.WebHooks.Infrastructure/e-Commerce.WebHooks.Infrastructure.csproj ./e-Commerce.WebHooks.Infrastructure/
COPY src/e-Commerce.WebHooks.Api/e-Commerce.WebHooks.Api.csproj ./e-Commerce.WebHooks.Api/
RUN dotnet restore ./e-Commerce.WebHooks.Api/e-Commerce.WebHooks.Api.csproj -s https://api.nuget.org/v3/index.json 
COPY . ./
RUN dotnet publish ./e-Commerce.WebHooks.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "e-Commerce.WebHooks.Api.dll"]

ENV ASPNETCORE_ENVIRONMENT="Development"
ENV TZ="Europe/Warsaw"
EXPOSE 80
EXPOSE 443

