namespace BookInventoryManagementSystem.Application.Services.Users
{
    public interface IUserService
    {
        Task<ApplicationUser> GetLoggedInUser();
        Task<ApplicationUser> GetUserById(string userId);
        Task<List<ApplicationUser>> GetLibrarians();
    }
}