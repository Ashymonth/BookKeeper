using Microsoft.EntityFrameworkCore.Migrations;

namespace BookKeeper.Data.Migrations
{
    public partial class initial30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDocuments_Accounts_AccountEntityId",
                table: "PaymentDocuments");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDocuments_AccountEntityId",
                table: "PaymentDocuments");

            migrationBuilder.DropColumn(
                name: "AccountEntityId",
                table: "PaymentDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDocuments_AccountId",
                table: "PaymentDocuments",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDocuments_Accounts_AccountId",
                table: "PaymentDocuments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDocuments_Accounts_AccountId",
                table: "PaymentDocuments");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDocuments_AccountId",
                table: "PaymentDocuments");

            migrationBuilder.AddColumn<int>(
                name: "AccountEntityId",
                table: "PaymentDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDocuments_AccountEntityId",
                table: "PaymentDocuments",
                column: "AccountEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDocuments_Accounts_AccountEntityId",
                table: "PaymentDocuments",
                column: "AccountEntityId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
