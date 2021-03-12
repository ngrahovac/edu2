using System;
using System.Collections.Generic;

namespace edu2Model.Domain
{
    public class Social : IEquatable<Social>
    {
        public string Name { get; set; }
        public ICollection<UserSocials> UserSocials { get; set; }
        public ICollection<UserSettings> UserSettings { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Social);
        }

        public bool Equals(Social other)
        {
            return other != null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
