using edu2Model.Display;

namespace edu2Model.Domain
{
    public class Student : User
    {
        public int FacultyId { get; set; }
        public int StudyProgramId { get; set; }
        public int? StudyProgramSpecializationId { get; set; }
        public int StudyYear { get; set; }

        public Student()
        {

        }

        public override UserDetailsDisplayModel GetDisplayModel()
        {
            return new StudentDisplayModel();
        }
    }
}
