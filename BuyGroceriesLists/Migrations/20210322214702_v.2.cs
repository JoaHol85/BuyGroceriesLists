using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_ProductList_ProductListID",
                table: "UserGroup");

            migrationBuilder.RenameColumn(
                name: "ProductListID",
                table: "UserGroup",
                newName: "ProductListId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_ProductListID",
                table: "UserGroup",
                newName: "IX_UserGroup_ProductListId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductListId",
                table: "UserGroup",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_ProductList_ProductListId",
                table: "UserGroup",
                column: "ProductListId",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_ProductList_ProductListId",
                table: "UserGroup");

            migrationBuilder.RenameColumn(
                name: "ProductListId",
                table: "UserGroup",
                newName: "ProductListID");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_ProductListId",
                table: "UserGroup",
                newName: "IX_UserGroup_ProductListID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductListID",
                table: "UserGroup",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_ProductList_ProductListID",
                table: "UserGroup",
                column: "ProductListID",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
