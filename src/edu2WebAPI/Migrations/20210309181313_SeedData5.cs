using Microsoft.EntityFrameworkCore.Migrations;

namespace edu2WebAPI.Migrations
{
    public partial class SeedData5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorId", "Description", "EndDate", "ProjectStatus", "StartDate", "StudyFieldId", "Title" },
                values: new object[] { 1, 1, "Opis projekta", null, 1, null, 1, "Naslov projekta" });

            migrationBuilder.InsertData(
                table: "CollaboratorProfile",
                columns: new[] { "Id", "Description", "Discriminator", "ProjectId", "StudyFieldId" },
                values: new object[] { 2, "Profil nastavnog saradnika", "FacultyMemberProfile", 1, null });

            migrationBuilder.InsertData(
                table: "CollaboratorProfile",
                columns: new[] { "Id", "Description", "Discriminator", "FacultyId", "ProjectId", "StudyCycle", "StudyProgramId", "StudyProgramSpecializationId", "StudyYear" },
                values: new object[] { 1, "Studentski profil", "StudentProfile", 1, 1, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ProjectApplications",
                columns: new[] { "Id", "ApplicantComment", "ApplicantId", "AuthorComment", "CollaboratorProfileId", "ProjectApplicationStatus", "ProjectId" },
                values: new object[] { 1, null, 2, null, 1, 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollaboratorProfile",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectApplications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CollaboratorProfile",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
