using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCardEligibilityCheckerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCardType",
                columns: table => new
                {
                    CardId = table.Column<string>(type: "varchar(3)", nullable: false),
                    Name = table.Column<string>(type: "varchar(16)", nullable: false),
                    APR = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    PromotionalMessage = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardType", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardAudit",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(16)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(16)", nullable: false),
                    DOB = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    CardId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardAudit", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_CreditCardAudit_CreditCardType_CardId",
                        column: x => x.CardId,
                        principalTable: "CreditCardType",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CreditCardType",
                columns: new[] { "CardId", "APR", "Name", "PromotionalMessage" },
                values: new object[] { "BAR", 33.9m, "Barclays", "abcd" });

            migrationBuilder.InsertData(
                table: "CreditCardType",
                columns: new[] { "CardId", "APR", "Name", "PromotionalMessage" },
                values: new object[] { "VAN", 36.2m, "Vanquis", "abcd" });

            migrationBuilder.InsertData(
                table: "CreditCardAudit",
                columns: new[] { "AuditId", "CardId", "DOB", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "BAR", "01-01-2010", "vidyarao.malka@gmail.com", "Jone", "Boll" });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardAudit_CardId",
                table: "CreditCardAudit",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardAudit");

            migrationBuilder.DropTable(
                name: "CreditCardType");
        }
    }
}
