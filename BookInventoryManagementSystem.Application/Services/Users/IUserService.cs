namespace BookInventoryManagementSystem.Application.Services.Users
{
    public interface IUserService
    {
        Task<ApplicationUser> GetLoggedInUserAsync();
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<List<UserViewModel>> GetUsersAsync();
    }
}