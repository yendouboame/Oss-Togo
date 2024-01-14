using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolidarityFund.Data.Migrations
{
    public partial class TablePriestsUpdatedColumnLastPensionPaymentDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastPensionPaymentDate",
                table: "PRETRES",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPensionPaymentDate",
                table: "PRETRES");

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "DIOCESES",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 13, 15, 48, 50, 941, DateTimeKind.Local).AddTicks(8258));
        }
    }
}
