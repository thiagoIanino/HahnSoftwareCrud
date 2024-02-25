# Estágio 1: Construir a aplicação Angular
FROM node:20 as build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia o arquivo package.json para o diretório de trabalho
COPY package.json .

# Instala as dependências do projeto
RUN npm install

# Copia todos os arquivos do projeto para o diretório de trabalho
COPY . .

# Compila o projeto Angular para produção
RUN npm run build

# Estágio 2: Executar o servidor Nginx
FROM nginx:latest

# Remove o arquivo de configuração padrão do Nginx
RUN rm /etc/nginx/conf.d/default.conf

# Copia os arquivos de configuração personalizados do Nginx
COPY nginx.conf /etc/nginx/conf.d/

# Define o diretório de trabalho como o diretório onde o código Angular compilado está
WORKDIR /usr/share/nginx/html

# Copia o código Angular compilado do estágio de compilação para o diretório de trabalho
COPY --from=build /app/dist .

# Expõe a porta 80, que é a porta padrão do Nginx
EXPOSE 80

# Comando para iniciar o servidor Nginx quando o contêiner for iniciado
CMD ["nginx", "-g", "daemon off;"]