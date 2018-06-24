using Microsoft.EntityFrameworkCore.Migrations;

namespace SoboruApi.Migrations
{
    public partial class UtensilioEReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utensilios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utensilios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaUtensilio",
                columns: table => new
                {
                    ReceitaId = table.Column<long>(nullable: false),
                    UtensilioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaUtensilio", x => new { x.ReceitaId, x.UtensilioId });
                    table.ForeignKey(
                        name: "FK_ReceitaUtensilio_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceitaUtensilio_Utensilios_UtensilioId",
                        column: x => x.UtensilioId,
                        principalTable: "Utensilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaUtensilio_UtensilioId",
                table: "ReceitaUtensilio",
                column: "UtensilioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaUtensilio");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Utensilios");
        }
    }
}
