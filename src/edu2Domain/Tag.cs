using System.Collections.Generic;
using System.Threading.Tasks;

namespace edu2Domain
{
    public class Tag
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties for the purpose of establishing m:n relationship via EF Core only. 
        public ICollection<UserSettings> UserSettings { get; set; }

        public ICollection<Project> Projects { get; set; }

        public Tag()
        {

        }
    }
}
