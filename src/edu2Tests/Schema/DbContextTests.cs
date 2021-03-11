using edu2Domain;
using edu2WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace edu2Tests.Schema
{
    public class DbContextTests
    {
        private readonly IConfiguration configuration;
        public DbContextTests()
        {
            configuration = new ConfigurationBuilder().AddUserSecrets(typeof(Edu2DbContext).Assembly).Build();

            using (var dbContext = new Edu2DbContext(configuration))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }
        }

        [Fact]
        public void DbContextReadTests()
        {
            using (var dbContext = new Edu2DbContext(configuration))
            {
                Assert.Equal(4, dbContext.Tags.Count());

                var etf = dbContext.Faculties.Find(1);
                Assert.Equal(1, etf.Id);
                Assert.Equal(0, etf.StudyPrograms.Count);

                etf = dbContext.Faculties.Include(f => f.StudyPrograms).ThenInclude(sp => sp.ProgramSpecializations).Where(f => f.Id == 1).Single();
                Assert.Equal(8, etf.StudyPrograms.Count);

                var settings = dbContext.Users.Include(u => u.UserSettings).ThenInclude(s => s.UserSocials).Where(u => u.Id == 1).Single().UserSettings;
                Assert.Equal("Sample bio", settings.Bio);
                Assert.Equal(2, settings.UserSocials.Count);

                var project = dbContext.Projects.Include(p => p.CollaboratorProfiles).Include(p => p.Tags).Where(p => p.Id == 1).Single();
                Assert.Equal(2, project.CollaboratorProfiles.Count);
                var profile = project.CollaboratorProfiles.First();
                Assert.Equal(project, profile.Project);
            }
        }

        [Fact]
        public void DbContextCreateTests()
        {
            var profile1 = new StudentProfile { Description = "", FacultyId = 2 };
        }

        [Fact]
        public void DbContextUpdateTests()
        {

        }

        [Fact]
        public void DbContextDeleteTests()
        {

        }
    }
}
