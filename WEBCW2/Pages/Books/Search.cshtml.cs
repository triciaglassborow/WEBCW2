using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WEBCW2.Data;
using WEBCW2.Models;
using System.Configuration;

namespace WEBCW2.Pages.Books
{
    public class SearchModel : PageModel
    {
        private readonly LibraryContext _context;
        private readonly ILogger<SearchModel> _logger;
        private readonly IConfiguration Configuration;

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Book> Books { get; set; }
        public SearchModel(LibraryContext context, ILogger<SearchModel> logger, IConfiguration _Configuration)
        {
            _context = context;
            _logger = logger;
            Configuration = _Configuration;
        }



        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Book> books = from s in _context.Books
                                     select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookTitle.Contains(searchString)
                                      || s.Author.Contains(searchString)
                                      || s.Genre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(s => s.BookTitle);
                    break;
                case "Date":
                    books = books.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    books = books.OrderBy(s => s.Author);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 9);
            Books = await PaginatedList<Book>.CreateAsync(
                books.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}