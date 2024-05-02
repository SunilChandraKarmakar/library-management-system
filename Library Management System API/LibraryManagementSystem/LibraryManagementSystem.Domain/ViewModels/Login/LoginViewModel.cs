using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.ViewModels.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, provied valid email address.")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provied password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}