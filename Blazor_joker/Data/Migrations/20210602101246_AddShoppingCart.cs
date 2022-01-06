using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor_joker.Migrations
{
    public partial class AddShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyItemId = table.Column<int>(type: "int", nullable: false),
                    IndetityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_IndetityUserId",
                        column: x => x.IndetityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_CompanyItems_CompanyItemId",
                        column: x => x.CompanyItemId,
                        principalTable: "CompanyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CompanyItemId",
                table: "ShoppingCarts",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_IndetityUserId",
                table: "ShoppingCarts",
                column: "IndetityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
