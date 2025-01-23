# Users API

Este é um projeto de API de usuários desenvolvido utilizando ASP.NET Core, com banco de dados PostgreSQL. A aplicação permite a criação e gestão de usuários, incluindo funcionalidades para armazenar e consultar informações no banco de dados.

## Pré-requisitos

Antes de rodar o projeto, certifique-se de ter os seguintes pré-requisitos instalados:

- **Docker**: Para rodar o banco de dados PostgreSQL em contêiner.
- **.NET 6 ou superior**: Para rodar a aplicação ASP.NET Core.
- **Docker Compose**: Para configurar e iniciar múltiplos contêineres com facilidade (opcional, mas recomendado).

## Passos para executar localmente

### 1. Clone o repositório

Clone o repositório para a sua máquina local:

```bash
git clone https://github.com/seu-usuario/UsersAPI.git
cd UsersAPI
```
### 2. Configuração das variáveis de ambiente
Certifique-se de que as variáveis de ambiente estejam configuradas corretamente para o seu projeto. Se estiver utilizando User Secrets (ou deseja configurar variáveis diretamente), execute o seguinte comando para configurar o banco de dados com as credenciais adequadas:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=usuario_db;Username=user;Password=password"
dotnet user-secrets set "POSTGRES_USER" "user"
dotnet user-secrets set "POSTGRES_PASSWORD" "password"
dotnet user-secrets set "POSTGRES_DB" "usuario_db"
```
Verifique se as variáveis de ambiente foram configuradas corretamente com o seguinte comando:
```bash
dotnet user-secrets list
```


2.1 Com variáveis de ambiente no host
Você pode exportar os segredos como variáveis de ambiente no sistema e passá-los para o contêiner:
```bash
linux:
export POSTGRES_USER=user
export POSTGRES_PASSWORD=password
export POSTGRES_DB=usuario_db

Powershell:
$env:POSTGRES_USER = "user"
$env:POSTGRES_PASSWORD = "password"
$env:POSTGRES_DB = "usuario_db"
```

### 3. Configuração do banco de dados
   Para rodar o banco de dados PostgreSQL localmente, você pode usar o Docker. No diretório raiz do projeto, crie os contêineres com o seguinte comando:

```bash
docker-compose up -d
```
Isso criará e inicializará um contêiner com o PostgreSQL, usando as configurações fornecidas no arquivo docker-compose.yml.

### 4. Executar a aplicação
Antes de iniciar a aplicação, é necessário aplicar as migrações para criar o esquema do banco de dados. Execute o seguinte comando no terminal:

```bash
dotnet ef database update
```
Agora você pode rodar a aplicação localmente com o seguinte comando: 
```bash
dotnet run
```
A aplicação ASP.NET Core deve estar rodando no endereço padrão, como http://localhost:5234.

## Documentação da API

A documentação da API está disponível no Swagger, que pode ser acessado em http://localhost:5234/swagger.
![api](https://github.com/user-attachments/assets/9d76d9ea-ec07-4591-a030-2c12308fc423)
