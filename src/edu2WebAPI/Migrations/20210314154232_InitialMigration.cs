using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace edu2WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailVisible = table.Column<bool>(type: "bit", nullable: false),
                    PhoneVisible = table.Column<bool>(type: "bit", nullable: false),
                    ProjectsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cycle = table.Column<int>(type: "int", nullable: false),
                    DurationYears = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyProgram_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagUserSettings",
                columns: table => new
                {
                    UserSettingsId = table.Column<int>(type: "int", nullable: false),
                    UserTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUserSettings", x => new { x.UserSettingsId, x.UserTagsId });
                    table.ForeignKey(
                        name: "FK_TagUserSettings_Tags_UserTagsId",
                        column: x => x.UserTagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUserSettings_UserSettings_UserSettingsId",
                        column: x => x.UserSettingsId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSocials",
                columns: table => new
                {
                    UserSettingsId = table.Column<int>(type: "int", nullable: false),
                    SocialId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocials", x => new { x.SocialId, x.UserSettingsId });
                    table.ForeignKey(
                        name: "FK_UserSocials_Socials_SocialId",
                        column: x => x.SocialId,
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSocials_UserSettings_UserSettingsId",
                        column: x => x.UserSettingsId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyProgramSpecialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyProgramId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgramSpecialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyProgramSpecialization_StudyProgram_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSettingsId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyMember_FacultyId = table.Column<int>(type: "int", nullable: true),
                    AcademicRank = table.Column<int>(type: "int", nullable: true),
                    StudyFieldId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    StudyProgramId = table.Column<int>(type: "int", nullable: true),
                    StudyProgramSpecializationId = table.Column<int>(type: "int", nullable: true),
                    StudyYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Faculties_FacultyMember_FacultyId",
                        column: x => x.FacultyMember_FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_StudyFields_StudyFieldId",
                        column: x => x.StudyFieldId,
                        principalTable: "StudyFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_StudyProgram_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_StudyProgramSpecialization_StudyProgramSpecializationId",
                        column: x => x.StudyProgramSpecializationId,
                        principalTable: "StudyProgramSpecialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserSettings_UserSettingsId",
                        column: x => x.UserSettingsId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyFieldId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_StudyFields_StudyFieldId",
                        column: x => x.StudyFieldId,
                        principalTable: "StudyFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    StudyFieldId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    StudyProgramId = table.Column<int>(type: "int", nullable: true),
                    StudyProgramSpecializationId = table.Column<int>(type: "int", nullable: true),
                    StudyYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollaboratorProfile_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollaboratorProfile_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollaboratorProfile_StudyFields_StudyFieldId",
                        column: x => x.StudyFieldId,
                        principalTable: "StudyFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollaboratorProfile_StudyProgram_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollaboratorProfile_StudyProgramSpecialization_StudyProgramSpecializationId",
                        column: x => x.StudyProgramSpecializationId,
                        principalTable: "StudyProgramSpecialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTag",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTag", x => new { x.ProjectsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ProjectTag_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CollaboratorProfileId = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    ApplicantComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectApplicationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectApplications_CollaboratorProfile_CollaboratorProfileId",
                        column: x => x.CollaboratorProfileId,
                        principalTable: "CollaboratorProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectApplications_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectApplications_Users_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserAccountType", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "80088041-9c29-474a-8668-3277462c4d51", "zoranpantos@test.com", false, true, null, "ZORANPANTOS@TEST.COM", "ZORANPANTOS@TEST.COM", "AQAAAAEAACcQAAAAEFhPDeoQp9iRyCWYDdk+1+BVvrNObJl/WW/vJBiezvzhe69X92GG4+z9XUzHS8qN3A==", null, false, "7ZTQGH5Q7AX4CPI73DWSQS2OMESYR6KT", false, 0, "zoranpantos@test.com" },
                    { 1, 0, "255fd95b-c771-4be6-852c-5634244b17ac", "nikolinagrahovac@test.com", false, true, null, "NIKOLINAGRAHOVAC@TEST.COM", "NIKOLINAGRAHOVAC@TEST.COM", "AQAAAAEAACcQAAAAEB3fErhGcr/yNJzrnpwkMN0eSAjxvNKxRhnu+pc/nKkNmCuBIFm9Hb6ow4nuD2EBrA==", null, false, "BRPZ5G5VMPU533RX5YC3S62EYN5H22EL", false, 0, "nikolinagrahovac@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Patre 5, 78000 Banja Luka", "Elektrotehnički fakultet" },
                    { 2, "Vojvode Stepe Stepanovića 71, 78000 Banja Luka", "Mašinski fakultet" }
                });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "LinkedIn" },
                    { 3, "ResearchGate" },
                    { 4, "Twitter" },
                    { 1, "Website" }
                });

            migrationBuilder.InsertData(
                table: "StudyFields",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Računarske nauke" },
                    { 2, null, "Opšta elektrotehnika" },
                    { 4, null, "Telekomunikacije" },
                    { 3, null, "Automatika i robotika" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "web" },
                    { 2, null, "desktop" },
                    { 3, null, "mobile" },
                    { 4, null, "iot" }
                });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "Bio", "CvLink", "EmailVisible", "PhoneVisible", "PhotoLink", "ProjectsVisible" },
                values: new object[,]
                {
                    { 1, "Sample bio", null, true, true, null, true },
                    { 2, "Another sample bio", null, true, true, null, true }
                });

            migrationBuilder.InsertData(
                table: "StudyProgram",
                columns: new[] { "Id", "Cycle", "DurationYears", "FacultyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 4, 1, "Računarstvo i informatika" },
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
                table: "UserSocials",
                columns: new[] { "SocialId", "UserSettingsId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "ngrahovac.com" },
                    { 2, 1, "www.linkedin.com/nikolina-grahovac" }
                });

            migrationBuilder.InsertData(
                table: "StudyProgramSpecialization",
                columns: new[] { "Id", "Name", "StudyProgramId" },
                values: new object[,]
                {
                    { 1, "Računarski inženjering", 1 },
                    { 2, "Softverski inženjering", 1 },
                    { 3, "Elektronika", 2 },
                    { 4, "Telekomunikacije", 2 },
                    { 5, "Elektroenergetika", 3 },
                    { 6, "Automatika", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FacultyId", "FirstName", "LastName", "StudyProgramId", "StudyProgramSpecializationId", "StudyYear", "UserSettingsId" },
                values: new object[] { 1, "Student", 1, "Jane", "Doe", 1, 2, 4, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "FacultyId", "FirstName", "LastName", "StudyProgramId", "StudyProgramSpecializationId", "StudyYear", "UserSettingsId" },
                values: new object[] { 2, "Student", 1, "John", "Doe", 1, 2, 3, 2 });

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
                columns: new[] { "Id", "Description", "Discriminator", "FacultyId", "ProjectId", "StudyProgramId", "StudyProgramSpecializationId", "StudyYear" },
                values: new object[] { 1, "Studentski profil", "StudentProfile", 1, 1, null, null, null });

            migrationBuilder.InsertData(
                table: "ProjectApplications",
                columns: new[] { "Id", "ApplicantComment", "ApplicantId", "AuthorComment", "CollaboratorProfileId", "ProjectApplicationStatus", "ProjectId" },
                values: new object[] { 1, null, 2, null, 1, 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorProfile_FacultyId",
                table: "CollaboratorProfile",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorProfile_ProjectId",
                table: "CollaboratorProfile",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorProfile_StudyFieldId",
                table: "CollaboratorProfile",
                column: "StudyFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorProfile_StudyProgramId",
                table: "CollaboratorProfile",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorProfile_StudyProgramSpecializationId",
                table: "CollaboratorProfile",
                column: "StudyProgramSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplications_ApplicantId",
                table: "ProjectApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplications_CollaboratorProfileId",
                table: "ProjectApplications",
                column: "CollaboratorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplications_ProjectId",
                table: "ProjectApplications",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudyFieldId",
                table: "Projects",
                column: "StudyFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_TagsId",
                table: "ProjectTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgram_FacultyId",
                table: "StudyProgram",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgramSpecialization_StudyProgramId",
                table: "StudyProgramSpecialization",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TagUserSettings_UserTagsId",
                table: "TagUserSettings",
                column: "UserTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyId",
                table: "Users",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyMember_FacultyId",
                table: "Users",
                column: "FacultyMember_FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudyFieldId",
                table: "Users",
                column: "StudyFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudyProgramId",
                table: "Users",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudyProgramSpecializationId",
                table: "Users",
                column: "StudyProgramSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSettingsId",
                table: "Users",
                column: "UserSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocials_UserSettingsId",
                table: "UserSocials",
                column: "UserSettingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ProjectApplications");

            migrationBuilder.DropTable(
                name: "ProjectTag");

            migrationBuilder.DropTable(
                name: "TagUserSettings");

            migrationBuilder.DropTable(
                name: "UserSocials");

            migrationBuilder.DropTable(
                name: "CollaboratorProfile");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StudyFields");

            migrationBuilder.DropTable(
                name: "StudyProgramSpecialization");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "StudyProgram");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
