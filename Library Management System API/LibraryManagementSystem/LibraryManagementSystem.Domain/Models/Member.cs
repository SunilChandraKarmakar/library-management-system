using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Models
{
    public class Member
    {
        public Member()
        {
            BorrowdBooks = new HashSet<BorrowdBook>();  
        }

        public int Id { get; set; }

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
        [StringLength(20, MinimumLength = 2)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please, provied member registration date.")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public ICollection<BorrowdBook> BorrowdBooks { get; set; }
    }
}