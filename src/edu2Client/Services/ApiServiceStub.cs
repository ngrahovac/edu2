using edu2Model.Display;
using edu2Model.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace edu2Client.Services
{
    public class ApiServiceStub : IApiService
    {
        public Task<T> GetAsync<T>(string url)
        {
            var jsonString = new ServerStub().ApiCall(url);
            var result = JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return Task.FromResult<T>(result);
        }
    }

    public class ServerStub
    {
        private static List<Project> projects;
        private static List<Tag> tags;
        private static List<StudyField> fields;
        private static List<Faculty> faculties;
        private static List<User> users;
        private static List<Social> socials;

        static ServerStub()
        {
            SeedData();
        }

        public string ApiCall(string url)
        {
            object obj = null;

            if (url.StartsWith("projects/"))
            {
                obj = new ProjectDetailsDisplayModel(projects.ElementAt(0), users.ElementAt(0));
            }
            else if (url.StartsWith("faculties"))
            {
                obj = faculties;
            }

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }

        private static void SeedData()
        {
            SeedValueObjects();
            SeedFaculties();
            SeedUsers();
            SeedProjects();
        }

        private static void SeedUsers()
        {
            var settings = new UserSettings
            {
                Id = 1,
                Bio = "Primjer biografije",
                EmailVisible = true,
                UserTags = tags,
                UserSocials = new List<UserSocials>()
                {
                    new UserSocials
                    {
                        UserSettingsId = 1,
                        Social = socials.ElementAt(0),
                        Value = "www.test.com"
                    },

                    new UserSocials
                    {
                        UserSettingsId = 1,
                        Social=socials.ElementAt(1),
                        Value = "linkedin.com"
                    }
                }
            };

            users = new List<User>()
            {
                new Student()
                {
                     Id = 1,
                     FirstName = "Jane",
                     LastName = "Doe",
                     FacultyId = 1,
                     StudyProgramId = 1,
                     StudyProgramSpecializationId = 1,
                     StudyYear = 4,
                     UserSettings = settings
                }
            };
        }

        private static void SeedFaculties()
        {
            faculties = new List<Faculty>()
            {
                new Faculty
                {
                    Id = 1,
                    Name = "Elektrotehnički fakultet",
                    Address = "Patre 5, 71 000 Banja Luka",
                    StudyPrograms = new List<StudyProgram>()
                    {
                        new StudyProgram
                        {
                            Id = 1,
                            Name = "Računarstvo i informatika",
                            Cycle = 1,
                            DurationYears = 4,
                            ProgramSpecializations = new List<StudyProgramSpecialization>()
                            {
                                new StudyProgramSpecialization
                                {
                                    Id=1,
                                    Name="Softversko inženjerstvo"
                                },

                                new StudyProgramSpecialization
                                {
                                    Id=2,
                                    Name="Računarsko inženjerstvo"
                                }
                            }
                        }
                    }
                }
            };
        }

        private static void SeedValueObjects()
        {
            tags = new List<Tag>()
            {
                new Tag
                {
                     Name="web",
                     Description="opis web taga"
                },

                new Tag
                {
                    Name="desktop",
                    Description ="opis desktop taga"
                }
            };

            fields = new List<StudyField>()
            {
                new StudyField
                {
                     Name ="Računarske nauke",
                     Description = ""
                },

                new StudyField
                {
                    Name="Elektronika",
                    Description = ""
                }
            };

            socials = new List<Social>()
            {
                new Social
                {
                     Name = "Website"
                },

                new Social
                {
                    Name = "Linkedin"
                }
            };
        }

        private static void SeedProjects()
        {
            var collaboratorProfiles = new List<CollaboratorProfile>()
            {
                new StudentProfile
                {
                    Id = 1,
                    Description = "Opis aktivnosti 1",
                    FacultyId = 1
                },

                new StudentProfile
                {
                    Id = 2,
                    Description = "Opis aktivnosti 2",
                    FacultyId = 1,
                    StudyProgramId = 1,
                    StudyProgramSpecializationId = 1
                },

                new FacultyMemberProfile
                {
                    Id = 3,
                    Description = "Opis aktivnosti 3",
                    StudyField = fields.ElementAt(0)
                }
            };

            projects = new List<Project>()
            {
                new Project
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Test projekat",
                    Description = "Test opis",
                    ProjectStatus = ProjectStatus.Active,
                    EndDate = new DateTime(2021, 10,10),
                    StudyField = fields.ElementAt(0),
                    Tags = tags,
                    CollaboratorProfiles = collaboratorProfiles
                }
            };
        }
    }
}
