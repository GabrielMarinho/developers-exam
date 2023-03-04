using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByValidationAsync(User user);
}