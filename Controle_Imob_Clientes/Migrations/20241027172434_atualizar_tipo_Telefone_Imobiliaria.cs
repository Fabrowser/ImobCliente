using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_Imob_Clientes.Migrations
{
    public partial class atualizar_tipo_Telefone_Imobiliaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Imobiliarias",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Imobiliarias",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
