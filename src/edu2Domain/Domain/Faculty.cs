using System;
using System.Collections.Generic;

namespace edu2Model.Domain
{
    public class Faculty : IEquatable<Faculty>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<StudyProgram> StudyPrograms { get; set; } = new HashSet<StudyProgram>();

        public Faculty()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Faculty);
        }

        public bool Equals(Faculty other)
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
