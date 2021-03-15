using edu2Model.Display;

namespace edu2Model.Domain
{
    public class FacultyMember : User
    {
        public int FacultyId { get; set; }
        public AcademicRank AcademicRank { get; set; }
        public StudyField StudyField { get; set; }

        public FacultyMember()
        {

        }
        public override UserDetailsDisplayModel GetDisplayModel()
        {
            return new FacultyMemberDisplayModel();
        }
    }
}
