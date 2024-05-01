using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.ViewModels.Author
{
    public class AuthorEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied author name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, provied author bio.")]
        [StringLength(200, MinimumLength = 2)]
        public string Bio { get; set; }
    }
}