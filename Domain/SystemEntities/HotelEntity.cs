using Domain.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Domain.SystemEntities;

public class HotelEntity : AuditableBaseEntity
{
    [Key]
    public int HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal RentParDay { get; set; }
    public int MaximumCapacity { get; set; }
}