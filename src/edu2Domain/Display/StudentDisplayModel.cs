using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Model.Display
{
    public class StudentDisplayModel : UserDetailsDisplayModel
    {
        public int FacultyId { get; set; }
        public int StudyProgramId { get; set; }
        public int? StudyProgramSpecializationId { get; set; }
        public int StudyYear { get; set; }

        public override void FromUser(User user)
        {
            base.FromUser(user);

            if (user is Student s)
            {
                FacultyId = s.FacultyId;
                StudyProgramId = s.StudyProgramId;
                StudyProgramSpecializationId = s.StudyProgramSpecializationId;
                StudyYear = s.StudyYear;
            }
        }
    }
}
