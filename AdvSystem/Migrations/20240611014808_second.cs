using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Saida_de_Caixa_ClienteId",
                table: "Saida_de_Caixa",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_de_Caixa_ClienteId",
                table: "Entrada_de_Caixa",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_ClienteId",
                table: "Cobrancas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Pessoa_Fisica_ClienteId",
                table: "Cobrancas",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Pessoa_Juridica_ClienteId",
                table: "Cobrancas",
                column: "ClienteId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Entrada_de_Caixa",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Juridica_ClienteId",
                table: "Entrada_de_Caixa",
                column: "ClienteId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Saida_de_Caixa",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Juridica_ClienteId",
                table: "Saida_de_Caixa",
                column: "ClienteId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Pessoa_Fisica_ClienteId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Pessoa_Juridica_ClienteId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Juridica_ClienteId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Juridica_ClienteId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_Saida_de_Caixa_ClienteId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_de_Caixa_ClienteId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_ClienteId",
                table: "Cobrancas");
        }
    }
}
