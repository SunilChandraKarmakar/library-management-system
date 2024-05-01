using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Models
{
    public class Member : IdentityUser
    {
        public Member()
        {
            BorrowdBooks = new HashSet<BorrowdBook>();  
        }

        [Required(ErrorMessage = "Please, provied member first name.")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, provied member last name.")]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, provied member registration date.")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please, select member type.")]
        public int MemberTypeId { get; set; }

        public MemberType MemberType { get; set; }
        public ICollection<BorrowdBook> BorrowdBooks { get; set; }
    }
}