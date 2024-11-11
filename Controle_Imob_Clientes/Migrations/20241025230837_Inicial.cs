using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_Imob_Clientes.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imobiliarias",
                columns: table => new
                {
                    imobiliariaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    Responsavel = table.Column<string>(nullable: true),
                    PaginaWeb = table.Column<string>(nullable: true),
                    PerfilInstagram = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imobiliarias", x => x.imobiliariaID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<int>(nullable: false),
                    Casa = table.Column<string>(nullable: true),
                    Modalidade = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    imobiliariaID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                    table.ForeignKey(
                        name: "FK_Clientes_Imobiliarias_imobiliariaID",
                        column: x => x.imobiliariaID,
                        principalTable: "Imobiliarias",
                        principalColumn: "imobiliariaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_imobiliariaID",
                table: "Clientes",
                column: "imobiliariaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Imobiliarias");
        }
    }
}
