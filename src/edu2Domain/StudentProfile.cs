namespace edu2Domain
{
    public class StudentProfile : CollaboratorProfile
    {
        public int? FacultyId { get; set; }
        public int? StudyProgramId { get; set; }
        public int? StudyProgramSpecializationId { get; set; }
        public int? StudyCycle { get; set; }
        public int? StudyYear { get; set; }

        public StudentProfile()
        {

        }

        public override bool IsRecommendedFor(User user)
        {
            return user is Student;
            // TODO: check if parameters match
        }
    }
}
