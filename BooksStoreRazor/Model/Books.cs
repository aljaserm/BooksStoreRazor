using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreRazor.Model
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Book Name")]
        public string BookName { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
