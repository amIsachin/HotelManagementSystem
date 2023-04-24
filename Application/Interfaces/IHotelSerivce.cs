using Domain.SystemEntities;

namespace Application.Interfaces;

public interface IHotelSerivce
{
    Task<List<HotelEntity>> GetHotelListAsync();
    Task<bool> AddNewHotelAsync(HotelEntity hotelEntity);
    Task<bool> DeleteHotelAsync(int hotelId);
    Task<bool> UpdateHotelAsync(int hotelId, HotelEntity hotelEntity);
    Task<HotelEntity?> GetHotelByHotelId(int hotelId);
}
