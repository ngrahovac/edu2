using System;
using System.Collections.Generic;

namespace edu2Domain
{
    public class StudyField : IEquatable<StudyField>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public StudyField()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StudyField);
        }

        public bool Equals(StudyField other)
        {
            return other != null &&
                   Name == other.Name &&
                   Description == other.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description);
        }
    }
}
