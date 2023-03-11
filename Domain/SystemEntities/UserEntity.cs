using Domain.BaseEntities;

namespace Domain.SystemEntities
{
    public class UserEntity : AuditableBaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public virtual HotelEntity HotelEntity { get; set; }

    }
}
