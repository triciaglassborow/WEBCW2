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
    public class IndexModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public IndexModel(WEBCW2.Data.LibraryContext context)
        {
            _context = context;
        }

        public IList<Stat> Stat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stats != null)
            {
                Stat = await _context.Stats
                .Include(s => s.Book)
                .Include(s => s.User).ToListAsync();
            }
        }
    }
}
