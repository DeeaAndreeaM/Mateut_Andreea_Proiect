using Microsoft.EntityFrameworkCore.Migrations;

namespace Mateut_Andreea_Proiect.Migrations
{
    public partial class MouvieCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleaserID",
                table: "Mouvie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Releaser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releaser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MouvieCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouvieID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouvieCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MouvieCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MouvieCategory_Mouvie_MouvieID",
                        column: x => x.MouvieID,
                        principalTable: "Mouvie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mouvie_ReleaserID",
                table: "Mouvie",
                column: "ReleaserID");

            migrationBuilder.CreateIndex(
                name: "IX_MouvieCategory_CategoryID",
                table: "MouvieCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MouvieCategory_MouvieID",
                table: "MouvieCategory",
                column: "MouvieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvie_Releaser_ReleaserID",
                table: "Mouvie",
                column: "ReleaserID",
                principalTable: "Releaser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mouvie_Releaser_ReleaserID",
                table: "Mouvie");

            migrationBuilder.DropTable(
                name: "MouvieCategory");

            migrationBuilder.DropTable(
                name: "Releaser");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Mouvie_ReleaserID",
                table: "Mouvie");

            migrationBuilder.DropColumn(
                name: "ReleaserID",
                table: "Mouvie");
        }
    }
}
