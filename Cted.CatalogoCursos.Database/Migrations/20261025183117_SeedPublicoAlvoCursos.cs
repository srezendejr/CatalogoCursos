using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cted.CatalogoCursos.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedPublicoAlvoCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 1,
                column: "PublicoAlvo",
                value: "Iniciantes em programação, estudantes técnicos e profissionais em transição para tecnologia.");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 2,
                column: "PublicoAlvo",
                value: "Desenvolvedores .NET, estudantes de tecnologia e profissionais que querem construir aplicações web.");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 3,
                column: "PublicoAlvo",
                value: "Líderes de equipe, coordenadores e profissionais envolvidos na gestão de projetos.");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 4,
                column: "PublicoAlvo",
                value: "Analistas de dados, gestores e profissionais da indústria focados em indicadores e dashboards.");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 5,
                column: "PublicoAlvo",
                value: "Supervisores de produção, engenheiros e profissionais de melhoria contínua e qualidade.");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 6,
                column: "PublicoAlvo",
                value: "Técnicos de segurança, gestores de SST e colaboradores expostos a riscos em processos industriais.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 1,
                column: "PublicoAlvo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 2,
                column: "PublicoAlvo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 3,
                column: "PublicoAlvo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 4,
                column: "PublicoAlvo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 5,
                column: "PublicoAlvo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "IdCurso",
                keyValue: 6,
                column: "PublicoAlvo",
                value: "");
        }
    }
}
