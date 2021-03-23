using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_ProductList_ProductListId",
                table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_ProductListId",
                table: "UserGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_ProductListId",
                table: "UserGroup",
                column: "ProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_ProductList_ProductListId",
                table: "UserGroup",
                column: "ProductListId",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
