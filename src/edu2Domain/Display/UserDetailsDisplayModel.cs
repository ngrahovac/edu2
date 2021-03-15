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
        public string Bio { get; set; }
        public string PhotoLink { get; set; }
        public string CvLink { get; set; }

        // set from controller
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Tag> UserTags { get; set; }
        public ICollection<UserSocials> UserSocials { get; set; }

        public virtual void FromUser(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Bio = user.UserSettings.Bio;
            PhotoLink = user.UserSettings.PhotoLink;
            CvLink = user.UserSettings.CvLink;
            UserTags = user.UserSettings.UserTags;
            UserSocials = user.UserSettings.UserSocials;
        }
    }
}
