using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginMicroservice.Migrations
{
    public partial class changeFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockCount",
                table: "StockDetails",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "MutualFundUnits",
                table: "MutualFundDetails",
                newName: "Count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "StockDetails",
                newName: "StockCount");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "MutualFundDetails",
                newName: "MutualFundUnits");
        }
    }
}
