using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Model.Display
{
    public class UserDetailsDisplayModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual void FromUser(User user)
        {

        }
    }
}
