using edu2Model.Display;
using System;

namespace edu2Model.Domain
{
    public abstract class User : IEquatable<User>
    {
        public int Id { get; set; } // same as Account.Id
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public UserSettings UserSettings { get; set; }

        public User()
        {

        }

        public abstract UserDetailsDisplayModel GetDisplayModel();

        public bool CanApplyTo(Project project)
        {
            return !IsAuthor(project)
                   && project.ProjectStatus == ProjectStatus.Active;
        }

        public bool IsAuthor(Project project)
        {
            return project.AuthorId == Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
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