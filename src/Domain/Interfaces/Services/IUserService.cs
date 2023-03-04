using Domain.Entities;
using Domain.Responses;

namespace Domain.Interfaces.Services;

public interface IUserService : IService<User>
{
    Task<User> GetUserByIdAsync(long id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<Response> AddUserAsync(User user);
    Task<Response> UpdateUserAsync(User user);
    Task<Response> DeleteUserAsync(long id);
}