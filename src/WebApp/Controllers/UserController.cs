using Domain.Enums;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mappers;
using WebApp.Models;
using DomainResponse = Domain.Responses;

namespace WebApp.Controllers;

public class UserController : BaseController
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    
    public UserController(
        ILogger<UserController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
            return CreateResponse(DomainResponse.Response.CreateWithError(ErrorCode.UserNotFound));

        return CreateResponse(DomainResponse
            .Response
            .CreateSuccess(
                UserMapper.ConvertToUserViewModel(user)));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = (await _userService
                .GetAllUsersAsync())?
            .Select(s => UserMapper.ConvertToUserViewModel(s));

        return CreateResponse(DomainResponse.Response.CreateSuccess(users));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel newUser)
    {
        var response = await _userService.AddUserAsync(
            UserViewModelMapper.CreateUserConvertToUser(newUser));

        return CreateResponse(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel user)
    {
        var response = await _userService.UpdateUserAsync(
            UserViewModelMapper.CreateUserConvertToUser(user));

        return CreateResponse(response);
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var response = await _userService.DeleteUserAsync(id);
        return CreateResponse(response);
    }
}