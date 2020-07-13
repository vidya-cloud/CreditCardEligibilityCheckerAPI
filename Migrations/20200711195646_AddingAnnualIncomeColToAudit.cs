using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityCheckerAPI.Migrations
{
    public partial class AddingAnnualIncomeColToAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnualIncome",
                table: "CreditCardAudit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CreditCardAudit",
                keyColumn: "AuditId",
                keyValue: 1,
                column: "AnnualIncome",
                value: 30000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualIncome",
                table: "CreditCardAudit");
        }
    }
}
