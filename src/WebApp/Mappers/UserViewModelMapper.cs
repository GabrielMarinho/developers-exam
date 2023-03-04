using Domain.Entities;
using WebApp.Models;

namespace WebApp.Mappers;

public class UserViewModelMapper
{
    public static User CreateUserConvertToUser(CreateUserViewModel newUser)
    {
        return new User(
            newUser.FirstName,
            newUser.LastName,
            newUser.Login,
            newUser.Email,
            newUser.Age);
    }
    
    public static User CreateUserConvertToUser(UpdateUserViewModel user)
    {
        return new User(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Login,
            user.Email,
            user.Age);
    }
}