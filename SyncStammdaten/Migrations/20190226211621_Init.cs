using Microsoft.EntityFrameworkCore.Migrations;

namespace SyncStammdaten.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntityDiffs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Clock = table.Column<int>(nullable: false),
                    Json = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntityDiffs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntityDiffs");
        }
    }
}
