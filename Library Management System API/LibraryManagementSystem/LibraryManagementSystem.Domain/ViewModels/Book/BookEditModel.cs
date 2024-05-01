using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.ViewModels.Book
{
    public class BookEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied book title.")]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, provied book ISBN.")]
        [StringLength(50, MinimumLength = 2)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please, select author name.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please, provied book published date.")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Please, provied book available copies.")]
        [DataType(DataType.PhoneNumber)]
        public int AvailableCopies { get; set; }

        [Required(ErrorMessage = "Please, provied book total copies.")]
        [DataType(DataType.PhoneNumber)]
        public int TotalCopies { get; set; }
    }
}