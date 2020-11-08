using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class balancingadjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalancingAdjustment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(nullable: false),
                    ComapnyId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancingAdjustment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BalancingAdjustmentYearBought",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssestId = table.Column<int>(nullable: false),
                    InitialAllowance = table.Column<decimal>(nullable: false),
                    AnnualAllowance = table.Column<decimal>(nullable: false),
                    SalesProceed = table.Column<decimal>(nullable: false),
                    Residue = table.Column<decimal>(nullable: false),
                    BalancingAllowance = table.Column<decimal>(nullable: false),
                    BalancingCharge = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    YearBought = table.Column<string>(nullable: true),
                    BalancingAdjustmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancingAdjustmentYearBought", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalancingAdjustment");

            migrationBuilder.DropTable(
                name: "BalancingAdjustmentYearBought");
        }
    }
}
