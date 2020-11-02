using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class AddBalancingAdjustmentToDBUpdate : Migration
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
                    Cost = table.Column<int>(nullable: false),
                    InitialAllowance = table.Column<int>(nullable: false),
                    AnnualAllowance = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Residue = table.Column<int>(nullable: false),
                    SalesProceed = table.Column<int>(nullable: false),
                    BalancingCharge = table.Column<int>(nullable: false),
                    BalancingAllowance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancingAdjustment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalancingAdjustment");
        }
    }
}
