using System.ComponentModel.DataAnnotations;

namespace AuthorBookWebApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        public string Genre { get; set; }

        public AuthorViewModel authorViewModel { get; set; }
    }
}
