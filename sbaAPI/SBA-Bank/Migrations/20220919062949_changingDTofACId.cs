using Microsoft.EntityFrameworkCore.Migrations;

namespace SBA_Bank.Migrations
{
    public partial class changingDTofACId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statements_accountDetails_AccountId",
                table: "statements");

            migrationBuilder.DropIndex(
                name: "IX_statements_AccountId",
                table: "statements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountDetails",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "statements");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "accountDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "AccId",
                table: "accountDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountDetails",
                table: "accountDetails",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_accountDetails",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "AccId",
                table: "accountDetails");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "statements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "accountDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountDetails",
                table: "accountDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_statements_AccountId",
                table: "statements",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_statements_accountDetails_AccountId",
                table: "statements",
                column: "AccountId",
                principalTable: "accountDetails",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
