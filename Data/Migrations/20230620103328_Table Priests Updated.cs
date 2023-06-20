using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolidarityFund.Data.Migrations
{
    public partial class TablePriestsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncardinated",
                table: "PRETRES",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspensionDate",
                table: "PRETRES",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuspensionReason",
                table: "PRETRES",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncardinated",
                table: "PRETRES");

            migrationBuilder.DropColumn(
                name: "SuspensionDate",
                table: "PRETRES");

            migrationBuilder.DropColumn(
                name: "SuspensionReason",
                table: "PRETRES");
        }
    }
}
