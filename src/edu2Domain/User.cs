using System;
using System.Collections.Generic;

namespace edu2Domain
{
    public abstract class User
    {
        public int Id { get; set; } // same as Account.Id
        public UserSettings UserSettings { get; set; }

        public User()
        {

        }

        public bool CanApplyTo(CollaboratorProfile collaboratorProfile)
        {
            return !IsAuthor(collaboratorProfile.Project)
                   && collaboratorProfile.Project.ProjectStatus == ProjectStatus.Active;
        }

        public bool IsAuthor(Project project)
        {
            return project.AuthorId == Id;
        }
    }
}