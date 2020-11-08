using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class AddCostBalancingadjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "BalancingAdjustmentYearBought",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "BalancingAdjustmentYearBought");
        }
    }
}
