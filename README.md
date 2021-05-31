# core-escola-digital-monolito

Aplicação .Net Core 5.0 Web API desenvolvida na arquitetura monolítica com o objetivo didático de demonstrar a implementação de uma API utilizando-se de Clean Architecture, CQRS  com MediatR, Repository Pattern e Fluent Validation.

Está API tem como cenário um aplicativo fictício chamado "Minha Escola Digital" onde este teria como funcionalidade principal o envio de resumos diários contendo o dia a dia do aluno. Foi implementado somente a controller do aluno.

# Este projeto contém:

- Pattern CQRS com MediatR;
- Pattern Repository;
- Fluent Validation;
- Mapeamento das entidades por Fluent API;
- Entity Framework (EF) Core; 
- Persistência em SQLServer;
- DTO e AutoMapper;
- Versionamento da API;
- Swagger/Swagger UI;

# Sobre o CQRS:
Existe muita discussão referente ao CQRS retornar valores ou não! Entendo que no caso deste projeto didádico não estamos implementando uma arquitetura assíncrona baseada em filas, mas sim utilizando "tarefas" assíncronas pode irão fornecer o resultado de conclusão para o comando async.

# Como executar:
- Clonar / baixar o repositório em seu workplace.
- Baixar o .Net Core SDK e o Visual Studio / Code mais recentes.

# TODO
- Desenvolver os demais controllers.
- Implementação dos testes.

# Sobre
Este projeto foi desenvolvido por Anderson Hansen sob [MIT license](LICENSE).
