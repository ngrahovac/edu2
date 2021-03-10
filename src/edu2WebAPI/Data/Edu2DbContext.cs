using edu2Domain;
using edu2WebAPI.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace edu2WebAPI.Data
{
    public class Edu2DbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectApplication> ProjectApplications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<StudyField> StudyFields { get; set; }
        public DbSet<Social> Socials { get; set; }

        public Edu2DbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("edu2Db"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // include derived concrete classes
            modelBuilder.Entity<StudentProfile>();
            modelBuilder.Entity<FacultyMemberProfile>();

            // configure join entity types
            modelBuilder.Entity<UserSettings>()
                        .HasMany(e => e.Socials)
                        .WithMany(e => e.UserSettings)
                        .UsingEntity<UserSocials>(
                            e => e.HasOne(e => e.Social)
                                  .WithMany(e => e.UserSocials)
                                  .HasForeignKey(e => e.SocialId),
                            e => e.HasOne(e => e.UserSettings)
                                  .WithMany(e => e.UserSocials)
                                  .HasForeignKey(e => e.UserSettingsId),
                            e => e.HasKey(e => new { e.SocialId, e.UserSettingsId }));

            modelBuilder.Entity<UserSettings>()
                        .HasMany(e => e.UserTags)
                        .WithMany(e => e.UserSettings);

            // configure FKs in derived concrete classes
            modelBuilder.Entity<Student>(e =>
            {
                e.HasOne<Faculty>()
                 .WithMany()
                 .HasForeignKey(e => e.FacultyId)
                 .OnDelete(DeleteBehavior.NoAction);

                e.HasOne<StudyProgram>()
                 .WithMany()
                 .HasForeignKey(e => e.StudyProgramId);

                e.HasOne<StudyProgramSpecialization>()
                 .WithMany()
                 .HasForeignKey(e => e.StudyProgramSpecializationId);
            });


            modelBuilder.Entity<FacultyMember>(e =>
            {
                e.HasOne<Faculty>()
                 .WithMany()
                 .HasForeignKey(e => e.FacultyId)
                 .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<StudentProfile>(e =>
            {
                e.HasOne<Faculty>()
                 .WithMany()
                 .HasForeignKey(e => e.FacultyId);

                e.HasOne<StudyProgram>()
                 .WithMany()
                 .HasForeignKey(e => e.StudyProgramId);

                e.HasOne<StudyProgramSpecialization>()
                 .WithMany()
                 .HasForeignKey(e => e.StudyProgramSpecializationId);

            });

            // add shadow PK for value objects
            modelBuilder.Entity<Tag>()
                        .Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Key", 0);

            modelBuilder.Entity<StudyField>()
                        .Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Key", 0);

            // configure FKs (no navigation property)
            modelBuilder.Entity<ProjectApplication>(e =>
            {
                e.HasOne<Project>()
                 .WithMany()
                 .HasForeignKey(e => e.ProjectId);

                e.HasOne<CollaboratorProfile>()
                 .WithMany()
                 .HasForeignKey(e => e.CollaboratorProfileId);

                e.HasOne<User>()
                 .WithMany()
                 .HasForeignKey(e => e.ApplicantId);
            });

            modelBuilder.Entity<Project>()
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey(e => e.AuthorId)
                        .OnDelete(DeleteBehavior.NoAction); // vidjeti kako se jos moglo doci dovdje

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                        .HasData(
                            new { Id = 1, Name = "web" },
                            new { Id = 2, Name = "desktop" },
                            new { Id = 3, Name = "mobile" },
                            new { Id = 4, Name = "iot" });

            modelBuilder.Entity<StudyField>()
                        .HasData(
                            new { Id = 1, Name = "Računarske nauke" },
                            new { Id = 2, Name = "Opšta elektrotehnika" },
                            new { Id = 3, Name = "Automatika i robotika" },
                            new { Id = 4, Name = "Telekomunikacije" });

            modelBuilder.Entity<Social>()
                        .HasData(
                            new Social { Id = 1, Name = "Website" },
                            new Social { Id = 2, Name = "LinkedIn" },
                            new Social { Id = 3, Name = "ResearchGate" },
                            new Social { Id = 4, Name = "Twitter" });

            modelBuilder.Entity<Faculty>()
                        .HasData(
                            new Faculty { Id = 1, Name = "Elektrotehnički fakultet", Address = "Patre 5, 78000 Banja Luka" },
                            new Faculty { Id = 2, Name = "Mašinski fakultet", Address = "Vojvode Stepe Stepanovića 71, 78000 Banja Luka" });

            modelBuilder.Entity<StudyProgram>()
                        .HasData(
                            new { Id = 1, FacultyId = 1, Name = "Računarstvo i informatika", Cycle = 1, DurationYears = 4 },
                            new { Id = 2, FacultyId = 1, Name = "Elektronika i telekomunikacije", Cycle = 1, DurationYears = 4 },
                            new { Id = 3, FacultyId = 1, Name = "Elektroenergetika i automatika", Cycle = 1, DurationYears = 4 },
                            new { Id = 4, FacultyId = 1, Name = "Računarstvo i informatika", Cycle = 2, DurationYears = 1 },
                            new { Id = 5, FacultyId = 1, Name = "Elektronika i telekomunikacije", Cycle = 2, DurationYears = 1 },
                            new { Id = 6, FacultyId = 1, Name = "Elektroenergetski i industrijski sistemi", Cycle = 2, DurationYears = 1 },
                            new { Id = 7, FacultyId = 1, Name = "Digitalno emitovanje i širokopojasne tehnologije", Cycle = 2, DurationYears = 1 },
                            new { Id = 8, FacultyId = 1, Name = "Informaciono-komunikacione tehnologije", Cycle = 3, DurationYears = 3 },
                            new { Id = 9, FacultyId = 2, Name = "Mehatronika", Cycle = 1, DurationYears = 4 },
                            new { Id = 10, FacultyId = 2, Name = "Industrijsko inženjerstvo", Cycle = 1, DurationYears = 4 });

            modelBuilder.Entity<StudyProgramSpecialization>()
                        .HasData(
                            new { Id = 1, StudyProgramId = 1, Name = "Računarski inženjering" },
                            new { Id = 2, StudyProgramId = 1, Name = "Softverski inženjering" },
                            new { Id = 3, StudyProgramId = 2, Name = "Elektronika" },
                            new { Id = 4, StudyProgramId = 2, Name = "Telekomunikacije" },
                            new { Id = 5, StudyProgramId = 3, Name = "Elektroenergetika" },
                            new { Id = 6, StudyProgramId = 3, Name = "Automatika" });

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    UserName = "nikolinagrahovac@test.com",
                    NormalizedUserName = "NIKOLINAGRAHOVAC@TEST.COM",
                    Email = "nikolinagrahovac@test.com",
                    NormalizedEmail = "NIKOLINAGRAHOVAC@TEST.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEB3fErhGcr/yNJzrnpwkMN0eSAjxvNKxRhnu+pc/nKkNmCuBIFm9Hb6ow4nuD2EBrA==",
                    SecurityStamp = "BRPZ5G5VMPU533RX5YC3S62EYN5H22EL",
                    ConcurrencyStamp = "255fd95b-c771-4be6-852c-5634244b17ac",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new Account
                {
                    Id = 2,
                    UserName = "zoranpantos@test.com",
                    NormalizedUserName = "ZORANPANTOS@TEST.COM",
                    Email = "zoranpantos@test.com",
                    NormalizedEmail = "ZORANPANTOS@TEST.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEFhPDeoQp9iRyCWYDdk+1+BVvrNObJl/WW/vJBiezvzhe69X92GG4+z9XUzHS8qN3A==",
                    SecurityStamp = "7ZTQGH5Q7AX4CPI73DWSQS2OMESYR6KT",
                    ConcurrencyStamp = "80088041-9c29-474a-8668-3277462c4d51",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                });

            modelBuilder.Entity<UserSettings>()
                        .HasData(
                            new UserSettings { Id = 1, Bio = "Sample bio", EmailVisible = true, PhoneVisible = true, ProjectsVisible = true },
                            new UserSettings { Id = 2, Bio = "Another sample bio", EmailVisible = true, PhoneVisible = true, ProjectsVisible = true });

            modelBuilder.Entity<UserSocials>()
                        .HasData(
                            new UserSocials { UserSettingsId = 1, SocialId = 1, Value = "ngrahovac.com" },
                            new UserSocials { UserSettingsId = 1, SocialId = 2, Value = "www.linkedin.com/nikolina-grahovac" }
                        );

            modelBuilder.Entity<Student>()
                        .HasData(
                            new
                            {
                                Id = 1,
                                UserSettingsId = 1,
                                FacultyId = 1,
                                StudyProgramId = 1,
                                StudyProgramSpecializationId = 2,
                                StudyYear = 4
                            },
                            new
                            {
                                Id = 2,
                                UserSettingsId = 2,
                                FacultyId = 1,
                                StudyProgramId = 1,
                                StudyProgramSpecializationId = 2,
                                StudyYear = 3
                            }
                        );

            modelBuilder.Entity<StudentProfile>()
                        .HasData(
                            new { Id = 1, ProjectId = 1, FacultyId = 1, Description = "Studentski profil" });

            modelBuilder.Entity<FacultyMemberProfile>()
                        .HasData(
                            new { Id = 2, ProjectId = 1, FacultyId = 1, Description = "Profil nastavnog saradnika" });

            modelBuilder.Entity<Project>()
                        .HasData(
                            new
                            {
                                Id = 1,
                                AuthorId = 1,
                                Description = "Opis projekta",
                                Title = "Naslov projekta",
                                StudyFieldId = 1,
                                ProjectStatus = ProjectStatus.Active
                            });

            modelBuilder.Entity<ProjectApplication>()
                        .HasData(
                            new ProjectApplication
                            {
                                Id = 1,
                                ApplicantId = 2,
                                ProjectId = 1,
                                CollaboratorProfileId = 1,
                                ProjectApplicationStatus = ProjectApplicationStatus.OnHold
                            });
        }
    }
}
