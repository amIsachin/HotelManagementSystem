namespace Domain.Common.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public int HotelId { get; set; }
        public DateTime Created { get; set; }
    }
}
