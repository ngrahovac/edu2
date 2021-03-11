namespace edu2Domain
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
    }
}
