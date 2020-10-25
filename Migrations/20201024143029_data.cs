using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostClosing",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "DepreciationClosing",
                table: "FixedAsset");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "TrialBalance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TrialBalanceMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrialBalanceId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    ModuleCode = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialBalanceMapping", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrialBalanceMapping");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "TrialBalance");

            migrationBuilder.AddColumn<long>(
                name: "CostClosing",
                table: "FixedAsset",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DepreciationClosing",
                table: "FixedAsset",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
