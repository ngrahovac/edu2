using edu2Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using Xunit;

namespace edu2Tests.Domain
{
    public class CollaboratorProfileTests
    {
        [Theory]
        [MemberData(nameof(IsRecommendedForTestParams))]
        public void IsRecommendedForTest(StudentProfile profile, Student student, bool expected)
        {
            Assert.True(expected == profile.IsRecommendedFor(student));
        }

        public static IEnumerable<object[]> IsRecommendedForTestParams
            => new List<object[]>
            {
                new object[]
                    {
                       new StudentProfile { FacultyId = 1},
                       new Student {FacultyId = 2 },
                       false
                    },
                new object[]
                    {
                       new StudentProfile { FacultyId = 1, StudyProgramId = 1},
                       new Student {FacultyId = 1, StudyProgramId = 2},
                       false
                    },
                new object[]
                    {
                       new StudentProfile { FacultyId = 1, StudyProgramId = 1, StudyProgramSpecializationId = 1},
                       new Student {FacultyId = 1, StudyProgramId = 1, StudyProgramSpecializationId = 2},
                       false
                    },
                new object[]
                    {
                       new StudentProfile { FacultyId = 1, StudyProgramId = 1, StudyProgramSpecializationId = 1, StudyYear = 1},
                       new Student {FacultyId = 1, StudyProgramId = 1, StudyProgramSpecializationId = 1, StudyYear = 2},
                       false
                    },
                new object[]
                    {
                       new StudentProfile { FacultyId = 1, StudyProgramId = 1, StudyProgramSpecializationId = 1, StudyYear = 1},
                       new Student {FacultyId = 1, StudyProgramId = 1, StudyProgramSpecializationId = 1, StudyYear = 1},
                       true
                    }

            };

    }
}
