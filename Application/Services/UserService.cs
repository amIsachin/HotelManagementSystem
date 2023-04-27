using Application.Interfaces;
using Domain.SystemEntities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// This class is sealed, in this we define all methods related to user like (CRUD) operation.
    /// This class deal directly with user database.
    /// </summary>
    public sealed class UserService : IUserService
    {
        #region InitializeUserConnection
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// this method return all user which is available in the database, 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.Include(nameof(HotelEntity)).ToListAsync();
        }

        /// <summary>
        /// This class add new user in database directly. 
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public async Task<bool> NewUserAsync(UserEntity userEntity)
        {
            try
            {
                await _context.Users.AddAsync(userEntity);

                bool isInserted = await _context.SaveChangesAsync() > 0;

                if (isInserted is true)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}