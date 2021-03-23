using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductList_ProductListID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductListID",
                table: "Product",
                newName: "ProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductListID",
                table: "Product",
                newName: "IX_Product_ProductListId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductListId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductList_ProductListId",
                table: "Product",
                column: "ProductListId",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductList_ProductListId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductListId",
                table: "Product",
                newName: "ProductListID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductListId",
                table: "Product",
                newName: "IX_Product_ProductListID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductListID",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductList_ProductListID",
                table: "Product",
                column: "ProductListID",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
