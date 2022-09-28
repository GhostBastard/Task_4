using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthorBookWebApp.DbData.DbModel
{
    public class BookDbModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int NumberOfPages { get; set; }

        public string Genre { get; set; }

        //Navigation props
        public AuthorDbModel authorDbModel { get; set; }
    }
}
