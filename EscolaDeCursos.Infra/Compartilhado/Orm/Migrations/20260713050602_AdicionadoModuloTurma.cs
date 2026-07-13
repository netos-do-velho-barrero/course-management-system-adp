using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoModuloTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas");

            migrationBuilder.RenameTable(
                name: "Turmas",
                newName: "TBTurma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBTurma",
                table: "TBTurma",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBTurma",
                table: "TBTurma");

            migrationBuilder.RenameTable(
                name: "TBTurma",
                newName: "Turmas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas",
                column: "Id");
        }
    }
}
