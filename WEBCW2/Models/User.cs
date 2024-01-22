namespace WEBCW2.Models
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ICollection<Book> Books { get; set; }

        public ICollection<Stat> Stats { get; set; }
    }
}
