namespace LibraryManagementSystem.Domain.ViewModels.Member
{
    public class MemberViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string MemberTypeName { get; set; }
        public int MemberTypeId { get; set; }
        public string Token { get; set; }
    }
}