using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyGroceriesLists.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_UserGroup_UserGroupID",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_UserGroupID",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "UserGroupID",
                table: "Member",
                newName: "UserGroupId");

            migrationBuilder.AlterColumn<int>(
                name: "UserGroupId",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "Member",
                newName: "UserGroupID");

            migrationBuilder.AlterColumn<int>(
                name: "UserGroupID",
                table: "Member",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserGroupID",
                table: "Member",
                column: "UserGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_UserGroup_UserGroupID",
                table: "Member",
                column: "UserGroupID",
                principalTable: "UserGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
