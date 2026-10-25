---
name: model-routing
description: Select economical models for simple CatalogoCursos tasks and capable models for complex implementation or debugging. Use before every project task and announce the actual execution model in Portuguese.
---

# Model routing

## Classify before implementation

Use the cheapest suitable model, considering risk and uncertainty rather than
file count alone. Respect an explicit model choice from the user.

| Complexity | Examples | Preferred model | Alternative |
| --- | --- | --- | --- |
| Simple | Local Razor/CSS edits, straightforward mappings, isolated validation, routine tests, documentation | GPT-6 Luna (`gpt-6-luna`) | Claude Haiku 5.5 (`claude-haiku-5.5`) |
| High | Architecture, cross-layer behavior changes, EF Core migrations with data risk, authentication, hard-to-reproduce bugs | GPT-6.1 Sol (`gpt-6.1-sol`) | Claude Sonnet 5.5 (`claude-sonnet-5.5`) |
| High, execution-focused | Well-specified end-to-end features requiring coordinated implementation and verification across controllers, services, repositories and views | GPT-5.3-Codex (`gpt-5.3-codex`) | GPT-6.1 Sol (`gpt-6.1-sol`) |

For intermediate tasks, use the simple tier only when requirements and
validation are clear and risk is low; otherwise use the high tier.
These are routing preferences, not guarantees of speed or total cost.
Do not embed fixed prices: check current official pricing when cost comparison
is requested.

## Announce the actual execution model

Before executing work, report in Portuguese:

`Modelo de execucao: <name> (<id>). Complexidade: <simples|alta>. Motivo: <short reason>.`

When delegation is used, distinguish the session model from the worker:

`Modelo da sessao: <actual session model>. Modelo executor: <selected worker model>.`

If the active session model is unknown, say so; do not guess.
If a fallback or escalation is needed, announce its reason and actual model
before continuing.
For simple tasks, explicitly confirm that the execution model is economical
(`gpt-6-luna` or `claude-haiku-5.5`) before implementation starts.

## Apply the selection using supported mechanisms

A skill supplies instructions; it does not itself change the session model.

1. For a substantial, bounded implementation task that may be delegated under
   the active tool instructions, use one model-selectable implementation
   subagent with the chosen model ID. Supply the complete requirements,
   project path, relevant context, scope, and validation criteria. Await its
   result. Do not duplicate the worker's implementation in the parent.
2. Do not create worker pools, nested delegation, workflows, or extra review
   agents merely to route models. Avoid delegation overhead for trivial reads,
   conversational replies, and tiny tasks when direct execution is required
   or more appropriate.
3. If direct execution is appropriate and the active model already matches,
   execute directly. Otherwise disclose the active model and the recommended
   model. Explain that `/model` changes the session model; never claim this
   skill has switched it.
4. For simple tasks, do not implement on a high-cost session model unless the
   user explicitly accepts it. First request session switch guidance with a
   direct command recommendation such as `/model gpt-6-luna`.
5. If the user keeps a high-cost model by explicit choice, proceed and label
   that exception before work starts.
6. Check model availability using supported tool capabilities. If a selection
   is rejected as unavailable, use the table's alternative and announce it.
   If neither is available, disclose the limitation instead of silently using
   a more expensive model or promising a switch.

## Direct responses and minimal code

- Respond directly and concisely in Portuguese, leading with the result.
  Avoid repetition, unnecessary explanations, and routine step narration.
  Still disclose the execution model, important limitations, and blockers.
- Implement the requested behavior with the least code necessary for a
  complete, correct, and readable solution. Prefer existing helpers and
  project conventions over new abstractions, dependencies, or files.
- Do not add speculative features, unrelated refactors, redundant comments,
  or boilerplate. Do not sacrifice validation, error handling, security,
  maintainability, or relevant tests merely to reduce line count.
- Include these response and implementation requirements in delegated tasks.

## Control cost without sacrificing correctness

- Keep context relevant and changes surgical; preserve the project's layers
  and existing behavior outside the requested scope.
- For simple-tier work that reveals architectural uncertainty, data-loss risk,
  or a failed targeted correction, stop repeating the same attempt and
  reclassify. Carry the findings and failure evidence into one high-tier
  continuation, subject to the active delegation rules.
- Run the smallest relevant existing checks. Never call a task complete solely
  because code was generated; verify the requested outcome.
- Do not change global defaults, billing settings, or user-wide model
  preferences as a side effect of this project skill.

## Discovery

This is a project-local skill. Open the CLI in `C:\Projetos\CatalogoCursos`
(or use `/cwd C:\Projetos\CatalogoCursos`), then run `/skills reload`.
Use `/skills info model-routing` to confirm discovery. The project
`AGENTS.md` also points to this file so its policy can be read directly when
the skill is not yet loaded.
