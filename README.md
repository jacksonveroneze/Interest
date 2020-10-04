# Interest

Projeto desenvolvido com o objetivo de realizar o cálculo de juros.

## Iniciando
Use as intruções abaixo para rodar o projeto.

### Requisitos
Você precisará das seguintes ferramentas se desejar codificar algo:

* [Visual Studio Code or 2017/2019](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 3.1](https://www.microsoft.com/net/download)

Você precisará das seguintes ferramentas se desejar rodar o projeto usando docker:

* [Docker](https://www.docker.com/)
* [Docker-compose](https://docs.docker.com/compose/install/)

### Setup
Siga estas etapas para para rodar o projeto em produção:

  1. Clone o repositório
  
  2. No diretório raiz, restaure os pacotes (nuget) executando:
     ```
     dotnet restore
     ```
  3. Em seguida compile o projeto executando:
     ```
     dotnet build
     ```
  3. Após acesse o diretório das APIs e execute:
     ```
     dotnet run
     ```
  4. Agora seus projetos estão em execução, abra o navegador e acesse: https://localhost:6001/swagger:
     ```
     [https://localhost:6001/swagger](https://localhost:6001/swagger)
     ```

### Setup (Com Docker)

Siga estas etapas para para rodar o projeto em produção:

  1. Clone o repositório
  
  2. No diretório raiz, execute o comando:
     ```
     docker-compose up -d
     ```
  3. Agora seus projetos estão em execução, abra o navegador e acesse: https://localhost:8001/swagger:

## Exemplos

## Api - Taxa de juros

```
curl -X GET "https://localhost:5001/taxaJuros" -H "accept: application/json"
````

## Api - Cálculo juros

```
curl -X GET "https://localhost:6001/calculajuros?valorInicial=100&meses=5" -H "accept: application/json"
````

## Technologies:

- C# 8.0
- ASP.NET Core 3.1
- ASP.NET WebApi Core 3.1
- .NET Core Native DI
- Refit
- Polly
- Serilog
- Docker

## Autor
* **Jackson Veroneze** - *Contributor* - [JacksonVeroneze](https://github.com/JacksonVeroneze)


## Licença
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/jacksonveroneze/Interest/blob/develop/LICENSE) file for details.
