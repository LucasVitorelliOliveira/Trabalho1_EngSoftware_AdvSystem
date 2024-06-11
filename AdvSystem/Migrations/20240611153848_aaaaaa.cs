using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class aaaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Entrada_de_Caixa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Saida_de_Caixa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Entrada_de_Caixa",
                type: "int",
                nullable: true);
        }
    }
}
