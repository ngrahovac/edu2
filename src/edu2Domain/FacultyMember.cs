namespace edu2Domain
{
    public class FacultyMember : User
    {
        public int FacultyId { get; set; }
        public AcademicRank AcademicRank { get; set; }
        public StudyField StudyField { get; set; }

        public FacultyMember()
        {

        }
    }
}
