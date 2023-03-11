using Domain.BaseEntities;

namespace Domain.SystemEntities;

public class HotelEntity : AuditableBaseEntity
{
    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("UserEntity")]
    public int HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal RentParDay { get; set; }
    public int MaximumCapacity { get; set; }
    public virtual UserEntity UserEntity { get; set; }
}