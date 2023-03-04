using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(SqlDbContext context) : base(context)
    {
    }

    public async Task<User> GetUserByValidationAsync(User user)
    {
        return await DbSet.FirstOrDefaultAsync(f => f.FirstName.Equals(user.FirstName, StringComparison.OrdinalIgnoreCase) &&
                                                    f.LastName.Equals(user.LastName, StringComparison.OrdinalIgnoreCase) ||
                                                    f.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase) &&
                                                    f.Login.Equals(user.Login, StringComparison.OrdinalIgnoreCase));
    }
}