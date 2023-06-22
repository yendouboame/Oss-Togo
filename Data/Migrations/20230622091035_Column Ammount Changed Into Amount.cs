using Microsoft.EntityFrameworkCore.Migrations;

namespace SolidarityFund.Data.Migrations
{
    public partial class ColumnAmmountChangedIntoAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ammount",
                table: "COTISATIONS",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Ammount",
                table: "ALLOCATIONS",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "COTISATIONS",
                newName: "Ammount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ALLOCATIONS",
                newName: "Ammount");
        }
    }
}
