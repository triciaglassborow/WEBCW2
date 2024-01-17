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



            //Can be deleted if we don't want books hard coded into the database
            var books = new Book[]
            {
                new Book{BookTitle="Carson",Author="Alexander", Genre="Alexander",Blurb="Alexander", StartDate=DateTime.Parse("2019-09-01"),EndDate=DateTime.Parse("2019-09-01"), Image=("https://www.w3schools.com/images/w3schools_green.jpg") },
                new Book{BookTitle="2",Author="2", Genre="2",Blurb="2", StartDate=DateTime.Parse("2019-09-01"),EndDate=DateTime.Parse("2019-09-01"), Image=("https://www.w3schools.com/images/w3schools_green.jpg") },
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

            var authors = new Author[]
            {
                new Author{LastName="LastName",FirstName="FirstName"},
                new Author{LastName="LastName",FirstName="FirstName"},
                new Author{LastName="LastName",FirstName="FirstName"},
            };

            context.Author.AddRange(authors);
            context.SaveChanges();
            
        }
    }
}
