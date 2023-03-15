using Domain.SystemEntities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserEntity>> GetAllUsersAsync();
    }
}
