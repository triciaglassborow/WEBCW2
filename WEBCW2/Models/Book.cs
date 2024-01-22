using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBCW2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? BookTitle { get; set; }
        public string Genre { get; set; }
        public string Blurb { get; set; }
        public string Image { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }
        public ICollection<Stat> Stats { get; set; }
    }
}
