using Application.Interfaces;
using Application.Methods;
using Domain.SystemEntities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public sealed class HotelService : IHotelSerivce
    {
        #region InitializeHotelConnection
        private readonly ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Get all hotel list functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<HotelEntity>> GetHotelListAsync()
        {
            return await this._context.Hotels.ToListAsync();
        }

        /// <summary>
        /// This method perfome add new hotel in database. if added successfully then return true otherwise false
        /// </summary>
        /// <param name="hotelEntity"></param>
        /// <returns></returns>
        public async Task<bool> AddNewHotelAsync(HotelEntity hotelEntity)
        {
            hotelEntity.Created = TimeManagement.Instance.DateTimeNow();

            await _context.AddAsync(hotelEntity);

            int isAdded = await _context.SaveChangesAsync();

            if (isAdded > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Delete hotel service.
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteHotelAsync(int hotelId)
        {
            var hotel = new HotelEntity() { HotelId = hotelId };

            _context.Hotels.Remove(hotel);

            int isDeleted = await _context.SaveChangesAsync();

            if (isDeleted > 0)
            {
                return true;
            }

            return false;
        }
    }
}
