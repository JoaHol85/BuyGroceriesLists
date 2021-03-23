using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Member_UserGroupId",
                table: "Member",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_UserGroup_UserGroupId",
                table: "Member",
                column: "UserGroupId",
                principalTable: "UserGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_UserGroup_UserGroupId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_UserGroupId",
                table: "Member");
        }
    }
}
