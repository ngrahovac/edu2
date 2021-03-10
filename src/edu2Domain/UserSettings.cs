using System;
using System.Collections.Generic;

namespace edu2Domain
{
    public class UserSettings : IEquatable<UserSettings>
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string PhotoLink { get; set; }
        public string CvLink { get; set; }
        public bool EmailVisible { get; set; } = false;
        public bool PhoneVisible { get; set; } = false;
        public bool ProjectsVisible { get; set; } = false;
        public ICollection<Tag> UserTags { get; set; }
        public ICollection<UserSocials> UserSocials { get; set; }
        public ICollection<Social> Socials { get; set; }

        public UserSettings()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserSettings);
        }

        public bool Equals(UserSettings other)
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
