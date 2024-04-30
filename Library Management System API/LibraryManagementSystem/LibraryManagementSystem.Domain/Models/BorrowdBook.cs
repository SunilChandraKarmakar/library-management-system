using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Models
{
    public class BorrowdBook
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, select member name.")]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Please, select book name.")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please, provied borrow date.")]
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "Please, provied return date.")]
        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Please, provied status.")]
        public BorrowBookStatus Status { get; set; }

        public Member Member { get; set; }  
        public Book Book { get; set; }
    }
}