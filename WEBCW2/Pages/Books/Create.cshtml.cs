using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBCW2.Data;
using WEBCW2.Models;

namespace WEBCW2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public CreateModel(WEBCW2.Data.LibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        public User Users { get; set; } = default!;
        public String errorText1 { get; set; } = "";
		public String errorText2 { get; set; } = "";
		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
        {
            Boolean duplicateChecker = false;
            Boolean userChecker = false;
            Boolean authorChecker = false;
            //Book existingBook = await Books.FirstOrDefault(
            //Book existingBook = await _context.Books.(
            //b => b.BookTitle == Book.BookTitle && b.AuthorName == Book.AuthorName);
            foreach (var item in _context.Books) 
            { 
                if (item.AuthorID== Book.Author.ID && item.BookTitle == Book.BookTitle) 
                {
                    duplicateChecker = true;
					errorText1 = "Book with this Author already exists";
				}
                
            }
            foreach (var item in _context.Users)
            {
                if (item.ID == Book.UserID)
                {
                    Book.User = item;
                    userChecker = true;

                }
                
            }
            foreach (var item in _context.Authors)
            {
                if (item.ID == Book.UserID)
                {
                    Book.Author = item;
                    authorChecker = true;

                }

            }
            /*if (!ModelState.IsValid || _context.Books == null || Book == null)
            {
                return Page();
            } */
            if (!duplicateChecker && userChecker && authorChecker)
            {
                errorText1 = "";
                errorText2 = "";
                _context.Books.Add(Book);

                await _context.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
            else if (!duplicateChecker)
            {
                errorText2 = "User and author doesn't exists";
                return Page();
            }
            else if (!userChecker) {
                errorText2 = "User doesn't exists";
                return Page();
            }
            else if (!authorChecker)
            {
                errorText2 = "Author doesn't exists";
                return Page();
            }
            else
            {

                return Page();
            }
        }
    }
}
