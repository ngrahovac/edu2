using System;

namespace edu2Model.Domain
{
    public class ProjectApplication : IEquatable<ProjectApplication>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CollaboratorProfileId { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantComment { get; set; }
        public string AuthorComment { get; set; }
        public ProjectApplicationStatus ProjectApplicationStatus { get; set; }

        public ProjectApplication()
        {

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectApplication);
        }

        public bool Equals(ProjectApplication other)
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
