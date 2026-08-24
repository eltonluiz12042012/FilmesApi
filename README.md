🎬 API REST — Gerenciamento de Cinema

API REST desenvolvida para gerenciamento de filmes, cinemas, endereços e sessões de cinema. O projeto foi criado com foco em boas práticas de desenvolvimento de APIs utilizando o ecossistema .NET 6 e Entity Framework Core.

🚀 Sobre o Projeto

A aplicação permite realizar o gerenciamento completo das principais informações de um sistema de cinemas, possibilitando cadastrar, consultar, atualizar e excluir registros.

O projeto contempla o relacionamento entre:

🎥 Filmes
🎦 Cinemas
📍 Endereços
🕐 Sessões

A API foi desenvolvida seguindo o padrão REST, disponibilizando endpoints HTTP para realização das operações de CRUD.

🛠️ Tecnologias Utilizadas
Tecnologia	Descrição
.NET 6	Plataforma utilizada para desenvolvimento da API
ASP.NET Core	Framework utilizado para construção da API REST
C#	Linguagem de programação
Entity Framework Core	ORM utilizado para acesso e persistência dos dados
MySQL	Sistema gerenciador de banco de dados
REST	Arquitetura utilizada para comunicação entre cliente e API
Swagger	Documentação e testes dos endpoints
📋 Funcionalidades
🎥 Filmes

Permite realizar o gerenciamento dos filmes cadastrados na aplicação.

Criar filme
Consultar filmes
Consultar filme por ID
Atualizar filme
Excluir filme
🎦 Cinemas

Gerenciamento dos cinemas disponíveis.

Criar cinema
Consultar cinemas
Consultar cinema por ID
Atualizar cinema
Excluir cinema
📍 Endereços

Gerenciamento dos endereços associados aos cinemas.

Criar endereço
Consultar endereço
Atualizar endereço
Excluir endereço
🕐 Sessões

Gerenciamento das sessões dos filmes nos cinemas.

Criar sessão
Consultar sessões
Consultar sessão por ID
Atualizar sessão
Excluir sessão
🔄 Operações CRUD

A API implementa as operações fundamentais de um CRUD:

CREATE  → POST
READ    → GET
UPDATE  → PUT
DELETE  → DELETE

Exemplo de fluxo:

Cliente
   │
   ▼
API REST
   │
   ▼
Entity Framework Core
   │
   ▼
MySQL
🗂️ Estrutura do Projeto

Organização da aplicação: <br/><br/>
<img width="595" height="479" alt="Screenshot_1" src="https://github.com/user-attachments/assets/c51a11ad-4858-483e-8123-bda58d317a4b" />


⚙️ Pré-requisitos

Antes de executar o projeto, é necessário ter instalado:

.NET 6 SDK
MySQL
Git
IDE de sua preferência, como Visual Studio ou Visual Studio Code
🔧 Configuração do Banco de Dados

Exemplo de organização das rotas:

GET     /api/filmes
GET     /api/filmes/{id}
POST    /api/filmes
PUT     /api/filmes/{id}
DELETE  /api/filmes/{id}
GET     /api/cinemas
GET     /api/cinemas/{id}
POST    /api/cinemas
PUT     /api/cinemas/{id}
DELETE  /api/cinemas/{id}
GET     /api/sessoes
GET     /api/sessoes/{id}
POST    /api/sessoes
PUT     /api/sessoes/{id}
DELETE  /api/sessoes/{id}
🎯 Objetivos do Projeto

Este projeto foi desenvolvido com o objetivo de praticar e demonstrar conhecimentos em:

Desenvolvimento de APIs REST
C# e .NET 6
ASP.NET Core
Entity Framework Core
Mapeamento objeto-relacional (ORM)
Relacionamentos entre entidades
Operações CRUD
Persistência de dados
MySQL
Desenvolvimento de aplicações backend
Documentação de APIs com Swagger
📌 Status do Projeto

🚧 Em desenvolvimento

Novas funcionalidades e melhorias poderão ser adicionadas ao projeto futuramente.

👨‍💻 Autor

Elton Luiz dos Santos do Franco

Desenvolvedor Backend

GitHub: Seu GitHub
LinkedIn: Seu LinkedIn
📄 Licença

Este projeto está disponível para fins educacionais e de estudo.
