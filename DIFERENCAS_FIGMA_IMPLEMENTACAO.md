# Diferenças entre Figma e Implementação

Este documento consolida as diferenças identificadas entre o protótipo Figma informado e a aplicação implementada, com justificativas.

> **Escopo da comparação**  
> A validação foi feita por evidência de código e estrutura funcional da aplicação.  
> O link do Figma disponibiliza protótipo renderizado por app JS, sem extração completa de estilos/tokens via leitura estática; por isso, pontos de pixel-perfect (spacing/tipografia fina/animações) são classificados como dependentes de inspeção visual frame a frame.

## Resumo executivo
- Aderência geral **boa** para estrutura, navegação e fluxo principal.
- Existem pendências funcionais e diferenças de acabamento visual/interativo.
- Principais lacunas: links de rodapé placeholder, endpoint de categoria sem implementação e área de vídeo estática.

## Diferenças identificadas e justificativas

| # | Diferença | Evidência na implementação | Justificativa | Impacto |
|---|---|---|---|---|
| 1 | Links sociais do rodapé não direcionam para páginas reais | `Views/Shared/_Layout.cshtml` com `href=\"#\"` | Mantidos como placeholder durante fase de desenvolvimento visual e integração inicial | Baixo (funcionalidade secundária) |
| 2 | Endpoint de categorias da API existe, mas sem ações | `Cted.CatalogoCursos.API/CategoriaController.cs` sem métodos `HttpGet/HttpPost` | Priorização do fluxo crítico de catálogo via cursos e modalidades | Médio (limita expansão de filtros 100% pela API) |
| 3 | Área de vídeo é imagem estática, sem player/interações | Uso de `video-thumb.png` na Home | Entrega focada em layout e conteúdo inicial; integração de mídia ficou para etapa posterior | Médio (diferença de experiência) |
| 4 | Comparação pixel-perfect de cores/spacing não fechada | Paleta implementada via CSS tokens (`--brand-red`, `--brand-beige`, etc.), porém sem extração oficial de tokens do Figma | Limitação técnica da leitura estática do protótipo; exige validação visual detalhada no Figma | Médio |
| 5 | Estados avançados de interação (hover/focus/transições específicas do design) podem divergir | CSS cobre estado base e responsividade, sem mapeamento formal de todos os estados do protótipo | Priorização de funcionalidade e responsividade antes de refinamento de microinterações | Baixo/Médio |

## Pontos aderentes (para contexto)
- Navegação principal (Início, AVA, Catálogo, Ver cursos).
- Fluxo de catálogo com filtros e listagem.
- Página de detalhes do curso.
- Responsividade aplicada com breakpoints e reorganização de layout.
- Paleta visual alinhada ao tema SESI (ver `wwwroot/css/site.css`).

## Ações recomendadas para fechamento de gap
1. Substituir links sociais placeholder por URLs oficiais.
2. Implementar ações no `CategoriaController` (mínimo `GET`).
3. Definir se a área de vídeo terá embed/player real e implementar.
4. Realizar validação visual lado a lado com Figma (desktop/tablet/mobile), registrando:
   - cores finais por componente,
   - tipografia (família, peso, tamanho, line-height),
   - espaçamentos,
   - estados hover/focus/active/disabled.
5. Formalizar checklist de aceite visual para evitar regressões.
