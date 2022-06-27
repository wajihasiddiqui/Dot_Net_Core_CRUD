using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dot_Net_Core_Practice.Models
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }

        [DisplayName("Book Name")]
        [Required(ErrorMessage = "Book Name Required")]
        public string  BookName { get; set; }

        [Required(ErrorMessage = "Book Type Required")]
        public string  BookType { get; set; }

        [Required(ErrorMessage = "Book Author Required")]
        public string BookAuthor { get; set; }

        [Required(ErrorMessage = "Book Publisher Required")]
        public string BookPublisher { get; set; }

        [Required(ErrorMessage = "DateTime Required")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
