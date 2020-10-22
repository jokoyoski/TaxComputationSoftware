using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class transfercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransferRemoved",
                table: "FixedAsset");

            migrationBuilder.AddColumn<bool>(
                name: "IsTransferCostRemoved",
                table: "FixedAsset",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTransferDepreciationRemoved",
                table: "FixedAsset",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransferCostRemoved",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "IsTransferDepreciationRemoved",
                table: "FixedAsset");

            migrationBuilder.AddColumn<bool>(
                name: "IsTransferRemoved",
                table: "FixedAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
