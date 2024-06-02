using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class processoalterado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apensos",
                table: "Controle_de_Processos");

            migrationBuilder.DropColumn(
                name: "pgAcordao",
                table: "Controle_de_Processos");

            migrationBuilder.DropColumn(
                name: "pgDecisao",
                table: "Controle_de_Processos");

            migrationBuilder.DropColumn(
                name: "pgDiligencias",
                table: "Controle_de_Processos");

            migrationBuilder.RenameColumn(
                name: "pgSentenca",
                table: "Controle_de_Processos",
                newName: "Movimentacoes");

            migrationBuilder.RenameColumn(
                name: "pgRecursos",
                table: "Controle_de_Processos",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Movimentacoes",
                table: "Controle_de_Processos",
                newName: "pgSentenca");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Controle_de_Processos",
                newName: "pgRecursos");

            migrationBuilder.AddColumn<string>(
                name: "Apensos",
                table: "Controle_de_Processos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pgAcordao",
                table: "Controle_de_Processos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pgDecisao",
                table: "Controle_de_Processos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pgDiligencias",
                table: "Controle_de_Processos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
