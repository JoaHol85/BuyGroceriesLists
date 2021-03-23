using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductList_ProductListId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductListId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductListId",
                table: "Product",
                column: "ProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductList_ProductListId",
                table: "Product",
                column: "ProductListId",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
