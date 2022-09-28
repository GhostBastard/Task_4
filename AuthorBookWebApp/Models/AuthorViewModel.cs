using System.ComponentModel.DataAnnotations;

namespace AuthorBookWebApp.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        public string? SecondName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public List<BookViewModel> Books { get; set; }
    }
}
