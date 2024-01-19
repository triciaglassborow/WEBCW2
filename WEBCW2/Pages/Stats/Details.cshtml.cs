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
    public class DetailsModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public DetailsModel(WEBCW2.Data.LibraryContext context)
        {
            _context = context;
        }

      public Stat Stats { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stats == null)
            {
                return NotFound();
            }

            var stats = await _context.Stats.FirstOrDefaultAsync(m => m.ID == id);
            if (stats == null)
            {
                return NotFound();
            }
            else 
            {
                Stats = stats;
            }
            return Page();
        }
    }
}
