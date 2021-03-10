namespace edu2Domain
{
    public abstract class CollaboratorProfile
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public string Description { get; set; }

        public CollaboratorProfile()
        {

        }

        public abstract bool IsRecommendedFor(User user);


    }
}
