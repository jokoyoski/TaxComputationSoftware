using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxComputationAPI.Migrations
{
    public partial class tribalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixedAssetName",
                table: "FixedAsset");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "FixedAsset",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "FixedAsset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrialBalance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Debit = table.Column<long>(nullable: false),
                    Credit = table.Column<long>(nullable: false),
                    MappedTo = table.Column<string>(nullable: true),
                    IsCheck = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialBalance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrialBalance");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "FixedAsset");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FixedAssetName",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
