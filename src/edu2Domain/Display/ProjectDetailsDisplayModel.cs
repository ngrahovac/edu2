using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu2Model.Display
{
    public class ProjectDetailsDisplayModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFullName { get; set; }
        public string Title { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public string Description { get; set; }
        public StudyField StudyField { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public ICollection<CollaboratorProfileDisplayModel> CollaboratorProfileDisplayModels { get; set; } = new HashSet<CollaboratorProfileDisplayModel>();

        public ProjectDetailsDisplayModel()
        {

        }

        public ProjectDetailsDisplayModel(Project project, User user)
        {
            Id = project.Id;
            AuthorId = project.AuthorId;
            AuthorFullName = user.FullName;
            Title = project.Title;
            ProjectStatus = project.ProjectStatus;
            Description = project.Description;
            StudyField = project.StudyField;
            StartDate = project.StartDate;
            EndDate = project.EndDate;
            Tags = project.Tags;

            foreach (var profile in project.CollaboratorProfiles)
            {
                var model = profile.GetDisplayModel();
                model.FromCollaboratorProfile(profile);
                CollaboratorProfileDisplayModels.Add(model);
            }
        }
    }
}
