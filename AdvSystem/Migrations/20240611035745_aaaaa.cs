using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class aaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Pessoa_Fisica_ClienteId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Pessoa_Juridica_ClienteJId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_ClienteId",
                table: "Cobrancas");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_ClienteJId",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "ClienteJId",
                table: "Cobrancas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cobrancas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteJId",
                table: "Cobrancas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_ClienteId",
                table: "Cobrancas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_ClienteJId",
                table: "Cobrancas",
                column: "ClienteJId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Pessoa_Fisica_ClienteId",
                table: "Cobrancas",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Pessoa_Juridica_ClienteJId",
                table: "Cobrancas",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
