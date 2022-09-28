using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthorBookWebApp.DbData.DbModel
{
    public class AuthorDbModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string? SecondName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime DateOfBirth { get; set; }

        //Navigation prop
        public List<BookDbModel> Books { get; set; }
    }
}
