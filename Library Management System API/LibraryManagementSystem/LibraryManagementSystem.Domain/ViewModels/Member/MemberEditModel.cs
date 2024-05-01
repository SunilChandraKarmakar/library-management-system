using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.ViewModels.Member
{
    public class MemberEditModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please, provied member first name.")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, provied member last name.")]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, provied member valid email address.")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provied member valid phone number.")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please, provied member password.")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, provied member registration date.")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please, select member type.")]
        public int MemberTypeId { get; set; }
    }
}