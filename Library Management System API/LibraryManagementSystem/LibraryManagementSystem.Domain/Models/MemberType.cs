using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Models
{
    public class MemberType
    {
        public MemberType()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied member type name.")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}