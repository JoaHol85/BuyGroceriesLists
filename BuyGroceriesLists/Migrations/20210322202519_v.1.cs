using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductListID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserGroup_ProductList_ProductListID",
                        column: x => x.ProductListID,
                        principalTable: "ProductList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserGroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Member_UserGroup_UserGroupID",
                        column: x => x.UserGroupID,
                        principalTable: "UserGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductListID",
                table: "Product",
                column: "ProductListID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserGroupID",
                table: "Member",
                column: "UserGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_ProductListID",
                table: "UserGroup",
                column: "ProductListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductList_ProductListID",
                table: "Product",
                column: "ProductListID",
                principalTable: "ProductList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductList_ProductListID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductListID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductListID",
                table: "Product");
        }
    }
}
