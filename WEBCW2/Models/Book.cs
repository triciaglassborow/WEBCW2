namespace WEBCW2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Blurb { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
