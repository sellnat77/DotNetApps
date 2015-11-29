using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVCBook.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }

        [Display(Name = "Author ID")]
        [Required]
        public int AuthorID { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Edition Number")]
        public int EditionNumber { get; set; }

        [Display(Name = "Copyright")]
        [Required]
        public string Copyright { get; set; }

        [Display(Name = "Authors First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Authors Last Name")]
        [Required]
        public string LastName { get; set; }
    }
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}