using Domain.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Domain.SystemEntities
{
    public class UserEntity : AuditableBaseEntity
    {
        [Key]
        //[System.ComponentModel.DataAnnotations.Schema.ForeignKey("HotelEntity")]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public HotelEntity HotelEntity { get; set; }

    }
}
