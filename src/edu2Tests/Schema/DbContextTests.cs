using edu2Domain;
using edu2WebAPI.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace edu2Tests.Schema
{
    public class DbContextTests
    {
        private readonly ITestOutputHelper output;
        private readonly IConfiguration configuration;

        public DbContextTests(ITestOutputHelper output)
        {
            this.output = output;

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

        [Fact]
        public void SerializationTests()
        {
            Project project = null;

            using (var dbContext = new Edu2DbContext(configuration))
            {
                project = dbContext.Projects.Include(p => p.CollaboratorProfiles).Where(p => p.Id == 1).Single();
            }

            var jsonString = JsonConvert.SerializeObject(project, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            output.WriteLine(jsonString);

            Project deserializedProject = JsonConvert.DeserializeObject<Project>(jsonString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            Assert.Equal(2, deserializedProject.CollaboratorProfiles.Count);

            Assert.True(deserializedProject.CollaboratorProfiles.ElementAt(0) is StudentProfile);
            Assert.True(deserializedProject.CollaboratorProfiles.ElementAt(1) is FacultyMemberProfile);

        }
    }
}
