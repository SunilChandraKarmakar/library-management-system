using LibraryManagementSystem.Domain.Models;

namespace LibraryManagementSystem.Domain.ViewModels.BorrowdBook
{
    public class BorrowdBookViewModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string BookName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public BorrowBookStatus Status { get; set; }
    }
}