using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                table: "Controle_de_Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteJId",
                table: "Controle_de_Processos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteJId",
                table: "Controle_de_Processos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Controle_de_Processos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                table: "Controle_de_Processos",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteJId",
                table: "Controle_de_Processos",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                table: "Controle_de_Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteJId",
                table: "Controle_de_Processos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteJId",
                table: "Controle_de_Processos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Controle_de_Processos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                table: "Controle_de_Processos",
                column: "ClienteId",
                principalTable: "Pessoa_Fisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteJId",
                table: "Controle_de_Processos",
                column: "ClienteJId",
                principalTable: "Pessoa_Juridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
