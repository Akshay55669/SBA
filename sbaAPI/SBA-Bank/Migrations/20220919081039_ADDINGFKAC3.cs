using Microsoft.EntityFrameworkCore.Migrations;

namespace SBA_Bank.Migrations
{
    public partial class ADDINGFKAC3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountNo",
                table: "statements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_statements_AccountNo",
                table: "statements",
                column: "AccountNo");

            migrationBuilder.AddForeignKey(
                name: "FK_statements_accountDetails_AccountNo",
                table: "statements",
                column: "AccountNo",
                principalTable: "accountDetails",
                principalColumn: "AccountNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statements_accountDetails_AccountNo",
                table: "statements");

            migrationBuilder.DropIndex(
                name: "IX_statements_AccountNo",
                table: "statements");

            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "statements");
        }
    }
}
