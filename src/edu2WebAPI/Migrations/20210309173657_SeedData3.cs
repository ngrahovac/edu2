using Microsoft.EntityFrameworkCore.Migrations;

namespace edu2WebAPI.Migrations
{
    public partial class SeedData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserAccountType", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "255fd95b-c771-4be6-852c-5634244b17ac", "nikolinagrahovac@test.com", false, true, null, "NIKOLINAGRAHOVAC@TEST.COM", "NIKOLINAGRAHOVAC@TEST.COM", "AQAAAAEAACcQAAAAEB3fErhGcr/yNJzrnpwkMN0eSAjxvNKxRhnu+pc/nKkNmCuBIFm9Hb6ow4nuD2EBrA==", null, false, "BRPZ5G5VMPU533RX5YC3S62EYN5H22EL", false, 0, "nikolinagrahovac@test.com" },
                    { 2, 0, "80088041-9c29-474a-8668-3277462c4d51", "zoranpantos@test.com", false, true, null, "ZORANPANTOS@TEST.COM", "ZORANPANTOS@TEST.COM", "AQAAAAEAACcQAAAAEFhPDeoQp9iRyCWYDdk+1+BVvrNObJl/WW/vJBiezvzhe69X92GG4+z9XUzHS8qN3A==", null, false, "7ZTQGH5Q7AX4CPI73DWSQS2OMESYR6KT", false, 0, "zoranpantos@test.com" }
                });

            migrationBuilder.InsertData(
                table: "StudyProgram",
                columns: new[] { "Id", "Cycle", "DurationYears", "FacultyId", "Name" },
                values: new object[,]
                {
                    { 2, 1, 4, 1, "Elektronika i telekomunikacije" },
                    { 3, 1, 4, 1, "Elektroenergetika i automatika" },
                    { 4, 2, 1, 1, "Računarstvo i informatika" },
                    { 5, 2, 1, 1, "Elektronika i telekomunikacije" },
                    { 6, 2, 1, 1, "Elektroenergetski i industrijski sistemi" },
                    { 7, 2, 1, 1, "Digitalno emitovanje i širokopojasne tehnologije" },
                    { 8, 3, 3, 1, "Informaciono-komunikacione tehnologije" },
                    { 9, 1, 4, 2, "Mehatronika" },
                    { 10, 1, 4, 2, "Industrijsko inženjerstvo" }
                });

            migrationBuilder.InsertData(
                table: "StudyProgramSpecialization",
                columns: new[] { "Id", "Name", "StudyProgramId" },
                values: new object[,]
                {
                    { 1, "Računarski inženjering", 1 },
                    { 2, "Softverski inženjering", 1 }
                });

            migrationBuilder.InsertData(
                table: "StudyProgramSpecialization",
                columns: new[] { "Id", "Name", "StudyProgramId" },
                values: new object[,]
                {
                    { 3, "Elektronika", 2 },
                    { 4, "Telekomunikacije", 2 },
                    { 5, "Elektroenergetika", 3 },
                    { 6, "Automatika", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StudyProgramSpecialization",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudyProgramSpecialization",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyProgramSpecialization",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudyProgramSpecialization",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudyProgramSpecialization",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudyProgramSpecialization",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyProgram",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
