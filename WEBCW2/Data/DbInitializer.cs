using System.Diagnostics;
using WEBCW2.Models;

namespace WEBCW2.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            // Look for any students.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var books = new Book[]
            {
                new Book{BookTitle="Carson",Author="Alexander", Genre="Alexander",Blurb="Alexander", StartDate=DateTime.Parse("2019-09-01"),EndDate=DateTime.Parse("2019-09-01") },
                new Book{BookTitle="2",Author="2", Genre="2",Blurb="2", StartDate=DateTime.Parse("2019-09-01"),EndDate=DateTime.Parse("2019-09-01") },
                new Book{BookTitle="2",Author="2", Genre="2",Blurb="2", StartDate=DateTime.Parse("2019-09-01"),EndDate=DateTime.Parse("2019-09-01") },
            };

            context.Books.AddRange(books);
            context.SaveChanges();


            var users = new User[]
            {
                new User{Username="Username",LastName="LastName",FirstName="FirstName"},
                new User{Username="Username",LastName="LastName",FirstName="FirstName"},
                new User{Username="Username",LastName="LastName",FirstName="FirstName"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
