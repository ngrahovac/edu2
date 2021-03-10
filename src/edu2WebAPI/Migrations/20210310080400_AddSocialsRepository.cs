using Microsoft.EntityFrameworkCore.Migrations;

namespace edu2WebAPI.Migrations
{
    public partial class AddSocialsRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocials_Social_SocialId",
                table: "UserSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Social",
                table: "Social");

            migrationBuilder.RenameTable(
                name: "Social",
                newName: "Socials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Socials",
                table: "Socials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocials_Socials_SocialId",
                table: "UserSocials",
                column: "SocialId",
                principalTable: "Socials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocials_Socials_SocialId",
                table: "UserSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Socials",
                table: "Socials");

            migrationBuilder.RenameTable(
                name: "Socials",
                newName: "Social");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Social",
                table: "Social",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocials_Social_SocialId",
                table: "UserSocials",
                column: "SocialId",
                principalTable: "Social",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
