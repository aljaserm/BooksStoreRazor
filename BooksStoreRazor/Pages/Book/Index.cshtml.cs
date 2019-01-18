using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStoreRazor.Model;

namespace BooksStoreRazor.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext context)
        {
            _db = context;
        }
        public IEnumerable<Books> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
