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
        public Stat Stats { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Stats == null || Stats == null)
            {
                return Page();
            }

            _context.Stats.Add(Stats);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
