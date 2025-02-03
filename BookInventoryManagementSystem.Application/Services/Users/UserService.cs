using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services.Users;

public class UserService(UserManager<ApplicationUser> _userManager,
    IHttpContextAccessor _httpContextAccessor,
    IMapper _mapper) : IUserService
{
    public async Task<ApplicationUser> GetLoggedInUserAsync()
    {
        return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<List<UserViewModel>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();

        var userVMs = new List<UserViewModel>();

        foreach (var user in users)
        {
            var userVM = new UserViewModel {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Roles.Administrator // TODO: look up actual role type
            };
            userVMs.Add(userVM);
        }

        return userVMs;
    }
}
