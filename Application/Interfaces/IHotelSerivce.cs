using Domain.SystemEntities;

namespace Application.Interfaces;

public interface IHotelSerivce
{
    Task<List<HotelEntity>> GetHotelListAsync();
}
