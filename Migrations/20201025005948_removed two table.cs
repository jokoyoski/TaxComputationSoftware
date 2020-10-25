using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class removedtwotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetClass");

            migrationBuilder.DropTable(
                name: "ItemsMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MappedCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsMapping", x => x.Id);
                });
        }
    }
}
