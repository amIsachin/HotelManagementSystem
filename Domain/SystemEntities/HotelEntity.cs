using Domain.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Domain.SystemEntities;

/// <summary>
/// Hotel entity class contains system information related to database. 
/// </summary>
public class HotelEntity : AuditableBaseEntity
{
    [Key]
    public int HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal RentParDay { get; set; }
    public int MaximumCapacity { get; set; }
}