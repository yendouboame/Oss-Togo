using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolidarityFund.Data.Migrations
{
    public partial class TablePensionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PENSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriestId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Ammount = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PENSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PENSIONS_PRETRES_PriestId",
                        column: x => x.PriestId,
                        principalTable: "PRETRES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PENSIONS_PriestId",
                table: "PENSIONS",
                column: "PriestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PENSIONS");
        }
    }
}
