using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBCW2.Data;
using WEBCW2.Models;

namespace WEBCW2.Pages.Stats
{
    public class DeleteModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public DeleteModel(WEBCW2.Data.LibraryContext context)
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

            var stat = await _context.Stats.FirstOrDefaultAsync(m => m.StatID == id);

            if (stat == null)
            {
                return NotFound();
            }
            else 
            {
                Stat = stat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stats == null)
            {
                return NotFound();
            }
            var stat = await _context.Stats.FindAsync(id);

            if (stat != null)
            {
                Stat = stat;
                _context.Stats.Remove(Stat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
