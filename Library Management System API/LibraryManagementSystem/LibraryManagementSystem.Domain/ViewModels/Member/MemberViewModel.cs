namespace LibraryManagementSystem.Domain.ViewModels.Member
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string MemberTypeName { get; set; }
    }
}