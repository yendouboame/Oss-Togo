using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolidarityFund.Data.Migrations
{
    public partial class TablePensionsUpdatedColumnDateDropedColumnsMonthAndYearAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ALLOCATIONS");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "ALLOCATIONS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "ALLOCATIONS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 46, 16, 312, DateTimeKind.Local).AddTicks(3609));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "ALLOCATIONS");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ALLOCATIONS");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ALLOCATIONS",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 14, 17, 2, 40, 335, DateTimeKind.Local).AddTicks(2251));
        }
    }
}
