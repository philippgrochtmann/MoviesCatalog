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





# Json Collection Insomnia
{"_type":"export","__export_format":4,"__export_date":"2024-11-19T02:21:17.230Z","__export_source":"insomnia.desktop.app:v10.1.1","resources":[{"_id":"req_7ba1aae3b84b4e989c938c7373fbce94","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731982750917,"created":1731981985012,"url":"{{ _.base_url }}/api/Movies/filter","name":"/api/Movies/filter","description":"","method":"GET","body":{},"parameters":[{"name":"Genre","disabled":false,"value":"Horror","id":"pair_822e1c5df2c3466c975e4016e99fd982"},{"name":"Year","disabled":false,"value":"2014","id":"pair_9abfe01497234ca5af2ef7831ff6495a"}],"headers":[],"authentication":{},"metaSortKey":-1731981985012,"isPrivate":false,"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","parentId":null,"modified":1731982674604,"created":1731982674604,"name":"My Collection","description":"","scope":"collection","_type":"workspace"},{"_id":"req_2715bca17a2a4a9582bceb04cc25b0f7","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731982137640,"created":1731981985010,"url":"{{ _.base_url }}/api/Movies/watched","name":"/api/Movies/watched","description":"","method":"GET","body":{},"parameters":[],"headers":[],"authentication":{},"metaSortKey":-1731981985010,"isPrivate":false,"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"req_0376ceb050dd409f88a23653635879c8","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731982140206,"created":1731981985009,"url":"{{ _.base_url }}/api/Movies/watchlist","name":"/api/Movies/watchlist","description":"","method":"GET","body":{},"parameters":[],"headers":[],"authentication":{},"metaSortKey":-1731981985009,"isPrivate":false,"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"req_db224e0aeb0740c7b3c0443462e4c3ba","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731982295367,"created":1731981985008,"url":"{{ _.base_url }}/api/Movies/4","name":"/api/Movies/{id}","description":"","method":"GET","body":{},"parameters":[{"id":"pair_db5b903cae3b431488a7dcb2910e380d","name":"id","value":"","description":"","disabled":false}],"headers":[],"authentication":{},"metaSortKey":-1731981985008,"isPrivate":false,"pathParameters":[],"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"req_57e17b29e4534d858c736123686593df","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731981985005,"created":1731981985005,"url":"{{ _.base_url }}/api/Movies/{{ _.id }}","name":"/api/Movies/{id}","description":"","method":"DELETE","body":{},"parameters":[],"headers":[],"authentication":{},"metaSortKey":-1731981985005,"isPrivate":false,"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"req_83896eb313824f1a9a049cf63b026673","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731982283050,"created":1731981985004,"url":"{{ _.base_url }}/rate/4","name":"/rate/{id}","description":"","method":"PUT","body":{"mimeType":"application/json","text":"{\n  \"rating\": 5\n}"},"parameters":[],"headers":[{"name":"Content-Type","disabled":false,"value":"application/json"}],"authentication":{},"metaSortKey":-1731981985004,"isPrivate":false,"pathParameters":[],"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"req_7fca486aeb51477ea97b9103275a6fb8","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731981985002,"created":1731981985002,"url":"{{ _.base_url }}/watch/{{ _.id }}","name":"/watch/{id}","description":"","method":"PUT","body":{},"parameters":[],"headers":[],"authentication":{},"metaSortKey":-1731981985002,"isPrivate":false,"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"req_85ed1cf5afde4d07a18721a7250f230e","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731981984999,"created":1731981984999,"url":"{{ _.base_url }}/api/Movies","name":"/api/Movies","description":"","method":"POST","body":{"mimeType":"application/json","text":"{\n  \"title\": \"string\"\n}"},"parameters":[],"headers":[{"name":"Content-Type","disabled":false,"value":"application/json"}],"authentication":{},"metaSortKey":-1731981984999,"isPrivate":false,"settingStoreCookies":true,"settingSendCookies":true,"settingDisableRenderRequestBody":false,"settingEncodeUrl":true,"settingRebuildPath":true,"settingFollowRedirects":"global","_type":"request"},{"_id":"env_2bbce780208b43e5bc3d82df128b212b","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731982089365,"created":1731981819383,"name":"Base Environment","data":{"base_url":"https://localhost:7236"},"dataPropertyOrder":{"&":["base_url"]},"color":null,"isPrivate":false,"metaSortKey":1731981819383,"_type":"environment"},{"_id":"jar_5df3e58c3c1048c69138dc3452dae573","parentId":"wrk_e483bfde4bf548e7b8ae00c097d0eed8","modified":1731981819385,"created":1731981819385,"name":"Default Jar","cookies":[],"_type":"cookie_jar"},{"_id":"env_cde9fbaee4f64d2e92c1493b9d0152a7","parentId":"env_2bbce780208b43e5bc3d82df128b212b","modified":1731981984996,"created":1731981984996,"name":"OpenAPI env example.com","data":{"scheme":"http","base_path":"","host":"example.com"},"dataPropertyOrder":null,"color":null,"isPrivate":false,"metaSortKey":1731981984996,"_type":"environment"}]}
