using Microsoft.EntityFrameworkCore.Migrations;

namespace edu2WebAPI.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Patre 5, 78000 Banja Luka", "Elektrotehnički fakultet" },
                    { 2, "Vojvode Stepe Stepanovića 71, 78000 Banja Luka", "Mašinski fakultet" }
                });

            migrationBuilder.InsertData(
                table: "Social",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Website" },
                    { 2, "LinkedIn" },
                    { 3, "ResearchGate" },
                    { 4, "Twitter" }
                });

            migrationBuilder.InsertData(
                table: "StudyFields",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Računarske nauke" },
                    { 2, null, "Opšta elektrotehnika" },
                    { 3, null, "Automatika i robotika" },
                    { 4, null, "Telekomunikacije" }
                });

            migrationBuilder.InsertData(
                table: "StudyProgram",
                columns: new[] { "Id", "Cycle", "DurationYears", "FacultyId", "Name" },
                values: new object[] { 1, 1, 4, 1, "Računarstvo i informatika" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Social",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Social",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Social",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Social",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudyFields",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudyFields",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyFields",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudyFields",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
