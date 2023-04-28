using Domain.Common.ViewModels;
using Domain.SystemEntities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<bool> NewUserAsync(UserEntity userEntity);
        Task<bool> IsExistUser(int userId);
        Task<bool> UpdateUserAsync(int userId, UserViewModel userViewModel, HotelEntity hotelRecord);
    }
}
