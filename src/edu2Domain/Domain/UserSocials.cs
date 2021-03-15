﻿using Newtonsoft.Json;
using System;

namespace edu2Model.Domain
{
    public class UserSocials : IEquatable<UserSocials>
    {
        public string Value { get; set; }

        // properties for establishing join table via EF core
        [JsonIgnore]
        public int UserSettingsId { get; set; }

        [JsonIgnore]
        public UserSettings UserSettings { get; set; }

        [JsonIgnore]
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
