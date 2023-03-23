using Application.Interfaces;
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
    }
}
