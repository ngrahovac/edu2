using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Domain
{
    public class UserSocials : IEquatable<UserSocials>
    {
        public string Value { get; set; }

        // properties for establishing join table via EF core
        public int UserSettingsId { get; set; }
        public UserSettings UserSettings { get; set; }
        public int SocialId { get; set; }
        public Social Social { get; set; }


        public UserSocials()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserSocials);
        }

        public bool Equals(UserSocials other)
        {
            return other != null &&
                   Value == other.Value &&
                   UserSettingsId == other.UserSettingsId &&
                   SocialId == other.SocialId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, UserSettingsId, SocialId);
        }
    }
}
