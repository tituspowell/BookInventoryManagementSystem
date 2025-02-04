using System.ComponentModel;

namespace BookInventoryManagementSystem.Application.ViewModels.Users;

public class UserViewModel
{
    [Required]
    public required string Id { get; set; }

    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [Required]
    public RolesEnum Role { get; set; }
}
