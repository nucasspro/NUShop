#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["NUShop.WebMVC/NUShop.WebMVC.csproj", "NUShop.WebMVC/"]
COPY ["NUShop.Service/NUShop.Service.csproj", "NUShop.Service/"]
COPY ["NUShop.Data/NUShop.Data.csproj", "NUShop.Data/"]
COPY ["NUShop.Infrastructure/NUShop.Infrastructure.csproj", "NUShop.Infrastructure/"]
COPY ["NUShop.Utilities/NUShop.Utilities.csproj", "NUShop.Utilities/"]
COPY ["NUShop.ViewModel/NUShop.ViewModel.csproj", "NUShop.ViewModel/"]
COPY ["WebAPI/NUShop.WebAPI.csproj", "WebAPI/"]
COPY ["NUShop.Data.EF/NUShop.Data.EF.csproj", "NUShop.Data.EF/"]
RUN dotnet restore "NUShop.WebMVC/NUShop.WebMVC.csproj"
COPY . .
WORKDIR "/src/NUShop.WebMVC"
RUN dotnet build "NUShop.WebMVC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NUShop.WebMVC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NUShop.WebMVC.dll"]