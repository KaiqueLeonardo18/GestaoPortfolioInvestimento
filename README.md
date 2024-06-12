
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
- SDK .NET 8
- SQL Server

## 1.1. Arquitetura Proposta
Foi utilizado a abordagem de arquitetura em camadas ou (Data Layers), de acordo com a seguinte arquitetura: 

1: Arquitetura do GestaoPortfolioInvestimentos

A arquitetura do GestaoPortfolioInvestimentos é descrita pelos itens a seguir:

1. Criação do banco e das tabelas

2. A API realiza login do usuário no BD de usuários db-xp

3. O resultado da API é verificado pelo usuário via Swagger ou Postman.

Por fim, apresentamos as entidades criadas, a partir do Migrations e Entity, para persistir as informações de consultas e de usuários.

## 1.2. Explicação dos Recursos
A seguir, definimos a função de cada recurso em nossa solução:

- BD SQL: **db-xp** - o BD em si, contendo as tabelas GestaoPortfolioInvestimentos.

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

- Interfaces

**Pasta Domain: (GestaoPortfolioInvestimentos.Domain)**

- Contém as definições das tabelas de BD.
- Enum para utilização do sistema.
- Schema para validação dos dados.

**Pasta Application: (GestaoPortfolioInvestimentos.Application)**

- Contém as constantes do sistema.

- DTOs.
- Interfaces
- Services

**Outras pastas: armazenam informações de configurações das IDEs utilizadas.**

## 2. Manual de utilização da aplicação

Primeiramente é necessário consumir o endpoint **/api/Auth/registrar** para Cadastrar o usuário no sistema. No momento o sistema possui dois tipos de roles de usuário, sendo elas "admin" ou "client".
Cada uma das roles fornece um acesso a endpoints específicos, Segue uma explicação sobre a descrição de cada role.

- admin
   Essa role permite que os usuários possam gerenciar os produtos de investimentos do sistema, caso o usuário com essa role tente executar outro endpoint a não ser os de **ProdutoInvestimento** receberá uma mensagem de erro por não possuir acesso à outros endpoints.
  
- client
   Essa role permite que os clientes possam executar ações de COMPRA, VENDA, e o EXTRATO de suas manipulações em produtos de investimento adquiridos e vendidos. , caso o usuário com essa role tente executar outro endpoint a não ser os de **ClienteInvestimentos** receberá uma mensagem de erro por não possuir acesso à outros endpoints.

Após a realização do cadastro do usuário, é ncessário consumir o endpoint de **/api/Auth/login** para que o usuário receba um token de acesso á aplicação.

No retorno da requisição, caso o usuário seja encontrado de acordo com as informações de username e password enviados, ele receberá em um campo JSON o token fornecido pela aplicação. 
Após receber o token é necessário aplicar ele no botão de Authorize do swagger ou pela opção de Authorization do postman. OBS: É necessário apenas copiar o token e colar no input de Authorize(swagger) ou Authorization(POSTMAN), sem a necessidade de incluir a palavra "Bearer" antes do token, apenas o token já será valido pois a aplicação já aplica a palavra "Bearer" por padrão.

## **admin**
Ao realizar a inclusão do token, sendo um usuário com a role de admin, será permitido fazer o gerenciamento dos produtos de investimento do sistema. Para fins de cadastro o usuário poderá consumir o endpoint de **/api/ProdutoInvestimento/cadastrar** para incluir um produto no sistema.

Caso seja necessário, o usuário pode também consumir o endpoint de **/api/ProdutoInvestimento/listarProdutos** para receber uma listagem de todos os produtos de investimento cadastrados no sistema.

Também, é possível consumir o endpoint de **/api/ProdutoInvestimento/{id}** para atualizar um produto de investimento de acordo com a necessidade, alterando-se o seu nome/valor.

## **client**
Um usuário com role de client possui permissão para execução o endpoint de **/api/ProdutoInvestimento/listarProdutos** para visualizar os produtos de investimento disponíveis para compra.
Após a verificação dos produtos o cliente pode requisitar o endpoint de **api/ClienteInvestimento/comprar** para realizar uma operação de compra de um determinado produto, fornecendo ali o ID do produto e a quantidade.

Para visualizar o extrato do cliente logado, basta requisitar o endpoint **api/ClienteInvestimento/extratoTransacoes**. OBS Este endpoint é necessário que o usuário com role de **client** esteja logado no sistema.

3. Referências
ASP.NET Core

Introduction to JSON Web Tokens

