using System;
using System.Collections.Generic;
using System.Linq;

namespace edu2Domain
{
    public class Project : IEquatable<Project>
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public string Description { get; set; }
        public StudyField StudyField { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<CollaboratorProfile> CollaboratorProfiles { get; set; } = new HashSet<CollaboratorProfile>();
        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

        public Project()
        {

        }

        public bool IsRecommendedFor(User user)
        {
            return CollaboratorProfiles.Any(profile => profile.IsRecommendedFor(user))
                || Tags.Any(projectTag => user.UserSettings.UserTags.Contains(projectTag));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Project);
        }

        public bool Equals(Project other)
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
