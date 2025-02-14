using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookInventoryManagementSystem.Application.Services.Users;

public class UserService(UserManager<ApplicationUser> _userManager,
    IHttpContextAccessor _httpContextAccessor) : IUserService
{
    public async Task<ApplicationUser> GetLoggedInApplicationUserAsync()
    {
        // Not currently used
        return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
    }

    public async Task<string> GetLoggedInApplicationUserFirstNameAsync()
    {
        // Not currently used
        ApplicationUser user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        if (user == null)
        {
            return "";
        }

        return user.FirstName;
    }

    public async Task<string?> GetIdOfLoggedInUserAsync()
    {
        var user = await GetLoggedInApplicationUserAsync();

        if (user == null)
        {
            return null;
        }

        return user.Id;
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        var applicationUser = await _userManager.FindByIdAsync(userId) ?? throw new Exception("User not found!");
        return applicationUser;
    }

    public async Task<UserViewModel> GetUserViewModelByIdAsync(string userId)
    {
        var applicationUser = await _userManager.FindByIdAsync(userId) ?? throw new Exception("User not found!");

        var role = await GetRoleForApplicationUserAsync(applicationUser);

        var userViewModel = new UserViewModel
        {
            Id = userId,
            FirstName = applicationUser.FirstName,
            LastName = applicationUser.LastName,
            Role = role
        };

        return userViewModel;
    }

    public async Task<List<UserViewModel>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var userRoles = new Dictionary<string, RolesEnum>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var firstAndOnlyRole = roles.FirstOrDefault();

            userRoles[user.Id] = firstAndOnlyRole == Roles.Administrator ? RolesEnum.Administrator
                : firstAndOnlyRole == Roles.Librarian ? RolesEnum.Librarian
                : RolesEnum.Reader;
        }

        var userVMs = users.Select(user => new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = userRoles[user.Id]
        }).ToList();

        return userVMs;
    }

    public async Task<IdentityResult> DeleteUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        return await _userManager.DeleteAsync(user);
    }

    public async Task<IdentityResult> UpdateUserAsync(UserViewModel userViewModel)
    {
        var user = await _userManager.FindByIdAsync(userViewModel.Id);
        if (user == null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        user.FirstName = userViewModel.FirstName;
        user.LastName = userViewModel.LastName;

        RolesEnum existingRole = GetRoleForApplicationUserAsync(user).Result;

        if (existingRole != userViewModel.Role)
        {
            await ChangeApplicationUserRole(user, userViewModel.Role);
        }

        return await _userManager.UpdateAsync(user);
    }

    public async Task<bool> IsLibrarianOrAdminAsync(string userId)
    {
        var applicationUser = await _userManager.FindByIdAsync(userId) ?? throw new Exception("User not found!");

        var role = await GetRoleForApplicationUserAsync(applicationUser);

        return role == RolesEnum.Librarian || role == RolesEnum.Administrator;
    }

    public async Task<string> GetFullNameAsync(string userId)
    {
        var applicationUser = await _userManager.FindByIdAsync(userId) ?? throw new Exception("User not found!");
        return $"{applicationUser.FirstName} {applicationUser.LastName}";
    }

    // Private methods

    private async Task<RolesEnum> GetRoleForApplicationUserAsync(ApplicationUser applicationUser)
    {
        var userRoles = await _userManager.GetRolesAsync(applicationUser);

        if (userRoles.Contains(Roles.Administrator))
        {
            return RolesEnum.Administrator;
        }
        else if (userRoles.Contains(Roles.Librarian))
        {
            return RolesEnum.Librarian;
        }
        else
        {
            return RolesEnum.Reader;
        }
    }

    private async Task ChangeApplicationUserRole(ApplicationUser user, RolesEnum newRole)
    {
        // Get the user's current roles
        var currentRoles = await _userManager.GetRolesAsync(user);

        // Remove the user from all current roles
        if (currentRoles.Any())
        {
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
        }

        // Add the user to the new role
        await _userManager.AddToRoleAsync(user, newRole.ToString());
    }
}
