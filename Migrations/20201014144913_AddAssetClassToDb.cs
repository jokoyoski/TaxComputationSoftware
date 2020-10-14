using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class AddAssetClassToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FixedAsset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    YearId = table.Column<int>(nullable: false),
                    FixedAssetName = table.Column<string>(nullable: true),
                    OpeningCost = table.Column<long>(nullable: false),
                    CostAddition = table.Column<long>(nullable: false),
                    CostDisposal = table.Column<long>(nullable: false),
                    CostClosing = table.Column<long>(nullable: false),
                    OpeningDepreciation = table.Column<long>(nullable: false),
                    DepreciationAddition = table.Column<long>(nullable: false),
                    DepreciationDisposal = table.Column<long>(nullable: false),
                    DepreciationClosing = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAsset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetClass");

            migrationBuilder.DropTable(
                name: "FixedAsset");
        }
    }
}
