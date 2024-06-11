using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdvSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cobrancas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProcessoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "float", nullable: false),
                    JurosPrazo = table.Column<float>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Parcela = table.Column<float>(type: "float", nullable: false),
                    Pago = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ValorAtualizado = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobrancas", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entrada_de_Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsusarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada_de_Caixa", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoa_Fisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Rg = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Celular = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Rua = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa_Fisica", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Saida_de_Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sangria = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saida_de_Caixa", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoa_Juridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(type: "longtext", nullable: false),
                    NomeFantasia = table.Column<string>(type: "longtext", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "longtext", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Rua = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false),
                    RepresentanteLegalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa_Juridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Juridica_Pessoa_Fisica_RepresentanteLegalId",
                        column: x => x.RepresentanteLegalId,
                        principalTable: "Pessoa_Fisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Controle_de_Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NumeroProcesso = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true),
                    Movimentacoes = table.Column<string>(type: "longtext", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controle_de_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Controle_de_Processos_Pessoa_Fisica_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoa_Fisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Controle_de_Processos_Pessoa_Juridica_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoa_Juridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Controle_de_Processos_ClienteId",
                table: "Controle_de_Processos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Juridica_RepresentanteLegalId",
                table: "Pessoa_Juridica",
                column: "RepresentanteLegalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Cobrancas");

            migrationBuilder.DropTable(
                name: "Controle_de_Processos");

            migrationBuilder.DropTable(
                name: "Entrada_de_Caixa");

            migrationBuilder.DropTable(
                name: "Saida_de_Caixa");

            migrationBuilder.DropTable(
                name: "Pessoa_Juridica");

            migrationBuilder.DropTable(
                name: "Pessoa_Fisica");
        }
    }
}
