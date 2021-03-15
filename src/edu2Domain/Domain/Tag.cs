using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace edu2Model.Domain
{
    public class Tag : IEquatable<Tag>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties for the purpose of establishing m:n relationship via EF Core only. 

        [JsonIgnore]
        public ICollection<UserSettings> UserSettings { get; set; }

        [JsonIgnore]
        public ICollection<Project> Projects { get; set; }

        public Tag()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tag);
        }

        public bool Equals(Tag other)
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
