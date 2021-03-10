using System.Collections.Generic;

namespace edu2Domain
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<StudyProgram> StudyPrograms { get; set; } = new HashSet<StudyProgram>();

        public Faculty()
        {

        }
    }
}
