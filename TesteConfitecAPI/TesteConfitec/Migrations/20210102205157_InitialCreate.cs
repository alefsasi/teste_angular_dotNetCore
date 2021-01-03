using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteConfitec.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_escolaridade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_escolaridade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: false),
                    EscolaridadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_usuario_tb_escolaridade_EscolaridadeId",
                        column: x => x.EscolaridadeId,
                        principalTable: "tb_escolaridade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_EscolaridadeId",
                table: "tb_usuario",
                column: "EscolaridadeId");

            // Já inicia o banco de dados com os dados de escolaridade Padrão Inseridos.
            migrationBuilder.InsertData(
                table: "tb_escolaridade",
                columns: new[] { "descricao" },
                values: new object[,] { { "Infantil" }, { "Fundamental" }, { "Médio" }, { "Superior" } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_escolaridade");
        }
    }
}
