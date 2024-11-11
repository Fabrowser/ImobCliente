using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_Imob_Clientes.Migrations
{
    public partial class atualizar_tipo_CPF_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
