using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class twocolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTransferRemoved",
                table: "FixedAsset",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TransferCost",
                table: "FixedAsset",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TransferDepreciation",
                table: "FixedAsset",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransferRemoved",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "TransferCost",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "TransferDepreciation",
                table: "FixedAsset");
        }
    }
}
