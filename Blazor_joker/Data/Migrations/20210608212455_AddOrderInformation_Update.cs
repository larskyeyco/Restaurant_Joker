using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor_joker.Migrations
{
    public partial class AddOrderInformation_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IndetityUserId",
                table: "OrderInformations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderInformations_IndetityUserId",
                table: "OrderInformations",
                column: "IndetityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInformations_AspNetUsers_IndetityUserId",
                table: "OrderInformations",
                column: "IndetityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInformations_AspNetUsers_IndetityUserId",
                table: "OrderInformations");

            migrationBuilder.DropIndex(
                name: "IX_OrderInformations_IndetityUserId",
                table: "OrderInformations");

            migrationBuilder.DropColumn(
                name: "IndetityUserId",
                table: "OrderInformations");
        }
    }
}
