using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class caixafkadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UsusarioId",
                table: "Entrada_de_Caixa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Saida_de_Caixa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Saida_de_Caixa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClienteJId",
                table: "Saida_de_Caixa",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Entrada_de_Caixa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClienteJId",
                table: "Entrada_de_Caixa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Entrada_de_Caixa",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Cobrancas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClienteJId",
                table: "Cobrancas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saida_de_Caixa_ClienteJId",
                table: "Saida_de_Caixa",
                column: "ClienteJId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_de_Caixa_ClienteJId",
                table: "Entrada_de_Caixa",
                column: "ClienteJId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_ClienteJId",
                table: "Cobrancas",
                column: "ClienteJId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Pessoa_Fisica_ClienteId",
                table: "Cobrancas",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobrancas_Pessoa_Juridica_ClienteJId",
                table: "Cobrancas",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Entrada_de_Caixa",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Juridica_ClienteJId",
                table: "Entrada_de_Caixa",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Saida_de_Caixa",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Juridica_ClienteJId",
                table: "Saida_de_Caixa",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Pessoa_Fisica_ClienteId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobrancas_Pessoa_Juridica_ClienteJId",
                table: "Cobrancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_de_Caixa_Pessoa_Juridica_ClienteJId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Fisica_ClienteId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Saida_de_Caixa_Pessoa_Juridica_ClienteJId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_Saida_de_Caixa_ClienteJId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_de_Caixa_ClienteJId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_Cobrancas_ClienteJId",
                table: "Cobrancas");

            migrationBuilder.DropColumn(
                name: "ClienteJId",
                table: "Saida_de_Caixa");

            migrationBuilder.DropColumn(
                name: "ClienteJId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Entrada_de_Caixa");

            migrationBuilder.DropColumn(
                name: "ClienteJId",
                table: "Cobrancas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Saida_de_Caixa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Saida_de_Caixa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Entrada_de_Caixa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsusarioId",
                table: "Entrada_de_Caixa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Cobrancas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
