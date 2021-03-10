using System;
using System.Collections.Generic;

namespace edu2Domain
{
    public class StudyProgram : IEquatable<StudyProgram>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cycle { get; set; }
        public int DurationYears { get; set; }
        public ICollection<StudyProgramSpecialization> ProgramSpecializations { get; set; } = new HashSet<StudyProgramSpecialization>();

        public StudyProgram()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StudyProgram);
        }

        public bool Equals(StudyProgram other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
