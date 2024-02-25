# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY . ./
RUN dotnet restore

# Compila a API e as bibliotecas de classes
RUN dotnet build -c Release

# Publica a API
RUN dotnet publish HahnSoftwareCrud.Api/HahnSoftwareCrud.Api.csproj -c Release -o /app/out

# Estágio de produção
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copia a API publicada do estágio de compilação
COPY --from=build-env /app/out .

# Expõe a porta 80 para a API
EXPOSE 5000

# Define o comando de inicialização para a API
ENTRYPOINT ["dotnet", "HahnSoftwareCrud.Api.dll"]