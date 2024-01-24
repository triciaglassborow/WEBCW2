using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBCW2.Data;
using WEBCW2.Models;

namespace WEBCW2.Pages.Stats
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
            ViewData["BookID"] = new SelectList(_context.Books, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Stat Stat { get; set; } = default!;
        public String errorText1 { get; set; } = "";

        public String errorText2 { get; set; } = "";
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Boolean UserExistsChecker = false;
            Boolean BookExistsChecker = false;
            Boolean StatExistsChecker = false;
            if (id == null || _context.Stats == null)
            {
                return NotFound();
            }
            foreach (var item in _context.Users)
            {
                if (id == item.ID)
                {
                    UserExistsChecker = true;
                    Stat.UserID = id.Value;
                }
            }
            foreach (var item in _context.Books)
            {
                if (Stat.BookID == item.ID)
                {
                    BookExistsChecker = true;
                }
            }
            foreach (var item in _context.Stats)
            {
                if (Stat.BookID == item.BookID && id == item.UserID)
                {
                    StatExistsChecker = true;
                }
            }
            if (UserExistsChecker && BookExistsChecker && !StatExistsChecker)
            {
                _context.Stats.Add(Stat);
                await _context.SaveChangesAsync();
                errorText1 = "";
                errorText2 = "";
                return RedirectToPage("../Users/Index");
            }
            else
            {

                if (!UserExistsChecker)
                {
                    errorText1 = "User doesn't exist";
                }
                if (!BookExistsChecker)
                {
                    errorText2 = "Book doesn't exist";
                }
                if (StatExistsChecker)
                {
                    errorText1 = "Book already saved to user ";
                }
                return Page();
            }


        }
    }
}
