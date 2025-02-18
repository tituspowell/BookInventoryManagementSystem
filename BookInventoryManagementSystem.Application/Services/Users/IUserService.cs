﻿
namespace BookInventoryManagementSystem.Application.Services.Users
{
    public interface IUserService
    {
        Task<ApplicationUser> GetLoggedInApplicationUserAsync();
        Task<UserViewModel> GetUserViewModelByIdAsync(string userId);
        Task<List<UserViewModel>> GetUsersAsync();
        Task<IdentityResult> UpdateUserAsync(UserViewModel userViewModel);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<string?> GetIdOfLoggedInUserAsync();
        Task<bool> IsLibrarianOrAdminAsync(string userId);
        Task<string> GetLoggedInApplicationUserFirstNameAsync();
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<string> GetFullNameAsync(string userId);
    }
}