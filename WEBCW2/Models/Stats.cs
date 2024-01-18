namespace WEBCW2.Models
{
    public class Stats
    {
        public int StatsId { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int BookID { get; set; }
        public User Book { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
