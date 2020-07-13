using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityCheckerAPI.Migrations
{
    public partial class Audittable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 7, 12, 12, 19, 41, 649, DateTimeKind.Utc).AddTicks(6419));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 7, 11, 21, 45, 20, 82, DateTimeKind.Utc).AddTicks(9370));
        }
    }
}
