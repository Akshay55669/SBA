using Microsoft.EntityFrameworkCore.Migrations;

namespace SBA_Bank.Migrations
{
    public partial class AddForeignKeytoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "accountDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_accountDetails_UserId",
                table: "accountDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_accountDetails_AspNetUsers_UserId",
                table: "accountDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountDetails_AspNetUsers_UserId",
                table: "accountDetails");

            migrationBuilder.DropIndex(
                name: "IX_accountDetails_UserId",
                table: "accountDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "accountDetails");
        }
    }
}
