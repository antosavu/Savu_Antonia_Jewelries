using Microsoft.EntityFrameworkCore.Migrations;

namespace Savu_Antonia_Jewelries.Migrations
{
    public partial class JewelryCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialID",
                table: "Jewelry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JewelryCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JewelryCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JewelryCategory_Jewelry_JewelryID",
                        column: x => x.JewelryID,
                        principalTable: "Jewelry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_MaterialID",
                table: "Jewelry",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryCategory_CategoryID",
                table: "JewelryCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryCategory_JewelryID",
                table: "JewelryCategory",
                column: "JewelryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelry_Material_MaterialID",
                table: "Jewelry",
                column: "MaterialID",
                principalTable: "Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelry_Material_MaterialID",
                table: "Jewelry");

            migrationBuilder.DropTable(
                name: "JewelryCategory");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Jewelry_MaterialID",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "MaterialID",
                table: "Jewelry");
        }
    }
}
