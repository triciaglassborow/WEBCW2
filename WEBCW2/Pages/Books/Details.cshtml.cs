using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBCW2.Data;
using WEBCW2.Models;

namespace WEBCW2.Pages.Books
{
	public class DetailsModel : PageModel
	{
		private readonly WEBCW2.Data.LibraryContext _context;

		public DetailsModel(WEBCW2.Data.LibraryContext context)
		{
			_context = context;
		}

		public Book Book { get; set; } = default!;
		public Author Author { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Books == null)
			{
				return NotFound();
			}


			var book = await _context.Books
			.Include(s => s.User)
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.ID == id);

			foreach (var item in _context.Authors)
			{
				if (item.ID == book.AuthorID)
				{
					Author = item;
				}
			}
			if (book == null)
			{
				return NotFound();
			}
			else
			{
				Book = book;
			}
			return Page();
		}
	}
}
