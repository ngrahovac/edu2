using edu2Shared.DisplayModel;
using System;

namespace edu2Model.Domain
{
    public abstract class CollaboratorProfile : IEquatable<CollaboratorProfile>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public CollaboratorProfile()
        {

        }

        public abstract bool IsRecommendedFor(User user);

        public abstract CollaboratorProfileDisplayModel GetDisplayModel();

        public override bool Equals(object obj)
        {
            return Equals(obj as CollaboratorProfile);
        }

        public bool Equals(CollaboratorProfile other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
