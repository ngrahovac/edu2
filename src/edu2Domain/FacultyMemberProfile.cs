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
            return user is FacultyMember;
            // TODO: check if parameters match
        }
    }
}
