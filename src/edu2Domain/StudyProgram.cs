using System.Collections.Generic;

namespace edu2Domain
{
    public class StudyProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cycle { get; set; }
        public int DurationYears { get; set; }
        public ICollection<StudyProgramSpecialization> ProgramSpecializations { get; set; } = new HashSet<StudyProgramSpecialization>();

        public StudyProgram()
        {

        }
    }
}
