using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStoreRazor.Model;

namespace BooksStoreRazor.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        public CreateModel(AppDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Books Books { get; set; }
        [TempData]
        public string msg { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Books);
            await _db.SaveChangesAsync();
            msg = "Added";
            return RedirectToPage("Index");
        }
    }
}