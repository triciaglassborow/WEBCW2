using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBCW2.Data;
using WEBCW2.Models;

namespace WEBCW2.Pages.Stats
{
    public class EditModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public EditModel(WEBCW2.Data.LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stat Stat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stats == null)
            {
                return NotFound();
            }

            var stat =  await _context.Stats.FirstOrDefaultAsync(m => m.StatID == id);
            if (stat == null)
            {
                return NotFound();
            }
            Stat = stat;
           ViewData["BookID"] = new SelectList(_context.Books, "ID", "ID");
           ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatExists(Stat.StatID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StatExists(int id)
        {
          return (_context.Stats?.Any(e => e.StatID == id)).GetValueOrDefault();
        }
    }
}
