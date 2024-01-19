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


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Boolean duplicateChecker = false;
            Boolean userChecker = false;
            //Book existingBook = await Books.FirstOrDefault(
            //Book existingBook = await _context.Books.(
            //b => b.BookTitle == Book.BookTitle && b.AuthorName == Book.AuthorName);
            foreach (var item in _context.Books) 
            { 
                if (item.AuthorName== Book.AuthorName) 
                {
                    duplicateChecker = true;
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
            /*if (!ModelState.IsValid || _context.Books == null || Book == null)
            {
                return Page();
            } */
            if (!duplicateChecker && userChecker)
            {
                _context.Books.Add(Book);
                await _context.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
            else {
                return Page();
            }
        }
    }
}
