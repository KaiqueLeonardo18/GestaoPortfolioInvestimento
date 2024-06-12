
# Gestão de Portfólio de Investimentos

<details>
 <summary>Documentação do projeto</summary>


# 0. Metadados
 
 **Nome do Projeto:** GestaoPortfolioInvestimentos

**Desenvolvedores do Projeto:**

| Kaique Leonardo Gomes da Silva |

**Tecnologias Utilizadas:**

| Tecnologia                               | Propósito                                                      |  
| -----------------------------------      | -------------------------------------------------------------- | 
| .NET 8                                   | API, Class Library		   										|
| Microsoft SQL Server                     | Banco de Dados                                                 |
| Visual Studio e VS Code                  | Desenvolvimento                                                |
| GitHub                                   | Versionamento                                                  |

**Requisitos:**

Requisitos:

## 1.1. Arquitetura Proposta
Para concretizar as ideias, foi utilizado a abordagem de arquitetura em camadas ou (Data Layers), de acordo com a seguinte arquitetura: 

1: Arquitetura do GestaoPortfolioInvestimentos

A arquitetura do GestaoPortfolioInvestimentos é descrita pelos itens a seguir:

1. Criação do banco e das tabelas

2. A API realiza login do usuário no BD de usuários sql-GPI

3. O resultado da API é verificado pelo usuário via Swagger ou Postman.

Por fim, apresentamos as entidades criadas, a partir do Migrations e Entity, para persistir as informações de consultas e de usuários.

## 1.2. Explicação dos Recursos
A seguir, definimos a função de cada recurso em nossa solução:

- BD SQL: **sql-GPI** - o BD em si, contendo as tabelas GestaoPortfolioInvestimentos.

## 1.3. Código Desenvolvido
Para elucidar o código desenvolvido, fornecemos as informações a seguir, de cada pasta deste repositório.

Observação: na raiz deste repositório temos a Solution, contendo: um projeto de API, Application, Domain e Infrastructure.

**Projeto API (GestaoPortfolioInvestimentos.Presentation.API):**

- Contém os Controllers.

- Os endpoints fornecem as funcionalidades para CRUD da aplicação.

- A API é documentada com o Swagger.

**Pasta Infraestrutura: (GestaoPortfolioInvestimentos.Infrastructure)**
- Contém as configurações de BD.

- Mapeamento das tabelas de BD.

- Repository para consultas de BD.

- Possui os migrations das entidades para os BDs.

**Pasta Domain: (DoctorAppointmentBooking.Domain)**

- Contém as definições das tabelas de BD.

- Interfaces utilizada pelo sistema.

**Pasta Application: (GestaoPortfolioInvestimentos.Application)**

- Contém as constantes do sistema.

- Models/DTOs.

**Outras pastas: armazenam informações de configurações das IDEs utilizadas.**

3. Referências
ASP.NET Core

Introduction to JSON Web Tokens

