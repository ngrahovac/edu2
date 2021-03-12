using System;

namespace edu2Model.Domain
{
    public class StudyProgramSpecialization : IEquatable<StudyProgramSpecialization>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudyProgramSpecialization()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StudyProgramSpecialization);
        }

        public bool Equals(StudyProgramSpecialization other)
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
