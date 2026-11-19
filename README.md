# CL Entregas API

API REST para gerenciamento de entregas, desenvolvida com C# e ASP.NET Core Minimal APIs.

O projeto foi criado como prática de desenvolvimento backend com .NET, explorando a construção de endpoints HTTP, manipulação de dados, orientação a objetos e implementação de regras de negócio.

## Tecnologias utilizadas

- C#
- .NET 10
- ASP.NET Core Minimal APIs
- OpenAPI

## Funcionalidades

- Listagem de todas as entregas.
- Consulta de entrega por identificador.
- Cadastro de novas entregas.
- Atualização do status de uma entrega.
- Validação de transições de status.
- Tratamento de respostas HTTP.

## Regras de negócio

O sistema trabalha com quatro status de entrega:

1. Pendente
2. Em trânsito
3. Saiu para entrega
4. Entregue

A atualização de status respeita uma sequência predefinida, impedindo transições inválidas.

## Endpoints

| Método | Rota                        | Descrição                    |
| ------ | --------------------------- | ---------------------------- |
| GET    | `/api/entregas`             | Lista todas as entregas      |
| GET    | `/api/entregas/{id}`        | Consulta uma entrega pelo ID |
| POST   | `/api/entregas`             | Cadastra uma nova entrega    |
| PUT    | `/api/entregas/{id}/status` | Atualiza o status da entrega |

## Como executar

**1. Clone o repositório**

```bash
git clone https://github.com/pedrofigueiredojsx/CLEntregas.git
```

**2. Acesse a pasta do projeto**

```bash
cd CLEntregas
```

**3. Execute a aplicação**

```bash
dotnet run
```

A API será iniciada no endereço local informado pelo terminal.

## Documentação OpenAPI

Durante a execução em ambiente de desenvolvimento, a documentação OpenAPI pode ser acessada em:

```text
/openapi/v1.json
```

## Armazenamento de dados

Nesta versão, as entregas são armazenadas em memória por meio de uma coleção de objetos. Os dados são perdidos quando a aplicação é encerrada.

## Objetivo do projeto

Consolidar conhecimentos em desenvolvimento backend com C# e .NET, aplicando conceitos de APIs REST, orientação a objetos, LINQ e validação de regras de negócio.

Projeto desenvolvido para fins de estudo e aprendizado.
