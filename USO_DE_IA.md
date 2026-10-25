# USO_DE_IA

## Ferramenta utilizada
- **GitHub Copilot CLI** (modelo em sessão: **GPT-5.3-Codex**).
- Apoio técnico via comandos de terminal (PowerShell/.NET CLI) para validação de build e migrations.

## Objetivo do uso
Utilizar IA para acelerar implementação e ajustes no projeto **CatalogoCursos**, com foco em:
- arquitetura em camadas (API → Service → Repository → Database),
- correções de build/migrations,
- melhorias funcionais no catálogo (filtros, público-alvo, tratamento de erro e responsividade).

## Prompts relevantes (mais importantes)
1. **"Compile a solução e corrija os erros"**  
   - **Aproveitado:** diagnóstico de erro de `StaticWebAssets` e limpeza de artefatos corrompidos (`bin/obj`).  
   - **Descartado:** qualquer alteração estrutural não relacionada ao erro de compilação.

2. **"Você consegue executar todos os migrations no banco de dados?"**  
   - **Aproveitado:** execução orientada por EF Core com validação do histórico de migrations.  
   - **Descartado:** soluções paliativas sem normalizar o estado do banco.

3. **"Na view de Courses, exiba o público alvo de cada curso."**  
   - **Aproveitado:** mapeamento ponta a ponta (`Repository` → `Controller` → `View`).  
   - **Descartado:** refatorações amplas fora do escopo da exibição.

4. **"Realizar o tratamento de erro na service, para exibir mensagem de erro ao invés de uma exceção."**  
   - **Aproveitado:** tratamento com mensagem amigável na Service/API e exibição no front-end.  
   - **Descartado:** exposição de stack trace/erro técnico para o usuário final.

5. **"Último ponto, a interface gráfica deve ser responsiva."**  
   - **Aproveitado:** ajustes de CSS com breakpoints e reorganização dos filtros no mobile/tablet.  
   - **Descartado:** reescrever layout inteiro sem necessidade.

## Como o conteúdo foi validado
- **Build da solução** após mudanças (`dotnet build`) para garantir compilação sem erros.
- **Validação de migrations** com `dotnet ef migrations list` e `dotnet ef database update`.
- **Validação de dados** no SQLite (consulta de status e `PublicoAlvo` após migration).
- **Validação funcional** das telas de cursos (filtros, limpeza e mensagens de erro amigáveis).

## Exemplo de erro/inadequação identificado
- **Problema:** falha de build com `MSB4018` / `JsonException ('0x00' is an invalid start of a value)` em arquivos de cache/manifests de `StaticWebAssets`.

## Correção realizada
- Limpeza de artefatos corrompidos em `bin/obj` dos projetos afetados.
- Rebuild da solução com sucesso.
- Substituição de `EnsureCreated()` por `Migrate()` na inicialização para manter consistência com migrations e evitar estado de banco inconsistente.
