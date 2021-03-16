using edu2Model.Domain;

namespace edu2Model.Display
{
    public class ProjectDisplayModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        public ProjectDisplayModel()
        {

        }

        public ProjectDisplayModel(Project project)
        {
            Title = project.Title;
            Description = project.Description;
        }
    }
}
