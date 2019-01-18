﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStoreRazor.Model;

namespace BooksStoreRazor.Pages.Book
{
    public class DeleteModel : PageModel
    {
        private readonly BooksStoreRazor.Model.AppDbContext _context;

        public DeleteModel(BooksStoreRazor.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Books Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);

            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books.FindAsync(id);

            if (Books != null)
            {
                _context.Books.Remove(Books);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
