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
                new User{LastName="Smtih",FirstName="Keisha"},
                new User{LastName="Brown",FirstName="Micheal"},
                new User{LastName="Gates",FirstName="Stacey"},
            };
            context.Users.AddRange(users);

            var author = new Author[]
            {
                new Author{LastName="Martin",FirstName="Kimmery"},
                new Author{LastName="Bonfigoli",FirstName="Kyri"},
                new Author{LastName="Tolken",FirstName="J.R.R."},
                new Author{LastName="Duguid",FirstName="Sarah"},
                new Author{LastName="Storace",FirstName="Patricia"},
                new Author{LastName="Crouch",FirstName="Stanlet"},
                new Author{LastName="Miller",FirstName="Sue"},
                new Author{LastName="Weir",FirstName="Andy"},
                new Author{LastName="Silverstein",FirstName="Ken"},
                new Author{LastName="Oyeyemi",FirstName="Helen"},
                new Author{LastName="Ultiskaya",FirstName="Ludmila"},
                new Author{LastName="Wyld",FirstName="Evie"},
            };
            context.Authors.AddRange(author);
            //Can be deleted if we don't want books hard coded into the database
            var books = new Book[]
            {
                new Book{BookTitle="The Queen Of Hearts",Author=author[0], Genre="Adventure",Blurb="Kimmery Martin reigns supreme in The Queen Of Hearts, a riveting tale that blends heart-pounding Thriller elements with an exploration of deep-seated secrets, friendships, and the complexities of the human heart.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/1.png"), User=users[0] },
                new Book{BookTitle="In The Woodshed",Author=author[1], Genre="Horror",Blurb="Explore the eerie secrets hidden In The Woodshed by Kyri Bonfigoli, a gripping horror novel that will leave you on the edge of your seat.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/2.png"), User=users[0] },
                new Book{BookTitle="The Hobbit",Author=author[2], Genre="Adventure",Blurb="Embark on an epic Adventure with J.R.R. Tolkien's timeless classic, The Hobbit, where a humble hobbit's journey unfolds in a world of magic and mythical creatures.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/3.png"), User=users[1] },
                new Book{BookTitle="Look At Me",Author=author[3], Genre="Comedy",Blurb="Sarah Duguid invites readers to Look At Me and laugh in this delightful comedy, where humor and self-discovery collide in a heartwarming exploration of identity.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/4.png"), User=users[0] },
                new Book{BookTitle="The Of Heaven",Author=author[4], Genre="Mystery",Blurb="Delve into the enigmatic pages of The Of Heaven by Patricia Storace, a mysterious tale that unravels the secrets of an otherworldly realm.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/5.png"), User=users[0] },
                new Book{BookTitle="Life Of Charlie Parker",Author=author[5], Genre="Thriller",Blurb="Stanlet Crouch crafts a heart-pounding Thriller in Charlie Parker, where suspense and danger intertwine, keeping readers guessing until the very end.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/6.png"), User=users[2] },
                new Book{BookTitle="The Arsonist",Author=author[6], Genre="Thriller",Blurb="Sue Miller sets the pages on fire with The Arsonist, a gripping Thriller that explores the dark and dangerous consequences of unchecked secrets.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/7.png"), User=users[2] },
                new Book{BookTitle="The Martian",Author=author[7], Genre="Fantasy",Blurb="Andy Weir's The Martian is a riveting Fantasy adventure where survival becomes an exhilarating journey on the harsh, alien landscape of Mars.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/8.png") , User=users[2]},
                new Book{BookTitle="The Secret World Of Oil",Author=author[8], Genre="Mystery",Blurb="Ken Silverstein unveils The Secret World Of Oil, a mysterious journey into the hidden realms of power, corruption, and intrigue in this captivating mystery.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/9.png"), User=users[0] },
                new Book{BookTitle="Boy, Snow, Bird",Author=author[9], Genre="Fantasy",Blurb="Helen Oyeyemi weaves a magical tapestry in Boy, Snow, Bird, a Fantasy novel that explores the complexities of family and identity in a world touched by enchantment.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/10.png"), User=users[1] },
                new Book{BookTitle="The Big Green Tent",Author=author[10], Genre="Comedy",Blurb="Ludmila Ultiskaya invites readers to laugh with The Big Green Tent, a delightful Comedy that explores friendship and camaraderie against the backdrop of Soviet Russia.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/11.png"), User=users[2] },
                new Book{BookTitle="All Birds Singing",Author=author[11], Genre="Comedy",Blurb="Evie Wyld's All Birds Singing is a comedic masterpiece, blending humor with a touch of the absurd as it explores the quirks and complexities of life.", Image=("https://raw.githubusercontent.com/triciaglassborow/WEBCW2/finalfuncdesign-testbranch/WEBCW2/Images/12.png"), User=users[0] },
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
