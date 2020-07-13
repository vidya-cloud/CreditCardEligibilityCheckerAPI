using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityCheckerAPI.Migrations
{
    public partial class RemoveEmailCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CreditCardAudit");

            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 7, 13, 6, 50, 52, 707, DateTimeKind.Utc).AddTicks(4595));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CreditCardAudit",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "Email" },
                values: new object[] { new DateTime(2020, 7, 12, 12, 22, 38, 106, DateTimeKind.Utc).AddTicks(9071), "JoneBoll@gmail.com" });
        }
    }
}
