using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStoreRazor.Model;

namespace BooksStoreRazor.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Books Book { get; set; }
        [TempData]
        public string msg { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Books.FindAsync(Book.Id);
                BookFromDb.BookName = Book.BookName;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();
                msg = "Updated";
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }

}
