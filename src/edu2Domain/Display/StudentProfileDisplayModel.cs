using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Model.Display
{
    public class StudentProfileDisplayModel : CollaboratorProfileDisplayModel
    {
        public int? FacultyId { get; set; }
        public int? StudyProgramId { get; set; }
        public int? StudyProgramSpecializationId { get; set; }
        public int? StudyYear { get; set; }

        public override void FromCollaboratorProfile(CollaboratorProfile profile)
        {
            base.FromCollaboratorProfile(profile);

            if (profile is StudentProfile sp)
            {
                FacultyId = sp.FacultyId;
                StudyProgramId = sp.StudyProgramId;
                StudyProgramSpecializationId = sp.StudyProgramSpecializationId;
                StudyYear = sp.StudyYear;
            }
        }
    }
}
