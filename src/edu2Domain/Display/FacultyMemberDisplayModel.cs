using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Model.Display
{
    class FacultyMemberDisplayModel : UserDetailsDisplayModel
    {
        public int FacultyId { get; set; }
        public AcademicRank AcademicRank { get; set; }
        public StudyField StudyField { get; set; }

        public override void FromUser(User user)
        {
            base.FromUser(user);

            if (user is FacultyMember fm)
            {
                FacultyId = fm.FacultyId;
                AcademicRank = fm.AcademicRank;
                StudyField = fm.StudyField;
            }
        }
    }
}
