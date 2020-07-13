using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityCheckerAPI.Migrations
{
    public partial class Audittablevalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 7, 12, 12, 22, 38, 106, DateTimeKind.Utc).AddTicks(9071));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 7, 12, 12, 19, 41, 649, DateTimeKind.Utc).AddTicks(6419));
        }
    }
}
