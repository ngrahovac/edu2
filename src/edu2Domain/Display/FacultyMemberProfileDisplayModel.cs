using edu2Model.Domain;
using edu2Shared.DisplayModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace edu2Model.Display
{
    public class FacultyMemberProfileDisplayModel : CollaboratorProfileDisplayModel
    {
        public StudyField StudyField { get; set; }

        public override void FromCollaboratorProfile(CollaboratorProfile profile)
        {
            base.FromCollaboratorProfile(profile);

            if (profile is FacultyMemberProfile fp)
            {
                StudyField = fp.StudyField;
            }
        }
    }
}
