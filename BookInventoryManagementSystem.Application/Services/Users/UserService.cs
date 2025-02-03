using Microsoft.AspNetCore.Http;

namespace BookInventoryManagementSystem.Application.Services.Users;

public class UserService(UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserService
{
    public async Task<ApplicationUser> GetLoggedInUser()
    {
        return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
    }

    public async Task<ApplicationUser> GetUserById(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<List<ApplicationUser>> GetLibrarians()
    {
        var employees = await _userManager.GetUsersInRoleAsync(Roles.Librarian);
        return [.. employees];
    }
}
