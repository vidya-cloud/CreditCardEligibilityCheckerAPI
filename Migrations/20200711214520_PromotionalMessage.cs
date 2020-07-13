using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityCheckerAPI.Migrations
{
    public partial class PromotionalMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PromotionalMessage",
                table: "CreditCardType",
                type: "varchar(800)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "Email" },
                values: new object[] { new DateTime(2020, 7, 11, 21, 45, 20, 82, DateTimeKind.Utc).AddTicks(9370), "JoneBoll@gmail.com" });

            migrationBuilder.UpdateData(
                table: "CreditCardType",
                keyColumn: "CardId",
                keyValue: "BAR",
                column: "PromotionalMessage",
                value: "0.25% cashback on all your spend.No fees abroad – you’ll be able to withdraw cash from an ATM or buy your souvenirs without any charges and benefit from Visa’s competitive exchange rate");

            migrationBuilder.UpdateData(
                table: "CreditCardType",
                keyColumn: "CardId",
                keyValue: "VAN",
                columns: new[] { "APR", "PromotionalMessage" },
                values: new object[] { 39.9m, "Great for credit building. Opening credit limit of £150 - £1,000.Increase your credit limit after the fifth statement,subject to eligibility.Manage your spending online or via the Vanquis app.Quick and easy eligibility check that won’t affect your credit score" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PromotionalMessage",
                table: "CreditCardType",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(800)");

            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "Email" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vidyarao.malka@gmail.com" });

            migrationBuilder.UpdateData(
                table: "CreditCardType",
                keyColumn: "CardId",
                keyValue: "BAR",
                column: "PromotionalMessage",
                value: "abcd");

            migrationBuilder.UpdateData(
                table: "CreditCardType",
                keyColumn: "CardId",
                keyValue: "VAN",
                columns: new[] { "APR", "PromotionalMessage" },
                values: new object[] { 36.2m, "abcd" });
        }
    }
}
