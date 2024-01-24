using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBCW2.Models;

namespace WEBCW2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEBCW2.Data.LibraryContext _context;

        public IndexModel(WEBCW2.Data.LibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public int count { get; set; } = 0;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.ToListAsync();
            }
        }
    }
}