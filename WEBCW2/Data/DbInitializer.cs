using System.Diagnostics;
using WEBCW2.Models;

namespace WEBCW2.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
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
            context.Users.AddRange(users);

            var author = new Author[]
            {
                new Author{LastName="TestLastName",FirstName="TestFirstName"},
                new Author{LastName="Smith",FirstName="John"},
                new Author{LastName="Name",FirstName="Len"},
            };
            context.Authors.AddRange(author);
            //Can be deleted if we don't want books hard coded into the database
            var books = new Book[]
            {
                new Book{BookTitle="Carson",Author=author[0], Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="2",Author=author[1], Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="Carson",Author=author[2], Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[1] },
                new Book{BookTitle="2",Author=author[1], Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="Carson",Author=author[1], Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="Carson",Author=author[0], Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[2] },
                new Book{BookTitle="Carson",Author=author[0], Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[2] },
                new Book{BookTitle="Carson",Author=author[2], Genre="Comedy",Blurb="My Life", Image=("https://www.w3schools.com/images/w3schools_green.jpg") , User=users[2]},
                new Book{BookTitle="2",Author=author[2], Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
                new Book{BookTitle="2",Author=author[2], Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[1] },
                new Book{BookTitle="2",Author=author[1], Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[2] },
                new Book{BookTitle="2",Author=author[1], Genre="2",Blurb="2", Image=("https://www.w3schools.com/images/w3schools_green.jpg"), User=users[0] },
            };
            context.Books.AddRange(books);


            


            var stats = new Stat[]
            {
                new Stat{User=users[0],Book=books[1],StartDate=DateTime.Parse("2019-09-01"),EndDate=DateTime.Parse("2019-09-02"),},
                new Stat{User=users[0],Book=books[2],StartDate=DateTime.Parse("2019-09-02"),EndDate=DateTime.Parse("2019-09-03"),},
                new Stat{User=users[0],Book=books[3],StartDate=DateTime.Parse("2019-09-03"),EndDate=DateTime.Parse("2019-09-04"),},
            };

            context.Stats.AddRange(stats);

            context.SaveChanges();
        }
    }
}
