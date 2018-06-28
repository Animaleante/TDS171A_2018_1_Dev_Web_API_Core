using Microsoft.EntityFrameworkCore.Migrations;

namespace SoboruApi.Migrations
{
    public partial class Usuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveAcesso",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaveAcesso",
                table: "Usuarios",
                nullable: true);
        }
    }
}
