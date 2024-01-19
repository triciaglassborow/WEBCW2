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


            var users = new User[]
            {
                new User{Username="Username",LastName="Name",FirstName="Ben"},
                new User{Username="Username",LastName="Name2",FirstName="Ken"},
                new User{Username="Username",LastName="Name3",FirstName="Ten"},
            };
            //Can be deleted if we don't want books hard coded into the database
            var books = new Book[]
            {
                new Book{BookTitle="Carson",AuthorName="Alexander", Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="2",AuthorName="2", Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="Carson",AuthorName="Alexander", Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[1] },
                new Book{BookTitle="2",AuthorName="2", Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="Carson",AuthorName="Alexander", Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="Carson",AuthorName="Alexander", Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[2] },
                new Book{BookTitle="Carson",AuthorName="Alexander", Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[2] },
                new Book{BookTitle="Carson",AuthorName="Alexander", Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg") , User=users[2]},
                new Book{BookTitle="2",AuthorName="2", Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="2",AuthorName="2", Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[1] },
                new Book{BookTitle="2",AuthorName="2", Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[2] },
                new Book{BookTitle="2",AuthorName="2", Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
            };
            context.Books.AddRange(books);


            context.Users.AddRange(users);


            var stats = new Stats[]
            {
                new Stats{User=users[0],Book=books[1],FirstName="FirstName"},
                new Stats{User=users[0],Book=books[2],FirstName="FirstName"},
                new Stats{User=users[0],Book=books[3],FirstName="FirstName"},
            };

            context.Stats.AddRange(stats);






            context.SaveChanges();
        }
    }
}
