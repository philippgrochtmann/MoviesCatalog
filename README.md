# MovieCatalogApi


A API de Catálogo de Filmes é um serviço RESTful construído com o ASP.NET Core que permite aos usuários gerenciar uma coleção de filmes. Os usuários podem:

- Adicionar filmes a uma lista de visualização.
- Marcar filmes como assistidos.
- Classificar os filmes assistidos.
- Filtrar filmes por gênero e ano.


# Execução:

- Para rodar a api é necessário ter instalado o SDK 8 do .NET
- No arquivo appsettings.json, configure as credenciais e o endereço do banco de dados. - Caso opte por criar e rodar um banco localmente usando dokcer, Execute o comando na pasta da aplicação: docker compose up -d

- Configurando a API OMDB:
A aplicação integra-se com a API OMDB para buscar informações sobre filmes. Siga os passos para obter e configurar a chave de API:

Obter a chave da API OMDB:

Acesse o site da OMDB API.
Escolha o plano desejado e registre-se para obter a chave.
Confirme seu e-mail e copie a chave de API.
Configurar a chave da API:

Abra o arquivo appsettings.json na raiz do projeto.
Localize a seção OMDB e substitua "your_omdb_api_key" pela sua chave real.
Exemplo:

"OMDB": {
  "ApiKey": "sua_chave_api_aqui"
}

# Arquitetura da API

Visão Geral

O MovieCatalogApi foi projetado com DDD (Domain-Driven Design) e CQRS (Command Query Responsibility Segregation). 
Ele organiza o código em camadas bem definidas, separando responsabilidades para facilitar a escalabilidade e a manutenção.

1. Controllers
Exposição dos endpoints da API. Apenas delegam tarefas para a camada Application (sem lógica de negócio).

2. Application
Contém a lógica de aplicação e orquestração de comandos e consultas.

- Commands: Ações que alteram o estado (ex.: criar, atualizar).
- Queries: Operações de leitura.
- Dtos: Objetos para transporte de dados.
- Mappings: Configuração de mapeamento (ex.: AutoMapper).


3. Domain
Contém as regras de negócio e conceitos fundamentais do domínio.


- Enums: Armazena enums que representam valores constantes no domínio.
- Exceptions: Define as exceções personalizadas para tratar erros específicos da aplicação.
- Interfaces: Contém as definições de contratos que descrevem o comportamento esperado das implementações.
- Model: Contém as entidades do domínio, que são as representações de objetos principais do negócio.


4. Infrastructure
Implementação de detalhes técnicos, como persistência de dados, acesso a APIs externas,

- Data: Contém o contexto do EF Core.
- Migrations: Configuração e arquivos gerados para migrações do banco de dados.
- Repositories: Implementação dos repositórios definidos na camada Interfaces.
- Services: Integrações externas.

Fluxo de Dados

Cliente → Controller: API recebe uma requisição.
Controller → Application: Chama um Command ou Query.
Application → Domain: Regras de negócio são aplicadas.
Domain → Infrastructure: Persistência ou leitura de dados.
Ferramentas Utilizadas
EF Core: Banco de dados (SqlServer)
AutoMapper: Mapeamento entre entidades e DTOs.
MediatR: Gerenciamento de Commands/Queries no padrão CQRS.



