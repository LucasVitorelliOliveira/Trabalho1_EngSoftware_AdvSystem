using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteId",
                table: "Controle_de_Processos");

            migrationBuilder.AddColumn<int>(
                name: "ClienteJId",
                table: "Controle_de_Processos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Controle_de_Processos_ClienteJId",
                table: "Controle_de_Processos",
                column: "ClienteJId");

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteJId",
                table: "Controle_de_Processos",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteJId",
                table: "Controle_de_Processos");

            migrationBuilder.DropIndex(
                name: "IX_Controle_de_Processos_ClienteJId",
                table: "Controle_de_Processos");

            migrationBuilder.DropColumn(
                name: "ClienteJId",
                table: "Controle_de_Processos");

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteId",
                table: "Controle_de_Processos",
                column: "ClienteId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
