namespace LibraryManagementSystem.Domain.ViewModels.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
    }
}