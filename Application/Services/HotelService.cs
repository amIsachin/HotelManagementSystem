﻿using Application.Interfaces;
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
            await _context.AddAsync(hotelEntity);

            int isAdded = await _context.SaveChangesAsync();

            if (isAdded > 0)
            {
                return true;
            }

            return false;
        }
    }
}
