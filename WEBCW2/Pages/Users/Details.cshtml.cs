using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using WEBCW2.Data;
using WEBCW2.Models;

namespace WEBCW2.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public DetailsModel(WEBCW2.Data.LibraryContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;
        public List<Stat> Stats { get; set; } = new List<Stat>();
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Author> Author { get; set; } = new List<Author>();

        public TimeSpan? LongestTime { get; set; } = new TimeSpan(0, 0, 0, 0, 0);
        public TimeSpan? TotalTime { get; set; } = new TimeSpan(0, 0, 0, 0, 0);
        public TimeSpan? AverageTime { get; set; } = new TimeSpan(0, 0, 0, 0, 0);

        public int? ComedyCount { get; set; } = 0;
        public int? TragedyCount { get; set; } = 0;
        public int? AdventureCount { get; set; } = 0;
        public int? HorrorCount { get; set; } = 0;
        public int? FantasyCount { get; set; } = 0;
        public int? SciFiCount { get; set; } = 0;
        public int? MysteryCount { get; set; } = 0;
        public int? ThrillerCount { get; set; } = 0;
        public int? RomanceCount { get; set; } = 0;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int count = 0;
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            //Checks if User exists
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
                //Checks if stats table isnt empty
                if (_context.Stats != null)
                {
                    foreach (var item in _context.Stats)
                    {
                        count++;
                        //Checks if the saved ID in the item is the same as the user
                        if (item.UserID == id)
                        {
                            TotalTimeCalculator(item);
                            LongestTimeCalculator(item);


                            foreach (var item2 in _context.Books)
                            {
                                //Used to add books to a book list
                                if (item2.ID == item.BookID)
                                {

                                    Books.Add(item2);
                                }
                                foreach (var item3 in _context.Authors)
                                {
                                    if (item3.ID == item2.AuthorID)
                                    {
                                        //Used to add author to a author list
                                        Author.Add(item3);
                                    }
                                }
                            }

                            AddItem(item, id);
                        }
                    }
                    AverageTime = TotalTime / count;
                }
                else
                {
                    return Page();
                }
            }
            //Checks each book the user has added and finds its genre
            foreach (var item in Books)
            {
                foreach (var user2 in _context.Users)
                {
                    if (user2.ID == id)
                    {
                        GenreChecker(item);
                    }
                }
            }
            return Page();
        }

        //Finds the Longest time spent reading
        private void LongestTimeCalculator(Stat item)
        {
            if (LongestTime == null)
            {
                LongestTime = item.EndDate - item.StartDate;

            }
            else
            {
                if (LongestTime < item.EndDate - item.StartDate)
                {
                    LongestTime = item.EndDate - item.StartDate;
                }
            }
        }

        //Calculates the total time spent reading
        private void TotalTimeCalculator(Stat item)
        {
            if (TotalTime == null)
            {
                TotalTime = item.EndDate - item.StartDate;

            }
            else
            {
                TotalTime = TotalTime + (item.EndDate - item.StartDate);
            }
        }

        //Adds item to array of books read if IDs match
        private void AddItem(Stat item, int? id)
        {
            if (item.UserID == id)
            {
                Console.WriteLine("a");
                Stats.Add(item);

            }
        }

        //Checks the genre of each book read and counts them
        private void GenreChecker(Book item)
        {

            if (item.Genre.ToLower().Contains("comedy"))
            {
                ComedyCount++;
            }
            if (item.Genre.ToLower().Contains("tragedy"))
            {
                TragedyCount++;
            }
            if (item.Genre.ToLower().Contains("adventure"))
            {
                AdventureCount++;
            }
            if (item.Genre.ToLower().Contains("horror"))
            {
                HorrorCount++;
            }
            if (item.Genre.ToLower().Contains("fantasy"))
            {
                FantasyCount++;
            }
            if (item.Genre.ToLower().Contains("scifi") || item.Genre.ToLower().Contains("sci-fi"))
            {
                SciFiCount++;
            }
            if (item.Genre.ToLower().Contains("mystery"))
            {
                MysteryCount++;
            }
            if (item.Genre.ToLower().Contains("thriller"))
            {
                ThrillerCount++;
            }
            if (item.Genre.ToLower().Contains("romance"))
            {
                RomanceCount++;
            }
        }
    }
}


