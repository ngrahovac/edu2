using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace edu2Domain
{
    public abstract class CollaboratorProfile : IEquatable<CollaboratorProfile>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public CollaboratorProfile()
        {

        }

        public abstract bool IsRecommendedFor(User user);

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
