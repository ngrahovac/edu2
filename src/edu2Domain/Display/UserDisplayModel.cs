using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Model.Display
{
    public class UserDisplayModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public UserDisplayModel(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
        }
    }
}
