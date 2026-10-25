using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cted.CatalogoCursos.Database.Migrations
{
    /// <inheritdoc />
    public partial class _DiagnosticoPendingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicoAlvo",
                table: "Cursos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicoAlvo",
                table: "Cursos");
        }
    }
}
