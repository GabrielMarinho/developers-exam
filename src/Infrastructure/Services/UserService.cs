using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Responses;
using Domain.Services;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class UserService : Service<User>, IUserService
{
    private readonly IEmailService _emailService;
    
    private readonly IUserRepository _userRepository;
    
    public UserService(
        IUserRepository repository,
        IEmailService emailService) : 
        base(repository)
    {
        _userRepository = repository;
        _emailService = emailService;
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        return await GetByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await GetAllAsync();
    }

    public async Task<Response> AddUserAsync(User user)
    {
        var dbUser = await _userRepository
            .GetUserByValidationAsync(user);
        if (dbUser is not null)
            return Response.CreateWithError(ErrorCode.UserNotAvailable);

        var result = await InsertAsync(user);
        if (result is not null)
            return Response.CreateBadRequest(result);

        _emailService.SendEmail(user.Email, "Parabéns! Você foi aprovado! ;). Comece na próxima semana...");
        return Response.CreateSuccess(user.Id);
    }

    public async Task<Response> UpdateUserAsync(User user)
    {
        var dbUser = await GetByIdAsync(user.Id);
        if (dbUser is null)
            return Response.CreateWithError(ErrorCode.UserNotFound);

        var result = await UpdateAsync(user);
        return result is not null ?
            Response.CreateBadRequest(result) :
            Response.CreateSuccess(user.Id);
    }

    public async Task<Response> DeleteUserAsync(long id)
    {
        var dbUser = await GetByIdAsync(id);
        if (dbUser is null)
            return Response.CreateWithError(ErrorCode.UserNotFound);

        var result = await DeleteAsync(id);
        return result is not null ?
            Response.CreateBadRequest(result) :
            Response.CreateSuccess();
    }
}