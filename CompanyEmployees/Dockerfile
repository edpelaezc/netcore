FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-image
WORKDIR /home/app
COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore

# esto hará que sólo tenga que hacer un publish al fuente cada que compile una imagen
# haciendo que los paquetes queden en caché para docker


COPY . .
RUN dotnet test ./Tests/Tests.csproj
RUN dotnet publish ./CompanyEmployees/CompanyEmployees.csproj -o /publish/ 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /publish
COPY --from=build-image /publish .
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
ENV ASPNETCORE_HTTPS_PORT=8081

# dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p <CREDENTIAL_PLACEHOLDER>
# dotnet dev-certs https --trust
# docker run --rm -it -p 8000:5000 -p 8001:5001 -v ${HOME}/.aspnet/https:/https/ companyemployees:2.0
# https://learn.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-3.1

ENTRYPOINT ["dotnet", "CompanyEmployees.dll"]