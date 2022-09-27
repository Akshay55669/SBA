using Microsoft.EntityFrameworkCore.Migrations;

namespace SBA_Bank.Migrations
{
    public partial class fktostatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "statements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_statements_UserId",
                table: "statements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_statements_AspNetUsers_UserId",
                table: "statements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statements_AspNetUsers_UserId",
                table: "statements");

            migrationBuilder.DropIndex(
                name: "IX_statements_UserId",
                table: "statements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "statements");
        }
    }
}
