namespace Silverlight.ApplicationCore.Dtos
{
    public class UserFilterDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string TextSearch { get; set; }
        public int PageIndex { get; set; }
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UrlImage { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
