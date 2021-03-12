using edu2Model.Display;
using edu2Shared.DisplayModel;

namespace edu2Model.Domain
{
    public class FacultyMemberProfile : CollaboratorProfile
    {
        public StudyField StudyField { get; set; }

        public FacultyMemberProfile()
        {

        }

        public override bool IsRecommendedFor(User user)
        {
            if (user is FacultyMember fm)
            {
                if (StudyField != null && StudyField != fm.StudyField)
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
            return new FacultyMemberProfileDisplayModel();
        }
    }
}
