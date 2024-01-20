namespace WEBCW2.Models
{
    public class Stat
    {
        public int StatID { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public int BookID { get; set; }
        public Book? Book { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
