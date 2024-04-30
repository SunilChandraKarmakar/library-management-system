using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();    
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied author name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, provied author bio.")]
        [StringLength (200, MinimumLength = 2)]
        public string Bio { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}