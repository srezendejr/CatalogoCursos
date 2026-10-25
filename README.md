# Catálogo de Cursos (SESI)

## Objetivo da aplicação
Aplicação web para **consulta de cursos** com catálogo, filtros e página de detalhes, consumindo uma API interna em arquitetura por camadas.

## Tecnologias utilizadas
- **.NET 10** / ASP.NET Core MVC
- ASP.NET Core Web API (`[ApiController]`)
- **Entity Framework Core 10**
- **SQLite**
- Razor Views + Bootstrap + CSS customizado

## Arquitetura da solução
Fluxo principal:

`Cted.CatalogoCursos (MVC) -> Cted.CatalogoCursos.API -> Cted.CatalogoCursos.Service -> Cted.CatalogoCursos.Repository -> Cted.CatalogoCursos.Database (SQLite)`

Componentes:
- **MVC (`Cted.CatalogoCursos`)**: interface, filtros, consumo da API via `HttpClient`.
- **API (`Cted.CatalogoCursos.API`)**: endpoints HTTP para consulta de dados.
- **Service (`Cted.CatalogoCursos.Service`)**: regras de aplicação e tratamento de erros.
- **Repository (`Cted.CatalogoCursos.Repository`)**: acesso e projeção de dados.
- **Database (`Cted.CatalogoCursos.Database`)**: `DbContext` e migrations.
- **Models/ViewModel**: entidades e contratos de transporte/apresentação.

## Estrutura das pastas
Na raiz:
- `Cted.CatalogoCursos/` -> app MVC
- `Cted.CatalogoCursos.API/` -> API principal
- `Cted.CatalogoCursos.Database/` -> contexto EF e migrations
- `Cted.CatalogoCursos.Repository/` -> repositórios
- `Cted.CatalogoCursos.Service/` -> serviços
- `Cted.CatalogoCursos.Models/` -> entidades de domínio
- `Cted.CatalogoCursos.ViewModel/` -> view models compartilhados
- `Cted.CatalogoCursos.Apis/` -> projeto alternativo/protótipo (não é o fluxo principal da solução)

## Instruções para execução
Pré-requisitos:
- SDK .NET 10 instalado

Passos:
1. Restaurar e compilar:
   - `dotnet restore Cted.CatalogoCursos.slnx`
   - `dotnet build Cted.CatalogoCursos.slnx`
2. Executar API:
   - `dotnet run --project Cted.CatalogoCursos.API`
3. Executar MVC:
   - `dotnet run --project Cted.CatalogoCursos`
4. Acessar:
   - MVC: `http://localhost:5164` (ou `https://localhost:7167`)
   - API: `http://localhost:5000`

> No Visual Studio, o perfil em `Cted.CatalogoCursos.slnLaunch.user` inicia MVC + API.

## Configuração do banco
- Banco: **SQLite**
- Arquivo principal (MVC): `Cted.CatalogoCursos\catalogocursos.db`
- Connection string padrão (MVC): `Data Source=catalogocursos.db`
- Connection string de desenvolvimento (API): `Data Source=..\\Cted.CatalogoCursos\\catalogocursos.db`

Migrations:
- Aplicar manualmente:  
  `dotnet ef database update --project Cted.CatalogoCursos.Database --startup-project Cted.CatalogoCursos --context AppDbContext`
- A aplicação também aplica migrations na inicialização via `Database.Migrate()`.

## Endpoints
API principal:
- `GET /api/Curso/buscar` -> retorna lista de cursos
- `GET /api/Modalidade/buscar` -> retorna modalidades
- `GET /api/Categoria/...` -> controller existe, mas sem ações implementadas no momento

MVC (rotas principais):
- `GET /` -> Home
- `GET /Ava` -> página AVA
- `GET /Courses` -> catálogo com filtros
- `GET /Courses/Details/{id}` -> detalhes do curso

## Modelo de dados
Entidades principais:
- **Curso**
  - `IdCurso`, `NomeCompleto`, `NomeBreve`, `Descricao`, `CargaHoraria`,
    `DataDisponibilizacao`, `IdCategoria`, `IdModalidade`, `IdStatus`, `PublicoAlvo`
- **Categoria**
  - `IdCategoria`, `Descricao`
- **Modalidade**
  - `IdModalidade`, `Descricao`
- **Status**
  - `IdStatus`, `Descricao`

Status atualmente utilizados:
- `Aberto`
- `Em breve`
- `Encerrado`

## Estratégia de responsividade
- Layout baseado em **grid/flex** com breakpoints em `991.98px` e `575.98px`.
- Formulário de filtros do catálogo com `flex-wrap`, reflow para tablet e mobile.
- Cards de cursos e seções principais adaptam colunas para 1 coluna em telas menores.

## Decisões de acessibilidade
- Uso de `label` associado aos campos de filtro.
- Textos alternativos (`alt`) em imagens relevantes.
- Navegação com links e botões semânticos.
- Mensagens de erro amigáveis exibidas na UI (alerta) em falhas de consumo da API.

## Processo de publicação
Processo atual é **manual** (não há pipeline de CI/CD documentada neste repositório):
1. `dotnet restore`
2. `dotnet build -c Release`
3. `dotnet publish Cted.CatalogoCursos -c Release -o .\\publish\\mvc`
4. `dotnet publish Cted.CatalogoCursos.API -c Release -o .\\publish\\api`
5. Publicar artefatos no ambiente alvo (IIS, container ou serviço cloud).
6. Configurar variáveis/connection strings por ambiente.

## Limitações conhecidas
- `CategoriaController` ainda não possui ações implementadas.
- Dependência de execução conjunta MVC + API para experiência completa de catálogo.
- Ausência de pipeline de publicação automatizada no repositório.
- Em ambiente com múltiplas instâncias subindo ao mesmo tempo, migrations automáticas exigem coordenação operacional.
