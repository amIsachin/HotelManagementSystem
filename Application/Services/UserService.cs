using Application.Interfaces;
using Domain.Common.ViewModels;
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


        /// <summary>
        /// This method checks the base on user primary key field if user exist return true otherwise fase.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> IsExistUser(int userId)
        {
            if (await _context.Users.AnyAsync(x => x.UserId == userId))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// This method update existing user if user updated successfully then return true otherwise return false.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userViewModel"></param>
        /// <param name="hotelRecord"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserAsync(int userId, UserViewModel userViewModel, HotelEntity hotelRecord)
        {
            var userEntity = new UserEntity()
            {
                UserId = userId,
                Name = userViewModel.Name,
                Gender = userViewModel.Gender,
                Age = userViewModel.Age,
                PhoneNumber = userViewModel.PhoneNumber,
                City = userViewModel.City,
                FromDate = userViewModel.FromDate,
                HotelEntity = hotelRecord,
                Created = userViewModel.Created,
            };

            _context.Users.Update(userEntity);

            int isUpdated = await _context.SaveChangesAsync();

            if (isUpdated > 0)
            {
                return true;
            }

            return false;

        }
    }
}