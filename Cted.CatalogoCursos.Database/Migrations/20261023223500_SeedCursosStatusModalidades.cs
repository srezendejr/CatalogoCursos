using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cted.CatalogoCursos.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20261023223500_SeedCursosStatusModalidades")]
    public partial class SeedCursosStatusModalidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                INSERT OR IGNORE INTO Status (IdStatus, Descricao) VALUES
                (1, 'Aberto'),
                (2, 'Em breve'),
                (3, 'Encerrado');
                """);

            migrationBuilder.Sql("""
                INSERT OR IGNORE INTO Modalidades (IdModalidade, Descricao) VALUES
                (1, 'Online'),
                (2, 'Presencial');
                """);

            migrationBuilder.Sql("""
                INSERT OR IGNORE INTO Categorias (IdCategoria, Descricao) VALUES
                (1, 'Tecnologia'),
                (2, 'Gestão'),
                (3, 'Indústria 4.0');
                """);

            migrationBuilder.Sql("""
                INSERT OR IGNORE INTO Cursos
                (IdCurso, NomeCompleto, NomeBreve, Descricao, CargaHoraria, DataDisponibilizacao, IdCategoria, IdModalidade, IdStatus)
                VALUES
                (1, 'Fundamentos de Programação com C#', 'Introdução à linguagem C#', 'Conceitos básicos de lógica, sintaxe, POO e boas práticas com .NET.', 40, '2026-11-10', 1, 1, 1),
                (2, 'Desenvolvimento Web com ASP.NET Core', 'Aplicações web com ASP.NET Core', 'Construção de aplicações MVC e APIs com arquitetura em camadas.', 60, '2026-11-18', 1, 1, 1),
                (3, 'Gestão de Projetos Ágeis para Indústria', 'Scrum e Kanban na prática', 'Planejamento, execução e acompanhamento de projetos com métodos ágeis.', 24, '2026-11-22', 2, 2, 2),
                (4, 'Power BI para Indicadores Industriais', 'Dashboards e análise de dados', 'Criação de painéis para monitoramento de produtividade e eficiência.', 30, '2026-12-01', 3, 1, 1),
                (5, 'Manufatura Enxuta e Melhoria Contínua', 'Lean para ambientes produtivos', 'Ferramentas de Lean Manufacturing para eliminar desperdícios e aumentar qualidade.', 20, '2026-12-05', 3, 2, 2),
                (6, 'Segurança do Trabalho em Processos Industriais', 'Normas e prevenção de riscos', 'Práticas de segurança, gestão de riscos e conformidade em operações industriais.', 16, '2026-12-12', 2, 2, 3);
                """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cursos WHERE IdCurso IN (1,2,3,4,5,6);");
            migrationBuilder.Sql("DELETE FROM Status WHERE IdStatus IN (1,2,3);");
            migrationBuilder.Sql("DELETE FROM Modalidades WHERE IdModalidade IN (1,2);");
            migrationBuilder.Sql("DELETE FROM Categorias WHERE IdCategoria IN (1,2,3);");
        }
    }
}
