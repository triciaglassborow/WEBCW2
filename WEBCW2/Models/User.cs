using System.ComponentModel.DataAnnotations;

namespace WEBCW2.Models
{
    public enum Star
    {
        A, B, C, D, F
    }
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        [DisplayFormat(NullDisplayText = "No Reviews")]
        public Star? Star { get; set; }
        public Book Book { get; set; }
    }
}
