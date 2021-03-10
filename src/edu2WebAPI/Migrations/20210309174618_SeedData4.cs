using Microsoft.EntityFrameworkCore.Migrations;

namespace edu2WebAPI.Migrations
{
    public partial class SeedData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Bio", "CvLink", "EmailVisible", "PhoneVisible", "PhotoLink", "ProjectsVisible" },
                values: new object[] { 1, "Sample bio", null, true, true, null, true });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Bio", "CvLink", "EmailVisible", "PhoneVisible", "PhotoLink", "ProjectsVisible" },
                values: new object[] { 2, "Another sample bio", null, true, true, null, true });

            migrationBuilder.InsertData(
                table: "UserSocials",
                columns: new[] { "SocialId", "UserSettingsId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "ngrahovac.com" },
                    { 2, 1, "www.linkedin.com/nikolina-grahovac" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FacultyId", "StudyProgramId", "StudyProgramSpecializationId", "StudyYear", "UserSettingsId" },
                values: new object[,]
                {
                    { 1, "Student", 1, 1, 2, 4, 1 },
                    { 2, "Student", 1, 1, 2, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSocials",
                keyColumns: new[] { "SocialId", "UserSettingsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserSocials",
                keyColumns: new[] { "SocialId", "UserSettingsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
