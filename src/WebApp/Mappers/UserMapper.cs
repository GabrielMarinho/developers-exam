using Domain.Entities;
using WebApp.Models;

namespace WebApp.Mappers;

public class UserMapper
{
    public static UserViewModel ConvertToUserViewModel(User user)
    {
        if (user is null)
            return null;

        return new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Login = user.Login,
            Email = user.Email,
            Age = user.Age
        };
    }
}