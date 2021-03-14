using edu2Model.Display;

namespace edu2Model.Domain
{
    public class StudentProfile : CollaboratorProfile
    {
        public int? FacultyId { get; set; }
        public int? StudyProgramId { get; set; }
        public int? StudyProgramSpecializationId { get; set; }
        public int? StudyYear { get; set; }

        public StudentProfile()
        {

        }

        public override bool IsRecommendedFor(User user)
        {
            if (user is Student s)
            {
                if (FacultyId.HasValue && FacultyId.Value != s.FacultyId ||
                    StudyProgramId.HasValue && StudyProgramId.Value != s.StudyProgramId ||
                    StudyProgramSpecializationId.HasValue && (!s.StudyProgramSpecializationId.HasValue || StudyProgramSpecializationId.Value != s.StudyProgramSpecializationId) ||
                    StudyYear.HasValue && StudyYear.Value != s.StudyYear)
                    return false;

                return true;
            }
            else
            {
                return false;
            }
        }

        public override CollaboratorProfileDisplayModel GetDisplayModel()
        {
            return new StudentProfileDisplayModel();
        }
    }
}
