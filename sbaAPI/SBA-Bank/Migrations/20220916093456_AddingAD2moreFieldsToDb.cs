using Microsoft.EntityFrameworkCore.Migrations;

namespace SBA_Bank.Migrations
{
    public partial class AddingAD2moreFieldsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "accountDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "BankBranch",
                table: "accountDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "BankBranch",
                table: "accountDetails");
        }
    }
}
