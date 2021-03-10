using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Domain
{
    public class Social
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserSocials> UserSocials { get; set; }
        public ICollection<UserSettings> UserSettings { get; set; }
    }
}
