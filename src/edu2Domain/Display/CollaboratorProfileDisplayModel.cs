using edu2Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu2Shared.DisplayModel
{
    public abstract class CollaboratorProfileDisplayModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual void FromCollaboratorProfile(CollaboratorProfile profile)
        {
            Id = profile.Id;
            Description = profile.Description;
        }
    }
}
