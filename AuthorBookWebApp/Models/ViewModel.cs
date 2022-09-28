namespace AuthorBookWebApp.Models
{
    public class ViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }
        public BookViewModel Book { get; set; }
    }
}
