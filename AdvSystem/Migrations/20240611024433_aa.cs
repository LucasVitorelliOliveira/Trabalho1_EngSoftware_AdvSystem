using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                table: "Controle_de_Processos");

            migrationBuilder.DropIndex(
                name: "IX_Controle_de_Processos_ClienteId",
                table: "Controle_de_Processos");

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "Controle_de_Processos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Controle_de_Processos_PessoaFisicaId",
                table: "Controle_de_Processos",
                column: "PessoaFisicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_PessoaFisicaId",
                table: "Controle_de_Processos",
                column: "PessoaFisicaId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_PessoaFisicaId",
                table: "Controle_de_Processos");

            migrationBuilder.DropIndex(
                name: "IX_Controle_de_Processos_PessoaFisicaId",
                table: "Controle_de_Processos");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "Controle_de_Processos");

            migrationBuilder.CreateIndex(
                name: "IX_Controle_de_Processos_ClienteId",
                table: "Controle_de_Processos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                table: "Controle_de_Processos",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id");
        }
    }
}
