using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOPAINNOGAIN.Migrations
{
    public partial class TabelaSistemaGR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AparelhosGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grupomuscular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Tempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tempoFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AparelhosGR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosGR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FuncionariosGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoFuncionario = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosGR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LogadosGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogadosGR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedGrupoGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedGrupoGR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosGR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EnderecosGR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosGR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnderecosGR_FuncionariosGR_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "FuncionariosGR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosGR_FuncionarioId",
                table: "EnderecosGR",
                column: "FuncionarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AparelhosGR");

            migrationBuilder.DropTable(
                name: "ComentariosGR");

            migrationBuilder.DropTable(
                name: "EnderecosGR");

            migrationBuilder.DropTable(
                name: "LogadosGR");

            migrationBuilder.DropTable(
                name: "MedGrupoGR");

            migrationBuilder.DropTable(
                name: "UsuariosGR");

            migrationBuilder.DropTable(
                name: "FuncionariosGR");
        }
    }
}
