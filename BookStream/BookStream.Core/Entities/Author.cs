namespace BookStream.Core.Entities
{
    public class Author : BaseEntity
    {
        protected Author()
        {

        }

        public Author(string name,
                      DateTime birthDate,
                      DateTime? deathDate,
                      bool active) : base()
        {
            Name = name;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Active = active;
            Books = [];
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime? DeathDate { get; private set; }
        public bool Active { get; private set; }
        public List<Book> Books { get; private set; }
    }
}
