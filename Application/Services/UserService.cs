using Application.Interfaces;
using Domain.SystemEntities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> NewUserAsync(UserEntity userEntity)
        {
            await _context.Users.AddAsync(userEntity);

            bool isInserted = await _context.SaveChangesAsync() > 0;

            if (isInserted is true)
            {
                return true;
            }

            return false;
        }
    }
}