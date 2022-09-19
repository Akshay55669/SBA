using Microsoft.EntityFrameworkCore.Migrations;

namespace SBA_Bank.Migrations
{
    public partial class changingFKACCId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AccId",
                table: "statements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AccountId",
                table: "statements",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_statements_AccountId",
                table: "statements",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_statements_accountDetails_AccountId",
                table: "statements",
                column: "AccountId",
                principalTable: "accountDetails",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statements_accountDetails_AccountId",
                table: "statements");

            migrationBuilder.DropIndex(
                name: "IX_statements_AccountId",
                table: "statements");

            migrationBuilder.DropColumn(
                name: "AccId",
                table: "statements");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "statements");
        }
    }
}
